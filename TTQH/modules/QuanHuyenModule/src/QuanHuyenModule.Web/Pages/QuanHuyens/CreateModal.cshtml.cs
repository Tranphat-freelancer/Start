using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using QuanHuyenModule.QuanHuyens;

namespace QuanHuyenModule.Web.Pages.QuanHuyens;

public class CreateModalModel : QuanHuyenModulePageModel
{
    [BindProperty]
    public CreateUpdateQuanHuyenDto QuanHuyen { get; set; }

    private readonly IQuanHuyenAppService QuanHuyenAppService;

    public CreateModalModel(IQuanHuyenAppService QuanHuyenAppService)
    {
        this.QuanHuyenAppService = QuanHuyenAppService;
    }

    public void OnGet()
    {
        QuanHuyen = new CreateUpdateQuanHuyenDto();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await QuanHuyenAppService.CreateAsync(QuanHuyen);
        return NoContent();
    }
}
