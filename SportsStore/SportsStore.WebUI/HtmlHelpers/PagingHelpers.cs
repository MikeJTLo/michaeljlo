using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.WebUI.Models;
using System.Text;

namespace SportsStore.WebUI.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper helper, PagingInfo info, Func<int, string> pageUrlFunction)
        {
            var result = new StringBuilder();
            for (int i = 1; i <= info.TotalPages; i++)
            {
                var tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrlFunction(i));
                tag.InnerHtml = i.ToString();
                if (i == info.CurrentPage)
                    tag.AddCssClass("selected");
                result.Append(tag.ToString());

            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}