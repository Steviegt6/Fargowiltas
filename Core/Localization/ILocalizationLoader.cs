using System.Collections.Generic;
using Terraria.ModLoader;

namespace Fargowiltas.Core.Localization
{
    public interface ILocalizationLoader
    {
        Dictionary<string, ModTranslation> Translations { get; }

        string FileExtension { get; }
    }
}