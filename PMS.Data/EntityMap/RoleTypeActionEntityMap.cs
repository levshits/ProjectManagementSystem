using FluentNHibernate.Mapping;
using PMS.Data.Enity;

namespace PMS.Data.EntityMap
{
    public class RoleTypeActionEntityMap: ClassMap<RoleTypeActionEntity>
    {
        public RoleTypeActionEntityMap()
        {
            Table("RoleTypeAction");

            Id(x => x.Id).GeneratedBy.Guid();

            Map(x => x.RoleTypeId);
            Map(x => x.ActionId);

            References(x => x.ActionIdObject).Column(nameof(RoleTypeActionEntity.ActionId)).ReadOnly();
            References(x => x.RoleTypeIdObject).Column(nameof(RoleTypeActionEntity.RoleTypeId)).ReadOnly();
        }
    }
}