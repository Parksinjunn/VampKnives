using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.Materials
{
    public class PlanteraCloth : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Magical Plant Silk");
            //Tooltip.SetDefault("Cloth infused with the power of a magical beast");
        }
        public override void SetDefaults()
        {
            item.width = 48;
            item.height = 44;
            item.maxStack = 99;
            item.value = Item.buyPrice(0, 1, 0, 0);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("PlantFiber"), 7);
            recipe.AddTile(TileID.LivingLoom);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("PlantFiber"), 5);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}