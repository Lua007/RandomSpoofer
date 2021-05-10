using System;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Threading;
using Microsoft.Win32;

namespace hwid_spoof_test
{
	// Token: 0x02000002 RID: 2
	internal class Program
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002058 File Offset: 0x00000258
		public static void SpoofGUID()
		{
			string value = Guid.NewGuid().ToString();
			RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
			registryKey = registryKey.OpenSubKey("SOFTWARE\\Microsoft\\Cryptography", true);
			registryKey.SetValue("MachineGuid", value);
		}

		// Token: 0x06000002 RID: 2 RVA: 0x000020A4 File Offset: 0x000002A4
		public static void SpoofHwProfileGUID()
		{
			string value = "{" + Guid.NewGuid().ToString() + "}";
			RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
			registryKey = registryKey.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\IDConfigDB\\Hardware Profiles\\0001", true);
			registryKey.SetValue("HwProfileGUID", value);
			registryKey.Close();
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002104 File Offset: 0x00000304
		private static void Main(string[] args)
		{
			if (Program.smethod_0())
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Do you want to spoof your HWID? - Type 'YES' if you want to spoof your GUID");
				string a = Console.ReadLine();
				if (a == "YES")
				{
					Console.WriteLine("Spoof starts.");
					Thread.Sleep(500);
					Program.SpoofHwProfileGUID();
					Program.SpoofGUID();
					Console.WriteLine("Done, cya <3");
					Console.ReadLine();
				}
				else if (a == "yes")
				{
					Console.WriteLine("Spoof starts.");
					Thread.Sleep(500);
					Program.SpoofHwProfileGUID();
					Program.SpoofGUID();
					Console.WriteLine("Done, cya <3");
					Console.ReadLine();
				}
				else
				{
					Console.WriteLine("Thats a no?");
					Console.ReadLine();
					Thread.Sleep(1250);
					Environment.Exit(0);
				}
			}
			else
			{
				Console.Write("Please run the program as administrator.");
				Thread.Sleep(1500);
				Environment.Exit(0);
			}
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000021E8 File Offset: 0x000003E8
		[CompilerGenerated]
		internal static bool smethod_0()
		{
			return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
		}
	}
}
