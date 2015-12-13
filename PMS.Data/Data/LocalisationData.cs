using System;
using Levshits.Data;
using Levshits.Data.Common;
using Levshits.Data.Data;
using PMS.Data.Enity;

namespace PMS.Data.Data
{
    public class LocalisationData: BaseData<LocalisationEntity>
    {
        public LocalisationData(DataProvider dataProvider) : base(dataProvider)
        {
        }

        public string GetTranlations(string key, int language)
        {
            LocalisationEntity localisation = null;
            var query = DataProvider.QueryOver(() => localisation);
            query.Where(x => x.TranslationKey == key && x.LanguageId == language);
            return query.SingleOrDefault()?.Value;
        }
    }
}