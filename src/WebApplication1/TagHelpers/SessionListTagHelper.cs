using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using WebApplication1.Models;

namespace WebApplication1.TagHelpers
{
    [HtmlTargetElement("session-list", Attributes = ItemsAttribute, TagStructure = TagStructure.WithoutEndTag)]
    public class SessionListTagHelper : TagHelper
    {
        public const string ItemsAttribute = "asp-items";

        [HtmlAttributeName(ItemsAttribute)]
        public List<Session> Sessions { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);
            output.TagName = "ul";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.Add("class", "list-group");
            
            foreach (Session session in Sessions)
            {
                TagBuilder sessionBuilder = new TagBuilder("li");

                TagBuilder badgeBuilder = new TagBuilder("span");
                badgeBuilder.AddCssClass("badge");
                badgeBuilder.InnerHtml.Append(session.SeatsAvailable.ToString());
                sessionBuilder.InnerHtml.AppendHtml(badgeBuilder);

                sessionBuilder.AddCssClass("list-group-item");
                sessionBuilder.InnerHtml.Append(session.Title);

                output.Content.AppendHtml(sessionBuilder);
            }
        }
    }
}
