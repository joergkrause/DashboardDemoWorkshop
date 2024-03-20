using DomainModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

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
  [CheckA]
  public string Name { get; set; } = default!;
}

public class DashboardUpdateDto : DashboardCreateDto
{
  public int Id { get; set; }
}

public class CheckAAttribute : ValidationAttribute
{
  public override bool IsValid(object? value)
  {
    if (value is not null && value is string v)
    {
      return v.StartsWith("A");
    }
    return false;
  }
}