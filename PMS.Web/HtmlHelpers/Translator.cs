using System.Collections.Generic;
using Levshits.Data.Common;
using Levshits.Data.Interfaces;
using PMS.Common.Request;

namespace PMS.Web.HtmlHelpers
{
    public class Translator
    {
        public ICommandBus CommandBus { get; set; }
        public const int ENGLISH = 1;
        private readonly Dictionary<string, string> _translations = new Dictionary<string, string>();

        public string Translate(string key)
        {
            return Translate(key, ENGLISH);
        }
        public string Translate(string key, int language)
        {
            if (_translations.ContainsKey(key))
            {
                return _translations[key];
            }
            ExecutionResult<string> result = CommandBus.ExecuteCommand(new TranslateRequest() {Key = key, Language = ENGLISH}) as ExecutionResult<string>;
            if (result != null)
            {
                _translations[key] = result.TypedResult;
                return result.TypedResult;
            }
            return key;
        }
    }
}