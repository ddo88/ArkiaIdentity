using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace ArkiaIdentity.Localization
{
    public static class ArkiaIdentityLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(ArkiaIdentityConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(ArkiaIdentityLocalizationConfigurer).GetAssembly(),
                        "ArkiaIdentity.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
