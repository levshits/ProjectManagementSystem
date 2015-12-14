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
    public class IssueBlo:BloBase<IssueEntity>
    {
        public PmsRepository PmsRepository => (PmsRepository)Repository;
        public IssueBlo(Repository repository) : base(repository)
        {
            
        }

        private ExecutionResult IssueListRequestHandler(IssueListRequest request, ExecutionContext context)
        {
            if (request == null)
            {
                return null;
            }
            int itemsCount = 0;
            var list = PmsRepository.IssueData.GetList(request.Page, request.SearchString, out itemsCount);
            return new ExecutionResult<ListResultDto<IssueListItem>>
            {
                TypedResult = new ListResultDto<IssueListItem> { ItemsCount = itemsCount, Items = list }
            };
        }

        public override void Init()
        {
            RegisterCommand<IssueListRequest>(IssueListRequestHandler);
            RegisterCommand<SaveIssueRequest>(SaveIssueRequestHandler);
        }

        private ExecutionResult SaveIssueRequestHandler(SaveIssueRequest request, ExecutionContext context)
        {
            throw new System.NotImplementedException();
        }

        public override int Priority => PriorityLevels.FIRST_LEVEL;
    }
}