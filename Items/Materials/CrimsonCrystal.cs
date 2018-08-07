using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.Materials
{
    public class CrimsonCrystal : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Unstable Crimson Crystal");
            Tooltip.SetDefault("Radiates the life essence of a monsterous beast");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(2, 9));
        }
        public override void SetDefaults()
        {
            item.maxStack = 10;
            item.value = 5000;
            item.rare = 10;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("CorruptionCrystal"), 1);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();

            HammerRecipe recipe2 = new HammerRecipe(mod);
            recipe2.AddIngredient(mod.GetItem("CrimsonShard"), 5);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }
    }
}