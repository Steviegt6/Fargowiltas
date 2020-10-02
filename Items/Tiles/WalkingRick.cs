using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.Localization;

namespace Fargowiltas.Items.Tiles
{
    public class WalkingRick : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Walking Rick");
            Tooltip.SetDefault("'Kien R. Oco'");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.Swing;
            item.consumable = true;
            item.rare = ItemRarityID.Blue;
            item.createTile = ModContent.TileType<WalkingRickSheet>();
        }
    }
}