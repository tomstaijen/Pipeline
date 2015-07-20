using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WinRemote.Test
{
    [TestFixture]
    public class RemoteTests
    {
        [Test]
        public void DoIt()
        {
            var remote = new Remote();

//            Print(remote.ExecutionPolicy());
//            Print(remote.InstallChoco());
            Print(remote.InstallIISManagementSnapin());
//            foreach (var x in remote.InstallChoco())
//            {
//                Console.WriteLine(x);
//            }
        }

        public void Print(ICollection<dynamic> result)
        {
            foreach (var x in result)
            {
                Console.WriteLine(x);
            }
        }
    }
}
