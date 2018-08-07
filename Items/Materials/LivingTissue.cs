using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.Materials
{
    public class LivingTissue : ModItem
    {
        public override void SetStaticDefaults()
        {
            //Defaults
            DisplayName.SetDefault("Living Tissue");
            Tooltip.SetDefault("It's still moving...");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(52, 4));
        }
        public override void SetDefaults()
        {
            item.width = 32;
                item.height = 32;
            item.maxStack = 99;
            item.value = Item.sellPrice(0,5,30,0);
            base.SetDefaults();
        }
    }
}
