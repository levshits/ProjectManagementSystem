using FluentNHibernate.Mapping;
using PMS.Data.Enity;

namespace PMS.Data.EntityMap
{
    public class ActivityEntityMap: ClassMap<ActivityEntity>
    {
        public ActivityEntityMap()
        {
            Table("Activity");

            Id(x => x.Id).GeneratedBy.Guid();

            Map(x => x.ActivityType);
            Map(x => x.CreateTime);
            Map(x => x.CreatorId);
            Map(x => x.IssueId);
            Map(x => x.OldValue).Nullable();
            Map(x => x.NewValue).Nullable();

            References(x => x.CreatorIdObject).Column(nameof(ActivityEntity.CreatorId)).ReadOnly();
            References(x => x.IssueIdObject).Column(nameof(ActivityEntity.IssueId)).ReadOnly();
        }
    }
}