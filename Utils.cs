using Microsoft.Win32;
using NATUPNPLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GTAV_Firewall
{
    public class Utils
    {
        public static readonly UInt32[] fixedIPv4 = { 1, 167772158, 184549377, 2886729726, 2887778305, 3232235518, 3232301057, 4294967294 };

        public static string GetGlobalIPv4()
        {
            var ipv4 = string.Empty;
            using (var wc = new WebClient())
            {
                ipv4 = wc.DownloadString("https://ip4.seeip.org/");
            }
            return ipv4;
        }

        public static string[] GetLocalIPv4()
        {
            var list_ipv4 = new List<string>();
            foreach (var ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.OperationalStatus == OperationalStatus.Up && ni.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                {
                    Console.WriteLine(ni.Name);
                    Console.WriteLine(ni.NetworkInterfaceType.ToString());

                    foreach (var ip in ni.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            list_ipv4.Add(ip.Address.ToString());
                        }
                    }
                }
            }
            return list_ipv4.ToArray();
        }

        public static void CreateUPnP(string[] IP_List)
        {
            var port = 54088;
            var upnpnat = new UPnPNAT();
            var mappings = upnpnat.StaticPortMappingCollection;

            if (mappings != null)
            {
                foreach (var ip in IP_List)
                {
                    try
                    {
                        mappings.Remove(port, "TCP");
                        mappings.Add(port, "TCP", port, ip, true, $"GTAV Firewall");
                    }
                    catch { }
                }
            }
        }

        public static void DeleteUPnP()
        {
            var port = 54088;
            var upnpnat = new UPnPNAT();
            var mappings = upnpnat.StaticPortMappingCollection;
            if (mappings != null)
            {
                mappings.Remove(port, "TCP");
            }
        }

        public static UInt32 IPv4toUInt32(string IPv4)
        {
            try
            {
                var i = IPv4.Split('.');
                var a = uint.Parse(i[0]);
                var b = uint.Parse(i[1]);
                var c = uint.Parse(i[2]);
                var d = uint.Parse(i[3]);
                if (a > 255 || b > 255 || c > 255 || d > 255)
                {
                    return 0;
                }
                var value = (a << 24) + (b << 16) + (c << 8) + d;
                return value;
            }
            catch
            {
                return 0;
            }
        }

        public static string Uint32toIPv4(UInt32 value)
        {
            var a = (value & 0xFF000000) >> 24;
            var b = (value & 0xFF0000) >> 16;
            var c = (value & 0xFF00) >> 8;
            var d = (value & 0xFF);
            return string.Format("{0}.{1}.{2}.{3}", a, b, c, d);
        }

        public static (string desc, string block) GetBlockRange(string[] IP)
        {
            var desc = string.Empty;
            var block = string.Empty;
            var arr = fixedIPv4.ToList();
            foreach (string ip in IP)
            {
                desc += ip + ",";
                var value = IPv4toUInt32(ip);

                var i = ((value + 1) % 256) == 0 ? value + 2 : value + 1;
                var j = ((value - 1) % 256) == 0 ? value - 2 : value - 1;

                if (!IP.Contains(Uint32toIPv4(i)))
                    arr.Add(i);

                if (!IP.Contains(Uint32toIPv4(j)))
                    arr.Add(j);
            }
            arr.Sort();
            var arr2 = new List<string>();
            foreach (var value in arr)
            {
                var ip = Uint32toIPv4(value);
                arr2.Add(ip);
            }
            for (int i = 0; i < arr2.Count; i += 2)
            {
                if (arr2[i].Contains(arr2[i + 1]))
                    block += arr2[i] + ",";
                else
                    block += arr2[i] + "-" + arr2[i + 1] + ",";
            }
            desc = desc.Substring(0, desc.Length - 1);
            block = block.Substring(0, block.Length - 1);
            return (desc, block);
        }

        public static string[] GetFirewallIP()
        {
            var p = Process.Start(new ProcessStartInfo
            {
                FileName = "netsh",
                Arguments = "advfirewall firewall show rule name=GTAV_Firewall verbose",
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true
            });
            var text = p.StandardOutput.ReadToEnd();
            text = Regex.Match(text, "CFW=([0-9.,]+)").Groups[1].Value;
            return string.IsNullOrEmpty(text) ? null : text.Split(',');
        }

        public static void SetFirewall(string block, string description)
        {
            ClearFirewall();
            Process.Start(new ProcessStartInfo
            {
                FileName = "netsh",
                Arguments = $"advfirewall firewall add rule name=GTAV_Firewall description=\"CFW={description}\" dir=in action=block remoteip=\"{block}\" localport=6672 protocol=udp",
                UseShellExecute = false,
                CreateNoWindow = true
            }).WaitForExit();
            
            Process.Start(new ProcessStartInfo
            {
                FileName = "netsh",
                Arguments = $"advfirewall firewall add rule name=GTAV_Firewall description=\"CFW={description}\" dir=out action=block remoteip=\"{block}\" localport=6672 protocol=udp",
                UseShellExecute = false,
                CreateNoWindow = true
            }).WaitForExit();
            
        }

        public static void ClearFirewall()
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "netsh",
                Arguments = "advfirewall firewall del rule name=GTAV_Firewall",
                UseShellExecute = false,
                CreateNoWindow = true
            }).WaitForExit();
        }
    }
}
