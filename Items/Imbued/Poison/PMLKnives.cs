using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.Imbued.Poison
{
	public class PMLKnives : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Refund");
            Tooltip.SetDefault("Right Click to get items back");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.rare = 12;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            player.QuickSpawnItem(ItemID.FlaskofPoison, 15);
            player.QuickSpawnItem(mod.ItemType("LuminiteKnives"));
            player.QuickSpawnItem(mod.ItemType("StableCorruptionCrystal"));
        }
    }

}
