namespace api_test;

public class UsefullMethods
{
    Random random = new Random();

    public int getRandomId()
    {
        int randomNumber = random.Next(10000, 100000);
        return randomNumber;
    }

    public string getRandomStrings()
    {
        const string chars = "abcdefghijklmnopqrstuvwxyz";

        string randomString = new string(Enumerable.Repeat(chars, 5)
            .Select(s => s[random.Next(s.Length)]).ToArray());

        return randomString;
    }

    public string getEmail()
    {
        return getRandomStrings() + "@" + getRandomStrings() + ".com";
    }
    
    public string getPhoneNumber()
    {
        return getRandomId().ToString() + getRandomId().ToString();
    }
}