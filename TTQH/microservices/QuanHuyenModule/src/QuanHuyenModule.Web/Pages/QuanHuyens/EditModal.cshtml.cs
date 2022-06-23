using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using QuanHuyenModule.QuanHuyens;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TinhThanhModule.TinhThanhs;
using Volo.Abp.Application.Dtos;
using System.Linq;

namespace QuanHuyenModule.Web.Pages.QuanHuyens;

public class EditModalModel : QuanHuyenModulePageModel
{
    //[HiddenInput]
    //[BindProperty(SupportsGet = true)]
    //public long Id { get; set; }

    [BindProperty]
    public EditQuanHuyenViewModel QuanHuyen { get; set; }
    public List<SelectListItem> TinhThanhs { get; set; }

    private readonly IQuanHuyenAppService QuanHuyenService;
    private readonly ITinhThanhAppService TinhThanhAppService;

    public EditModalModel(IQuanHuyenAppService QuanHuyenService,
        ITinhThanhAppService TinhThanhAppService)
    {
        this.QuanHuyenService = QuanHuyenService;
        this.TinhThanhAppService = TinhThanhAppService;
    }

    public async Task OnGetAsync(long Id)
    {
        var QuanHuyenDto = await QuanHuyenService.GetAsync(Id);
        QuanHuyen = ObjectMapper.Map<QuanHuyenDto, EditQuanHuyenViewModel>(QuanHuyenDto);
        var tinhThanhLookup = TinhThanhAppService
            .GetListAsync(new PagedAndSortedResultRequestDto() { MaxResultCount = 10 })
            .Result;
        TinhThanhs = tinhThanhLookup.Items
            .Select(x => new SelectListItem(x.TenTinhThanh, x.Id.ToString()))
            .ToList();

    }

    public async Task<IActionResult> OnPostAsync()
    {
        await QuanHuyenService.UpdateAsync(
            QuanHuyen.Id,
            ObjectMapper.Map<EditQuanHuyenViewModel, CreateUpdateQuanHuyenDto>(QuanHuyen)
            );
        return NoContent();
    }
    public class EditQuanHuyenViewModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public long Id { get; set; }

        [SelectItems(nameof(TinhThanhs))]
        [DisplayName("Mã Tỉnh Thành")]
        public long IdTinhThanh { get; set; }

        [Required]
        public string TenQuanHuyen { get; set; }

        [Required]
        public string MaQuanHuyen { get; set; }
    }
}
