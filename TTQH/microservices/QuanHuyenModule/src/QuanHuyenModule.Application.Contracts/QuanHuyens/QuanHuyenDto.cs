using Volo.Abp.Application.Dtos;

namespace QuanHuyenModule.QuanHuyens;

public class QuanHuyenDto : AuditedEntityDto<long>
{
    public string TenQuanHuyen { get; set; }
    public string MaQuanHuyen { get; set; }
    public long IdTinhThanh { get; set; }
}
