using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace QuanHuyenModule.QuanHuyens;

public interface IQuanHuyenAppService : ICrudAppService<
    QuanHuyenDto,
    long,
    PagedAndSortedResultRequestDto,
    CreateUpdateQuanHuyenDto>
{
}
