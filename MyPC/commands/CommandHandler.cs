using System.Reflection;
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
            if (type.GetCustomAttribute<CommandProvider>() != null)
            {
                Command instance = (Command) Activator.CreateInstance(type);
                
                commands.Add(instance);
            }
        }
    }

    public void Handle(string command, params string[] args)
    {
        foreach (var cmd in commands)
        {
            if (Utils.EqualsIgnoreCase(cmd.name, command))
            {
                cmd.Handle(ArgsToParams(args));
            }
        }
    }

    public List<IParam> ArgsToParams(params string[] args)
    {
        List<IParam> result = new List<IParam>();
        
        foreach (var s in args)
        {
            result.Add(new Param { Value = s });
        }

        return result;
    }
}