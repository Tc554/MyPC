namespace MyPC;

[System.AttributeUsage(System.AttributeTargets.Class |
                       System.AttributeTargets.Struct)
]
public class CommandProvider : System.Attribute
{
    public bool enabled;

    public CommandProvider(bool enabled)
    {
        enabled = true;
    }
}