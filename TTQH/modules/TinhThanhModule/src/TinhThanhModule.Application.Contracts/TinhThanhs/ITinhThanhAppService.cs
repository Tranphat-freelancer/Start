using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace TinhThanhModule.TinhThanhs
{
    public interface ITinhThanhAppService : ICrudAppService<
        TinhThanhDto,
        long,
        PagedAndSortedResultRequestDto,
        CreateUpdateTinhThanhDto>
    {
    }
}
