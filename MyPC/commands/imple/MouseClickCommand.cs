namespace MyPC.imple;

public class MouseClickCommand : Command
{
    public MouseClickCommand() : base("MouseClick", new List<Param<>> {
        new Param<string>()
    })
    {
        
    }
}