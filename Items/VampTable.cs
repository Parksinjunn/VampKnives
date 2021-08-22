using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VampKnives.Items.Materials;

namespace VampKnives.Items
{
    public class VampTable : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vampire Altar");
            Tooltip.SetDefault("Used to craft knives more efficiently \n(most recipes from this mod are cheaper at this altar)");
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
            recipe.AddIngredient(ItemID.Obsidian, 75);
            recipe.AddIngredient(ModContent.ItemType<StableCrimsonCrystal>(), 2);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<VampireKnivesMagic>());
            recipe.AddIngredient(ItemID.Obsidian, 75);
            recipe.AddIngredient(ModContent.ItemType<StableCrimsonCrystal>(), 2);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.VampireKnives);
            recipe.AddIngredient(ItemID.Obsidian, 75);
            recipe.AddIngredient(ModContent.ItemType<StableCrimsonCrystal>(), 2);
            recipe.AddTile(mod.GetTile("KnifeBench"));
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<VampireKnivesMagic>());
            recipe.AddIngredient(ItemID.Obsidian, 75);
            recipe.AddIngredient(ModContent.ItemType<StableCrimsonCrystal>(), 2);
            recipe.AddTile(mod.GetTile("KnifeBench"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}