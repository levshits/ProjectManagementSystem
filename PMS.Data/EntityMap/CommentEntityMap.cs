using FluentNHibernate.Mapping;
using PMS.Data.Enity;

namespace PMS.Data.EntityMap
{
    public class CommentEntityMap: ClassMap<CommentEntity>
    {
        public CommentEntityMap()
        {
            Table("Comment");

            Id(x => x.Id).GeneratedBy.Guid();
            Version(x => x.Version);

            Map(x => x.Text);
            Map(x => x.CreatorId);
            Map(x => x.IssueId);
            Map(x => x.CreateTime);

            References(x => x.CreatorIdObject).Column(nameof(CommentEntity.CreatorId)).ReadOnly();
            References(x => x.IssueIdObject).Column(nameof(CommentEntity.IssueId)).ReadOnly();
        }
    }
}