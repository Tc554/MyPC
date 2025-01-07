using System.Text.Json.Nodes;

namespace MyPC.requests;

public class Requests
{
    private HttpClient client;
    
    public Requests()
    {
        client = new HttpClient();
    }

    public async void SendRequest()
    {
        string url = "get url here!";
        try
        {
            HttpResponseMessage response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();
        }
        catch (Exception ignore)
        {
            
        }
    }
}