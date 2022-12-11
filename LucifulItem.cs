using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Luciful.Common.Systems;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace Luciful
{
    internal class LucifulItem : GlobalItem
    {
        public int genericTracker1 = 0;

        public override bool InstancePerEntity => true;
        public float baseScale;
        public bool scaled = false;

        public int shovelPower = 0;
        public bool autoSift = false;

        public int bonusProjectiles = 0;
        public float projectileSpread = 15f;
        public float speedVariation = 0.3f;

        public bool reforgable = false;

        public CommanderSpecial commanderSpecial = null;

        public static LucifulItem Convert(Item item) {
            return item.GetGlobalItem<LucifulItem>();
        }

        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            LucifulPlayer modPlayer = player.GetModPlayer<LucifulPlayer>();
            modPlayer.accessories.Add(item.type);
        }

        public override void SetDefaults(Item item)
        {
            if (item.type == ItemID.PaperAirplaneA || item.type == ItemID.PaperAirplaneB)
            {
                item.value = Item.sellPrice(copper: 40);
                item.ammo = ItemID.PaperAirplaneA;
            }
        }

        public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            LucifulItem modItem = Convert(item);

            if (modItem.commanderSpecial != null)
            {
                int projWhoAmI = Projectile.NewProjectile(source, position, velocity, item.shoot, damage, knockback, player.whoAmI);
                Main.projectile[projWhoAmI].GetGlobalProjectile<LucifulProjectile>().commanderSpecial = modItem.commanderSpecial;
                return false;
            }

            return base.Shoot(item, player, source, position, velocity, type, damage, knockback);
        }
    }
}