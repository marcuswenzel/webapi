using AutoMapper;
using FPWEB.API.Domain.Models;
using FPWEB.API.Resources;
using FPWEB.API.Extensions;

namespace FPWEB.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Category, CategoryResource>();

            CreateMap<Product, ProductResource>()
                 .ForMember(src => src.UnitOfMeasurement,
                            opt => opt.MapFrom(src => src.UnitOfMeasurement.ToDescription()));

            CreateMap<Customer, CustomerResource>();
            CreateMap<Participant, ParticipantResource>();
        }
    }
}
