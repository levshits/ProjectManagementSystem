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
            Version(x => x.Version);

            Map(x => x.Name);
            Map(x => x.ObjectTypeId);

            References(x => x.ObjectTypeIdObject).Column(nameof(ActionEntity.ObjectTypeId)).ReadOnly();
        }
    }
}