namespace MyPC.commands.imple;

[CommandProvider(true)]
public class ForceCloseCommand : Command
{
    public ForceCloseCommand() : base("ForceClose", new List<Param>())
    {
        
    }

    public override void Handle(List<Param> _params)
    {
        Environment.Exit(0);
    }
}