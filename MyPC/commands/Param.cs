namespace MyPC;

public interface IParam
{
    string Value { get; }
    bool Required { get; }
}

public class Param : IParam
{
    public string Value { get; set; }
    string IParam.Value => Value;
    public bool Required { get; set; }
    bool IParam.Required => Required;
}