using System;
using System.Collections.Generic;
using AutoMapper;
using Levshits.Data;
using Levshits.Data.Common;
using PMS.Common.Dto;
using PMS.Common.Immutable;
using PMS.Common.ListItem;
using PMS.Common.Request;
using PMS.Data.Common;
using PMS.Data.Enity;

namespace PMS.Logic.Blo
{
    public class ProjectBlo: BloBase<ProjectEntity>
    {
        public ProjectBlo(Repository repository) : base(repository)
        {
        }
        public PmsRepository PmsRepository => (PmsRepository)Repository;

        public override void Init()
        {
            RegisterCommand<ProjectLookupListRequest>(ProjectLookupListRequestHandler);
            RegisterCommand<ProjectListRequest>(ProjectListRequestHandler);
            RegisterCommand<ProjectSaveRequest>(ProjectSaveRequestHandler);
            RegisterCommand<GetProjectEntitybyIdRequest>(GetProjectEntitybyIdRequestHandler);
        }

        private ExecutionResult GetProjectEntitybyIdRequestHandler(GetProjectEntitybyIdRequest request, ExecutionContext context)
        {
            if (request == null)
            {
                return null;
            }
            var entity = PmsRepository.ProjectData.GetEntityById(request.EntityId);
            ProjectDto dto = Mapper.Map<ProjectDto>(entity);
            return new ExecutionResult<ProjectDto> { TypedResult = dto };
        }

        private ExecutionResult ProjectSaveRequestHandler(ProjectSaveRequest request, ExecutionContext context)
        {
            if (request == null)
            {
                return null;
            }
            ProjectEntity entity = new ProjectEntity();
            if (request.Dto.Id != Guid.Empty)
            {
                entity = PmsRepository.ProjectData.GetEntityById(request.Dto.Id);
            }
            Mapper.Map<ProjectDto, ProjectEntity>(request.Dto, entity);
            PmsRepository.ProjectData.Save(entity);
            return new ExecutionResult();
        }

        private ExecutionResult ProjectListRequestHandler(ProjectListRequest request, ExecutionContext context)
        {
            if (request == null)
            {
                return null;
            }
            int itemsCount = 0;
            var list = PmsRepository.ProjectData.GetList(request.Page, request.SearchString, out itemsCount);
            return new ExecutionResult<ListResultDto<ProjectListItem>>
            {
                TypedResult = new ListResultDto<ProjectListItem> { ItemsCount = itemsCount, Items = list }
            };
        }

        private ExecutionResult ProjectLookupListRequestHandler(ProjectLookupListRequest request, ExecutionContext context)
        {
            if (request == null)
            {
                return null;
            }
            return new ExecutionResult<List<LookupItem>> { TypedResult = PmsRepository.ProjectData.GetLookupList() };
        }

        public override int Priority => PriorityLevels.SECOND_LEVEL;
    }
}