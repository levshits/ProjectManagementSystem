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
    public class IssueData: BaseData<IssueEntity>
    {
        public IssueData(DataProvider dataProvider) : base(dataProvider)
        {
        }
        public IList<IssueListItem> GetList(int page, string searchString, out int itemsCount)
        {
            IssueEntity entity = null;
            IssueListItem listItem = null;
            PrincipalEntity assigneeAlias = null;
            ProjectEntity projectAlias = null;
            var query = DataProvider.QueryOver(() => entity);
            var creatorQuery = query.JoinAlias(x => x.AssigneeIdObject, () => assigneeAlias, JoinType.InnerJoin);
            var projectQuery = query.JoinAlias(x => x.ProjectIdObject, () => projectAlias, JoinType.InnerJoin);

            var projections = Projections.ProjectionList();
            projections.Add(Projections.Property(() => entity.Id).WithAlias(() => listItem.Id));
            projections.Add(Projections.Property(() => entity.CreateTime).WithAlias(() => listItem.CreateTime));
            projections.Add(Projections.Property(() => entity.Name).WithAlias(() => listItem.Name));
            projections.Add(Projections.Property(() => entity.AssigneeId).WithAlias(() => listItem.AssigneeId));
            projections.Add(Projections.Property(() => entity.ProjectId).WithAlias(() => listItem.ProjectId));
            projections.Add(Projections.Property(() => entity.Priority).WithAlias(() => listItem.Priority));
            projections.Add(Projections.Property(() => assigneeAlias.Username).WithAlias(() => listItem.AssigneeName));
            projections.Add(Projections.Property(() => projectAlias.ShortName).WithAlias(() => listItem.ProjectName));

            var pagingOptions = new PagingOptions { ItemsPerPage = 10, Page = page };

            AddPaging(query, pagingOptions);
            query.OrderBy(x => x.CreateTime);

            query.Select(projections);
            var result =
                query.TransformUsing(Transformers.AliasToBean<IssueListItem>())
                    .List<IssueListItem>();
            itemsCount = pagingOptions.ItemsCount;
            return result;
        }
    }
}