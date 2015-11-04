using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Formatting;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Routing;
using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using Newtonsoft.Json.Converters;

namespace WindowsService1
{
  class WebStartup
  {
    public void Configuration(IAppBuilder app)
    {
      var dir = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "webdir");

      var staticFilesOptions = new StaticFileOptions
      {
        RequestPath = new PathString(""),
        FileSystem = new PhysicalFileSystem(dir)
      };
      app.UseStaticFiles(staticFilesOptions);

      var config = new HttpConfiguration();
      config.Formatters.Clear();
      config.Formatters.Add(new JsonMediaTypeFormatter());
      config.Formatters.JsonFormatter.SerializerSettings = new JsonSerializerSettings
      {
        ContractResolver = new CamelCasePropertyNamesContractResolver()
      };
      config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new StringEnumConverter());
      config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new {id = RouteParameter.Optional});
      app.UseWebApi(config);
    }
  }
}
