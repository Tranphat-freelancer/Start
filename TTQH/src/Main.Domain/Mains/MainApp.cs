using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Main.Mains;

public class MainApp : AuditedAggregateRoot<long>
{
    public string Content { get; set; }
}
