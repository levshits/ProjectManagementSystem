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
    public class RoleBlo: BloBase<RoleEntity>
    {
        public PmsRepository PmsRepository => (PmsRepository) Repository;

        public RoleBlo(Repository repository) : base(repository)
        {
        }

        public override void Init()
        {
            RegisterCommand<SaveRequest<RoleDto>>(SaveRequestHandler);
            RegisterCommand<ListRequest<RoleListItem>>(ListRequestHandler);
        }

        private ExecutionResult ListRequestHandler(ListRequest<RoleListItem> request, ExecutionContext context)
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

        private ExecutionResult SaveRequestHandler(SaveRequest<RoleDto> request, ExecutionContext context)
        {
            if (request == null || request.Dto == null)
            {
                return null;
            }
            var entity = Mapper.Map<RoleEntity>(request.Dto);

            PmsRepository.RoleData.Save(entity);

            return new ExecutionResult();
        }

        public override int Priority => PriorityLevels.FIRST_LEVEL;
    }
}