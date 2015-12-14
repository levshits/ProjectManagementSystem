using Levshits.Data.Common;
using PMS.Data.Data;

namespace PMS.Data.Common
{
    public class PmsRepository: Repository
    {
        public ActionData ActionData { get; set; }
        public ActivityData ActivityData { get; set; }
        public CommentData CommentData { get; set; }
        public IssueData IssueData { get; set; }
        public LocalisationData LocalisationData { get; set; }
        public MediaContentData MediaContentData { get; set; }
        public PrincipalData PrincipalData { get; set; }
        public ProjectData ProjectData { get; set; }
        public RoleData RoleData { get; set; }
        public SprintData SprintData { get; set; }
        public RoleTypeData RoleTypeData { get; set; }
    }
}