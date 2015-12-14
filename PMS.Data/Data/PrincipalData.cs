using System.Collections.Generic;
using System.Linq;
using Levshits.Data;
using Levshits.Data.Common;
using Levshits.Data.Data;
using NHibernate.Criterion;
using NHibernate.Transform;
using PMS.Common.ListItem;
using PMS.Data.Enity;

namespace PMS.Data.Data
{
    public class PrincipalData: BaseData<PrincipalEntity>
    {
        public PrincipalData(DataProvider dataProvider) : base(dataProvider)
        {
        }

        public IList<PrincipalListItem> GetList(int page, string searchString, out int itemsCount)
        {
            PrincipalExtendedEntity entity = null;
            PrincipalListItem listItem = null;
            var query = DataProvider.QueryOver(() => entity);

            var projections = Projections.ProjectionList();
            projections.Add(Projections.Property(() => entity.Id).WithAlias(() => listItem.Id));
            projections.Add(Projections.Property(() => entity.FirstName).WithAlias(() => listItem.FirstName));
            projections.Add(Projections.Property(() => entity.LastName).WithAlias(() => listItem.LastName));
            projections.Add(Projections.Property(() => entity.Username).WithAlias(() => listItem.Username));
            projections.Add(Projections.Property(() => entity.Email).WithAlias(() => listItem.Email));

            var pagingOptions = new PagingOptions { ItemsPerPage = 10, Page = page };

            AddPaging(query, pagingOptions);

            query.Select(projections);
            var result =
                query.TransformUsing(Transformers.AliasToBean<PrincipalListItem>())
                    .List<PrincipalListItem>();
            itemsCount = pagingOptions.ItemsCount;
            return result;
        }

        public PrincipalEntity GetUserByUsernameAndPassword(string username, string password)
        {
            PrincipalEntity principal = null;
            var query = DataProvider.QueryOver(() => principal);
            query.Where(x => x.Username == username && x.Password == password);
            return query.SingleOrDefault();
        }
    }
}