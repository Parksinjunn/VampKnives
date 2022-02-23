using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.Materials
{
    public abstract class PlateItem : ModItem
    {
        public short BarType;
        public int Rarity;
        public override void SetDefaults()
        {
            item.width = 36;
            item.height = 36;
            item.rare = Rarity;
            item.maxStack = 99;
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
            TooltipLine line3 = new TooltipLine(mod, "Face", "Used to craft Defense Knives");
            line3.overrideColor = new Color(86, 86, 86);
            tooltips.Add(line3);
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
            recipeHC.AddIngredient(BarType, 3);
            recipeHC.anyIronBar = true;
            recipeHC.SetResult(this);
            recipeHC.AddRecipe();

            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(BarType, 3);
            recipe.anyIronBar = true;
            recipe.AddTile(mod.GetTile("KnifeBench"));
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(BarType, 2);
            recipe.anyIronBar = true;
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}