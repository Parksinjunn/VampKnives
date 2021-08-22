using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VampKnives.UI;

namespace VampKnives.Items.RecipePages
{
    public abstract class RecipeItem : ModItem
    {
        bool FirstUse = true;
        public override void SetDefaults()
        {
            item.width = 80;
            item.height = 108;
            item.useAnimation = 15;
            item.useTime = 15;
            item.scale = 0.5f;
            item.useStyle = 1;
            item.value = Item.sellPrice(0, 0, 5, 0);
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                item.useStyle = 1;
                if (FirstUse)
                {
                    RecipePageState.visible = true;
                    FirstUse = false;
                }
                else if (FirstUse == false)
                {
                    RecipePageState.visible = false;
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