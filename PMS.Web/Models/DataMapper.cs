﻿using AutoMapper;
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

            Mapper.CreateMap<ProjectListItem, ProjectListItemModel>();
            Mapper.CreateMap<ProjectListItemModel, ProjectListItem>();

            Mapper.CreateMap<IssueListItem, IssueListItemModel>();

            Mapper.CreateMap<CreateIssueModel, IssueDto>();
            Mapper.CreateMap<IssueDto, CreateIssueModel>();
            Mapper.CreateMap<IssueDto, IssueDetailsModel>();

            Mapper.CreateMap<CreateProjectModel, ProjectDto>();
            Mapper.CreateMap<ProjectDto, CreateProjectModel>();

            Mapper.CreateMap<CreateRoleFirstStepModel, CreateRoleSecondStepModel>();
            Mapper.CreateMap<CreateRoleSecondStepModel, CreateRoleFirstStepModel>();

            Mapper.CreateMap<CreateRoleSecondStepModel, RoleDto>();

            Mapper.CreateMap<RoleDetailsModel, RoleDto>();
            Mapper.CreateMap<RoleDto, RoleDetailsModel>();

            Mapper.CreateMap<PrincipalListItem, UserListItemModel>();
            Mapper.CreateMap<UserListItemModel, PrincipalListItem>();

            Mapper.CreateMap<PrincipalDto, CreateUserModel>();
            Mapper.CreateMap<CreateUserModel, PrincipalDto>();

            Mapper.CreateMap<UserDetailsModel, PrincipalDto>();
            Mapper.CreateMap<PrincipalDto, UserDetailsModel>();

            Mapper.CreateMap<CreateSprintModel, SprintDto>();
            Mapper.CreateMap<SprintDto, CreateSprintModel>();

            Mapper.CreateMap<SprintListItem, SprintListItemModel>();
            Mapper.CreateMap<ActivityListItem, ActivityListItemModel>();

        } 
    }
}