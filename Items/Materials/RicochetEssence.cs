using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.Materials
{
    public class RicochetEssence : ModItem
    {
        public override void SetStaticDefaults()
        {
            //Defaults
            DisplayName.SetDefault("Ricochet Essence");
            Tooltip.SetDefault("Essence of a once very bouncy thing");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(2, 18));
        }
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 30;
            item.maxStack = 999;
            //item.value = Item.sellPrice(0, 5, 30, 0);
            base.SetDefaults();
        }
    }
}
