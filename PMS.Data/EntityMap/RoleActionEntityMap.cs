using FluentNHibernate.Mapping;
using PMS.Data.Enity;

namespace PMS.Data.EntityMap
{
    public class RoleActionEntityMap: ClassMap<RoleActionEntity>
    {
        public RoleActionEntityMap()
        {
            Table("RoleAction");

            Id(x => x.Id).GeneratedBy.Guid();
            Version(x => x.Version);

            Map(x => x.RoleId);
            Map(x => x.ActionId);

            References(x => x.ActionIdObject).Column(nameof(RoleActionEntity.ActionId)).ReadOnly();
            References(x => x.RoleIdObject).Column(nameof(RoleActionEntity.RoleId)).ReadOnly();
        }
    }
}