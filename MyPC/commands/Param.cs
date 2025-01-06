namespace MyPC;

public interface IParam
{
    object Value { get; }
    bool Required { get; }
}

public class Param<T> : IParam
{
    public T Value { get; set; }
    object IParam.Value => Value;
    public bool Required { get; set; }
    bool IParam.Required => Required;
}