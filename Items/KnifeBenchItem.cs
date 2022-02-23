using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items
{
    public class KnifeBenchItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Knife Worktable");
            Tooltip.SetDefault("Used to craft knives");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 14;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.value = 150;
            item.createTile = mod.TileType("KnifeBench");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 10);
            recipe.anyWood = true;
            recipe.AddIngredient(ItemID.IronBar, 8);
            recipe.anyIronBar = true;
            recipe.AddIngredient(mod.GetItem("Hammer"), 1);
            recipe.AddIngredient(mod.GetItem("Chisel"), 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 8);
            recipe.anyWood = true;
            recipe.AddIngredient(ItemID.IronBar, 6);
            recipe.anyIronBar = true;
            recipe.AddIngredient(mod.GetItem("Hammer"), 1);
            recipe.AddIngredient(mod.GetItem("Chisel"), 1);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}