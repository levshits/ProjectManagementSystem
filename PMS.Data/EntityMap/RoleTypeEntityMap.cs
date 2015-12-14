using FluentNHibernate.Mapping;
using PMS.Data.Enity;

namespace PMS.Data.EntityMap
{
    public class RoleTypeEntityMap: ClassMap<RoleTypeEntity>
    {
        public RoleTypeEntityMap()
        {
            Table("RoleType");

            Id(x => x.Id).GeneratedBy.Guid();

            Map(x => x.Name).Length(100);

            HasManyToMany(x => x.ActionEntities).Cascade.All().Table("RoleTypeAction")
                .ParentKeyColumn(nameof(RoleTypeActionEntity.RoleTypeId))
                .ChildKeyColumn(nameof(RoleTypeActionEntity.ActionId));
        }
    }
}