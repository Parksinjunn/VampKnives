using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Audio;
using Terraria.GameContent.Events;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.UI;
using Terraria.Utilities;

namespace VampKnives.Items
{
    public class VampKnivesGlobal : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            if(item.type == ItemID.VampireKnives)
            {
                item.damage = 0;
                item.useStyle = 0;
            }
        }
        public override void Update(Item item, ref float gravity, ref float maxFallSpeed)
        {
            if (item.type == ItemID.BottledWater)
            {
                if (Collision.LavaCollision(item.position, item.width, item.height))
                {
                    int g = Item.NewItem(item.position, ItemID.Obsidian);
                    Main.item[g].stack = item.stack;
                    item.active = false;
                }
            }
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (item.type == ItemID.VampireKnives)
                foreach (TooltipLine line in tooltips)
                {
                    if (line.mod == "Terraria" && line.Name == "Tooltip0")
                    {
                        line.text = "";
                    }
                }
        }
    }
}