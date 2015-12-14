using System.Collections.Generic;
using Levshits.Data;
using Levshits.Data.Common;
using PMS.Common.Immutable;
using PMS.Common.ListItem;
using PMS.Common.Request;
using PMS.Data.Common;
using PMS.Data.Enity;

namespace PMS.Logic.Blo
{
    public class RoleTypeBlo: BloBase<RoleTypeEntity>
    {
        public RoleTypeBlo(Repository repository) : base(repository)
        {
        }

        public override void Init()
        {
            RegisterCommand<RoleTypeLookupListRequest>(RoleTypeLookupListRequestHandler);
        }

        private ExecutionResult RoleTypeLookupListRequestHandler(RoleTypeLookupListRequest request, ExecutionContext context)
        {
            if (request == null)
            {
                return null;
            }
            return new ExecutionResult<List<LookupItem>> {TypedResult = PmsRepository.RoleTypeData.GetLookupList()};
        }

        public PmsRepository PmsRepository => (PmsRepository) Repository;
        public override int Priority => PriorityLevels.SECOND_LEVEL;
    }
}