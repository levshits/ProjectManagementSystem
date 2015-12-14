using AutoMapper;
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

            Mapper.CreateMap<PrincipalEntity, PrincipalListItem>();
            Mapper.CreateMap<PrincipalListItem, PrincipalEntity>();

            Mapper.CreateMap<PrincipalExtendedEntity, PrincipalDto>();
            Mapper.CreateMap<PrincipalDto, PrincipalExtendedEntity>();

            Mapper.CreateMap<RoleEntity, RoleDto>();
            Mapper.CreateMap<RoleDto, RoleEntity>();

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

            Mapper.CreateMap<IssueEntity, IssueListItem>();
            Mapper.CreateMap<IssueListItem, IssueEntity>();
        } 
    }
}