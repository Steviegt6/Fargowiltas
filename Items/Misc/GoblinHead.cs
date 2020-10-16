using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Misc
{
    public class GoblinHead : ModItem
    {
        private static Item target;
        private static bool weapon = false;
        private static bool accessory = false;
        private static int counter = 0;
        private static int index = 0;

        private readonly byte[] weaponPrefixes = new byte[]
        {
            PrefixID.Ruthless,
            PrefixID.Godly,
            PrefixID.Demonic,
            PrefixID.Legendary,
            PrefixID.Unreal,
            PrefixID.Mythical
        };

        private readonly string[] weaponPrefixNames = new string[]
        {
            "Ruthless",
            "Godly",
            "Demonic",
            "Legendary",
            "Unreal",
            "Mythical"
        };

        private readonly byte[] accessoryPrefixes = new byte[]
        {
            PrefixID.Warding,
            PrefixID.Arcane,
            PrefixID.Lucky,
            PrefixID.Menacing,
            PrefixID.Quick2,
            PrefixID.Violent
        };

        private readonly string[] accessoryPrefixNames = new string[]
        {
            "Warding",
            "Arcane",
            "Lucky",
            "Menacing",
            "Quick",
            "Violent"
        };

        public override string Texture => "Terraria/NPC_Head_9";

        public override void SetStaticDefaults() => DisplayName.SetDefault("Cheapskate's End");

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.value = Item.sellPrice(0, 0, 2);
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = ItemUseStyleID.HoldUp;
        }

        public override bool CanRightClick() => true;

        public override void RightClick(Player player)
        {
            if (target == null)
            {
                return;
            }

            target.SetDefaults(target.type);

            if (accessory)
            {
                target.Prefix(accessoryPrefixes[index]);
            }
            else if (weapon)
            {
                target.Prefix(weaponPrefixes[index]);
            }
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            Player player = Main.player[Main.myPlayer];

            for (int i = 0; i < player.inventory.Length; i++)
            {
                if (player.inventory[i] != null && player.inventory[i].type == ModContent.ItemType<GoblinHead>())
                {
                    target = player.inventory[++i];
                    break;
                }
            }

            if (target == null)
            {
                tooltips.Add(new TooltipLine(Mod, "1", "This goblin head seems drawn to weapons and accessories"));

                return;
            }

            if (target.accessory)
            {
                accessory = true;
                weapon = false;
            }
            else if (target.damage > 0)
            {
                accessory = false;
                weapon = true;
            }
            else
            {
                tooltips.Add(new TooltipLine(Mod, "1", "This goblin head seems drawn to weapons and accessories"));

                return;
            }

            counter++;

            if (counter > 60)
            {
                counter = 0;
                index++;
            }

            if ((accessory && index >= accessoryPrefixes.Length) || (weapon && index >= weaponPrefixes.Length))
            {
                index = 0;
            }

            if (accessory)
            {
                tooltips.Add(new TooltipLine(Mod, "1", "Right click to give the item to the right of this the " + accessoryPrefixNames[index] + " prefix"));
            }
            else if (weapon)
            {
                tooltips.Add(new TooltipLine(Mod, "1", "Right click to give the item to the right of this the " + weaponPrefixNames[index] + " prefix"));
            }
        }
    }
}