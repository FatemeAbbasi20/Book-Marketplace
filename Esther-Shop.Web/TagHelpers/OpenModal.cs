using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;

namespace Esther_Shop.Web.TagHelpers
{
    public class OpenModal:TagHelper
    {
        public string Url { get; set; }=string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Class { get; set; } = "btn btn-Success";
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName="button";
            output.Attributes.Add("onclick",$"OpenModal('{Url}','default_Modal','{Title}')");
            output.Attributes.Add("class",Class);
            base.Process(context, output);

        }
    }
}
