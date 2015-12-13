using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Common.Dto;

namespace PMS.Common.Immutable
{
    public class ObjectTypes
    {
        public static readonly Guid PRINCIPAL = new Guid("02B85078-AFDD-4CB7-B52A-7963B0B6FC84");
        public static readonly Guid PROJECT = new Guid("B175B017-1BCE-4FAE-9AD2-7C61FDE7D5A0");
        public static readonly Guid ROLE = new Guid("F5FDE65F-A4E2-4D54-8E7D-08A170E2746A");
        public static readonly Guid ISSUE = new Guid("F5FDE65F-A4E2-4D54-8E7D-08A170E2746A");
    }
}
