using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;

using SKV.VML.ViewModels.Common;

namespace SKV.PL.Helpers
{
    public static class SidebarMenuHelper
    {
        public static MvcHtmlString CreateSidebarMenu(this HtmlHelper html, IEnumerable<UIMenuItemView> items)
        {
            var div = new TagBuilder("div"); div.MergeAttribute("id", "sidebar-menu");

            var ul = new TagBuilder("ul");
            foreach (var item in items)
                ul.InnerHtml += MakeParent(item);
            div.InnerHtml = ul.ToString();

            return new MvcHtmlString(div.ToString());
        }

        private static string MakeParent(UIMenuItemView parent)
        {
            var li = new TagBuilder("li");
            if (parent.Childs.Any())
            {
                li.AddCssClass("has_sub");

                var a = new TagBuilder("a");
                a.MergeAttribute("href", "javascript:void(0);");

                var i = new TagBuilder("i");
                i.MergeAttribute("class", parent.IconClass);

                var span_title = new TagBuilder("span");
                span_title.SetInnerText(GetLocalizedString(parent.Name));

                var span_icon = new TagBuilder("span"); span_icon.MergeAttribute("class", "pull-right");
                var span_icon_i = new TagBuilder("i"); span_icon_i.MergeAttribute("class", "fa fa-angle-down");

                span_icon.InnerHtml = span_icon_i.ToString();

                a.InnerHtml += i.ToString();
                a.InnerHtml += span_title.ToString();
                a.InnerHtml += span_icon.ToString();

                var sub_items_ul = new TagBuilder("ul");
                foreach (var sub_item in parent.Childs)
                    sub_items_ul.InnerHtml += MakeParent(sub_item);

                li.InnerHtml += a.ToString();
                li.InnerHtml += sub_items_ul.ToString();
            }
            else
            {
                var last_li = new TagBuilder("li");
                var last_a = new TagBuilder("a");

                last_a.MergeAttribute("href", $"/{ parent.Controller }/{ parent.Action }");

                var span_title = new TagBuilder("span");
                span_title.SetInnerText(GetLocalizedString(parent.Name));

                last_a.InnerHtml = span_title.ToString();
                last_li.InnerHtml = last_a.ToString();

                li.InnerHtml = last_li.ToString();
            }

            return li.ToString();
        }

        private static string GetLocalizedString(string key) => Resources.Resource.ResourceManager.GetString(key);
    }
}