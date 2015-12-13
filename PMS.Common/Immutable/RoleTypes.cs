using System;

namespace PMS.Common.Immutable
{
    public class RoleTypes
    {
        public const string Tester = "EBEC1686-3D77-4AA6-82FE-27349BAA78B9";
        public const string BusinessAnalyses = "CCEF8163-C270-4BCA-90AF-8D483E6B4B42";
        public const string Manager = "01C15163-AA26-41A6-A275-68514C4DE518";
        public const string Developer = "3A7F9180-7FA6-497B-A158-102B92D10411";
        public const string Administrator = "68063E7D-75D3-4168-BE87-F067502F532B";

        public static readonly Guid TESTER = new Guid(Tester);
        public static readonly Guid BUSINESS_ANALYSES = new Guid(BusinessAnalyses);
        public static readonly Guid MANAGER = new Guid(Manager);
        public static readonly Guid DEVELOPER = new Guid(Developer);
        public static readonly Guid ADMINITRATOR = new Guid(Administrator);

        public const string SuperuserRole = "1E341E5C-B54C-4921-931B-0A05AD990ABC";
        public static readonly Guid SUPERUSER_ROLE = new Guid("1E341E5C-B54C-4921-931B-0A05AD990ABC");
    }
}