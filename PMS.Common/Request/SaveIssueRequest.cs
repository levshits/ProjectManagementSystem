using PMS.Common.Dto;
using PMS.Common.Immutable;

namespace PMS.Common.Request
{
    public class SaveIssueRequest: SaveRequest<IssueDto>
    {
        public ActivityType ActivityType { get; set; }
    }
}