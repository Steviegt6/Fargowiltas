using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace Fargowiltas
{
    public sealed class FargoConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Label("$Mods.Fargowiltas.Mutant")]
        [DefaultValue(true)]
        public bool Mutant;

        [Label("$Mods.Fargowiltas.Abom")]
        [DefaultValue(true)]
        public bool Abom;

        [Label("$Mods.Fargowiltas.Devi")]
        [DefaultValue(true)]
        public bool Devi;

        [Label("$Mods.Fargowiltas.Lumber")]
        [DefaultValue(true)]
        public bool Lumber;

        [Label("[i:1774] Halloween Season Active")]
        [DefaultValue(false)]
        public bool Halloween;

        [Label("[i:1869] Christmas Season Active")]
        [DefaultValue(false)]
        public bool Christmas;

        [Label("[i:771] Unlimited Ammo at 3996+ in Hardmode")]
        [DefaultValue(true)]
        public bool UnlimitedAmmo;

        [Label("[i:42] Unlimited Consumable Weapons at 3996+ in Hardmode")]
        [DefaultValue(true)]
        public bool UnlimitedConsumableWeapons;

        [Label("[i:292] Unlimited Potion Buffs for 60+ Potions")]
        [DefaultValue(true)]
        public bool UnlimitedPotionBuffsOn120;

        [Label("[i:2374] Angler Quest Instant Reset")]
        [DefaultValue(true)]
        public bool AnglerQuestInstantReset;

        [Label("[i:2294] Extra Lures on Fishing Rods")]
        [DefaultValue(true)]
        public bool ExtraLures;

        [Label("[i:3213] Stalker Money Trough")]
        [DefaultValue(true)]
        public bool StalkerMoneyTrough;

        [Label("[i:267] Catch Town NPCs")]
        [DefaultValue(true)]
        public bool CatchNPCs;

        [Label("[i:267] Extra Town NPC sales")]
        [DefaultValue(true)]
        public bool NPCSales;

        [Label("[i:1809] Powerful Rotten Eggs")]
        [DefaultValue(true)]
        public bool RottenEggs;

        [Label("[i:1683] Banner Recipes")]
        [DefaultValue(true)]
        public bool BannerRecipes;

        [Label("[i:2] Increased Max Stacks")]
        [DefaultValue(true)]
        public bool IncreaseMaxStack;

        [Label("[i:997] Increased Extractinator Speed")]
        [DefaultValue(true)]
        public bool ExtractSpeed;

        [Label("[i:909] Fountains Cause Biomes")]
        [DefaultValue(true)]
        public bool Fountains;

        [Label("[i:3117] Boss Zen")]
        [DefaultValue(true)]
        public bool BossZen;
    }
}