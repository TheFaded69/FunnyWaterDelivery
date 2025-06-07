using AutoMapper;
using FunnyWaterDelivery.App.ViewModels.RowViewModels;
using FunnyWaterDelivery.Database.Models;

namespace FunnyWaterDelivery.App.Models.Mapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<DbEmployee, EmployeeRowViewModel>()
            .ReverseMap();
        
        CreateMap<DbOrder, OrderRowViewModel>()
            .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.Employee != null ? (Guid?)src.Employee.ID : null))
            .ForMember(dest => dest.PartnerId, opt => opt.MapFrom(src => src.Partner != null ? (Guid?)src.Partner.ID : null))
            .ReverseMap()
            .ForMember(dest => dest.Employee, opt => opt.MapFrom(src => src.EmployeeId.HasValue ?  new DbEmployee { ID = src.EmployeeId.Value } : null))
            .ForMember(dest => dest.Partner, opt => opt.MapFrom(src => src.PartnerId.HasValue ?  new DbPartner { ID = src.PartnerId.Value } : null));
        
        CreateMap<DbPartner, PartnerRowViewModel>()
            .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.Curator != null ? (Guid?)src.Curator.ID : null))
            .ReverseMap()
            .ForMember(dest => dest.Curator, opt => opt.MapFrom(src => src.EmployeeId.HasValue ?  new DbEmployee { ID = src.EmployeeId.Value } : null));
    }
}