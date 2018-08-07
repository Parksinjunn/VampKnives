using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items
{
    public class VampTable : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Knife Worktable");
            Tooltip.SetDefault("Used to craft knives");
        }

        public override void SetDefaults()
        {
            item.width = 60;
            item.height = 47;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.createTile = mod.TileType("VampTableTile");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.VampireKnives);
            recipe.AddIngredient(ItemID.Obsidian, 50);
            recipe.AddIngredient(mod.ItemType("StableCrimsonCrystal"), 2);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe.AddIngredient(mod.ItemType("VampireKnivesMagic"));
            recipe.AddIngredient(ItemID.Obsidian, 50);
            recipe.AddIngredient(mod.ItemType("StableCrimsonCrystal"), 2);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}