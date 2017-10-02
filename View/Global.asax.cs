using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Mock;
using Services;

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
            var mock = new UsuarioMock();
            mock.CriarUsuariosTeste();
            //BUSCAR USUARIOS
            var result = mock.SelectUsuarios();
            */
        }

    }
}
