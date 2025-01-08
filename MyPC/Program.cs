using MyPC;
using MyPC.requests;

class Program
{
    public static CommandHandler commandHandler = new CommandHandler();

    static void Main(string[] args)
    {
        var cancellationTokenSource = new CancellationTokenSource();
        Requests requests = new Requests();
        
        Task.Delay(-1).Wait();
    }
}