using AutoMapper;
using ProjApp.Models.BrandViewModels;
using ProjApp.Models.CarViewModels;
using ProjApp.Models.CountryViewModels;

namespace ProjApp.Models.Mappings
{
    /// <summary>
    /// Default model to view-model automapper mapping profile.
    /// </summary>
    public class ModelToViewModelMappingProfile : Profile
    {
        public ModelToViewModelMappingProfile()
        {
            CreateMap<Brand, BrandViewModel>();
            CreateMap<Brand, CreateBrandViewModel>();
            CreateMap<Brand, DeleteBrandViewModel>();
            CreateMap<Brand, DetailsBrandViewModel>();
            CreateMap<Brand, EditBrandViewModel>();

            CreateMap<Country, CountryViewModel>();
            CreateMap<Country, CreateCountryViewModel>();
            CreateMap<Country, DeleteCountryViewModel>();
            CreateMap<Country, DetailsCountryViewModel>();
            CreateMap<Country, EditCountryViewModel>();

            CreateMap<Car, CarViewModel>();
            CreateMap<Car, CreateCarViewModel>()
                .ForMember(dest => dest.BrandId,
                    opts => opts.MapFrom(src => src.Brand.BrandId))
                .ForMember(dest => dest.CountryId,
                    opts => opts.MapFrom(src => src.Country.CountryId));
            CreateMap<Car, DeleteCarViewModel>();
            CreateMap<Car, DetailsCarViewModel>();
            CreateMap<Car, EditCarViewModel>()
                .ForMember(dest => dest.BrandId,
                    opts => opts.MapFrom(src => src.Brand.BrandId))
                .ForMember(dest => dest.CountryId,
                    opts => opts.MapFrom(src => src.Country.CountryId));
        }
    }
}
