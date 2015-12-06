using Levshits.Data;
using Levshits.Data.Common;
using NHibernate;

namespace PMS.Data
{
    public class PmsDataProvider: DataProvider
    {
        public PmsDataProvider(ISessionStorage storage) : base(storage)
        {
        }

        public override ISessionFactory InitFactory()
        {
            throw new System.NotImplementedException();
        }
    }
}