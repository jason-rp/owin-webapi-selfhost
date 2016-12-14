using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using Owin;

namespace SelfHost.WinService
{
    public class Startup
    {
        public static void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();

            config.Services.Replace(typeof(IAssembliesResolver), new AssembliesResolver());
            config.MapHttpAttributeRoutes();
            appBuilder.UseWebApi(config);

        }
    }
    public class AssembliesResolver : DefaultAssembliesResolver
    {
        public override ICollection<Assembly> GetAssemblies()
        {

            ICollection<Assembly> baseAssemblies = base.GetAssemblies();
            var assemblies = new List<Assembly>(baseAssemblies);
            var controllersAssembly = Assembly.LoadFrom(@"D:\Learning\owin-api-es\Api\bin\Api.dll");
            assemblies.Add(controllersAssembly);
            return assemblies;

        }
    }
}
