using Levshits.Data;
using Levshits.Data.Data;
using PMS.Data.Enity;

namespace PMS.Data.Data
{
    public class PrincipalData: BaseData<PrincipalEntity>
    {
        public PrincipalData(DataProvider dataProvider) : base(dataProvider)
        {
        }
    }
}