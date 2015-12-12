using FluentNHibernate.Mapping;
using PMS.Data.Enity;

namespace PMS.Data.EntityMap
{
    public class ProjectEntityMap : ClassMap<ProjectEntity>
    {
        public ProjectEntityMap()
        {
            Table("Project");

            Id(x => x.Id).GeneratedBy.Guid();
            Version(x => x.Version);

            Map(x => x.Name);
            Map(x => x.ShortName);
            Map(x => x.Description);
            Map(x => x.CreateTime);
            Map(x => x.CreatorId);

            References(x => x.CreatorIdObject).Column(nameof(ProjectEntity.CreatorId)).ReadOnly();
            HasMany(x => x.IssueEntities).Cascade.AllDeleteOrphan();
        }
    }
}