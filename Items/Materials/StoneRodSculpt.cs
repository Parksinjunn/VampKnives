using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.Materials
{
    public class StoneRodSculpt : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sculpted Rod ");
            Tooltip.SetDefault("A rough sculpt of a sharpening rod");
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
            TooltipLine line = new TooltipLine(mod, "Face", "Requires a Chisel to craft");
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
            ChiselRecipe recipeC = new ChiselRecipe(mod);
            recipeC.AddIngredient(ItemID.StoneBlock, 20);
            recipeC.SetResult(this);
            recipeC.AddRecipe();

            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 20);
            recipe.AddTile(mod.GetTile("KnifeBench"));
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 15);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}