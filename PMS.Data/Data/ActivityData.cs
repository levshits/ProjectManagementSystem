using System.Collections.Generic;
using Levshits.Data;
using Levshits.Data.Common;
using Levshits.Data.Data;
using NHibernate.Criterion;
using NHibernate.SqlCommand;
using NHibernate.Transform;
using PMS.Common.ListItem;
using PMS.Data.Enity;

namespace PMS.Data.Data
{
    public class ActivityData: BaseData<ActivityEntity>
    {
        public ActivityData(DataProvider dataProvider) : base(dataProvider)
        {
        }
        public IList<ActivityListItem> GetList(int page, string searchString, out int itemsCount)
        {
            ActivityEntity entity = null;
            ActivityListItem listItem = null;
            PrincipalEntity creatorAlias = null;
            IssueEntity issueAlias = null;
            var query = DataProvider.QueryOver(() => entity);
            var creatorQuery = query.JoinAlias(x => x.CreatorIdObject, () => creatorAlias, JoinType.InnerJoin);
            var issueQuery = query.JoinAlias(x => x.IssueIdObject, () => issueAlias, JoinType.InnerJoin);

            var projections = Projections.ProjectionList();
            projections.Add(Projections.Property(() => entity.Id).WithAlias(() => listItem.Id));
            projections.Add(Projections.Property(() => entity.CreateTime).WithAlias(() => listItem.CreateTime));
            projections.Add(Projections.Property(() => entity.ActivityType).WithAlias(() => listItem.ActivityType));
            projections.Add(Projections.Property(() => entity.CreatorId).WithAlias(() => listItem.CreatorId));
            projections.Add(Projections.Property(() => entity.IssueId).WithAlias(() => listItem.IssueId));
            projections.Add(Projections.Property(() => creatorAlias.Username).WithAlias(() => listItem.CreatorName));
            projections.Add(Projections.Property(() => issueAlias.Name).WithAlias(() => listItem.IssueName));

            var pagingOptions = new PagingOptions { ItemsPerPage = 10, Page = page };

            AddPaging(query, pagingOptions);
            query.OrderBy(x => x.CreateTime);

            query.Select(projections);
            var result =
                query.TransformUsing(Transformers.AliasToBean<ActivityListItem>())
                    .List<ActivityListItem>();
            itemsCount = pagingOptions.ItemsCount;
            return result;
        }
    }
}