using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Naos.WinRM;

namespace WinRemote
{
    public static class MachineManagerExtensions
    {
        
    }

    public class Remote
    {


        public ICollection<dynamic> DoIt()
        {
            var manager = new Naos.WinRM.MachineManager("192.168.1.239", "Administrator", MachineManager.ConvertStringToSecureString("Spe11ilm12"), true);
            return manager.RunScript(@"{ dir c:\ }");
        }

        public ICollection<dynamic> InstallChoco()
        {
            var manager = new Naos.WinRM.MachineManager("192.168.1.239", "Administrator", MachineManager.ConvertStringToSecureString("Spe11ilm12"), true);
            return
                manager.RunScript(
                    "{ iex ((new-object net.webclient).DownloadString('https://chocolatey.org/install.ps1')) }");
        }

        public ICollection<dynamic> InstallIISManagementSnapin()
        {
            var script = @"
$iisVersion = Get-ItemProperty ""HKLM:\\software\\microsoft\\InetStp"";
if ($iisVersion.MajorVersion -eq 7)
{
    if ($iisVersion.MinorVersion -ge 5)
    {
        Import-Module WebAdministration;
    }           
    else
    {
        if (-not (Get-PSSnapIn | Where {$_.Name -eq ""WebAdministration"";})) {
            Add-PSSnapIn WebAdministration;
        }
    }
}
";
        }

        public ICollection<dynamic> ExecutionPolicy()
        {
            var manager = new Naos.WinRM.MachineManager("192.168.1.239", "Administrator", MachineManager.ConvertStringToSecureString("Spe11ilm12"), true);
            return
                manager.RunScript(
                    "{ Get-ExecutionPolicy }");
        }
        
    }
}
