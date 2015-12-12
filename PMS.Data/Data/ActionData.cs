using Levshits.Data;
using Levshits.Data.Data;
using PMS.Data.Enity;

namespace PMS.Data.Data
{
    public class ActionData: BaseData<ActionEntity>
    {
        public ActionData(DataProvider dataProvider) : base(dataProvider)
        {
        }
    }
}