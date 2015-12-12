﻿using FluentNHibernate.Mapping;
using PMS.Data.Enity;

namespace PMS.Data.EntityMap
{
    public class RoleEntityMap: ClassMap<RoleEntity>
    {
        public RoleEntityMap()
        {
            Table("Role");

            Id(x => x.Id).GeneratedBy.Guid();
            Version(x => x.Version);

            Map(x => x.Name);
            Map(x => x.CreateTime);
            Map(x => x.CreatorId);
            Map(x => x.Description);

            References(x => x.CreatorIdObject).Column(nameof(RoleEntity.CreatorId)).ReadOnly();

            HasManyToMany(x => x.ActionEntities).Cascade.All().Inverse().Table("RoleAction");
        }
    }
}