using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.Materials
{
    public class SharpeningRodCast : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sharpening Rod Cast");
            Tooltip.SetDefault("Hmm... Maybe I could put something in this");
        }

        public override void SetDefaults()
        {
            item.width = 38;
            item.height = 38;
        }

        public override void AddRecipes()
        {

            HammerRecipe recipe = new HammerRecipe(mod);
            recipe.AddIngredient(mod.GetItem("StoneRodSculpt"), 1);
            recipe.AddIngredient(ItemID.IronBar, 5);
            recipe.anyIronBar = true;
            recipe.AddTile(mod.GetTile("KnifeBench"));
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new HammerRecipe(mod);
            recipe.AddIngredient(mod.GetItem("StoneRodSculpt"), 1);
            recipe.AddIngredient(ItemID.IronBar, 3);
            recipe.anyIronBar = true;
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}