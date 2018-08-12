using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.Materials
{
    public class StoneKnifeSculpt : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sculpted Stone Knives");
            Tooltip.SetDefault("Useful for making a cast");
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
        ExamplePlayer p = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
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
            ChiselRecipe recipe = new ChiselRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 20);
            recipe.AddTile(mod.GetTile("KnifeBench"));
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ChiselRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 15);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}