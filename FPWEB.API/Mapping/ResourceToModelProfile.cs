using AutoMapper;
using FPWEB.API.Domain.Models;
using FPWEB.API.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPWEB.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCategoryResource, Category>();
            CreateMap<SaveProductResource, Product>();
            CreateMap<SaveCustomerResource, Customer>();
            CreateMap<SaveParticipantResource, Participant>();
        }
    }
}
