using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Levshits.Web.Common.Models;
using PMS.Common.ListItem;
using PMS.Web.Attributes;

namespace PMS.Web.Models
{
    public class IssueDetailsModel: ModelBase
    {
        [Localised]
        public string Name { get; set; }
        [Localised]
        public string Description { get; set; }
        [Localised]
        public IssueTypeEnumModel Type { get; set; }
        [Localised]
        public string ProjectName { get; set; }
        [Localised]
        public IssueStatusEnumModel Status { get; set; }
        [Localised]
        public IssuePriorityEnumModel Priority { get; set; }
        [Localised]
        public String Assignee { get; set; }
        [Localised]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan EstimatedTime { get; set; }

        public List<CommentModel> Comments { get; set; } 
        public CreateCommentModel CreateCommentModel { get; set; }

        public IssueDetailsModel()
        {
            Comments = new List<CommentModel>();
        }
    }
}