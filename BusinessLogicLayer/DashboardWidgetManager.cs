using BusinessLogicLayer.TransferObjects;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
  public class DashboardWidgetManager : Manager, IDashboardWidgetManager
  {
    public DashboardWidgetManager(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public async Task<IEnumerable<DashboardListDto>> GetDashboards()
    {
      var entities = await DashboardRepository.GetAll();
      return Mapper.Map<IEnumerable<DashboardListDto>>(entities);
    }

    public async Task<DashboardDto> GetDashboardById(int id)
    {
      var entity = await DashboardRepository.GetById(id);
      return Mapper.Map<DashboardDto>(entity);
    }

    public async Task UpdateDashboard(DashboardUpdateDto dashboard)
    {
      var entity = Mapper.Map<Dashboard>(dashboard);
      await DashboardRepository.InsertOrUpdate(entity);
    }

    public async Task CreateDashboard(DashboardCreateDto dashboard)
    {
      var entity = Mapper.Map<Dashboard>(dashboard);
      await DashboardRepository.Add(entity);
    }

  }
}
