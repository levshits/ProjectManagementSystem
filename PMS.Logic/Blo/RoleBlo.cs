using Levshits.Data;
using Levshits.Data.Common;
using PMS.Data.Enity;

namespace PMS.Logic.Blo
{
    public class RoleBlo: BloBase<RoleEntity>
    {
        public string SUPERUSER_TYPE { get; set; }
        public RoleBlo(Repository repository) : base(repository)
        {
        }

        public override void Init()
        {
            throw new System.NotImplementedException();
        }

        public override int Priority { get; }
    }
}