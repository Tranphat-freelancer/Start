using Main.Mains;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Main.Web.Pages.MainApps
{
    public class EditModalModel : MainPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public long Id { get; set; }

        [BindProperty]
        public CreateUpdateMainAppDto MainApp { get; set; }

        private readonly IMainAppService MainAppService;

        public EditModalModel(IMainAppService MainAppService)
        {
            this.MainAppService = MainAppService;
        }

        public async Task OnGetAsync()
        {
            var mainAppDto = await MainAppService.GetAsync(Id);
            MainApp = ObjectMapper.Map<MainAppDto, CreateUpdateMainAppDto>(mainAppDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await MainAppService.UpdateAsync(Id, MainApp);
            return NoContent();
        }
    }
}
