using FluentNHibernate.Mapping;
using PMS.Data.Enity;

namespace PMS.Data.EntityMap
{
    public class ObjectTypeEntityMap: ClassMap<ObjectTypeEntity>
    {
        public ObjectTypeEntityMap()
        {
            Table("ObjectType");

            Id(x => x.Id).GeneratedBy.Guid();
            Version(x => x.Version);

            Map(x => x.Name);
        }
    }
}