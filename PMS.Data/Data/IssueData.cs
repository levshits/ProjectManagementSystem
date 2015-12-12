using Levshits.Data;
using Levshits.Data.Data;
using PMS.Data.Enity;

namespace PMS.Data.Data
{
    public class IssueData: BaseData<IssueEntity>
    {
        public IssueData(DataProvider dataProvider) : base(dataProvider)
        {
        }
    }
}