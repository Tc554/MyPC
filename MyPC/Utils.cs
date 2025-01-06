namespace MyPC;

public class Utils
{
    public static bool EqualsIgnoreCase(string a, string b)
    {
        return a.ToLower().Equals(b.ToLower());
    }
}