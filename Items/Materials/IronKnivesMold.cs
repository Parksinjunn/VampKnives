using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.Materials
{
    public class IronKnivesMold : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Knives Cast");
            Tooltip.SetDefault("Hmm... Maybe I could put something in this");
        }
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
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
            TooltipLine line3 = new TooltipLine(mod, "Face", "Used to craft all Ore-Tier Knives");
            line3.overrideColor = new Color(255, 0, 0);
            tooltips.Add(line3);
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
            recipe.AddIngredient(mod.GetItem("StoneKnifeSculpt"), 1);
            recipe.AddIngredient(ItemID.IronBar, 5);
            recipe.anyIronBar = true;
            recipe.AddTile(mod.GetTile("KnifeBench"));
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new HammerRecipe(mod);
            recipe.AddIngredient(mod.GetItem("StoneKnifeSculpt"), 1);
            recipe.AddIngredient(ItemID.IronBar, 3);
            recipe.anyIronBar = true;
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}