using System.Reflection.Metadata;

namespace MyPC;

public class Command
{
    public string name;
    public List<IParam> _params;

    public Command(string name, List<IParam> _params)
    {
        this.name = name;
        this._params = _params;
    }

    public virtual void Handle(List<IParam> _params)
    {
        
    }
}