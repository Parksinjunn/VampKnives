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
            Tooltip.SetDefault("Automatically mines block to the top or sides of the drill head");
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
            item.createTile = mod.TileType("PrimitiveAutoMiner");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronBar, 40);
            recipe.anyIronBar = true;
            recipe.AddIngredient(ItemID.StoneBlock, 68);
            recipe.AddIngredient(ItemID.CobaltDrill);
            recipe.AddIngredient(ModContent.ItemType<Items.Materials.ProcessingUnit>());
            recipe.AddTile(mod.GetTile("KnifeBench"));
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe.AddIngredient(ItemID.IronBar, 32);
            recipe.anyIronBar = true;
            recipe.AddIngredient(ItemID.StoneBlock, 52);
            recipe.AddIngredient(ItemID.CobaltDrill);
            recipe.AddIngredient(ModContent.ItemType<Items.Materials.ProcessingUnit>());
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();

            //recipe.AddIngredient(ItemID.IronBar, 40);
            //recipe.anyIronBar = true;
            //recipe.AddIngredient(ItemID.StoneBlock, 68);
            //recipe.AddIngredient(ItemID.PalladiumDrill);
            //recipe.AddIngredient(ModContent.ItemType<Items.Materials.ProcessingUnit>());
            //recipe.AddTile(mod.GetTile("KnifeBench"));
            //recipe.SetResult(this);
            //recipe.AddRecipe();

            //recipe.AddIngredient(ItemID.IronBar, 32);
            //recipe.anyIronBar = true;
            //recipe.AddIngredient(ItemID.StoneBlock, 52);
            //recipe.AddIngredient(ItemID.PalladiumDrill);
            //recipe.AddIngredient(ModContent.ItemType<Items.Materials.ProcessingUnit>());
            //recipe.AddTile(mod.GetTile("VampTableTile"));
            //recipe.SetResult(this);
            //recipe.AddRecipe();
        }
    }
}