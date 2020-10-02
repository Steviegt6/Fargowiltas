using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace Fargowiltas.Items.Summons.Mutant
{
    public class FleshyDoll : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fleshy Doll");
            Tooltip.SetDefault("Summons the Wall of Flesh" +
                               "\nMake sure you use it in the Underworld");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 20;
            item.value = Item.sellPrice(0, 0, 2);
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = ItemUseStyleID.HoldUp;
            item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return player.position.Y / 16 > Main.maxTilesY - 200 && !NPC.AnyNPCs(NPCID.WallofFlesh);
        }

        public override bool UseItem(Player player)
        {
            NPC.SpawnWOF(player.Center);
            SoundEngine.PlaySound(SoundID.Roar, player.position, 0);

            return true;
        }

        public override void PostUpdate()
        {
            if (item.lavaWet && !NPC.AnyNPCs(NPCID.WallofFlesh))
            {
                NPC.SpawnWOF(item.position);
                item.TurnToAir();
            }
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.GuideVoodooDoll);
            recipe.AddTile(TileID.WorkBenches);
            
            recipe.Register();
        }
    }
}