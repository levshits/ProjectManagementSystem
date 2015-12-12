using FluentNHibernate.Mapping;
using PMS.Data.Enity;

namespace PMS.Data.EntityMap
{
    public class MediaContentEntityMap : ClassMap<MediaContentEntity>
    {
        public MediaContentEntityMap()
        {
            Table("MediaContent");

            Id(x => x.Id).GeneratedBy.Guid();
            Version(x => x.Version);

            Map(x => x.Name);
            Map(x => x.Path);
            Map(x => x.IssueId);

            References(x => x.IssueIdObject).Column(nameof(MediaContentEntity.IssueId)).ReadOnly();
        }
    }
}