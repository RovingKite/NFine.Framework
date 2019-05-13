using AutoMapper;
using NFine.Support;
using NFine.EntityFramework.Dto.SystemManage;
using NFine.EntityFramework.Entity.SystemManage;
using NFine.Repository.SystemManage;
using SharpRepository.Repository;
using SharpRepository.Repository.Queries;
using SharpRepository.Repository.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NFine.Service.SystemManage
{
    public class PermissionService
    {
        PermissionRepository permissionRepository = new PermissionRepository(SharpRepoConfig.sharpRepoConfig, "efCore");
        UserRepository userRepository = new UserRepository(SharpRepoConfig.sharpRepoConfig, "efCore");

        public List<ResourceGridDto> GetPermsResList(long userId)
        {
            var resourceList = new List<Resource>();
            string[] includePath = { "Company", "Department", "Position", "UserRoles", "UserRoles.Role", "UserRoles.User" };
            User user = userRepository.Get(userId, includePath);

            //添加角色权限资源
            var rolePermsResList = GetRolePermsResList(user.UserRoles);
            resourceList.AddRange(rolePermsResList);

            resourceList = resourceList.Distinct().OrderBy(o => o.SortCode).ToList();
            return Mapper.Map<List<ResourceGridDto>>(resourceList);
        }

        public List<Resource> GetRolePermsResList(List<UserRole> userRoles)
        {
            List<Resource> rolePermsResList = new List<Resource>();
            string roleIds = string.Empty;
            string roleNames = string.Empty;
            if (userRoles.Count > 0)
            {
                foreach (UserRole ur in userRoles)
                {
                    roleIds += ur.Role.Id + ",";
                    roleNames += ur.Role.FullName + ",";
                }
                roleIds = roleIds.TrimEnd(',');
                roleNames = roleNames.TrimEnd(',');
            }
            long[] objectIds = Array.ConvertAll<string, long>(roleIds.Split(','), delegate (string s) { return long.Parse(s); });
            var roleSpecification = new Specification<Permission>(p => objectIds.Contains(p.ObjectId));
            roleSpecification.FetchStrategy.Include(obj => obj.Resource);
            var sortingOtopns = new SortingOptions<Permission, int?>(x => x.Resource.SortCode, isDescending: false);
            var rolePermissions = permissionRepository.FindAll(roleSpecification, sortingOtopns);
            foreach (Permission p in rolePermissions)
            {
                rolePermsResList.Add(p.Resource);
            }
            return rolePermsResList;
        }

        public List<PermissionGridDto> GetRolePermissionList(long roleId)
        {
            var specification = new Specification<Permission>(p => p.ObjectId.Equals(roleId) && p.ObjectType.Equals("RolePermission"));
            var sortingOtopns = new SortingOptions<Permission, int?>(x => x.Resource.SortCode, isDescending: false);
            var list = permissionRepository.FindAll(specification, sortingOtopns).ToList();
            return Mapper.Map<List<PermissionGridDto>>(list);
        }

        public List<PermissionGridDto> GetUserPermissionList(long userId)
        {
            var specification = new Specification<Permission>(p => p.ObjectId.Equals(userId) && p.ObjectType.Equals("UserPermission"));
            var sortingOtopns = new SortingOptions<Permission, int?>(x => x.Resource.SortCode, isDescending: false);
            var list = permissionRepository.FindAll(specification, sortingOtopns).ToList();
            return Mapper.Map<List<PermissionGridDto>>(list);
        }
    }
}
