using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TinhThanhModule.TinhThanhs;

namespace Ms.AppTTQH.Web.Pages.TinhThanhs;

public class CreateModalModel : AppTTQHPageModel
{
    [BindProperty]
    public CreateUpdateTinhThanhDto TinhThanh { get; set; }

    private readonly ITinhThanhAppService TinhThanhService;

    public CreateModalModel(ITinhThanhAppService TinhThanhService)
    {
        this.TinhThanhService = TinhThanhService;
    }

    public void OnGet()
    {
        TinhThanh = new CreateUpdateTinhThanhDto();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await TinhThanhService.CreateAsync(TinhThanh);
        return NoContent();
    }
}
