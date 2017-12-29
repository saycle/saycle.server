using System.Linq;
using System.Collections.Generic;

using saycle.server.Models;

namespace saycle.server.Data
{
    public class LanguagesInitializer : BaseInitializer
    {
        public LanguagesInitializer(SaycleContext context) : base(context)
        {
            
        }

        public override void Seed()
        {
            if (Context.Language.Any())
            {
                return;
            }
            var languages = new List<Language>
            {
                new Language() {Code = "de-ch", Name = "Schwizerdütsch"},
                new Language() {Code = "de", Name = "Deutsch"},
                new Language() {Code = "en", Name = "English"}
            };
            Context.Language.AddRange(languages);
            Context.SaveChangesAsync().Wait();
        }
    }
}
