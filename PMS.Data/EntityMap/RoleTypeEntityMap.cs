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
            Version(x => x.Version);

            Map(x => x.Name).Length(100);

            HasManyToMany(x => x.ActionEntities).Cascade.None().Inverse().Table("RoleTypeAction");
        }
    }
}