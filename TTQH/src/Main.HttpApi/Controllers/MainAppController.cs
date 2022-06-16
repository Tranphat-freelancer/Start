using Main.Mains;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Main.Controllers
{
    [RemoteService(Name = "Default")]
    [ControllerName("MainApps")]
    [Route("api/app/mainApp")]
    public class MainAppController : MainController, IMainAppService
    {
        protected IMainAppService MainAppService { get; }

        public MainAppController(IMainAppService MainAppService)
        {
            this.MainAppService = MainAppService;
        }
        [HttpPost]
        public virtual Task<MainAppDto> CreateAsync(CreateUpdateMainAppDto input)
        {
            return MainAppService.CreateAsync(input);
        }
        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(long id)
        {
            return MainAppService.DeleteAsync(id);
        }
        [HttpGet]
        [Route("{id}")]
        public virtual Task<MainAppDto> GetAsync(long id)
        {
            return MainAppService.GetAsync(id);
        }
        [HttpGet]
        public virtual Task<PagedResultDto<MainAppDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return MainAppService.GetListAsync(input);
        }
        [HttpPut]
        [Route("{id}")]
        public virtual Task<MainAppDto> UpdateAsync(long id, CreateUpdateMainAppDto input)
        {
            return MainAppService.UpdateAsync(id, input);
        }
    }
}
