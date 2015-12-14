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
    public class ActionBlo: BloBase<ActionEntity>
    {
        public ActionBlo(Repository repository) : base(repository)
        {
        }

        public override void Init()
        {
            RegisterCommand<ActionsLookupListRequest>(ActionsLookupListRequestHandler);
        }

        private ExecutionResult ActionsLookupListRequestHandler(ActionsLookupListRequest request, ExecutionContext context)
        {
            if (request == null)
            {
                return null;
            }
            return new ExecutionResult<List<LookupItem>> { TypedResult = PmsRepository.ActionData.GetLookupList(request.RoleTypeId) };
        }

        public PmsRepository PmsRepository => (PmsRepository)Repository;
        public override int Priority => PriorityLevels.SECOND_LEVEL;
    }
}