using Levshits.Data;
using Levshits.Data.Data;
using PMS.Data.Enity;

namespace PMS.Data.Data
{
    public class ProjectData : BaseData<ProjectEntity>
    {
        public ProjectData(DataProvider dataProvider) : base(dataProvider)
        {
        }
    }
}