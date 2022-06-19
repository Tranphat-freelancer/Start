using Main.Mains;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Main.Web.Pages.MainApps
{
    public class CreateModalModel : MainPageModel
    {
        [BindProperty]
        public CreateUpdateMainAppDto MainApp { get; set; }

        private readonly IMainAppService MainAppService;
        public CreateModalModel(IMainAppService MainAppService)
        {
            this.MainAppService = MainAppService;
        }

        public void OnGet()
        {
            MainApp = new CreateUpdateMainAppDto();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await MainAppService.CreateAsync(MainApp);
            return NoContent();
        }
    }
}
