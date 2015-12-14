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
    public class ProjectBlo: BloBase<ProjectEntity>
    {
        public ProjectBlo(Repository repository) : base(repository)
        {
        }
        public PmsRepository PmsRepository => (PmsRepository)Repository;

        public override void Init()
        {
            RegisterCommand<ProjectLookupListRequest>(ProjectLookupListRequestHandler);
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