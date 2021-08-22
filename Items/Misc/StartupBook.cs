using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace VampKnives.Items.Misc
{
    public class StartupBook : RecipePages.RecipeItem
    {
        bool FirstUse = true;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Notebook of Varujan Balitiu");
            Tooltip.SetDefault("Right-click to open");
        }
        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 50;
            item.useAnimation = 15;
            item.useTime = 15;
            item.scale = 0.5f;
            item.useStyle = 1;
            item.value = Item.sellPrice(0, 0, 1, 0);
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                item.useStyle = 5;
                if (FirstUse)
                {
                    UI.StartupBookUI.visible = true;
                    FirstUse = false;
                }
                else if (FirstUse == false)
                {
                    UI.StartupBookUI.visible = false;
                    FirstUse = true;
                }
            }
            else
            {
            }
            return true;
        }
    }
}