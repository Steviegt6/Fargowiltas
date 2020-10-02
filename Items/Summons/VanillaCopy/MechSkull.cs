using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace Fargowiltas.Items.Summons
{
    public class MechSkull : BaseSummon
    {
        public override string Texture => "Terraria/Item_557";

        public override int Type => NPCID.SkeletronPrime;

        public override string NPCName => "Skeletron Prime";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Some Kind of Metallic Skull");
            Tooltip.SetDefault("Summons Skeletron Prime");
        }

        public override bool CanUseItem(Player player)
        {
            return Main.dayTime != true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.MechanicalSkull);
            recipe.AddTile(TileID.WorkBenches);
            
            recipe.Register();
        }
    }
}