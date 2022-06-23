using Volo.Abp.Domain.Entities.Auditing;

namespace QuanHuyenModule.QuanHuyens;

public class QuanHuyen : AuditedAggregateRoot<long>
{
    public string TenQuanHuyen { get; set; }
    public string MaQuanHuyen { get; set; }
    public long IdTinhThanh { get; set; }
}
