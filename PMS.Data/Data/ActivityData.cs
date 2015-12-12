using Levshits.Data;
using Levshits.Data.Data;
using PMS.Data.Enity;

namespace PMS.Data.Data
{
    public class ActivityData: BaseData<ActivityEntity>
    {
        public ActivityData(DataProvider dataProvider) : base(dataProvider)
        {
        }
    }
}