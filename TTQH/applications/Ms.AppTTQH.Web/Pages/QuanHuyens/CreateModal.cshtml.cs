using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuanHuyenModule.QuanHuyens;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TinhThanhModule.TinhThanhs;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Ms.AppTTQH.Web.Pages.QuanHuyens;

public class CreateModalModel : AppTTQHPageModel
{
    [BindProperty]
    public CreateQuanHuyenViewModel QuanHuyen { get; set; }
    public List<SelectListItem> TinhThanhs { get; set; }

    private readonly IQuanHuyenAppService QuanHuyenAppService;
    private readonly ITinhThanhAppService TinhThanhAppService;

    public CreateModalModel(IQuanHuyenAppService QuanHuyenAppService,
        ITinhThanhAppService TinhThanhAppService)
    {
        this.QuanHuyenAppService = QuanHuyenAppService;
        this.TinhThanhAppService = TinhThanhAppService;
    }

    public void OnGet()
    {
        QuanHuyen = new CreateQuanHuyenViewModel();
        var tinhThanhLookup = TinhThanhAppService
            .GetListAsync(new PagedAndSortedResultRequestDto() { MaxResultCount = 10000 })
            .Result;
        TinhThanhs = tinhThanhLookup.Items
            .Select(x => new SelectListItem(x.TenTinhThanh, x.Id.ToString()))
            .ToList();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await QuanHuyenAppService.CreateAsync(
            ObjectMapper.Map<CreateQuanHuyenViewModel, CreateUpdateQuanHuyenDto>(QuanHuyen)
                );
        return NoContent();
    }
    public class CreateQuanHuyenViewModel
    {
        [SelectItems(nameof(TinhThanhs))]
        [DisplayName("Mã Tỉnh Thành")]
        public long IdTinhThanh { get; set; }
        [Required]
        public string TenQuanHuyen { get; set; }

        [Required]
        public string MaQuanHuyen { get; set; }
    }
}
