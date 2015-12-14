using FluentNHibernate.Mapping;
using PMS.Data.Enity;

namespace PMS.Data.EntityMap
{
    public class ActionEntityMap : ClassMap<ActionEntity>
    {
        public ActionEntityMap()
        {
            Table("Action");

            Id(x => x.Id).GeneratedBy.Guid();

            Map(x => x.Name);
            Map(x => x.ObjectTypeId);

            References(x => x.ObjectTypeIdObject).Column(nameof(ActionEntity.ObjectTypeId)).ReadOnly();
            HasManyToMany(x => x.RoleEntities).Cascade.AllDeleteOrphan().Inverse().Table("RoleAction")
                .ParentKeyColumn(nameof(RoleActionEntity.ActionId))
                .ChildKeyColumn(nameof(RoleActionEntity.RoleId));
        }
    }
}