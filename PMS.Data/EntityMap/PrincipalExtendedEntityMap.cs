using FluentNHibernate.Mapping;
using Levshits.Data.Entity;
using PMS.Data.Enity;

namespace PMS.Data.EntityMap
{
    public class PrincipalExtendedEntityMap: SubclassMap<PrincipalExtendedEntity>
    {
        public PrincipalExtendedEntityMap()
        {
            Table("PrincipalExtended");

            KeyColumn(nameof(BaseEntity.Id));

            Map(x => x.FirstName);
            Map(x => x.LastName);
        }
    }
}