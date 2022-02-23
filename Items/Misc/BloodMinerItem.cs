using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.Misc
{
    public class BloodMinerItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blood Infused Auto-Miner");
            Tooltip.SetDefault("Automatically mines blocks infront of the drill head\nDirection can be changed using a hammer");
        }
        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 32;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.value = 150;
            item.createTile = mod.TileType("BloodMiner");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Materials.ProcessingUnit>());
            recipe.AddIngredient(ModContent.ItemType<PrimitiveAutoMinerItem>());
            recipe.AddTile(ModContent.TileType<Tiles.VampTableTile>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}