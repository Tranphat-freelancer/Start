using Microsoft.AspNetCore.Mvc;
using QuanHuyenModule.QuanHuyens;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace QuanHuyenModule.Controllers;

[RemoteService(Name = QuanHuyenModuleRemoteServiceConsts.RemoteServiceName)]
[ControllerName("QuanHuyen")]
[Route("api/app/quanHuyens")]
public class QuanHuyenController : QuanHuyenModuleController, IQuanHuyenAppService
{
    protected IQuanHuyenAppService QuanHuyenAppService { get; }
    public QuanHuyenController(IQuanHuyenAppService QuanHuyenAppService)
    {
        this.QuanHuyenAppService = QuanHuyenAppService;
    }
    [HttpPost]
    public virtual Task<QuanHuyenDto> CreateAsync(CreateUpdateQuanHuyenDto input)
    {
        return QuanHuyenAppService.CreateAsync(input);
    }
    [HttpDelete]
    [Route("{id}")]
    public virtual Task DeleteAsync(long id)
    {
        return QuanHuyenAppService.DeleteAsync(id);
    }
    [HttpGet]
    [Route("{id}")]
    public virtual Task<QuanHuyenDto> GetAsync(long id)
    {
        return QuanHuyenAppService.GetAsync(id);
    }
    [HttpGet]
    public virtual Task<PagedResultDto<QuanHuyenDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return QuanHuyenAppService.GetListAsync(input);
    }
    [HttpPut]
    [Route("{id}")]
    public virtual Task<QuanHuyenDto> UpdateAsync(long id, CreateUpdateQuanHuyenDto input)
    {
        return QuanHuyenAppService.UpdateAsync(id, input);
    }
}
