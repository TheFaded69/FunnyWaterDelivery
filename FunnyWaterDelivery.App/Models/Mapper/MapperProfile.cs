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
            .ReverseMap();
        CreateMap<DbPartner, PartnerRowViewModel>()
            .ReverseMap();
    }
}