using DAL.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BerkMusicUI.CustomTagHelper
{
    [HtmlTargetElement("td", Attributes = "user-roles")]
    public class UserRolesName:TagHelper
    {
        private readonly UserManager<AppUser> userManager;

        public UserRolesName(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }
        [HtmlAttributeName("user-roles")]
        public string UserId { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            AppUser user = await userManager.FindByIdAsync(UserId);
            IList<string> roles = await userManager.GetRolesAsync(user);
            string html = string.Empty;
            roles.ToList().ForEach(x =>
            {
                if (x=="Admin")
                {
                    html += $"<span class='badge badge-danger'>{x}</span>";


                }
                else
                {
                    html += $"<span class='badge badge-info'>{x}</span>";

                }




            });
            output.Content.SetHtmlContent(html);



        }
    }
}
