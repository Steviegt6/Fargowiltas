using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons
{
    public class CelestialSigil2 : BaseSummon
    {
        public override string Texture => "Terraria/Item_3601";

        public override int Type => NPCID.MoonLordCore;

        public override string NPCName => "Moon Lord";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Celestially Sigil");
            Tooltip.SetDefault("Summons the Moon Lord instantly");
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.CelestialSigil);
            recipe.AddTile(TileID.WorkBenches);

            recipe.Register();
        }
    }
}