using System;
using Levshits.Data.Dto;

namespace PMS.Common.Dto
{
    [Serializable]
    public class IssueHistoryItemDto: IssueDto
    {
        public DateTime UpdateTime { get; set; }
    }
}