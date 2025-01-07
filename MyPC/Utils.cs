using System.Net.NetworkInformation;

namespace MyPC;

public class Utils
{
    public static bool EqualsIgnoreCase(string a, string b)
    {
        return a.ToLower().Equals(b.ToLower());
    }

    public static string GetIP()
    {
        foreach (NetworkInterface netInterface in NetworkInterface.GetAllNetworkInterfaces())
        {
            if (netInterface.OperationalStatus != OperationalStatus.Up) continue;

            foreach (UnicastIPAddressInformation ipAddress in netInterface.GetIPProperties().UnicastAddresses)
            {
                if (ipAddress.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    return ipAddress.Address.ToString();
                }
            }
        }

        return "";
    }
}