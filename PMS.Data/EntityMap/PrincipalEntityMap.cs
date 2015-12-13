using FluentNHibernate.Mapping;
using PMS.Data.Enity;

namespace PMS.Data.EntityMap
{
    public class PrincipalEntityMap: ClassMap<PrincipalEntity>
    {
        public PrincipalEntityMap()
        {
            Table("Principal");

            Id(x => x.Id).GeneratedBy.Guid();
            Version(x => x.Version);

            Map(x => x.Username);
            Map(x => x.Email);
            Map(x => x.Password);
            Map(x => x.CreateTime);

            HasManyToMany(x => x.RoleEntities).Cascade.AllDeleteOrphan().Table("PrincipalRole")
                .ParentKeyColumn(nameof(PrincipalRoleEntity.PrincipalId))
                .ChildKeyColumn(nameof(PrincipalRoleEntity.RoleId));
            HasManyToMany(x => x.ProjectEntities).Cascade.All().Table("PrincipalProject")
                .ParentKeyColumn(nameof(PrincipalProjectEntity.PrincipalId))
                .ChildKeyColumn(nameof(PrincipalProjectEntity.ProjectId));
            HasMany(x => x.IssueEntities).Cascade.None().Inverse();
        }
    }
}