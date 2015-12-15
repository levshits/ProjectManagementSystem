using FluentNHibernate.Mapping;
using PMS.Data.Enity;

namespace PMS.Data.EntityMap
{
    public class IssueEntityMap: ClassMap<IssueEntity>
    {
        public IssueEntityMap()
        {
            Table("Issue");

            Id(x => x.Id).GeneratedBy.Guid();
            Version(x => x.Version);

            Map(x => x.Name).Length(200);
            Map(x => x.Description).Length(1000).Nullable();
            Map(x => x.Type);
            Map(x => x.ProjectId);
            Map(x => x.Status);
            Map(x => x.Priority);
            Map(x => x.AssigneeId);
            Map(x => x.SprintId);
            Map(x => x.EstimatedTime).Nullable().CustomType("TimeAsTimeSpan"); ;
            Map(x => x.CreateTime);

            References(x => x.ProjectIdObject).Column(nameof(IssueEntity.ProjectId)).ReadOnly();
            References(x => x.AssigneeIdObject).Column(nameof(IssueEntity.AssigneeId)).ReadOnly();
            References(x => x.SprintIdObject).Column(nameof(IssueEntity.SprintId)).ReadOnly();

            HasMany(x => x.MediaContentEntities).Cascade.AllDeleteOrphan();
            HasMany(x => x.CommentEntities).Cascade.AllDeleteOrphan();
        }
    }
}