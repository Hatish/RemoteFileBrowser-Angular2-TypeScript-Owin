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
      app.UseStaticFiles();

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
