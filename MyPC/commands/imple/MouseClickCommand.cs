namespace MyPC.commands.imple;

public class MouseClickCommand : Command
{
    public MouseClickCommand() : base("MouseClick", new List<IParam> {
        new Param<string> { Required = true }
    })
    {
        
    }
}