using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace y64pwdMVC
{
    //http://stackoverflow.com/questions/10279873/dynamic-stylesheets-using-razor
    public class IonicAppViewEngine : RazorViewEngine
    {
        public IonicAppViewEngine()
        {
            var viewLocations = new[] {
                "~/IonicApp/www/{0}.html"
                // etc
            };

            var fileExts = new[] { "html" };

            this.PartialViewLocationFormats = viewLocations;
            this.ViewLocationFormats = viewLocations;
            this.FileExtensions = fileExts;
        }

        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            controllerContext.HttpContext.Response.ContentType = "text/html";
            return base.CreateView(controllerContext, viewPath, masterPath);
        }
    }
}