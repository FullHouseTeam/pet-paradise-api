using AutoMapper;
using api.DTOs;
using api.Models;
using System.Globalization;

namespace api.Utilities
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Brand
            CreateMap<Brand, BrandDTO>().ReverseMap();
            #endregion

            #region Provider
            CreateMap<Provider, ProviderDTO>().ReverseMap();
            #endregion
        }
    }
}