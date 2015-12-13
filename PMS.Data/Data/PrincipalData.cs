using System.Linq;
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

        public PrincipalEntity GetUserByUsernameAndPassword(string username, string password)
        {
            PrincipalEntity principal = null;
            var query = DataProvider.Query<PrincipalEntity>();
            query.Where(x => x.Username == username && x.Password == password);
            return query.SingleOrDefault();
        }
    }
}