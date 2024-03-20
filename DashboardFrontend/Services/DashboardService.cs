using AutoMapper;
using Services;
using ViewModels;

namespace DashboardFrontend.Services;

public class DashboardService(DashboardClient client, IMapper mapper)
{

  public async Task<DashboardTableViewModel> GetDashboardListAsync()
  {
    var dtos = await client.GetDashboardsAsync();
    var vms = mapper.Map<IEnumerable<DashboardViewModel>>(dtos);
    return new DashboardTableViewModel { Dashboards = vms };
  }
}
