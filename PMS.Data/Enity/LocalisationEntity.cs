using Levshits.Data.Entity;

namespace PMS.Data.Enity
{
    public class LocalisationEntity: BaseEntity
    {
        public virtual string TranslationKey { get; set; }
        public virtual string Value { get; set; }
        public virtual int LanguageId { get; set; }
    }
}