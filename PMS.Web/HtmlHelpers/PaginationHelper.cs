using System;
using System.Text;
using System.Web.Mvc;
using PMS.Web.Models;

namespace PMS.Web.HtmlHelpers
{
    public static class PaginationHelper
    {
        /// <summary>
        /// Method extension to HtmlHelpers class.
        /// Require bootstrap
        /// </summary>
        public static MvcHtmlString PageLinks(this HtmlHelper helper, PagingInfo pagingInfo, Antlr.Runtime.Misc.Func<int, string> pageFunc)
        {
            if (pagingInfo.TotalPages > 0) 
            { 
                StringBuilder builder = new StringBuilder();
                TagBuilder groupTagBuilder = new TagBuilder("ul");
                groupTagBuilder.AddCssClass("pagination");
                groupTagBuilder.MergeAttribute("role", "group");
                for (int i = 1; i <= pagingInfo.TotalPages; i++)
                {
                    TagBuilder linkTagBuilder = new TagBuilder("a");
                    linkTagBuilder.MergeAttribute("href", pageFunc(i));
                    linkTagBuilder.InnerHtml = (i).ToString();

                    TagBuilder listTagBuilder = new TagBuilder("li");
                    listTagBuilder.InnerHtml = linkTagBuilder.ToString();
                    if (pagingInfo.CurrentPage == i)
                    {
                        listTagBuilder.AddCssClass("active");
                    }

                    builder.Append(listTagBuilder.ToString());

                }
                groupTagBuilder.InnerHtml = builder.ToString();
                return MvcHtmlString.Create(groupTagBuilder.ToString());
            }
            return new MvcHtmlString(String.Empty);
        }
    }
}