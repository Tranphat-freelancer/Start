using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace QuanHuyenModule.QuanHuyens;

public class QuanHuyenAppService : CrudAppService<
    QuanHuyen,
    QuanHuyenDto,
    long,
    PagedAndSortedResultRequestDto,
    CreateUpdateQuanHuyenDto>, IQuanHuyenAppService

{
    public QuanHuyenAppService(IRepository<QuanHuyen, long> repository) : base(repository)
    {
    }
}
