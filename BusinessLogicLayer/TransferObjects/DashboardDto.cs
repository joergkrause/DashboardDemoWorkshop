using DomainModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.TransferObjects;

public class DashboardListDto
{
  public int Id { get; set; }

  public string Name { get; set; } = default!;

  public bool Active { get; set; }

}

public class DashboardDto : DashboardListDto
{
  public bool HasWidgets { get; set; }  
}

public class DashboardCreateDto
{
  [StringLength(64), Required]
  public string Name { get; set; } = default!;
}

public class DashboardUpdateDto : DashboardCreateDto
{
  public int Id { get; set; }
}