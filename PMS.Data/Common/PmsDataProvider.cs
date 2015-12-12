using FluentNHibernate.Cfg;
using Levshits.Data;
using Levshits.Data.Common;
using NHibernate;
using NHibernate.Cfg;

namespace PMS.Data.Common
{
    public class PmsDataProvider: DataProvider
    {
        public PmsDataProvider(ISessionStorage storage) : base(storage)
        {
        }
        public override ISessionFactory InitFactory()
        {
            var cfg = new Configuration();
            cfg.Configure();
            var factory = Fluently.Configure(cfg)
                .Mappings(
                  m => m.FluentMappings.AddFromAssemblyOf<PmsDataProvider>())
                .BuildSessionFactory();
            return factory;
        }
    }
}