using System;

namespace PMS.Common.Immutable
{
    public class Actions
    {
        public const string CreatePrincipal = "654D750A-3EBD-4DCB-B135-E8C385E13147";
        public const string ViewPrincipal = "7FCB7D6D-E9A5-4FA9-8A33-D801DDEFFEE0";
        public const string SavePrincipal = "C6DAC871-C60E-486A-895D-9141ADE25E7C";

        public const string CreateRole = "8CB90CDF-324F-4D5A-AE1E-3EB489B8C524";
        public const string SaveRole = "39DB2DBA-387C-4400-AC39-C136F8A481DF";
        public const string RemoveRole = "EC3A247C-4F56-401A-8101-0B8407DB9347";
        public const string ViewRole = "8B480214-F6BC-4646-8AEE-A8AC2FF938A5";

        public const string CreateProject = "F799004B-096F-4DC3-9D15-60699D23E918";
        public const string ViewProject = "A1691A4E-5AEF-4023-A8EB-95C103D2C925";
        public const string SaveProject = "182A68E0-9A54-4BD5-B03F-A1FDC44E5FE0";
        public const string CreateIssue = "333193E7-285D-4BB5-8703-8AE44428452A";
        public const string CloseIssue = "8243DA28-1CC4-4757-8715-9C8C5B165F77";
        public const string ResolveIssue = "740C964A-0D72-4872-B444-2DE0B14183DB";
        public const string ReopenIssue = "6FA8DD08-BDE9-4877-A249-98B225CE1C89";
        public const string CommentIssue = "C7E27578-F22F-4488-9F60-B50FDCAE64D8";
        public const string AttachContentToIssue = "CD452935-8F5A-42D5-9644-4FB4A3D79B6A";
        public const string CreateSprint = "87D78981-8561-4E7B-B941-AE65B85C6155";
        public const string ViewSprint = "DBE3CFBE-F5FA-40AC-A39F-964D4F7C4AB0";
        public const string SaveSprint = "CB2E31CC-0932-461F-85C3-BE94D9FD73CF";


        public static readonly Guid CREATE_PRINCIPAL = new Guid(CreatePrincipal);
        public static readonly Guid VIEW_PRINCIPAL = new Guid(ViewPrincipal);
        public static readonly Guid SAVE_PRINCIPAL = new Guid(SavePrincipal);

        public static readonly Guid CREATE_ROLE = new Guid(CreateRole);
        public static readonly Guid SAVE_ROLE = new Guid(SaveRole);
        public static readonly Guid REMOVE_ROLE = new Guid(RemoveRole);
        public static readonly Guid VIEW_ROLE = new Guid(ViewRole);

        public static readonly Guid CREATE_PROJECT = new Guid(CreateProject);
        public static readonly Guid VIEW_PROJECT = new Guid(ViewProject);
        public static readonly Guid SAVE_PROJECT = new Guid(SaveProject);

        public static readonly Guid CREATE_ISSUE = new Guid(CreateIssue);
        public static readonly Guid CLOSE_ISSUE = new Guid(CloseIssue);
        public static readonly Guid RESOLVE_ISSUE = new Guid(ResolveIssue);
        public static readonly Guid REOPEN_ISSUE = new Guid(ReopenIssue);
        public static readonly Guid COMMENT_ISSUE = new Guid(CommentIssue);
        public static readonly Guid ATTACH_CONTENT_TO_ISSUE = new Guid(AttachContentToIssue);

        public static readonly Guid CREATE_SPRINT = new Guid(CreateSprint);
        public static readonly Guid VIEW_SPRINT = new Guid(ViewSprint);
        public static readonly Guid SAVE_SPRINT = new Guid(SaveSprint);
    }
}
