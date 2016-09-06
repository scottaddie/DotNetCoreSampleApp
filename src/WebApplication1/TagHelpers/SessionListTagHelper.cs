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
            const string BADGE_CONTAINER_TAG = "span";
            const string BADGE_CSS_CLASS = "badge";

            base.Process(context, output);
            output.TagName = "ul";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.Add("class", "list-group");
            
            foreach (Session session in Sessions)
            {
                TagBuilder sessionBuilder = new TagBuilder("li");

                TagBuilder trackBadgeBuilder = new TagBuilder(BADGE_CONTAINER_TAG);
                trackBadgeBuilder.AddCssClass(BADGE_CSS_CLASS);
                trackBadgeBuilder.InnerHtml.Append(session.Track.ToString());
                sessionBuilder.InnerHtml.AppendHtml(trackBadgeBuilder);

                TagBuilder timeBadgeBuilder = new TagBuilder(BADGE_CONTAINER_TAG);
                timeBadgeBuilder.AddCssClass(BADGE_CSS_CLASS);
                timeBadgeBuilder.InnerHtml.Append(session.TimeSlot.ToString(@"h\:mm"));
                sessionBuilder.InnerHtml.AppendHtml(timeBadgeBuilder);

                sessionBuilder.AddCssClass("list-group-item");
                sessionBuilder.InnerHtml.Append(session.Title);

                output.Content.AppendHtml(sessionBuilder);
            }

        }
    }
}
