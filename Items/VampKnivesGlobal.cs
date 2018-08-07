using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.Collections.Generic;

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