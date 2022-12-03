using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Luciful.Content.Items.Placeables.Bars;
using Microsoft.Xna.Framework;
using Luciful.Common.Systems.GenPasses;
using Terraria.Audio;

namespace Luciful.Content.Items.Tools.Special
{
    internal class CursedMirror : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        
        public override void SetDefaults()
        {
            Item.width = 48;
            Item.height = 48;
            Item.scale = 1f;

            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.useTime = 45;
            Item.useAnimation = 45;

            Item.rare = ItemRarityID.LightRed;
            Item.useTurn = true;
            Item.value = Item.sellPrice(gold: 5);
        }

        public override bool? UseItem(Player player)
        {
            LucifulPlayer modPlayer = player.GetModPlayer<LucifulPlayer>();
            if (modPlayer.deathPos != null)
            {
                Vector2 dustPos;
                for (int i = 0; i < 25; i++)
                {
                    dustPos = player.Center;
                    dustPos.X += Main.rand.NextFloat(-0.5f, 0.5f);
                    dustPos.Y += Main.rand.NextFloat(-0.5f, 0.5f);
                    Dust.NewDust(dustPos, 3, 3, DustID.MagicMirror);
                }
                SoundEngine.PlaySound(SoundID.Item6, player.Center);
                player.Teleport(modPlayer.deathPos.Value, TeleportationStyleID.RecallPotion);
                player.velocity.X = 0;
                player.velocity.Y = 0;
                SoundEngine.PlaySound(SoundID.Item6, player.Center);
                for (int i = 0; i < 25; i++)
                {
                    dustPos = player.Center;
                    dustPos.X += Main.rand.NextFloat(-0.5f, 0.5f);
                    dustPos.Y += Main.rand.NextFloat(-0.5f, 0.5f);
                    Dust.NewDust(dustPos, 3, 3, DustID.MagicMirror);
                }
            }
            else
            {
                SoundEngine.PlaySound(SoundID.Item16, player.Center);
            }
            return true;
        }
    }
}
