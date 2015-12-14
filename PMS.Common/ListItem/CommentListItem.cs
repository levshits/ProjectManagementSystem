using System;
using Levshits.Data.Item;
using PMS.Common.Dto;

namespace PMS.Common.ListItem
{
    public class CommentListItem: BaseItem
    {
        public string Text { get; set; }
        public DateTime CreateTime { get; set; }
        public Guid CreatorId { get; set; }
        public PrincipalDto CreatorIdObject { get; set; }
    }
}