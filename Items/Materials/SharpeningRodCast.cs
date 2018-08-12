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
            Tooltip.SetDefault("Hmm... Maybe I could put something in this");
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
        ExamplePlayer p = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
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