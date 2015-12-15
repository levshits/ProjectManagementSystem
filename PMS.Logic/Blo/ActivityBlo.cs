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
    public class ActivityBlo: BloBase<ActivityEntity>
    {
        public PmsRepository PmsRepository => (PmsRepository)Repository;
        public ActivityBlo(Repository repository) : base(repository)
        {
        }

        public override void Init()
        {
            RegisterCommand<ActivityListRequest>(ActivityListRequestHandler);
        }

        private ExecutionResult ActivityListRequestHandler(ActivityListRequest request, ExecutionContext context)
        {
            if (request == null)
            {
                return null;
            }
            int itemsCount = 0;
            var list = PmsRepository.ActivityData.GetList(request.Page, request.SearchString, out itemsCount);
            return new ExecutionResult<ListResultDto<ActivityListItem>>
            {
                TypedResult = new ListResultDto<ActivityListItem> { ItemsCount = itemsCount, Items = list }
            };
        }

        public override int Priority => PriorityLevels.FIRST_LEVEL;
    }
}