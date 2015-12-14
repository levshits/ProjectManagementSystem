using Levshits.Data;
using Levshits.Data.Common;
using PMS.Common.Immutable;
using PMS.Data.Enity;

namespace PMS.Logic.Blo
{
    public class ActivityBlo: BloBase<ActivityEntity>
    {
        public ActivityBlo(Repository repository) : base(repository)
        {
        }

        public override void Init()
        {
        }

        public override int Priority => PriorityLevels.FIRST_LEVEL;
    }
}