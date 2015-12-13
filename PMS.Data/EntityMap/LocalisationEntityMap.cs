using FluentNHibernate.Mapping;
using PMS.Data.Enity;

namespace PMS.Data.EntityMap
{
    public class LocalisationEntityMap : ClassMap<LocalisationEntity>
    {
        public LocalisationEntityMap()
        {
            Table("Localisation");

            Id(x => x.Id).GeneratedBy.Guid();

            Map(x => x.TranslationKey);
            Map(x => x.Value);
            Map(x => x.LanguageId);
        }
    }
}