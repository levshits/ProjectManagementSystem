using System;

namespace PMS.Common.Immutable
{
    public class ObjectTypes
    {
        public const string Principal = "02B85078-AFDD-4CB7-B52A-7963B0B6FC84";
        public const string Project = "B175B017-1BCE-4FAE-9AD2-7C61FDE7D5A0";
        public const string Role = "F5FDE65F-A4E2-4D54-8E7D-08A170E2746A";
        public const string Issue = "0639E136-CC53-4BE3-8E92-D8940B829FFD";

        public static readonly Guid PRINCIPAL = new Guid(Principal);
        public static readonly Guid PROJECT = new Guid(Project);
        public static readonly Guid ROLE = new Guid(Role);
        public static readonly Guid ISSUE = new Guid(Issue);
        
    }
}
