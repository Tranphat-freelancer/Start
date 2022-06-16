using Volo.Abp.Application.Dtos;

namespace TinhThanhModule.TinhThanhs
{
    public class TinhThanhDto : AuditedEntityDto<long>
    {
        public string MaTinhThanh { get; set; }
        public string TenTinhThanh { get; set; }
    }
}
