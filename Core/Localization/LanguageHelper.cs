using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Core.Localization
{
    public static class LanguageHelper
    {
        public const string RootPath = "Localization";

        public static LocalizedText GetText(string key)
        {
            LocalizedText text = Language.GetText($"Mods.{Assembly.GetCallingAssembly().GetName().Name}.{key}");

            if (text.Value != text.Key)
                return text;

            foreach (Mod mod in ModLoader.Mods)
            {
                text = Language.GetText($"Mods.{mod.Name}.{key}");

                if (text.Value != text.Key)
                    return text;
            }

            return Language.GetText(key);
        }

        public static string GetTextValue(string key) => GetText(key).Value;

        public static string GetTextValue(string key, params object[] args) => string.Format(GetTextValue(key), args);

        public static IEnumerable<string> GetCultureStrings() => Enum.GetValues<GameCulture.CultureName>().Select(name => GameCulture.FromCultureName(name).Name).ToArray();

        public static string GetStartingPath(string culture) => Path.Combine(RootPath, culture);

        public static ModTranslation GetOrCreateTranslation(string key, Mod mod, ref Dictionary<string, ModTranslation> translations)
        {
            if (translations.TryGetValue(key, out ModTranslation found))
                return found;

            return translations[key] = LocalizationLoader.CreateTranslation(mod, key);
        }
    }
}