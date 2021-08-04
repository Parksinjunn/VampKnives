using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.Misc
{
    public class DamagedWyvernHead : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Damaged Wyvern Head");
            Tooltip.SetDefault("A wyvern's head that's been damaged beyond repair");
        }
        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 48;
            item.maxStack = 99;
            base.SetDefaults();
        }
    }
}
