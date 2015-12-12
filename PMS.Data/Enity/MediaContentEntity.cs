using System;
using Levshits.Data.Entity;

namespace PMS.Data.Enity
{
    public class MediaContentEntity: BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual string Path { get; set; }
        public virtual Guid IssueId { get; set; }
        public virtual IssueEntity IssueIdObject { get; set; }
    }
}