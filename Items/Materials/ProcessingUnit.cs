using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.Materials
{
    public class ProcessingUnit : ModItem
    {
        public override void SetStaticDefaults()
        {
            //Defaults
            DisplayName.SetDefault("Processing Unit");
            //Tooltip.SetDefault("An empty pouch");
        }
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.maxStack = 99;
            item.value = Item.sellPrice(gold: 1);           //The value of the weapon
            base.SetDefaults();
        }
    }
}
