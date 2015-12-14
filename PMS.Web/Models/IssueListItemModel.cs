namespace PMS.Web.Models
{
    public class IssueListItemModel: ListItemModel
    {
        public string Name { get; set; }
        public IssueTypeEnumModel Type { get; set; }
        public IssueStatusEnumModel Status { get; set; }
        public IssuePriorityEnumModel Priority { get; set; }
        public string AssigneeName { get; set; }
        public string ProjectName { get; set; }
    }
}