using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.VanillaCopy
{
    public class LihzahrdPowerCell2 : BaseSummon
    {
        public override int NPCType => NPCID.Golem;

        public override string NPCName => "Golem";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lihzahrd Battery Pack");
            Tooltip.SetDefault("Summons the Golem without an altar");
        }

        public override bool CanUseItem(Player player) => NPC.downedPlantBoss;

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.LihzahrdPowerCell);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();
        }
    }
}