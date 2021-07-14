using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Terraria.ModLoader;
using Terraria.ModLoader.Core;

namespace Fargowiltas.Core.Localization
{
    public abstract class BaseLocalizationLoader : ModSystem, ILocalizationLoader
    {
        public Dictionary<string, ModTranslation> Translations { get; protected set; }

        public abstract string FileExtension { get; }

        protected BaseLocalizationLoader()
        {
            Translations = new Dictionary<string, ModTranslation>();
        }

        public override void Load()
        {
            base.Load();

            foreach (string culture in LanguageHelper.GetCultureStrings())
            {
                TmodFile modFile = (TmodFile) typeof(Mod)
                    .GetProperty("File", BindingFlags.Instance | BindingFlags.NonPublic)
                    ?.GetValue(Mod);

                IDictionary<string, TmodFile.FileEntry> files =
                    (IDictionary<string, TmodFile.FileEntry>) typeof(TmodFile)
                        .GetField("files", BindingFlags.Instance | BindingFlags.NonPublic)
                        ?.GetValue(modFile);

                string[] validFiles = GetValidFiles(files, culture);

                foreach (string file in validFiles)
                {
                    if (!Mod.FileExists(file))
                        continue;

                    using Stream stream = Mod.GetFileStream(file);
                    ParseFromStream(stream, culture);
                }
            }

            foreach (ModTranslation translation in Translations.Values)
                LocalizationLoader.AddTranslation(translation);
        }

        public abstract void ParseFromStream(Stream stream, string culture);

        // can probably move this to LanguageHelper later
        public virtual string[] GetValidFiles(IDictionary<string, TmodFile.FileEntry> files, string culture)
        {
            return files
                .Where(x => x.Value.Name.Contains(culture) &&
                            x.Value.Name.EndsWith(FileExtension))
                .Select(x => x.Value.Name).ToArray();
        }
    }
}