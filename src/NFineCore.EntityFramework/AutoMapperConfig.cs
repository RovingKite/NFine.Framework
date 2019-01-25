using NFineCore.EntityFramework.Dtos.SystemManage;
using NFineCore.EntityFramework.Models.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFineCore.EntityFramework
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                #region SystemManage Map

                cfg.CreateMap<DictInputDto, Dict>();
                cfg.CreateMap<Dict, DictOutputDto>();
                cfg.CreateMap<Dict, DictGridDto>();

                cfg.CreateMap<DictItemInputDto, DictItem>();
                cfg.CreateMap<DictItem, DictItemOutputDto>();
                cfg.CreateMap<DictItem, DictItemGridDto>();

                cfg.CreateMap<OrganizeInputDto, Organize>();
                cfg.CreateMap<Organize, OrganizeOutputDto>();
                cfg.CreateMap<Organize, OrganizeGridDto>();

                cfg.CreateMap<AreaInputDto, Area>();
                cfg.CreateMap<Area, AreaOutputDto>();
                cfg.CreateMap<Area, AreaGridDto>();

                cfg.CreateMap<RoleInputDto, Role>();
                cfg.CreateMap<Role, RoleOutputDto>();
                cfg.CreateMap<Role, RoleGridDto>();

                cfg.CreateMap<LoginLogInputDto, LoginLog>();
                //cfg.CreateMap<LoginLog, LoginLogOutputDto>();
                cfg.CreateMap<LoginLog, LoginLogGridDto>();

                cfg.CreateMap<OperateLogInputDto, OperateLog>();
                //cfg.CreateMap<LoginLog, LoginLogOutputDto>();
                cfg.CreateMap<OperateLog, OperateLogGridDto>();

                cfg.CreateMap<UserInputDto, User>()
                .ForMember(d => d.CompanyId, opt => opt.MapFrom(s => s.CompanyId))
                .ForMember(d => d.DepartmentId, opt => opt.MapFrom(s => s.DepartmentId))
                .ForMember(d => d.PositionId, opt => opt.MapFrom(s => s.PositionId))
                .ForMember(d => d.Password, opt => opt.Ignore())
                //.ForPath(s => s.Company.Id, opt => opt.MapFrom(src => src.CompanyId))
                //.ForPath(s => s.Department.Id, opt => opt.MapFrom(src => src.DepartmentId))
                //.ForPath(s => s.Position.Id, opt => opt.MapFrom(src => src.PositionId))
                ;

                cfg.CreateMap<User, UserOutputDto>()
                .ForMember(d => d.CompanyName, opt => opt.MapFrom(s => s.Company.FullName))
                .ForMember(d => d.CompanyId, opt => opt.MapFrom(s => s.Company.Id))
                .ForMember(d => d.DepartmentName, opt => opt.MapFrom(s => s.Department.FullName))
                .ForMember(d => d.DepartmentId, opt => opt.MapFrom(s => s.Department.Id))
                .ForMember(d => d.PositionName, opt => opt.MapFrom(s => s.Position.FullName))
                .ForMember(d => d.PositionId, opt => opt.MapFrom(s => s.Position.Id))
                .ForMember(d => d.UserRoles, opt => opt.MapFrom(s => s.UserRoles))
                ;
                cfg.CreateMap<User, UserGridDto>();
                
                cfg.CreateMap<PositionInputDto, Position>();
                cfg.CreateMap<Position, PositionOutputDto>();
                cfg.CreateMap<Position, PositionGridDto>();

                cfg.CreateMap<ResourceInputDto, Resource>();
                cfg.CreateMap<Resource, ResourceGridDto>();
                cfg.CreateMap<Resource, ResourceOutputDto>();

                cfg.CreateMap<AttachInputDto, Attach>();
                cfg.CreateMap<Attach, AttachGridDto>()
                .ForMember(d => d.UserName, opt => opt.MapFrom(s => s.CreatorUser.UserName));
                //cfg.CreateMap<AttachInputDto, Attach>();

                #endregion


            });
        }
    }
}
