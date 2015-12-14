using Levshits.Data;
using Levshits.Data.Common;
using PMS.Data.Enity;

namespace PMS.Logic.Blo
{
    public class IssueBlo:BloBase<IssueEntity>
    {
        public IssueBlo(Repository repository) : base(repository)
        {
        }

        public override void Init()
        {
        }

        public override int Priority { get; }
    }
}