using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PMS.Web.HtmlHelpers;
using Spring.Context;
using Spring.Context.Support;

namespace PMS.Web.Attributes
{
    [AttributeUsage(AttributeTargets.Property|AttributeTargets.Field)]
    public class LocalisedAttribute : DisplayNameAttribute
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
        public LocalisedAttribute([CallerMemberName] string displayName = null)
            : base(GetLocalizedString(displayName))
        {
        }

        public static string GetLocalizedString(string id)
        {
            return Translator.Translate(id);
        }
    }
}