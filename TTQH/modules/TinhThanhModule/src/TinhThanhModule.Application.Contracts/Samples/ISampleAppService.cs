using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace TinhThanhModule.Samples;

public interface ISampleAppService : IApplicationService
{
    Task<SampleDto> GetAsync();

    Task<SampleDto> GetAuthorizedAsync();
}
