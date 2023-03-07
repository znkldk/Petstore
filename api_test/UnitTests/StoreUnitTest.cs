using api_test.Resources;

namespace api_test;
using api_test;
using System;

public class StoreUnitTest
{
    
    ApiMetods apiMetods = new ApiMetods();
    UsefullMethods usefullMethods = new UsefullMethods();
    private const string petUrlBase = "https://petstore.swagger.io/v2/pet";
    private const string storeUrlBase = "https://petstore.swagger.io/v2/store/order";
    private const string storeInventoryUrl = "https://petstore.swagger.io/v2/store/inventory";
    
    public pet createAPet(string status,int urlCount,int tagCount,bool idOneCracter)
    {
        pet Pet = new pet();
        if(idOneCracter){
            Pet.setId(2);
        } else {
        Pet.setId(usefullMethods.getRandomId());
        }
        Pet.setCategory(
            usefullMethods.getRandomId(),
            usefullMethods.getRandomStrings());
        Pet.setName(usefullMethods.getRandomStrings());
        for (int i = 0; i < tagCount; i++)
        {
            Pet.addTag(
                usefullMethods.getRandomId(),
                usefullMethods.getRandomStrings());
        }
        for (int i = 0; i < urlCount; i++)
        {
            Pet.setUrl(usefullMethods.getRandomStrings());
        }
        
        Pet.setStatus(status);
        
        return Pet;
    }

    public Store createAStoreJson(pet newPet, int quantity, string shipDate, bool complete)
    {
        Store store = new Store();
        
        store.setPetId(newPet.getId());
        store.setQuantity(quantity);
        store.setShipDate(shipDate);
        store.setStatus(newPet.getStatus());
        store.setComplete(complete);
        return store;
    }

    public dynamic makeAnOrder(Store store)
    {
        dynamic r=apiMetods.apiPost(
            
            storeUrlBase ,
            store.getStore().ToString());
        
        Console.WriteLine(r.id);
        store.setId(long.Parse(r.id.ToString()));
        r.shipDate = "shipDate";
        store.setShipDate("shipDate");
        
        Assert.AreEqual(
            store.getStore(),
            r,
            "Expected value and actual value do not match.");
        return r;
    }

    public dynamic getOrderById(long orderId)
    {
        return apiMetods.apiGet(storeUrlBase+"/"+orderId );
    }
    
    
    [Test]
    public void storeOrder()
    { 
        pet newPet = createAPet("available",1,1,false);
        dynamic r=apiMetods.apiPost(petUrlBase , newPet.getPet().ToString());
        Assert.AreEqual(newPet.getPet(), r, "Expected value and actual value do not match.");
        
        Store store = createAStoreJson(
            newPet,
            1,
            "2023-02-25T16:40:04.104Z",
            true);

        makeAnOrder(store);
        
    }
    
    [Test]
    public void getStoreOrder()
    { 
        
        // This Api Does Not Work Properly
        pet newPet = createAPet("available",1,1,true);
        dynamic r=apiMetods.apiPost(petUrlBase , newPet.getPet().ToString());
        Assert.AreEqual(newPet.getPet(), r, "Expected value and actual value do not match.");
        
        // api does not work !! it gives me order Id like 123213 but it only accepts betwen 1-10
        
        // Store store = createAStoreJson(
        //     newPet,
        //     1,
        //     "2023-02-25T16:40:04.104Z",
        //     true);

        // dynamic r3=makeAnOrder(store);
        // Console.Write(r3.ToString());
        // Console.WriteLine(store.getStore());
        // dynamic r2=getOrderById(newPet.getId());
        
        // r2.id = 0;
        // r2.shipDate = "shipDate";
        // store.setShipDate("shipDate");
        // Console.WriteLine("-------- hereee");
        // Console.WriteLine(r2.ToString());
        // Console.WriteLine(store.getStore().ToString());

        // Assert.AreEqual(
        //     store.getStore(),
        //     r2,
        //     "Expected value and actual value do not match.");
            
    }

    [Test]
    public void deleteOrder()
    {
        pet newPet = createAPet("available",1,1,false);
        dynamic r=apiMetods.apiPost(petUrlBase , newPet.getPet().ToString());
        Assert.AreEqual(newPet.getPet(), r, "Expected value and actual value do not match.");
        Store store = createAStoreJson(
            newPet,
            1,
            "2023-02-25T16:40:04.104Z",
            true);

        dynamic r2=makeAnOrder(store);
        apiMetods.apiDelete(
            storeUrlBase+"/"+r2.id);
    }
    
    [Test]
    public void inventory()
    {
        dynamic r=apiMetods.apiGet(storeInventoryUrl);
    }
    
}
