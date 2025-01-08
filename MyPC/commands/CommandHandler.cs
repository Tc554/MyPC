using System.Reflection;
using MyPC.requests;
using WindowsInput;

namespace MyPC;

public class CommandHandler
{
    public static InputSimulator inputSimulator = new InputSimulator();
    public HashSet<Command> commands = new HashSet<Command>();

    public CommandHandler()
    {
        RegisterCommands();
    }

    private void RegisterCommands()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var types = assembly.GetTypes();

        foreach (var type in types)
        {
            CommandProvider? provider = type.GetCustomAttribute<CommandProvider>();
            if (provider != null)
            {
                if (provider.enabled)
                {
                    Command instance = (Command)Activator.CreateInstance(type);

                    commands.Add(instance);
                }
            }
        }
    }

    public void Handle(CommandResponse response)
    {
        foreach (var cmd in commands)
        {
            if (Utils.EqualsIgnoreCase(cmd.name, response.Command))
            {
                cmd.Handle(response.Parameters);
            }
        }
    }

    public List<Param> ArgsToParams(params string[] args)
    {
        List<Param> result = new List<Param>();
        
        foreach (var s in args)
        {
            result.Add(new Param { Value = s });
        }

        return result;
    }
}