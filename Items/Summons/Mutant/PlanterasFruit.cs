using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria;

namespace Fargowiltas.Items.Summons.Mutant
{
    public class PlanterasFruit : BaseSummon
    {
        public override int Type => NPCID.Plantera;

        public override string NPCName => "Plantera";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Plantera's Fruit");
            Tooltip.SetDefault("Summons Plantera");
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.ChlorophyteBar, 2);
            recipe.AddIngredient(ItemID.Moonglow, 5);
            recipe.AddIngredient(ItemID.Blinkroot, 5);
            recipe.AddTile(TileID.DemonAltar);
            
            recipe.Register();
        }
    }
}