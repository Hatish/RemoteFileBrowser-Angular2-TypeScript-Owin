using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    static void Main()
    {
#if DEBUG

      var svc = new RemoteFileBrowser();
      svc.InternalStart();
      Console.WriteLine("Press any key to stop service...");
      Console.ReadKey();
      Console.WriteLine("Stopping Service...");

#else

      ServiceBase[] ServicesToRun;
      ServicesToRun = new ServiceBase[] 
            { 
                new RemoteFileBrowser() 
            };
      ServiceBase.Run(ServicesToRun);

#endif


    }
  }
}
