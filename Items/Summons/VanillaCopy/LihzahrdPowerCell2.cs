using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria;

namespace Fargowiltas.Items.Summons.VanillaCopy
{
    public class LihzahrdPowerCell2 : BaseSummon
    {
        public override int Type => NPCID.Golem;

        public override string NPCName => "Golem";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lihzahrd Battery Pack");
            Tooltip.SetDefault("Summons the Golem without an altar");
        }

        public override bool CanUseItem(Player player)
        {
            return NPC.downedPlantBoss;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.LihzahrdPowerCell);
            recipe.AddTile(TileID.WorkBenches);
            
            recipe.Register();
        }
    }
}