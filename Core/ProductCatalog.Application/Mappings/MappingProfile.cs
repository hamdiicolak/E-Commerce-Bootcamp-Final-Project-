using AutoMapper;
using ProductCatalog.Application.Features;
using ProductCatalog.Application.Features.Authentications.Commands.SignUp;
using ProductCatalog.Application.Features.Authentications.Queries.LogIn;
using ProductCatalog.Application.Features.Brands;
using ProductCatalog.Application.Features.Categories.Queries.GetAllCategories;
using ProductCatalog.Application.Features.Categories.Queries.GetAllOffers;
using ProductCatalog.Application.Features.Categories.Queries.GetCategory;
using ProductCatalog.Application.Features.Colors;
using ProductCatalog.Application.Features.Products.Commands.New_Product;
using ProductCatalog.Application.Features.Products.Queries.GetAllOfferedUserProducts;
using ProductCatalog.Application.Features.Products.Queries.GetAllProduct;
using ProductCatalog.Application.Features.Products.Queries.GetAllProductsByCategory;
using ProductCatalog.Application.Features.Products.Queries.GetAllProductsOfferedByUser;
using ProductCatalog.Application.Features.Products.Queries.GetProduct;
using ProductCatalog.Application.Features.Products.Queries.GetUserProducts;
using ProductCatalog.Application.Features.UsingStatuses;
using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Application.Mappings
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			#region Users

			CreateMap<User, LogInQueryResponse>();
			CreateMap<User, SignUpUserCommandRequest>().ReverseMap();

			#endregion

			#region Products

			// All Products
			CreateMap<Product, GetAllProductsQueryResponse>()
				.ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
				.ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name))
				.ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand.BrandName))
				.ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color.ColorName))
				.ForMember(dest => dest.UsingStatus, opt => opt.MapFrom(src => src.UsingStatus.UsingStatusDetail));

			// Product Detail
			CreateMap<Product, GetProductQueryResponse>()
				.ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
				.ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name))
				.ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color.ColorName))
				.ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand.BrandName))
				.ForMember(dest => dest.UsingStatus, opt => opt.MapFrom(src => src.UsingStatus.UsingStatusDetail))
				.ReverseMap();

			CreateMap<Product, GetAllUserProductsQueryResponse>()
				.ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
				.ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name))
				.ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color.ColorName))
				.ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand.BrandName))
				.ForMember(dest => dest.UsingStatus, opt => opt.MapFrom(src => src.UsingStatus.UsingStatusDetail))
				.ReverseMap();

			// Makes a two way mapping src -> dest  dest -> src
			CreateMap<Product, NewProductCommandRequest>()
				.ReverseMap();

			CreateMap<Product, GetAllProductsByCategoryIdQueryResponse>()
				.ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
				.ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name))
				.ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand.BrandName))
				.ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color.ColorName))
				.ForMember(dest => dest.UsingStatus, opt => opt.MapFrom(src => src.UsingStatus.UsingStatusDetail));

			CreateMap<Product, GetAllProductsOfferedByUserQueryResponse>()
				.ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
				.ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name))
				.ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand.BrandName))
				.ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color.ColorName))
				.ForMember(dest => dest.UsingStatus, opt => opt.MapFrom(src => src.UsingStatus.UsingStatusDetail));

			CreateMap<Product, GetAllOfferedUserProductsQueryResponse>()
				.ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
				.ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name))
				.ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand.BrandName))
				.ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color.ColorName))
				.ForMember(dest => dest.UsingStatus, opt => opt.MapFrom(src => src.UsingStatus.UsingStatusDetail));

			#endregion

			#region Categories

			CreateMap<Category, GetAllCategoriesQueryResponse>();
			CreateMap<Category, GetCategoryQueryResponse>();

			#endregion

			#region UsingStatuses

			CreateMap<UsingStatus, GetAllUsingStatusesQueryResponse>()
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.UsingStatusDetail));
			CreateMap<UsingStatus, GetUsingStatusQueryResponse>()
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.UsingStatusDetail));

			#endregion

			#region Brands

			CreateMap<Brand, GetAllBrandsQueryResponse>()
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.BrandName));
			CreateMap<Brand, GetBrandQueryResponse>()
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.BrandName));

			#endregion

			#region Colors

			CreateMap<Color, GetAllColorsQueryResponse>()
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ColorName));
			CreateMap<Color, GetColorQueryResponse>()
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ColorName));

			#endregion

			#region Offer

			CreateMap<Offer, NewOfferCommandRequest>()
				.ReverseMap();

			CreateMap<Offer, GetAllOffersQueryResponse>();

			#endregion
		}
	}
}
