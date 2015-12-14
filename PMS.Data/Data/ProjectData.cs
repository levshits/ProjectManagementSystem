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
    public class ProjectData : BaseData<ProjectEntity>
    {
        public ProjectData(DataProvider dataProvider) : base(dataProvider)
        {
        }
        public IList<ProjectListItem> GetList(int page, string searchString, out int itemsCount)
        {
            ProjectEntity entity = null;
            ProjectListItem listItem = null;
            var query = DataProvider.QueryOver(() => entity);

            var projections = Projections.ProjectionList();
            projections.Add(Projections.Property(() => entity.Id).WithAlias(() => listItem.Id));
            projections.Add(Projections.Property(() => entity.Name).WithAlias(() => listItem.Name));
            projections.Add(Projections.Property(() => entity.ShortName).WithAlias(() => listItem.ShortName));

            var pagingOptions = new PagingOptions { ItemsPerPage = 10, Page = page };

            AddPaging(query, pagingOptions);

            query.Select(projections);
            var result =
                query.TransformUsing(Transformers.AliasToBean<ProjectListItem>())
                    .List<ProjectListItem>();
            itemsCount = pagingOptions.ItemsCount;
            return result;
        }
        public List<LookupItem> GetLookupList()
        {
            ProjectEntity entity = null;
            LookupItem listItem = null;
            var query = DataProvider.QueryOver(() => entity);

            var projections = Projections.ProjectionList();
            projections.Add(Projections.Property(() => entity.Id).WithAlias(() => listItem.Id));
            projections.Add(Projections.Property(() => entity.ShortName).WithAlias(() => listItem.Value));

            query.Select(projections);
            var result =
                query.TransformUsing(Transformers.AliasToBean<LookupItem>())
                    .List<LookupItem>();
            return result.ToList();
        }
    }
}