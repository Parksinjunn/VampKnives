using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.Ammo
{
    public abstract class AmmoCraftItem : KnifeItem
    {
        public override bool CloneNewInstances
        {
            get
            {
                return true;
            }
        }
        public bool crafted;
        int NumberCrafted;
        public short BarType;
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            ExamplePlayer p = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
            TooltipLine line = new TooltipLine(mod, "Face", "Requires a Throwing Knives Cast");
            line.overrideColor = new Color(86, 86, 86);
            if (crafted == false)
                tooltips.Add(line);
        }
        public override void OnCraft(Recipe recipe)
        {
            ExamplePlayer p = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
            crafted = true;
            p.NumCrafted += 1;
            NumberCrafted = p.NumCrafted;
            //Main.NewText("Number Crafted: " + p.NumCrafted);
        }
        public override void UpdateInventory(Player player)
        {
            crafted = true;
        }
        public override void AddRecipes()
        {
            AmmoRecipe1 recipe = new AmmoRecipe1(mod);
            recipe.AddIngredient(BarType, 1);
            recipe.anyIronBar = true;
            recipe.AddTile(null, "KnifeBench");
            recipe.SetResult(this, 10);
            recipe.AddRecipe();

            recipe = new AmmoRecipe1(mod);
            recipe.AddIngredient(BarType, 1);
            recipe.anyIronBar = true;
            recipe.AddTile(null, "VampTableTile");
            recipe.SetResult(this, 20);
            recipe.AddRecipe();

            AmmoRecipe2 recipe2 = new AmmoRecipe2(mod);
            recipe2.AddIngredient(BarType, 1);
            recipe2.anyIronBar = true;
            recipe2.AddTile(null, "KnifeBench");
            recipe2.SetResult(this, 20);
            recipe2.AddRecipe();

            recipe2 = new AmmoRecipe2(mod);
            recipe2.AddIngredient(BarType, 1);
            recipe2.anyIronBar = true;
            recipe2.AddTile(null, "VampTableTile");
            recipe2.SetResult(this, 30);
            recipe2.AddRecipe();

            AmmoRecipe3 Recipe3 = new AmmoRecipe3(mod);
            Recipe3.AddIngredient(BarType, 1);
            Recipe3.anyIronBar = true;
            Recipe3.AddTile(null, "KnifeBench");
            Recipe3.SetResult(this, 30);
            Recipe3.AddRecipe();

            Recipe3 = new AmmoRecipe3(mod);
            Recipe3.AddIngredient(BarType, 1);
            Recipe3.anyIronBar = true;
            Recipe3.AddTile(null, "VampTableTile");
            Recipe3.SetResult(this, 40);
            Recipe3.AddRecipe();

            AmmoRecipe4 Recipe4 = new AmmoRecipe4(mod);
            Recipe4.AddIngredient(BarType, 1);
            Recipe4.anyIronBar = true;
            Recipe4.AddTile(null, "KnifeBench");
            Recipe4.SetResult(this, 35);
            Recipe4.AddRecipe();

            Recipe4 = new AmmoRecipe4(mod);
            Recipe4.AddIngredient(BarType, 1);
            Recipe4.anyIronBar = true;
            Recipe4.AddTile(null, "VampTableTile");
            Recipe4.SetResult(this, 40);
            Recipe4.AddRecipe();

            AmmoRecipe5 Recipe5 = new AmmoRecipe5(mod);
            Recipe5.AddIngredient(BarType, 1);
            Recipe5.anyIronBar = true;
            Recipe5.AddTile(null, "KnifeBench");
            Recipe5.SetResult(this, 50);
            Recipe5.AddRecipe();

            Recipe5 = new AmmoRecipe5(mod);
            Recipe5.AddIngredient(BarType, 1);
            Recipe5.anyIronBar = true;
            Recipe5.AddTile(null, "VampTableTile");
            Recipe5.SetResult(this, 60);
            Recipe5.AddRecipe();

            AmmoRecipe6 Recipe6 = new AmmoRecipe6(mod);
            Recipe6.AddIngredient(BarType, 1);
            Recipe6.anyIronBar = true;
            Recipe6.AddTile(null, "KnifeBench");
            Recipe6.SetResult(this, 65);
            Recipe6.AddRecipe();

            Recipe6 = new AmmoRecipe6(mod);
            Recipe6.AddIngredient(BarType, 1);
            Recipe6.anyIronBar = true;
            Recipe6.AddTile(null, "VampTableTile");
            Recipe6.SetResult(this, 75);
            Recipe6.AddRecipe();

            AmmoRecipe7 Recipe7 = new AmmoRecipe7(mod);
            Recipe7.AddIngredient(BarType, 1);
            Recipe7.anyIronBar = true;
            Recipe7.AddTile(null, "KnifeBench");
            Recipe7.SetResult(this, 75);
            Recipe7.AddRecipe();

            Recipe7 = new AmmoRecipe7(mod);
            Recipe7.AddIngredient(BarType, 1);
            Recipe7.anyIronBar = true;
            Recipe7.AddTile(null, "VampTableTile");
            Recipe7.SetResult(this, 85);
            Recipe7.AddRecipe();

            AmmoRecipe8 Recipe8 = new AmmoRecipe8(mod);
            Recipe8.AddIngredient(BarType, 1);
            Recipe8.anyIronBar = true;
            Recipe8.AddTile(null, "KnifeBench");
            Recipe8.SetResult(this, 85);
            Recipe8.AddRecipe();

            Recipe8 = new AmmoRecipe8(mod);
            Recipe8.AddIngredient(BarType, 1);
            Recipe8.anyIronBar = true;
            Recipe8.AddTile(null, "VampTableTile");
            Recipe8.SetResult(this, 95);
            Recipe8.AddRecipe();

            AmmoRecipe9 Recipe9 = new AmmoRecipe9(mod);
            Recipe9.AddIngredient(BarType, 1);
            Recipe9.anyIronBar = true;
            Recipe9.AddTile(null, "KnifeBench");
            Recipe9.SetResult(this, 125);
            Recipe9.AddRecipe();

            Recipe9 = new AmmoRecipe9(mod);
            Recipe9.AddIngredient(BarType, 1);
            Recipe9.anyIronBar = true;
            Recipe9.AddTile(null, "VampTableTile");
            Recipe9.SetResult(this, 150);
            Recipe9.AddRecipe();

            AmmoRecipe10 Recipe10 = new AmmoRecipe10(mod);
            Recipe10.AddIngredient(BarType, 1);
            Recipe10.anyIronBar = true;
            Recipe10.AddTile(null, "KnifeBench");
            Recipe10.SetResult(this, 500);
            Recipe10.AddRecipe();

            Recipe10 = new AmmoRecipe10(mod);
            Recipe10.AddIngredient(BarType, 1);
            Recipe10.anyIronBar = true;
            Recipe10.AddTile(null, "VampTableTile");
            Recipe10.SetResult(this, 999);
            Recipe10.AddRecipe();
        }
    }
}
