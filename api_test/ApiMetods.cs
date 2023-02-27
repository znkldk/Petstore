global using NUnit.Framework;
using System.Net;
using Newtonsoft.Json;

public class ApiMetods
{
    public dynamic apiGet(string url)
    {
      
        dynamic data;

        HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
        httpWebRequest.Method = "GET";
        HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
        Stream stream = response.GetResponseStream();
        using (StreamReader reader = new StreamReader(stream))
        {
            data = JsonConvert.DeserializeObject(reader.ReadToEnd());
        }

        return data;
    }
    
    public dynamic apiDelete(string url)
    {
      
        dynamic data;

        HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
        httpWebRequest.Method = "DELETE";
        HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
        Stream stream = response.GetResponseStream();
        using (StreamReader reader = new StreamReader(stream))
        {
            data = JsonConvert.DeserializeObject(reader.ReadToEnd());
        }

        return data;
    }
    
    public dynamic apiPost(string url, string body)
    {
        var request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "POST";
        request.ContentType = "application/json";
        dynamic data;
        var bytes = System.Text.Encoding.UTF8.GetBytes(body);
        request.ContentLength = bytes.Length;
        using (var stream = request.GetRequestStream())
        {
            stream.Write(bytes, 0, bytes.Length);
        }

        using (var response = (HttpWebResponse)request.GetResponse())
        {
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                string result = reader.ReadToEnd();
                
                Assert.IsNotNull(result);
                data = JsonConvert.DeserializeObject(result);
                return data;
            }
        }

    }
    
    public dynamic urlEncodedApiPost(string url, string body)
    {
        var request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "POST";
        request.ContentType = "application/x-www-form-urlencoded";
        dynamic data;
        var bytes = System.Text.Encoding.UTF8.GetBytes(body);
        request.ContentLength = bytes.Length;
        using (var stream = request.GetRequestStream())
        {
            stream.Write(bytes, 0, bytes.Length);
        }

        using (var response = (HttpWebResponse)request.GetResponse())
        {
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                string result = reader.ReadToEnd();
                
                Assert.IsNotNull(result);
                data = JsonConvert.DeserializeObject(result);
                return data;
            }
        }

    }
    
    public dynamic apiPut(string url, string body)
    {
        var request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "PUT";
        request.ContentType = "application/json";

        var bytes = System.Text.Encoding.UTF8.GetBytes(body);
        request.ContentLength = bytes.Length;
        using (var stream = request.GetRequestStream())
        {
            stream.Write(bytes, 0, bytes.Length);
        }

        using (var response = (HttpWebResponse)request.GetResponse())
        {
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                Assert.IsNotNull(result);

                dynamic data = JsonConvert.DeserializeObject(result);
                return data;
            }
        }
    }
    
    
}

