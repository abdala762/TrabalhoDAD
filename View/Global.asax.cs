using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Mock;

namespace View
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

           
            /*
            //EXECUTAR APENAS UMA VEZ PRA PREENCHER ALGUNS USUARIOS NO BANCO
            var mock = new ClasseMock();
            mock.CriarUsuario();
            //PRA TESTAR SE TEM USUARIO
            var result = mock.SelectUsuarios();
            */
        }

    }
}
