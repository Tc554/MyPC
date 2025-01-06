using WindowsInput;

namespace MyPC;

public class CommandHandler
{
    public static InputSimulator inputSimulator = new InputSimulator();

    public void Handle(string command, params string[] args)
    {
        if (Utils.EqualsIgnoreCase(command, "MouseClick"))
        {
            
        }
    }
}