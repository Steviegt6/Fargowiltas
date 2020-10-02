using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace Fargowiltas.Items.Summons
{
    public class SlimyCrown : BaseSummon
    {
        public override string Texture => "Terraria/Item_560";

        public override int Type => NPCID.KingSlime;

        public override string NPCName => "King Slime";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Slimy Crown");
            Tooltip.SetDefault("Summons King Slime");
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.SlimeCrown);
            recipe.AddTile(TileID.WorkBenches);
            
            recipe.Register();
        }
    }
}