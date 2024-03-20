using AutoMapper;
using Services;
using ViewModels;

namespace DashboardFrontend.Profiles;

public class MappingProfile : Profile
{
  public MappingProfile()
  {
    CreateMap<DashboardDto, DashboardViewModel>();
    CreateMap<DashboardListDto, DashboardViewModel>();

  }
}

