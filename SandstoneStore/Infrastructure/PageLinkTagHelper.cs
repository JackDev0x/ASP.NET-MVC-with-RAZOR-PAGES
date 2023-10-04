using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SandstoneStore.Models.ViewModels;
using System.Collections.Generic;

namespace SandstoneStore.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        private readonly IUrlHelperFactory _urlHelperFactory;

        public PageLinkTagHelper(IUrlHelperFactory urlHelperFactory)
        {
            _urlHelperFactory = urlHelperFactory ?? throw new ArgumentNullException(nameof(urlHelperFactory));
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public PagingInfo PageModel { get; set; }
        public string PageAction { get; set; }

        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>();

        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; } = "";
        public string PageClassNormal { get; set; } = "";
        public string PageClassSelected { get; set; } = "";

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if (PageModel == null || PageModel.Pages_total < 2)
            {
                // Brak stron do wygenerowania linków
                output.SuppressOutput();
                return;
            }

            var urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);

            var containerTag = new TagBuilder("div");
            containerTag.AddCssClass("pagination");

            for (var i = 1; i <= PageModel.Pages_total; i++)
            {
                var pageTag = new TagBuilder("a");
                PageUrlValues["productPage"] = i;

                pageTag.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);
                pageTag.InnerHtml.Append(i.ToString());

                if (PageClassesEnabled)
                {
                    pageTag.AddCssClass(PageClass);
                    pageTag.AddCssClass(i == PageModel.CurrentPage
                        ? PageClassSelected
                        : PageClassNormal);
                }

                containerTag.InnerHtml.AppendHtml(pageTag);
            }

            output.TagName = "div";
            output.Content.AppendHtml(containerTag.InnerHtml);
        }
    }
}

