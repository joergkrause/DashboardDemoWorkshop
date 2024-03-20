using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels;

public class DashboardViewModel
{
  public int Id { get; set; }

  [Required(ErrorMessage = "Name ist erforderlich!")]
  [StringLength(64, ErrorMessage = "zu lang!")]
  public string Name { get; set; }
  public bool IsActive { get; set; }
}

public class DashboardTableViewModel
{
  public IEnumerable<DashboardViewModel> Dashboards { get; set; }

  public int Count { get => Dashboards.Count(); }
}
