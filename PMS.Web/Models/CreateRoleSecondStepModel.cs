using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Levshits.Web.Common.Models;
using PMS.Common.ListItem;

namespace PMS.Web.Models
{
    public class CreateRoleSecondStepModel: CreateRoleFirstStepModel
    {
        public List<LookupItem> AvailableActions { get; set; }
        public List<LookupItem> SelectedActions { get; set; }
        public Guid[] SelectedActionIds { get; set; }

        public CreateRoleSecondStepModel()
        {
            AvailableActions = new List<LookupItem>();
            SelectedActions = new List<LookupItem>();
            SelectedActionIds = new Guid[0];
        }

    }
}