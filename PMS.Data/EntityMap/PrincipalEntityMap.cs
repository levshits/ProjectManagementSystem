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

            HasManyToMany(x => x.RoleEntities).Cascade.None().Inverse().Table("PrincipalRole");
            HasManyToMany(x => x.ProjectEntities).Cascade.None().Inverse().Table("PrincipalProject");
            HasMany(x => x.IssueEntities).Cascade.None().Inverse();
        }
    }
}