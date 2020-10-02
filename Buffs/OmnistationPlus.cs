//using CalamityMod.CalPlayer;
using Fargowiltas.Items.Tiles;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
//using ThoriumMod;
using static Terraria.ModLoader.ModContent;

namespace Fargowiltas.Buffs
{
    public class OmnistationPlus : ModBuff
    {
        private Mod thorium;

        private Mod calamity;

        public override string Texture => "Fargowiltas/Buffs/Omnistation";

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Omnistation+");
            Description.SetDefault("Effects of all stations, vanilla and modded");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;

            thorium = Fargowiltas.FargosGetMod("ThoriumMod");
            calamity = Fargowiltas.FargosGetMod("CalamityMod");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffImmune[BuffType<Buffs.Omnistation>()] = true;
            player.buffImmune[BuffID.Sunflower] = true;
            player.buffImmune[BuffID.Campfire] = true;
            player.buffImmune[BuffID.HeartLamp] = true;
            player.buffImmune[BuffID.StarInBottle] = true;
            player.buffImmune[BuffID.DryadsWard] = true;

            if (player.whoAmI == Main.myPlayer)
            {
                // sunflow, campfire, etc. bools moved to SceneMetrics and made readonly because Re-Logic hates modders
                player.AddBuff(146, 2, quiet: false);
                player.AddBuff(BuffID.Campfire, 2, quiet: false);
                player.AddBuff(BuffID.HeartLamp, 2, quiet: false);
                player.AddBuff(BuffID.StarInBottle, 2, quiet: false);

                //dryad's blessing
                player.lifeRegen += 6;
                player.statDefense += 8;
                if (player.thorns < 1f)
                {
                    player.thorns += 0.2f;
                }

                if (Fargowiltas.ModLoaded["ThoriumMod"]) Thorium(player);

                if (Fargowiltas.ModLoaded["CalamityMod"]) Calamity(player);
            }

            int type = Framing.GetTileSafely(player.Center).type;
            if (type == ModContent.TileType<OmnistationPlusSheet>())
            {
                player.AddBuff(BuffID.Honey, 30 * 60 + 1);
            }
        }

        private void Thorium(Player player)
        {
            // TODO: Thorium Crossmod
            /*player.buffImmune[thorium.BuffType("SeasonsGreeting")] = true;

            //mistletoe effect
            player.lifeRegenTime++;
            player.lifeRegen++;
            player.manaRegenBonus++;
            player.manaRegenDelayBonus++;
            player.GetModPlayer<ThoriumPlayer>().inspirationRegenBonus += 0.02f;*/
        }

        private void Calamity(Player player)
        {
            // TODO: Calamity Crossmod
            /*player.buffImmune[calamity.BuffType("PurpleDefenseCandle")] = true;
            player.buffImmune[calamity.BuffType("YellowDamageCandle")] = true;
            player.buffImmune[calamity.BuffType("PinkHealthCandle")] = true;
            player.buffImmune[calamity.BuffType("BlueSpeedCandle")] = true;

            player.GetModPlayer<CalamityPlayer>().purpleCandle = true;
            player.GetModPlayer<CalamityPlayer>().yellowCandle = true;
            player.GetModPlayer<CalamityPlayer>().pinkCandle = true;
            player.GetModPlayer<CalamityPlayer>().blueCandle = true;*/

        }
    }
}