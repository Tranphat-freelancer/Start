using System;
using Volo.Abp.Application.Dtos;

namespace Main.Mains
{
    public class MainAppDto : AuditedEntityDto<long>
    {
        public string Content { get; set; }
    }
}
