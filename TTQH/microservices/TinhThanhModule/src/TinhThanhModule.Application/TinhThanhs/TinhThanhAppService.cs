using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace TinhThanhModule.TinhThanhs;

public class TinhThanhAppService : CrudAppService<
    TinhThanh,
    TinhThanhDto,
    long,
    PagedAndSortedResultRequestDto,
    CreateUpdateTinhThanhDto>,
    ITinhThanhAppService
{
    public TinhThanhAppService(IRepository<TinhThanh, long> repository) : base(repository)
    {
    }
}
