using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace MediKal.Models
{
    public static class ExpansionHtmlHelper
    {
        public static MvcHtmlString DisplayImage(this HtmlHelper html, string imgPath)
        {
            return new MvcHtmlString($"<img src='{imgPath}' height='150' width='150'/>");
        }
    }
}