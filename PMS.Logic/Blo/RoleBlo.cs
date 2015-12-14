using System;
using System.Collections.Generic;
using System.Linq;
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
    public class RoleBlo: BloBase<RoleEntity>
    {
        public PmsRepository PmsRepository => (PmsRepository) Repository;

        public RoleBlo(Repository repository) : base(repository)
        {
        }

        public override void Init()
        {
            RegisterCommand<RoleSaveRequest>(SaveRequestHandler);
            RegisterCommand<RoleListRequest>(ListRequestHandler);
            RegisterCommand<RoleRemoveRequest>(RoleRemoveRequestHandler);
            RegisterCommand<GetRoleEntityRequest>(GetEntityByIdRequestHandler);
            RegisterCommand<RoleLookupListRequest>(RoleLookupListRequestHandler);
        }

        private ExecutionResult RoleLookupListRequestHandler(RoleLookupListRequest request, ExecutionContext context)
        {
            if (request == null)
            {
                return null;
            }
            return new ExecutionResult<List<LookupItem>> { TypedResult = PmsRepository.RoleData.GetLookupList() };
        }

        private ExecutionResult GetEntityByIdRequestHandler(GetRoleEntityRequest request, ExecutionContext context)
        {
            if (request == null)
            {
                return null;
            }
            var entity = PmsRepository.RoleData.GetEntityById(request.EntityId);
            RoleDto dto = Mapper.Map<RoleDto>(entity);
            return new ExecutionResult<RoleDto> {TypedResult = dto};
        }

        private ExecutionResult RoleRemoveRequestHandler(RoleRemoveRequest request, ExecutionContext context)
        {
            if (request == null)
            {
                return null;
            }
            PmsRepository.RoleData.Delete(request.RoleId);
            return new ExecutionResult();
        }

        private ExecutionResult ListRequestHandler(RoleListRequest request, ExecutionContext context)
        {
            if (request == null)
            {
                return null;
            }
            int itemsCount = 0;
            var list = PmsRepository.RoleData.GetList(request.Page, request.SearchString, out itemsCount);
            return new ExecutionResult<ListResultDto<RoleListItem>>
            {
                TypedResult = new ListResultDto<RoleListItem> {ItemsCount = itemsCount, Items = list}
            };
        }

        private ExecutionResult SaveRequestHandler(RoleSaveRequest request, ExecutionContext context)
        {
            if (request == null || request.Dto == null)
            {
                return null;
            }
            var dto = request.Dto;
            RoleEntity entity = null; 
            if (request.Dto.Id == Guid.Empty)
            {
                entity = Mapper.Map<RoleEntity>(request.Dto);
                entity.ActionEntities.Clear();
                var id = PmsRepository.RoleData.Save(entity);
                entity = PmsRepository.RoleData.GetEntityById(id);
            }
            entity = entity ?? PmsRepository.RoleData.GetEntityById(dto.Id);
            entity.Name = dto.Name;
            entity.Description = dto.Description;
            var availbleActions = entity.ActionEntities.Select(x => x.Id).ToList();
            foreach (var actionEntity in dto.ActionEntities)
            {
                if (!availbleActions.Contains(actionEntity.Id))
                {
                    entity.RoleActionEntities.Add(new RoleActionEntity() {ActionId = actionEntity.Id, RoleId = entity.Id});
                }
            }

            var removedRoles = entity.RoleActionEntities.Where(roleActionEntity => dto.ActionEntities.All(x => x.Id != roleActionEntity.RoleId)).ToList();
            foreach (var principalRoleEntity in removedRoles)
            {
                entity.RoleActionEntities.Remove(principalRoleEntity);
            }
            PmsRepository.RoleData.Save(entity);

            return new ExecutionResult();
        }

        public override int Priority => PriorityLevels.FIRST_LEVEL;
    }
}