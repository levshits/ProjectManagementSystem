using System;
using System.Collections.Generic;
using Levshits.Web.Common.Models;
using PMS.Common.Dto;

namespace PMS.Web.Models
{
    public class RoleDetailsModel: CreateRoleSecondStepModel
    {
        public virtual RoleTypeDto RoleTypeIdObject { get; set; }
        public DateTime CreateTime { get; set; }
        public IList<ActionDto> ActionEntities { get; set; }
    }
}