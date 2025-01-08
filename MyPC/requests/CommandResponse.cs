namespace MyPC.requests;

public class CommandResponse
{
    public string Command { get; set; }
    public List<Param> Parameters { get; set; }
}