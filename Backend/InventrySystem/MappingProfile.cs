using AutoMapper;
using Entities.Identity;
using Entities.Models;
using Shared.DTO.Brand;
using Shared.DTO.CartItem;
using Shared.DTO.Category;
using Shared.DTO.Device;
using Shared.DTO.Sale;
using Shared.DTO.Supplier;
using Shared.DTO.User;

namespace InventrySystem
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<UserForRegistrationDto, User>()
                        .ForMember(u => u.UserName, opt => opt.MapFrom(x => GenerateValidUserName(x.Email)));

            CreateMap<Device, DeviceDto>()
                .ForMember(d => d.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(d => d.BrandName, opt => opt.MapFrom(src => src.Brand.Name))
                .ForMember(d => d.SupplierName, opt => opt.MapFrom(src => src.Supplier.Name));
            CreateMap<DeviceForCreationDto, Device>();
            CreateMap<DeviceForUpdateDto, Device>();

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryForCreationDto, Category>();
            CreateMap<CategoryForUpdateDto, Category>();

            CreateMap<Brand, BrandDto>();
            CreateMap<BrandForCreationDto, Brand>();
            CreateMap<BrandForUpdateDto, Brand>();

            CreateMap<Supplier, SupplierDto>();
            CreateMap<SupplierForCreationDto, Supplier>();
            CreateMap<SupplierForUpdateDto, Supplier>();

            CreateMap<UserForRegistrationDto, User>();
            CreateMap<User, UserDto>();
            CreateMap<UserRole, UserRoleDto>();
            CreateMap<UserForUpdateDto, User>();
            CreateMap<UserRoleForCreationDto, UserRole>();
            CreateMap<UserRoleForUpdateDto, UserRole>();

            CreateMap<Cartitem,CartItemDTO>();
            CreateMap<CartItemRequstDto,Cartitem>();

            CreateMap<SaleRequest, Sales>();
            CreateMap<SaleProductRequestDto, Cartitem>();
            CreateMap<Sales, SaleResponseDto>();
        }
        private string GenerateValidUserName(string email)
        {
            var atIndex = email.IndexOf('@');
            if (atIndex > 0)
            {
                return email.Substring(0, atIndex);
            }
            return email;
        }
    }
}
