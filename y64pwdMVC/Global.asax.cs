using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;

using System.Web.Razor;
using System.Web.WebPages;

namespace y64pwdMVC
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);


            //---------------------------------------------------------
            //for Ionic App
            //---------------------------------------------------------
            ViewEngines.Engines.Add(new IonicAppViewEngine());
            RazorCodeLanguage.Languages.Add("html", new CSharpRazorCodeLanguage());
            WebPageHttpHandler.RegisterExtension("html");
            //---------------------------------------------------------
        }

        void Application_BeginRequest(object sender, EventArgs e)
        {
            //for IonicApp
            if (isIonicAppRewrite())
            {
                doIonicAppRewrite();
            }
            //end of ... for IonicApp
        }

        //------------------------------------------------------------
        //  private rewrite
        //------------------------------------------------------------
        private void doIonicAppRewrite()
        {
            string newUrl = string.Format("/IonicApp/www/{0}", HttpContext.Current.Request.RawUrl);
            HttpContext.Current.RewritePath(newUrl);
        }
        private bool isIonicAppRewrite()
        {
            string rawUrl = HttpContext.Current.Request.RawUrl;
            if (rawUrl.StartsWith("/css/")) return true;
            if (rawUrl.StartsWith("/img/")) return true;
            if (rawUrl.StartsWith("/js/")) return true;
            if (rawUrl.StartsWith("/lib/")) return true;
            if (rawUrl.StartsWith("/templates/")) return true;
            return false;
        }

    }
}