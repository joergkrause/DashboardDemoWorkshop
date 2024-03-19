using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels;

public class Dashboard : EntityBase<int>
{
  public string Name { get; set; } = default!;

  public bool Active { get; set; }

  public ICollection<Widget> Widgets { get; set; } = [];
}
