using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Terraria.ModLoader;

namespace Fargowiltas.Core.Localization
{
    public class JsonLocalizationLoader : BaseLocalizationLoader
    {
        public override string FileExtension => ".json";

        public override void ParseFromStream(Stream stream, string culture)
        {
            foreach ((string startingKey, Dictionary<string, string> transValues) in
                DeserializeJsonFromStream<Dictionary<string, Dictionary<string, string>>>(stream))
            foreach ((string transKey, string transValue) in transValues)
            {
                Dictionary<string, ModTranslation> translations = Translations;
                LanguageHelper
                    .GetOrCreateTranslation($"{startingKey}.{transKey}", Mod, ref translations)
                    .AddTranslation(culture, transValue);
                Translations = translations;
            }
        }

        public static T DeserializeJsonFromStream<T>(Stream stream)
        {
            using StreamReader reader = new(stream);
            using JsonTextReader textReader = new(reader);
            return new JsonSerializer().Deserialize<T>(textReader);
        }
    }
}