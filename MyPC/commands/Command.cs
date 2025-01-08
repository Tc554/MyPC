using System.Reflection.Metadata;

namespace MyPC;

public class Command
{
    public string name;
    public List<Param> _params;

    public Command(string name, List<Param> _params)
    {
        this.name = name;
        this._params = _params;
    }

    public virtual void Handle(List<Param> _params)
    {
        
    }
    
    public string GetParamValue(List<Param> _params, string param)
    {
        return _params.Find(p => Utils.EqualsIgnoreCase(p.Name, param))?.Value ?? "";
    }
}