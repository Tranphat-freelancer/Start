using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Ms.AppTTQH.Web.Pages;

public class IndexModel : AppTTQHPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
