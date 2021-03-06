﻿using System;
using System.Collections.Generic;
using System.Linq;
using Levshits.Data;
using Levshits.Data.Data;
using NHibernate.Criterion;
using NHibernate.SqlCommand;
using NHibernate.Transform;
using PMS.Common.ListItem;
using PMS.Data.Enity;

namespace PMS.Data.Data
{
    public class ActionData: BaseData<ActionEntity>
    {
        public ActionData(DataProvider dataProvider) : base(dataProvider)
        {
        }
        public List<LookupItem> GetLookupList(Guid roleTypeId)
        {
            RoleTypeActionEntity entity = null;
            ActionEntity actionEntity = null;
            LookupItem listItem = null;
            var query = DataProvider.QueryOver(() => entity);
            query.JoinAlias(x => x.ActionIdObject, () => actionEntity, JoinType.InnerJoin);

            var projections = Projections.ProjectionList();
            projections.Add(Projections.Property(() => actionEntity.Id).WithAlias(() => listItem.Id));
            projections.Add(Projections.Property(() => actionEntity.Name).WithAlias(() => listItem.Value));

            query.Where(x => x.RoleTypeId == roleTypeId);
            query.Select(projections);
            var result =
                query.TransformUsing(Transformers.AliasToBean<LookupItem>())
                    .List<LookupItem>();
            return result.ToList();
        }
    }
}