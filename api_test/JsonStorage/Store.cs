namespace api_test.Resources;

public class Store
{
    public static string store = "{\n" +
                                 "  \"id\": 0,\n" +
                                 "  \"petId\": 0,\n" +
                                 "  \"quantity\": 0,\n" +
                                 "  \"shipDate\": \"2023-02-25T16:40:04.104Z\",\n" +
                                 "  \"status\": \"available\",\n" +
                                 "  \"complete\": true\n" +
                                 "}";

    public static dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(store);

    public dynamic getStore()
    {
        return jsonObj;
    }
    
    public void setId(long id)
    { 
        jsonObj["id"] = id;
    }
    public void setPetId(int petId)
    { 
        jsonObj["petId"] = petId;
    }    
    
    public void setQuantity(int quantity)
    { 
        jsonObj["quantity"] = quantity;
    }    
    
    public void setShipDate(string shipDate)
    { 
        jsonObj["shipDate"] = shipDate;
    }    
    
    public void setStatus(string status)
    { 
        jsonObj["status"] = status;
    }    
    
    public void setComplete(bool complete)
    { 
        jsonObj["complete"] = complete;
    }    
    
    
    public long getId()
    { 
        return jsonObj["id"];
    }
    public int getPetId()
    { 
        return jsonObj["petId"];
    }    
    
    public int getQuantity()
    { 
        return jsonObj["quantity"];
    }    
    
    public string getShipDate()
    { 
        return jsonObj["shipDate"];
    }    
    
    public string getStatus()
    { 
        return jsonObj["status"];
    }    
    
    public bool getComplete()
    { 
        return jsonObj["complete"];
    }    
}