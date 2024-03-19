using DataAccessLayer;
using DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories;

public class DashboardRepository(DashboardContext dashboardContext)
  : GenericRepository<Dashboard, int>(dashboardContext), IDashboardRepository
{

  public async Task<IEnumerable<Dashboard>> GetDashboardsByNameWithWidgets(string name)
  {
    var entities = await Context.Set<Dashboard>()
      .Include(e => e.Widgets)
      .Where(e => e.Name.Contains(name))
      .ToListAsync();
    return entities;
  }

}
