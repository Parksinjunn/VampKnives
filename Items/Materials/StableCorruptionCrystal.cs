using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.Materials
{
    public class StableCorruptionCrystal : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stable Corruption Crystal");
            Tooltip.SetDefault("Energy is sealed within this translucent purple vessel");
        }
        public override void SetDefaults()
        {
            item.maxStack = 10;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 11;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("CorruptionCrystal"), 1);
            recipe.AddIngredient(mod.GetItem("Superglue"), 1);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("CorruptionCrystal"), 1);
            recipe.AddIngredient(mod.GetItem("Superglue"), 1);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}