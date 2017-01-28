﻿using System.Web.Mvc;

namespace DynamicBundles.TestWeb.Helpers
{
    public static class Helpers
    {
        public static MvcHtmlString MyHelper(this HtmlHelper html, string x)
        {
            return new MvcHtmlString(x + "<b>x</b>");
        }
    }
}

