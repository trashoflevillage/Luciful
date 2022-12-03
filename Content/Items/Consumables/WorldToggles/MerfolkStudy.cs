using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Luciful.Content.Items.Consumables.WorldToggles
{
    internal class MerfolkStudy : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.consumable = true;
            Item.UseSound = SoundID.Item92;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.useTime = 45;
            Item.useAnimation = 45;
            Item.rare = ItemRarityID.Orange;
        }

        public override bool? UseItem(Player player)
        {
            Luciful.Instance.merfolkStudy = true;
            return true;
        }
    }
}
