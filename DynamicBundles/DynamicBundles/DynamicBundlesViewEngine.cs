using System.Web.Mvc;

namespace DynamicBundles
{
    public class DynamicBundlesViewEngine : RazorViewEngine
    {
        public DynamicBundlesViewEngine()
        {
            // Finds views sitting in own directories, such as ~/Views/Home/Index/Index.cshtml.
            // Note that this only works if you specify only the name of the view ("Index"), because only then
            // does the view engine do a search. If you specify the path, then you need to specify the view's directory as well
            // (such as: "~/Views/Shared/_Layout/_Layout.cshtml")
            //
            // See book "Pro ASP.NET MVC 4, page 495
            ViewLocationFormats = new[]
            {
                "~/Views/{1}/{0}/{0}.cshtml",
                "~/Views/{1}/{0}/{0}.vbhtml",
                "~/Views/Shared/{0}/{0}.cshtml",
                "~/Views/Shared/{0}/{0}.vbhtml"
            };

            MasterLocationFormats = ViewLocationFormats;
            PartialViewLocationFormats = ViewLocationFormats;

            AreaViewLocationFormats = new[]
            {
                "~/Areas/{2}/Views/{1}/{0}/{0}.cshtml",
                "~/Areas/{2}/Views/{1}/{0}/{0}.vbhtml",
                "~/Areas/{2}/Views/Shared/{0}/{0}.cshtml",
                "~/Areas/{2}/Views/Shared/{0}/{0}.vbhtml"
            };

            AreaMasterLocationFormats = AreaViewLocationFormats;
            AreaPartialViewLocationFormats = AreaViewLocationFormats;
        }
    }
}
