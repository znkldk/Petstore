
namespace PetUnitTest;

using api_test;

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;

public class PetUnitTest
{
    private const string urlBase = "https://petstore.swagger.io/v2/pet";
    ApiMetods apiMetods = new ApiMetods();
    UsefullMethods usefullMethods = new UsefullMethods();

    private protected string findByStatusUrl = urlBase+"/findByStatus?status=";

    public pet createAPet(string status,int urlCount,int tagCount)
    {
        pet Pet = new pet();
        Pet.setId(usefullMethods.getRandomId());
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
    
    
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void addNewPet()
    {
        pet newPet = createAPet("available",1,1);
        
        dynamic r=apiMetods.apiPost(urlBase , newPet.getPet().ToString());
        Assert.AreEqual(newPet.getPet(), r, "Expected value and actual value do not match.");
    }
    
    [Test]
    public void updateAPet()
    {
        pet newPet = createAPet("available",1,1);
        
        dynamic r=apiMetods.apiPost(urlBase , newPet.getPet().ToString());
        Assert.AreEqual(newPet.getPet(), r, "Expected value and actual value do not match.");
        
        newPet.setName(usefullMethods.getRandomStrings());
        newPet.addTag(
            usefullMethods.getRandomId(),
            usefullMethods.getRandomStrings());
        newPet.addTag(
            usefullMethods.getRandomId(),
            usefullMethods.getRandomStrings());
        
        newPet.setCategory(
            usefullMethods.getRandomId(),
            usefullMethods.getRandomStrings());
        newPet.setUrl(usefullMethods.getRandomStrings());
        newPet.setUrl(usefullMethods.getRandomStrings());
        newPet.setUrl(usefullMethods.getRandomStrings());
        
        dynamic r2=apiMetods.apiPut(urlBase , newPet.getPet().ToString());
        
        Assert.AreEqual(newPet.getPet(), r2, "Expected value and actual value do not match.");
        
    }

    [Test]
    public void findByStatus()
    {
        pet newPet = createAPet("available",1,1);
        dynamic r=apiMetods.apiPost(urlBase , newPet.getPet().ToString());
        Assert.AreEqual(newPet.getPet(), r, "Expected value and actual value do not match.");
        string url = findByStatusUrl + "available";
        
        dynamic r2=apiMetods.apiGet(url);
        
        dynamic petObj = null;
        foreach (var obje in r2)
        {
            if (obje["id"] == newPet.getId())
            {
                petObj = obje;
                break;
            }
        }
        Assert.AreEqual(newPet.getPet(), petObj, "Expected value and actual value do not match.");
        Console.WriteLine(petObj);
    }

    [Test]
    public void findPetById()
    {
        pet newPet = createAPet("available",1,1);
        dynamic r=apiMetods.apiPost(urlBase , newPet.getPet().ToString());
        Assert.AreEqual(newPet.getPet(), r, "Expected value and actual value do not match.");
        string url = urlBase +"/"+ newPet.getId();
        dynamic r2=apiMetods.apiGet(url);
        Assert.AreEqual(newPet.getPet(), r2, "Expected value and actual value do not match.");

    }

    [Test]
    public void updatePetWithFormDataUpdataName()
    {
        pet newPet = createAPet("available",1,1);
        dynamic r=apiMetods.apiPost(urlBase , newPet.getPet().ToString());
        Assert.AreEqual(newPet.getPet(), r, "Expected value and actual value do not match.");
        
        Console.WriteLine(r.ToString());

        newPet.setName(usefullMethods.getRandomStrings());
        string body = "name=" + newPet.getName();
        apiMetods.urlEncodedApiPost(urlBase  + "/" + newPet.getId(), body);
        
        string url = urlBase +"/"+ newPet.getId();
        dynamic r2=apiMetods.apiGet(url);
        Assert.AreEqual(newPet.getPet(), r2, "Expected value and actual value do not match.");
        
    }

    [Test]
    public void deletePet()
    {        
        pet newPet = createAPet("available",1,1);
        dynamic r=apiMetods.apiPost(urlBase , newPet.getPet().ToString());
        Assert.AreEqual(newPet.getPet(), r, "Expected value and actual value do not match.");
        apiMetods.apiDelete(urlBase  + "/" + newPet.getId());
        string url = urlBase +"/"+ newPet.getId();
        try 
        {
        apiMetods.apiGet(url);
        Assert.Fail("Deleted Pet Is Still Exists");
        }
        catch (Exception e)
        {
            //Success
        }
    }
    
        
    [Test]
    public void updateAPetWhichIsNotExist()
    {
        pet newPet = createAPet("available",1,1);
        
        dynamic r2=apiMetods.apiPut(urlBase , newPet.getPet().ToString());
        
        Assert.AreNotEqual(newPet.getPet(), r2, "User Able To Update The Pet Doesnt Exist");
        
    }

    [Test]
    public void deletePetWhichIsNotExist()
    {        
        pet newPet = createAPet("available",1,1);
        dynamic r=apiMetods.apiPost(urlBase , newPet.getPet().ToString());
        Assert.AreEqual(newPet.getPet(), r, "Expected value and actual value do not match.");
        apiMetods.apiDelete(urlBase  + "/" + newPet.getId());
        string url = urlBase +"/"+ newPet.getId();
        try 
        {
        apiMetods.apiGet(url);
        Assert.Fail("Deleted Pet Is Still Exists");
        }
        catch (Exception e)
        {
            //Success
        }
    }
     
} 