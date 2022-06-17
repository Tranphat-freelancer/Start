using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TinhThanhModule.TinhThanhs;

namespace TinhThanhModule.Web.Pages.TinhThanhs;

public class EditModalModel : TinhThanhModulePageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public long Id { get; set; }

    [BindProperty]
    public CreateUpdateTinhThanhDto TinhThanh { get; set; }

    private readonly ITinhThanhAppService TinhThanhService;

    public EditModalModel(ITinhThanhAppService TinhThanhService)
    {
        this.TinhThanhService = TinhThanhService;
    }

    public async Task OnGetAsync()
    {
        var TinhThanhDto = await TinhThanhService.GetAsync(Id);
        TinhThanh = ObjectMapper.Map<TinhThanhDto, CreateUpdateTinhThanhDto>(TinhThanhDto);

    }

    public async Task<IActionResult> OnPostAsync()
    {
        await TinhThanhService.UpdateAsync(Id, TinhThanh);
        return NoContent();
    }
}
