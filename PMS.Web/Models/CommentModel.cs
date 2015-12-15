using System;
using PMS.Data.Enity;

namespace PMS.Web.Models
{
    public class CommentModel
    {
        public string Text { get; set; }
        public DateTime CreateTime { get; set; }
        public string Creator { get; set; }
    }
}