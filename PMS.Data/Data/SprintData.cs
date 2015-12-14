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
    public class SprintData : BaseData<SprintEntity>
    {
        public SprintData(DataProvider dataProvider) : base(dataProvider)
        {
        }
        public IList<SprintListItem> GetList(int page, string searchString, out int itemsCount)
        {
            SprintEntity entity = null;
            SprintListItem listItem = null;
            ProjectEntity projectAlias = null;
            var query = DataProvider.QueryOver(() => entity);
            query.JoinAlias(x => x.ProjectIdObject, () => projectAlias, JoinType.InnerJoin);

            var projections = Projections.ProjectionList();
            projections.Add(Projections.Property(() => entity.Id).WithAlias(() => listItem.Id));
            projections.Add(Projections.Property(() => entity.ProjectId).WithAlias(() => listItem.ProjectId));
            projections.Add(Projections.Property(() => entity.ProjectVersion).WithAlias(() => listItem.ProjectVersion));
            projections.Add(Projections.Property(() => entity.StartTime).WithAlias(() => listItem.StartTime));
            projections.Add(Projections.Property(() => entity.EndTime).WithAlias(() => listItem.EndTime));
            projections.Add(Projections.Property(() => projectAlias.ShortName).WithAlias(() => listItem.ProjectName));

            var pagingOptions = new PagingOptions { ItemsPerPage = 10, Page = page };

            AddPaging(query, pagingOptions);

            query.Select(projections);
            var result =
                query.TransformUsing(Transformers.AliasToBean<SprintListItem>())
                    .List<SprintListItem>();
            itemsCount = pagingOptions.ItemsCount;
            return result;
        }
    }
}