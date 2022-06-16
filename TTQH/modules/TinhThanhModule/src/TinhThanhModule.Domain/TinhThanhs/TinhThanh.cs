using Volo.Abp.Domain.Entities.Auditing;

namespace TinhThanhModule.TinhThanhs;

public class TinhThanh : AuditedAggregateRoot<long>
{
    public string MaTinhThanh { get; set; }
    public string TenTinhThanh { get; set; }
}
