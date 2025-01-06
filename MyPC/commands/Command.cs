using System.Reflection.Metadata;

namespace MyPC;

public class Command
{
    private string name;
    private List<IParam> _params;

    public Command(string name, List<IParam> _params)
    {
        this.name = name;
        this._params = _params;
    }

    public void Handle(List<IParam> _params)
    {
        
    }
}