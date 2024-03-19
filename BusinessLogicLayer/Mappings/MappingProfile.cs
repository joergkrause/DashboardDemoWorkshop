using AutoMapper;
using BusinessLogicLayer.TransferObjects;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Mappings
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<Dashboard, DashboardListDto>();
      CreateMap<Dashboard, DashboardDto>()
        .ForMember(e => e.HasWidgets, opt => opt.MapFrom(s => s.Widgets.Any()))
        ;
      CreateMap<DashboardCreateDto, Dashboard>();
      CreateMap<DashboardUpdateDto, Dashboard>();
    }
  }
}
