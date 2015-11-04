using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Hosting;

namespace WindowsService1
{
  public partial class RemoteFileBrowser: ServiceBase
  {
    private IDisposable webApp;

    public RemoteFileBrowser()
    {
      InitializeComponent();
    }

    protected override void OnStart(string[] args)
    {
    }

    internal void InternalStart(string url = "http://localhost:12345")
    {
      webApp = WebApp.Start<WebStartup>(url);
    }

    protected override void OnStop()
    {

    }

    internal void InternalStop()
    {
      
    }
  }
}
