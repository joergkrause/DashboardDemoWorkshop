using Microsoft.Extensions.DependencyInjection;
using Repositories;

namespace BusinessLogicLayer;

public abstract class Manager(IServiceProvider serviceProvider)
{
  protected IDashboardRepository DashboardRepository { get; init; } = serviceProvider.GetRequiredService<IDashboardRepository>();

}
