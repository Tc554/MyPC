using WindowsInput;

namespace MyPC.commands.imple;

[CommandProvider(true)]
public class MouseClickCommand : Command
{
    public MouseClickCommand() : base("MouseClick", new List<Param> {
        new Param{ Name = "ClickType" }
    })
    {
        
    }

    public override void Handle(List<Param> _params)
    {
        InputSimulator robot = CommandHandler.inputSimulator;

        if (Utils.EqualsIgnoreCase(GetParamValue(_params, "ClickType"), "true"))
        {
            robot.Mouse.LeftButtonClick();
        }
        else
        {
            robot.Mouse.RightButtonClick();
        }
    }
}