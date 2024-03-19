using DomainModels;

namespace Repositories
{
  public interface IDashboardRepository : IGenericRepository<Dashboard, int>
  {
    Task<IEnumerable<Dashboard>> GetDashboardsByNameWithWidgets(string name);
  }
}