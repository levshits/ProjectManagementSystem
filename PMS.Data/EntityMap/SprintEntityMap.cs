using FluentNHibernate.Mapping;
using PMS.Data.Enity;

namespace PMS.Data.EntityMap
{
    public class SprintEntityMap: ClassMap<SprintEntity>
    {
        public SprintEntityMap()
        {
            Table("Sprint");

            Id(x => x.Id).GeneratedBy.Guid();
            Version(x => x.Version);

            Map(x => x.ProjectId);
            Map(x => x.StartTime);
            Map(x => x.EndTime).Nullable();
            Map(x => x.ProjectVersion).Length(50);

            References(x => x.ProjectIdObject).Column(nameof(SprintEntity.ProjectId)).ReadOnly();
        }
    }
}