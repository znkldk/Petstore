namespace api_test;
using System;

public class UserUnitTest
{
    
    protected string createWithArrayUrl = "https://petstore.swagger.io/v2/user/createWithArray";
    protected string createWithListUrl =  "https://petstore.swagger.io/v2/user/createWithList";
    protected string userUrl =  "https://petstore.swagger.io/v2/user";
    protected string userLogin = "https://petstore.swagger.io/v2/user/login?username=USERNAMEHERE&password=PASSWORDHERE";

    ApiMetods apiMetods = new ApiMetods();
    UsefullMethods usefullMethods = new UsefullMethods();
    public User createAnUser()
    {
        User user = new User();
        user.setId(usefullMethods.getRandomId());
        user.setFirstName(usefullMethods.getRandomStrings());
        user.setUsername(usefullMethods.getRandomStrings());
        user.setLastName(usefullMethods.getRandomStrings());
        user.setEmail(usefullMethods.getEmail());
        user.setPassword(usefullMethods.getRandomStrings());
        user.setPhone(usefullMethods.getPhoneNumber());
        user.setUserStatus(0);

        return user;
    }
    [Test]
    public void createWithArray()
    {
        User user = createAnUser();
        dynamic r=apiMetods.apiPost(createWithArrayUrl , user.getUser().ToString());
        Assert.AreEqual("ok",r.message.ToString());
        Console.WriteLine(user.getUsername().ToString());
        Console.WriteLine(user.getPassword().ToString());

    }
    
    [Test]
    public void createWithList()
    {
        User user = createAnUser();
        dynamic r=apiMetods.apiPost(createWithListUrl , user.getUser().ToString());
        Assert.AreEqual("ok",r.message.ToString());
    }
    
    [Test]
    public void getByUserName()
    {
        User user = createAnUser();
        dynamic r=apiMetods.apiPost(createWithListUrl , user.getUser().ToString());
        Assert.AreEqual("ok",r.message.ToString());
        
        dynamic r2=apiMetods.apiGet(userUrl+"/"+user.getUsername());
        Assert.AreEqual(user.getUser()[0], r2, "Expected value and actual value do not match.");
        
    }

    [Test]
    public void updateUser()
    {
        User user = createAnUser();
        dynamic r=apiMetods.apiPost(createWithListUrl , user.getUser().ToString());
        Assert.AreEqual("ok",r.message.ToString());
        
        apiMetods.apiGet(userUrl+"/"+user.getUsername());
        user.setEmail(usefullMethods.getEmail());
        dynamic r2 = apiMetods.apiPut(userUrl + "/" + user.getUsername(), user.getUser()[0].ToString());
        Assert.AreEqual(user.getId().ToString(), r2.message.ToString(), "Expected value and actual value do not match.");

        dynamic r3=apiMetods.apiGet(userUrl+"/"+user.getUsername());
        Assert.AreEqual(user.getUser()[0], r3, "Expected value and actual value do not match.");
        
    }

    [Test]
    public void deleteUser()
    {
        User user = createAnUser();
        dynamic r=apiMetods.apiPost(createWithArrayUrl , user.getUser().ToString());
        Assert.AreEqual("ok",r.message.ToString());

        dynamic r2 = apiMetods.apiDelete(userUrl + "/" + user.getUsername());
        Assert.AreEqual(
            r2.message.ToString(),
            user.getUsername().ToString());

    }

    [Test]
    public void login()
    {
        User user = createAnUser();
        dynamic r=apiMetods.apiPost(createWithArrayUrl , user.getUser().ToString());
        Assert.AreEqual("ok",r.message.ToString());
        dynamic r2 = apiMetods.apiGet(
            userLogin.Replace("USERNAMEHERE", user.getUsername())
                .Replace("PASSWORDHERE", user.getPassword()));
        Assert.True(r2.message.ToString().Contains("logged in user session"));

    }
}