using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons
{
    public class SuspiciousEye : BaseSummon
    {
        public override string Texture => "Terraria/Item_43";

        public override int Type => NPCID.EyeofCthulhu;

        public override string NPCName => "Eye of Cthulhu";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eye That Could Be Seen As Suspicious");
            Tooltip.SetDefault("Summons the Eye of Cthulhu");
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.SuspiciousLookingEye);
            recipe.AddTile(TileID.WorkBenches);

            recipe.Register();
        }
    }
}