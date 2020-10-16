using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Abom
{
    public class PartyCone : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Party Cone");
            Tooltip.SetDefault("Starts a Party!");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 20;
            item.value = Item.sellPrice(0, 0, 2);
            item.rare = ItemRarityID.Blue;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = ItemUseStyleID.HoldUp;
            item.consumable = true;
        }

        public override bool CanUseItem(Player player) => !BirthdayParty.PartyIsUp;

        public override bool UseItem(Player player)
        {
            BirthdayParty.ToggleManualParty();

            NetMessage.SendData(MessageID.WorldData);

            if (!NPC.AnyNPCs(NPCID.PartyGirl))
            {
                NPC.SpawnOnPlayer(player.whoAmI, NPCID.PartyGirl);
            }

            Main.NewText("Looks like someone's throwing a Party!", new Color(255, 0, 160));
            SoundEngine.PlaySound(28, player.position);

            return true;
        }
    }
}