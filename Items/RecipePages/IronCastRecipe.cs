using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace VampKnives.Items.RecipePages
{
    public class IronCastRecipe : RecipeItem
    {
        bool FirstUse;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Knife Cast Recipe");
            Tooltip.SetDefault("Right-click to open");
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine line3 = new TooltipLine(mod, "Face", "Recipe:");
            line3.overrideColor = new Color(220, 220, 220);
            tooltips.Add(line3);
            TooltipLine line4 = new TooltipLine(mod, "Face", "-Hammer");
            line4.overrideColor = new Color(220, 220, 220);
            tooltips.Add(line4);
            TooltipLine line5 = new TooltipLine(mod, "Face", "-5 Iron Bars");
            line5.overrideColor = new Color(220, 220, 220);
            tooltips.Add(line5);
            TooltipLine line6 = new TooltipLine(mod, "Face", "-Knife Sculpt");
            line6.overrideColor = new Color(220, 220, 220);
            tooltips.Add(line6);
        }
        public override void HoldItem(Player player)
        {
            //Main.NewText("Is Knife: " + VampKnives.IsKnifeRecipe);
            //Main.NewText("Is KnifeState: " + RecipePageState.IsKnifeRecipe);
            //Main.NewText("Is Ammo: " + VampKnives.IsAmmoRecipe);
            //Main.NewText("Is AmmoState: " + RecipePageState.IsAmmoRecipe);
            VampKnives.IsAmmoRecipe = false;
            VampKnives.IsKnifeRecipe = true;
            VampKnives.IsSharpeningRodRecipe = false;
            VampKnives.IsPlateRecipe = false;
            VampKnives.IsAmmoSculptRecipe = false;
            VampKnives.IsKnifeSculptRecipe = false;
            VampKnives.IsSharpeningSculptRecipe = false;
        }
    }
}