using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhThanhModule.TinhThanhs;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace TinhThanhModule.Controllers
{
    [RemoteService(Name = TinhThanhModuleRemoteServiceConsts.RemoteServiceName)]
    [ControllerName("TinhThanh")]
    [Route("api/app/tinhThanh")]
    public class TinhThanhController : TinhThanhModuleController, ITinhThanhAppService
    {
        protected ITinhThanhAppService TinhThanhAppService { get; }
        public TinhThanhController(ITinhThanhAppService TinhThanhAppService)
        {
            this.TinhThanhAppService = TinhThanhAppService;
        }
        [HttpPost]
        public virtual Task<TinhThanhDto> CreateAsync(CreateUpdateTinhThanhDto input)
        {
            return TinhThanhAppService.CreateAsync(input);
        }
        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(long id)
        {
            return TinhThanhAppService.DeleteAsync(id);

        }
        [HttpGet]
        [Route("{id}")]
        public virtual Task<TinhThanhDto> GetAsync(long id)
        {
            return TinhThanhAppService.GetAsync(id);
        }
        [HttpGet]
        public virtual Task<PagedResultDto<TinhThanhDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return TinhThanhAppService.GetListAsync(input);
        }
        [HttpPut]
        [Route("{id}")]
        public virtual Task<TinhThanhDto> UpdateAsync(long id, CreateUpdateTinhThanhDto input)
        {
           return TinhThanhAppService.UpdateAsync(id, input);
        }
    }
}
