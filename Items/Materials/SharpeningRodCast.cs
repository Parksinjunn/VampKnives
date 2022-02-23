using System.Collections.Generic;
using Microsoft.Xna.Framework;
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
            Tooltip.SetDefault("Cast used to make a sharpening rod");
        }

        public override void SetDefaults()
        {
            item.width = 38;
            item.height = 38;
        }
        public override bool CloneNewInstances
        {
            get
            {
                return true;
            }
        }
        public bool crafted;
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
        VampPlayer p = Main.LocalPlayer.GetModPlayer<VampPlayer>();
            TooltipLine line = new TooltipLine(mod, "Face", "Requires a Hammer to craft");
            line.overrideColor = new Color(86, 86, 86);
            if (crafted == false)
                tooltips.Add(line);
        }
        public override void OnCraft(Recipe recipe)
        {
            crafted = true;
        }
        public override void UpdateInventory(Player player)
        {
            crafted = true;
        }
        public override void AddRecipes()
        {
            HammerRecipe recipeHC = new HammerRecipe(mod);
            recipeHC.AddIngredient(mod.GetItem("StoneRodSculpt"), 1);
            recipeHC.AddIngredient(ItemID.IronBar, 3);
            recipeHC.anyIronBar = true;
            recipeHC.SetResult(this);
            recipeHC.AddRecipe();

            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("StoneRodSculpt"), 1);
            recipe.AddIngredient(ItemID.IronBar, 5);
            recipe.anyIronBar = true;
            recipe.AddTile(mod.GetTile("KnifeBench"));
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("StoneRodSculpt"), 1);
            recipe.AddIngredient(ItemID.IronBar, 3);
            recipe.anyIronBar = true;
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}