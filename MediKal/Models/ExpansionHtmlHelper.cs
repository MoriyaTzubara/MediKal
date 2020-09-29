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
        public static MvcHtmlString DisplayImage(this HtmlHelper html, string imgPath, int size=150)
        {
            return new MvcHtmlString($"<img src='{imgPath}' height='{size}' width='{size}'/>");
        }
        public static MvcHtmlString DisplayRoundImage(this HtmlHelper html, string imgPath, int size = 150)
        {
            return new MvcHtmlString($"<img  class='round-img' src='{imgPath}' height='{size}' width='{size}'/>");
        }
        public static MvcHtmlString DisplayHeader(this HtmlHelper html, string textForHeader, int size)
        {
            return new MvcHtmlString($"<h{size}>{textForHeader}</h{size}>");
        }
}
}