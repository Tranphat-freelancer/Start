using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Main.Web.Pages;

public class IndexModel : MainPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
