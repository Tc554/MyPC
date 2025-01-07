using WindowsInput;

namespace MyPC.commands.imple;

[CommandProvider(true)]
public class MouseClickCommand : Command
{
    public MouseClickCommand() : base("MouseClick", new List<IParam> {
        new Param{ Required = true }
    })
    {
        
    }

    public override void Handle(List<IParam> _params)
    {
        InputSimulator robot = CommandHandler.inputSimulator;

        if (Utils.EqualsIgnoreCase((string) _params[0].Value, "left"))
        {
            robot.Mouse.LeftButtonClick();
        }
        else
        {
            robot.Mouse.RightButtonClick();
        }
    }
}