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
    public class SprintBlo: BloBase<SprintEntity>
    {
        public SprintBlo(Repository repository) : base(repository)
        {
        }
        public PmsRepository PmsRepository => (PmsRepository)Repository;

        public override void Init()
        {
            RegisterCommand<SprintLookupListRequest>(SprintLookupListRequestHandler);
            RegisterCommand<SprintListRequest>(SprintListRequestHandler);
            RegisterCommand<SaveSprintRequest>(SaveSprintRequestHandler);
            RegisterCommand<GetSprintEntityByIdRequest>(GetSprintEntityByIdRequestHandler);
        }

        private ExecutionResult GetSprintEntityByIdRequestHandler(GetSprintEntityByIdRequest request, ExecutionContext context)
        {
            if (request == null)
            {
                return null;
            }
            var entity = PmsRepository.SprintData.GetEntityById(request.EntityId);
            SprintDto dto = Mapper.Map<SprintDto>(entity);
            return new ExecutionResult<SprintDto> { TypedResult = dto };
        }

        private ExecutionResult SaveSprintRequestHandler(SaveSprintRequest request, ExecutionContext context)
        {
            if (request == null)
            {
                return null;
            }
            SprintEntity entity = new SprintEntity();
            if (request.Dto.Id != Guid.Empty)
            {
                entity = PmsRepository.SprintData.GetEntityById(request.Dto.Id);
            }
            Mapper.Map<SprintDto, SprintEntity>(request.Dto, entity);
            PmsRepository.SprintData.Save(entity);
            return new ExecutionResult();
        }

        private ExecutionResult SprintListRequestHandler(SprintListRequest request, ExecutionContext context)
        {
            if (request == null)
            {
                return null;
            }
            int itemsCount = 0;
            var list = PmsRepository.SprintData.GetList(request.Page, request.SearchString, out itemsCount);
            return new ExecutionResult<ListResultDto<SprintListItem>>
            {
                TypedResult = new ListResultDto<SprintListItem> { ItemsCount = itemsCount, Items = list }
            };
        }

        private ExecutionResult SprintLookupListRequestHandler(SprintLookupListRequest request, ExecutionContext context)
        {
            if (request == null)
            {
                return null;
            }
            return new ExecutionResult<List<LookupItem>> { TypedResult = PmsRepository.SprintData.GetLookupList() };
        }

        public override int Priority => PriorityLevels.SECOND_LEVEL;
    }
}