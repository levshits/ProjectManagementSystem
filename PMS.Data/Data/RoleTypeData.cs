using System;
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
    public class RoleTypeData : BaseData<RoleTypeEntity>
    {
        public RoleTypeData(DataProvider dataProvider) : base(dataProvider)
        {
        }

        public List<LookupItem> GetLookupList()
        {
            RoleTypeEntity entity = null;
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