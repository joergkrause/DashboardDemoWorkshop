using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels;

public class DashboardViewModel
{
  public int Id { get; set; }
  public string Name { get; set; }
  public bool IsActive { get; set; }
}

public class DashboardTableViewModel
{
  public IEnumerable<DashboardViewModel> Dashboards { get; set; }

  public int Count { get => Dashboards.Count(); }
}
