using Levshits.Data;
using Levshits.Data.Common;
using PMS.Data.Enity;

namespace PMS.Logic.Blo
{
    public class MediaContentBlo: BloBase<MediaContentEntity>
    {
        public MediaContentBlo(Repository repository) : base(repository)
        {
        }

        public override void Init()
        {
            throw new System.NotImplementedException();
        }

        public override int Priority { get; }
    }
}