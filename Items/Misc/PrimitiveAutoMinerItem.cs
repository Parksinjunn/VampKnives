using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.Misc
{
    public class PrimitiveAutoMinerItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Primitive Auto-Miner");
            //Tooltip.SetDefault("Parts to a bigger picture\nAutomatically combine into crystals");
        }
        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.value = 150;
            item.createTile = mod.TileType("PrimitiveAutoMiner");
        }
    }
}