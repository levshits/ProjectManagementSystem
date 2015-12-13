using System.Collections.Generic;
using System.Globalization;
using System.Web.Mvc;
using Spring.Context;
using Spring.Context.Support;

namespace PMS.Web.HtmlHelpers
{
    public static class HtmlHelperExtensions
    {
        private static Translator _translator;
        public static Translator Translator
        {
            get
            {
                if (_translator == null)
                {
                    IApplicationContext context = ContextRegistry.GetContext();
                    _translator = context.GetObject<Translator>();
                }
                return _translator;
            }
        }

        public static string Text(this HtmlHelper html, string key)
        {
            return Translator.Translate(key) ?? key;
        }
    }
}