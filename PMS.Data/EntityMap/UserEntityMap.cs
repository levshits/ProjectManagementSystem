using FluentNHibernate.Mapping;
using Levshits.Data.Entity;
using PMS.Data.Enity;

namespace PMS.Data.EntityMap
{
    public class UserEntityMap: SubclassMap<UserEntity>
    {
        public UserEntityMap()
        {
            Table("User");

            KeyColumn(nameof(BaseEntity.Id));

            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.Avatar);
        }
    }
}