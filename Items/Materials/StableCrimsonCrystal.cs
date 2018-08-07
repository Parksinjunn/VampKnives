
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.Materials
{
    public class StableCrimsonCrystal : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stable Crimson Crystal");
            Tooltip.SetDefault("The life energy of a monsterous beast is sealed within this translucent crimson vessel");
        }
        public override void SetDefaults()
        {
            item.maxStack = 10;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 10;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("CrimsonCrystal"), 1);
            recipe.AddIngredient(mod.GetItem("Superglue"), 1);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("CrimsonCrystal"), 1);
            recipe.AddIngredient(mod.GetItem("Superglue"), 1);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}