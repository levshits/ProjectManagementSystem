using System;
using PMS.Common.Dto;

namespace PMS.Web.Models
{
    public class RoleListItemModel: ListItemModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid RoleTypeId { get; set; }
        public string RoleTypeName { get; set; }
    }
}