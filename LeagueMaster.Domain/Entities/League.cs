using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueMaster.Domain.Entities;

public class League : BaseDomainObject
{
    public string Name { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string Season { get; set; } = null!;
    public DateTime StartDate { get; set; } = DateTime.Now;
    public DateTime EndDate { get; set; } = DateTime.Now.AddMonths(3);
}
