using System;
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
    public class CommentData: BaseData<CommentEntity>
    {
        public CommentData(DataProvider dataProvider) : base(dataProvider)
        {
        }

        public IList<CommentListItem> GetList(Guid issueId)
        {
            CommentEntity entity = null;
            CommentListItem listItem = null;
            PrincipalEntity creatorAlias = null;
            var query = DataProvider.QueryOver(() => entity);
            var creatorQuery = query.JoinAlias(x => x.CreatorIdObject, () => creatorAlias, JoinType.InnerJoin);

            var projections = Projections.ProjectionList();
            projections.Add(Projections.Property(() => entity.Id).WithAlias(() => listItem.Id));
            projections.Add(Projections.Property(() => entity.CreateTime).WithAlias(() => listItem.CreateTime));
            projections.Add(Projections.Property(() => entity.Text).WithAlias(() => listItem.Text));
            projections.Add(Projections.Property(() => entity.CreatorId).WithAlias(() => listItem.CreatorId));
            projections.Add(Projections.Property(() => creatorAlias.Username).WithAlias(() => listItem.CreatorName));

            query.OrderBy(x => x.CreateTime);

            query.Select(projections);
            var result =
                query.TransformUsing(Transformers.AliasToBean<CommentListItem>())
                    .List<CommentListItem>();
            return result;
        }
    }
}