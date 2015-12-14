using System;
using System.Collections.Generic;
using System.Linq;
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
    public class RoleData : BaseData<RoleEntity>
    {
        public RoleData(DataProvider dataProvider) : base(dataProvider)
        {
        }

        public IList<RoleListItem> GetList(int page, string searchString, out int itemsCount)
        {
            RoleEntity entity = null;
            RoleTypeEntity roleTypeEntity = null;
            RoleListItem listItem = null;
            var query = DataProvider.QueryOver(() => entity);
            var roleTypeQuery = query.JoinQueryOver(x => x.RoleTypeIdObject, () => roleTypeEntity, JoinType.InnerJoin);

            var projections = Projections.ProjectionList();
            projections.Add(Projections.Property(() => entity.Id).WithAlias(() => listItem.Id));
            projections.Add(Projections.Property(() => entity.Name).WithAlias(() => listItem.Name));
            projections.Add(Projections.Property(() => entity.RoleTypeId).WithAlias(() => listItem.RoleTypeId));
            projections.Add(Projections.Property(() => roleTypeEntity.Name).WithAlias(() => listItem.RoleTypeName));

            var pagingOptions = new PagingOptions {ItemsPerPage = 10, Page = page};

            AddPaging(query, pagingOptions);

            query.Select(projections);
            var result =
                query.TransformUsing(Transformers.AliasToBean<RoleListItem>())
                    .List<RoleListItem>();
            itemsCount = pagingOptions.ItemsCount;
            return result;
        }

        public List<LookupItem> GetLookupList()
        {
            RoleEntity entity = null;
            LookupItem listItem = null;
            var query = DataProvider.QueryOver(() => entity);

            var projections = Projections.ProjectionList();
            projections.Add(Projections.Property(() => entity.Id).WithAlias(() => listItem.Id));
            projections.Add(Projections.Property(() => entity.Name).WithAlias(() => listItem.Value));

            query.Select(projections);
            var result =
                query.TransformUsing(Transformers.AliasToBean<LookupItem>())
                    .List<LookupItem>();
            return result.ToList();
        }
    }
}