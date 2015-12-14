using System;
using Levshits.Data.Item;
using PMS.Common.Dto;

namespace PMS.Common.ListItem
{
    public class RoleListItem: BaseItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid RoleTypeId { get; set; }
        public RoleTypeDto RoleTypeIdObject { get; set; }

    }
}