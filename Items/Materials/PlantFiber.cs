using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.Materials
{
    public class PlantFiber : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Plant Fiber");
            Tooltip.SetDefault("Fiber of a Terrifying Plant Beast");
        }
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.maxStack = 999;
            item.value = Item.buyPrice(0, 0, 50, 0);
            base.SetDefaults();
        }
    }
}