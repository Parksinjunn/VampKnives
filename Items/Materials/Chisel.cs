using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.Materials
{
    public class Chisel : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chisel");
            Tooltip.SetDefault("[c/FF0000:Used to chip stone into shapes]\nCan be stored in the knife workbench");
        }
        public override void SetDefaults()
        {
            item.width = 52;
            item.height = 16;
            base.SetDefaults();
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronBar, 1);
            recipe.anyIronBar = true;
            recipe.AddIngredient(ItemID.Wood, 1);
            recipe.anyWood = true;
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronBar, 1);
            recipe.anyIronBar = true;
            recipe.AddIngredient(ItemID.Wood, 1);
            recipe.anyWood = true;
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}