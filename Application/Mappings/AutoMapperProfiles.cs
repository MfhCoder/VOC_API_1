using Application.Dtos.Merchant;
using Application.Dtos.RoleDtos;
using Application.Dtos.UserDtos;
using AutoMapper;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // Merchant mappings
            CreateMap<Merchant, MerchantDto>();

            // User mappings
            CreateMap<User, UserDto>()
              .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
              .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.Name));
            CreateMap<CreateUserDto, User>()
             .ForMember(dest => dest.JoiningDate, opt => opt.MapFrom(_ => DateTime.UtcNow))
             .ForMember(dest => dest.Status, opt => opt.MapFrom(_ => "Active"));
            CreateMap<UpdateUserDto, User>();

            // Role mappings
            CreateMap<Role, RoleDto>()
                .ForMember(dest => dest.Permissions,
                    opt => opt.MapFrom(src => src.RolePermissions
                        .Select(rp => rp.Permission.Name)));

            //// Permission mappings
            //CreateMap<Permission, PermissionDto>()
            //    .ForMember(dest => dest.PermissionId, opt => opt.MapFrom(src => src.Id))
            //    .ForMember(dest => dest.ModuleName, opt => opt.MapFrom(src => src.Module.Name))
            //    .ForMember(dest => dest.SurveyName, opt => opt.MapFrom(src => src.Survey != null ? src.Survey.Title : null));

            //// Module mappings
            //CreateMap<Module, ModuleDto>()
            //    .ForMember(dest => dest.ModuleId, opt => opt.MapFrom(src => src.Id));


        }
    }
}
