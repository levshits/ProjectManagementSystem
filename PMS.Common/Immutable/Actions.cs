using System;

namespace PMS.Common.Immutable
{
    public class Actions
    {
        public static readonly Guid CREATE_PRINCIPAL = new Guid("654D750A-3EBD-4DCB-B135-E8C385E13147");
        public static readonly Guid SAVE_PRINCIPAL = new Guid("C6DAC871-C60E-486A-895D-9141ADE25E7C");

        public static readonly Guid CREATE_ROLE = new Guid("8CB90CDF-324F-4D5A-AE1E-3EB489B8C524");
        public static readonly Guid SAVE_ROLE = new Guid("39DB2DBA-387C-4400-AC39-C136F8A481DF");
        public static readonly Guid REMOVE_ROLE = new Guid("EC3A247C-4F56-401A-8101-0B8407DB9347");

        public static readonly Guid CREATE_PROJECT = new Guid("F799004B-096F-4DC3-9D15-60699D23E918");
        public static readonly Guid SAVE_PROJECT = new Guid("182A68E0-9A54-4BD5-B03F-A1FDC44E5FE0");

        public static readonly Guid CREATE_ISSUE = new Guid("333193E7-285D-4BB5-8703-8AE44428452A");
        public static readonly Guid CLOSE_ISSUE = new Guid("8243DA28-1CC4-4757-8715-9C8C5B165F77");
        public static readonly Guid RESOLVE_ISSUE = new Guid("740C964A-0D72-4872-B444-2DE0B14183DB");
        public static readonly Guid REOPEN_ISSUE = new Guid("6FA8DD08-BDE9-4877-A249-98B225CE1C89");
        public static readonly Guid COMMENT_ISSUE = new Guid("C7E27578-F22F-4488-9F60-B50FDCAE64D8");
        public static readonly Guid ATTACH_CONNTENT_TO_ISSUE = new Guid("CD452935-8F5A-42D5-9644-4FB4A3D79B6A");

        public static readonly Guid CREATE_SPRINT = new Guid("CD452935-8F5A-42D5-9644-4FB4A3D79B6A");
        public static readonly Guid SAVE_SPRINT = new Guid("CD452935-8F5A-42D5-9644-4FB4A3D79B6A");
    }
}
