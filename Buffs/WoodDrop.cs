using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.ModLoader;
using Terraria;

namespace Fargowiltas.Buffs
{
    public class WoodDrop : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Wood Drop");
            Main.buffNoSave[Type] = true;
        }
    }
}