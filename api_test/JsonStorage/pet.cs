using Newtonsoft.Json.Linq;

namespace api_test;
using System.Text.Json;

public class pet
{
    public static string petString = "{\n" +
                         "  \"id\": 0,\n" +
                         "  \"category\": {\n" +
                         "    \"id\": 0,\n" +
                         "    \"name\": \"string\"\n" +
                         "  },\n" +
                         "  \"name\": \"doggie\",\n" +
                         "  \"photoUrls\": [\n" +
                       
                         "  ],\n" +
                         "  \"tags\": [\n" +
              
                         "  ],\n" +
                         "  \"status\": \"available\"\n" +
                         "}";  
    public static dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(petString);
    public static JArray urlArr = new JArray();
    public static JArray tagJsonArray = new JArray();

    public dynamic getPet()
    {
        return jsonObj;
    }

    public void setId(int id)
    { 
        jsonObj["id"] = id;
    }
    
    public void setCategory(int id,string name)
    { 
        jsonObj["category"]["id"] = id;
        jsonObj["category"]["name"] = name;

    }
    public void setName(string name)
    { 
        jsonObj["name"] = name;

    }
    
    public void setUrl(string url)
    {
        urlArr.Add(url);
        jsonObj.photoUrls = urlArr;

    }

    public void addTag(int id, string name)
    {
        JObject tagObj = new JObject();
        tagObj.Add("id", id);
        tagObj.Add("name", name);
        tagJsonArray.Add(tagObj);
        jsonObj.tags = tagJsonArray;
    }
    
    public void setStatus(string status)
    { 
        jsonObj["status"] = status;

    }
    
    public string getStatus()
    { 
        return  jsonObj["status"];

    }
    
    public int getId()
    { 
        return jsonObj["id"];
    }
    
    public int getCategoryId()
    { 
        return  jsonObj["category"]["id"];
    }
    
    public string getName()
    {
        return jsonObj["name"];
    }
    
    public string getCategoryName()
    { 
        return  jsonObj["category"]["name"];
    }
    
    public JArray getTag()
    {
        return jsonObj.tags;
    }
    
    public JArray getUrl()
    {
        return jsonObj.photoUrls;

    }
    
    
    
}