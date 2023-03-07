namespace api_test;

public class User
{
    public static string userString = "[\n" +
                                      "  {\n" +
                                      "    \"id\": 0,\n" +
                                      "    \"username\": \"string\",\n" +
                                      "    \"firstName\": \"string\",\n" +
                                      "    \"lastName\": \"string\",\n" +
                                      "    \"email\": \"string\",\n" +
                                      "    \"password\": \"string\",\n" +
                                      "    \"phone\": \"string\",\n" +
                                      "    \"userStatus\": 0\n" +
                                      "  }\n" +
                                      "]";
    public static dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(userString);

    public dynamic getUser()
    {
        return jsonObj;
    }
    
    public void setId(int id)
    {
        jsonObj[0].id = id;
    }
    public void setUsername(string username)
    {
        jsonObj[0].username = username;
    }
    public void setFirstName(string firstName)
    {
        jsonObj[0].firstName = firstName;
    }
    public void setLastName(string lastName)
    {
        jsonObj[0].lastName = lastName;
    }
    public void setEmail(string email)
    {
        jsonObj[0].email = email;
    }
    public void setPassword(string password)
    {
        jsonObj[0].password = password;
    }
    public void setPhone(string phone)
    {
        jsonObj[0].phone = phone;
    }
    public void setUserStatus(int userStatus)
    {
        jsonObj[0].userStatus = userStatus;
    }
    
    
    public int getId()
    {
        return jsonObj[0].id;
    }
    public string getUsername()
    {
        return jsonObj[0].username;
    }
    public string getFirstName()
    {
        return jsonObj[0].firstName;
    }
    public string getLastName()
    {
        return jsonObj[0].lastName;
    }
    public string getEmail()
    {
        return jsonObj[0].email;
    }
    public string getPassword()
    {
        return jsonObj[0].password;
    }
    public string getPhone()
    {
        return jsonObj[0].phone;
    }
    public int getUserStatus()
    {
        return jsonObj[0].userStatus;
    }
    
}