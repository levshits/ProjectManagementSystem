using FluentNHibernate.Mapping;
using PMS.Data.Enity;

namespace PMS.Data.EntityMap
{
    public class PrincipalRoleEntityMap : ClassMap<PrincipalRoleEntity>
    {
        public PrincipalRoleEntityMap()
        {
            Table("PrincipalRole");

            Id(x => x.Id).GeneratedBy.Guid();
            Version(x => x.Version);

            Map(x => x.PrincipalId);
            Map(x => x.RoleId);
            Map(x => x.CreateTime);

            References(x => x.RoleIdObject).Column(nameof(PrincipalRoleEntity.RoleId)).ReadOnly();
            References(x => x.PrincipalIdObject).Column(nameof(PrincipalRoleEntity.PrincipalId)).ReadOnly();
        }
    }
}