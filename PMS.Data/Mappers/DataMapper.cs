﻿using AutoMapper;
using PMS.Common.Dto;
using PMS.Common.ListItem;
using PMS.Data.Enity;

namespace PMS.Data.Mappers
{
    public class DataMapper
    {
        public DataMapper()
        {
            Mapper.CreateMap<PrincipalEntity, PrincipalDto>();
            Mapper.CreateMap<PrincipalDto, PrincipalEntity>();

            Mapper.CreateMap<ProjectEntity, ProjectDto>();
            Mapper.CreateMap<ProjectDto, ProjectEntity>();

            Mapper.CreateMap<SprintDto, SprintEntity>();
            Mapper.CreateMap<SprintEntity, SprintDto>();

            Mapper.CreateMap<PrincipalEntity, PrincipalListItem>();
            Mapper.CreateMap<PrincipalListItem, PrincipalEntity>();

            Mapper.CreateMap<PrincipalExtendedEntity, PrincipalDto>();
            Mapper.CreateMap<PrincipalDto, PrincipalExtendedEntity>();

            Mapper.CreateMap<RoleEntity, RoleDto>();
            Mapper.CreateMap<RoleDto, RoleEntity>();

            Mapper.CreateMap<RoleTypeEntity, RoleTypeDto>();
            Mapper.CreateMap<RoleTypeDto, RoleTypeEntity>();

            Mapper.CreateMap<RoleEntity, RoleListItem>();
            Mapper.CreateMap<RoleListItem, RoleEntity>();

            Mapper.CreateMap<ActionEntity, ActionDto>();
            Mapper.CreateMap<ActionDto, ActionEntity>();

            Mapper.CreateMap<MediaContentEntity, MediaContentListItem>();
            Mapper.CreateMap<MediaContentListItem, MediaContentEntity>();

            Mapper.CreateMap<SprintEntity, SprintListItem>();
            Mapper.CreateMap<SprintListItem, SprintEntity>();

            Mapper.CreateMap<ProjectEntity, ProjectListItem>();
            Mapper.CreateMap<ProjectListItem, ProjectEntity>();

            Mapper.CreateMap<CommentEntity, CommentListItem>();
            Mapper.CreateMap<CommentListItem, CommentEntity>();
            Mapper.CreateMap<CommentEntity, CommentDto>();
            Mapper.CreateMap<CommentDto, CommentDto>();

            Mapper.CreateMap<IssueEntity, IssueListItem>();
            Mapper.CreateMap<IssueListItem, IssueEntity>();

            Mapper.CreateMap<IssueEntity, IssueDto>();
            Mapper.CreateMap<IssueDto, IssueEntity>();
        } 
    }
}