using AutoMapper;
using Contractors.Domain;
using Contractors.WebApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contractors.WebApp.Profiles
{
    public class ContractorMapperProfile : Profile
    {
        public ContractorMapperProfile()
        {
            CreateMap<Contractor, ContractorViewModel>()
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address.Street))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
                .ForMember(dest => dest.ZIPCode, opt => opt.MapFrom(src => src.Address.ZIPCode))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Address.Country));
            CreateMap<ContractorViewModel, Address>();
            CreateMap<ContractorViewModel, Contractor>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src));


        }
    }
}