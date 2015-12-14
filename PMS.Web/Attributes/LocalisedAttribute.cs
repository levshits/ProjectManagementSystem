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
        public Translator Translator { get; }

        public LocalisedAttribute([CallerMemberName] string displayName = null)
            : base()
        {
            //IApplicationContext context = ContextRegistry.GetContext();
            //Translator = context.GetObject<Translator>();
            DisplayNameValue = GetLocalizedString(displayName);
        }

        public string GetLocalizedString(string id)
        {
            return id;
        }
    }
}