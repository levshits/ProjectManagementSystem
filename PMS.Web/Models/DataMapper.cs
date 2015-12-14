using AutoMapper;
using PMS.Common.Dto;
using PMS.Common.ListItem;

namespace PMS.Web.Models
{
    public class DataMapper
    {
        public DataMapper()
        {
            Mapper.CreateMap<RoleListItem, RoleListItemModel>();
            Mapper.CreateMap<RoleListItemModel, RoleListItem>();

            Mapper.CreateMap<CreateRoleFirstStepModel, CreateRoleSecondStepModel>();
            Mapper.CreateMap<CreateRoleSecondStepModel, CreateRoleFirstStepModel>();

            Mapper.CreateMap<CreateRoleSecondStepModel, RoleDto>();

            Mapper.CreateMap<RoleDetailsModel, RoleDto>();
            Mapper.CreateMap<RoleDto, RoleDetailsModel>();

        } 
    }
}