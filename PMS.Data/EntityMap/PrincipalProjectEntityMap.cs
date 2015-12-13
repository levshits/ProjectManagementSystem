using FluentNHibernate.Mapping;
using PMS.Data.Enity;

namespace PMS.Data.EntityMap
{
    public class PrincipalProjectEntityMap : ClassMap<PrincipalProjectEntity>
    {
        public PrincipalProjectEntityMap()
        {
            Table("PrincipalProject");

            Id(x => x.Id).GeneratedBy.Guid();

            Map(x => x.PrincipalId);
            Map(x => x.ProjectId);
            Map(x => x.CreateTime);

            References(x => x.ProjectIdObject).Column(nameof(PrincipalProjectEntity.ProjectId)).ReadOnly();
            References(x => x.PrincipalIdObject).Column(nameof(PrincipalProjectEntity.PrincipalId)).ReadOnly();
        }
    }
}