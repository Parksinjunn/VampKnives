using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.Materials
{
    public class CorruptionCrystal : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Unstable Corruption Crystal");
            Tooltip.SetDefault("Seems to have corrupt energy pouring from its cracks");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(2, 9));
        }
        public override void SetDefaults()
        {
            item.maxStack = 10;
            item.value = Item.sellPrice(0, 0, 50, 0) ;
            item.rare = 11;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("CrimsonCrystal"), 1);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();

            HammerRecipe recipe2 = new HammerRecipe(mod);
            recipe2.AddIngredient(mod.GetItem("CorruptionShard"), 5);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }
    }
}