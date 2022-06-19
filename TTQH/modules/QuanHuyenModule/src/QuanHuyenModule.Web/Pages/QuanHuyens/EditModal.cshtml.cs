using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using QuanHuyenModule.QuanHuyens;

namespace QuanHuyenModule.Web.Pages.QuanHuyens;

public class EditModalModel : QuanHuyenModulePageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public long Id { get; set; }

    [BindProperty]
    public CreateUpdateQuanHuyenDto QuanHuyen { get; set; }

    private readonly IQuanHuyenAppService QuanHuyenService;

    public EditModalModel(IQuanHuyenAppService QuanHuyenService)
    {
        this.QuanHuyenService = QuanHuyenService;
    }

    public async Task OnGetAsync()
    {
        var QuanHuyenDto = await QuanHuyenService.GetAsync(Id);
        QuanHuyen = ObjectMapper.Map<QuanHuyenDto, CreateUpdateQuanHuyenDto>(QuanHuyenDto);

    }

    public async Task<IActionResult> OnPostAsync()
    {
        await QuanHuyenService.UpdateAsync(Id, QuanHuyen);
        return NoContent();
    }
}
