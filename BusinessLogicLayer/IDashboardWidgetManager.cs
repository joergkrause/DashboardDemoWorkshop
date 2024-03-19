using BusinessLogicLayer.TransferObjects;

namespace BusinessLogicLayer
{
  public interface IDashboardWidgetManager
  {
    Task CreateDashboard(DashboardCreateDto dashboard);
    Task<DashboardDto> GetDashboardById(int id);
    Task<IEnumerable<DashboardListDto>> GetDashboards();
    Task UpdateDashboard(DashboardUpdateDto dashboard);
  }
}