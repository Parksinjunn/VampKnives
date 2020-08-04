using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace VampKnives.Items
{
    public class HorsemansKnives : KnifeDamageItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Horsemans Knives");
            Tooltip.SetDefault("");
        }
        public override void SafeSetDefaults()
        {
            item.damage = 62; //PUT DAMAGE, GENERALLY 1/2 OF COMPONENT'S DAMAGE
            item.width = 68;
            item.height = 68;
            item.useTime = 15;
            item.useAnimation = 15;
            item.noUseGraphic = true;
            item.useStyle = 1;
            item.noMelee = true;
            item.knockBack = 4.25f;
            item.value = Item.sellPrice(1, 0, 0, 0);
            item.rare = 8; // -1 = Grey; 0 = White; 1 = Blue; 2 = Green; 3 = Orange; 4 = Light Red
            //5 = Pink; 6 = Light Purple; 7 = Lime; 8 = Yellow; 9 = Cyan; 10 = Red; 11 = Purple
            //-12 = Rainbow; -2 = Amber
            item.UseSound = SoundID.Item39; //Default 39
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("HorsemansKnivesProj");
            item.shootSpeed = 15f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TheHorsemansBlade, 1);
            recipe.AddIngredient(ItemID.VampireKnives, 1);
            recipe.AddTile(mod.GetTile("KnifeBench"));
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TheHorsemansBlade, 1);
            recipe.AddIngredient(ItemID.SpookyWood, 132);
            recipe.AddTile(mod.GetTile("KnifeBench"));
            recipe.SetResult(this);
            recipe.AddRecipe();


            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TheHorsemansBlade, 1);
            recipe.AddIngredient(ItemID.VampireKnives, 1);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TheHorsemansBlade, 1);
            recipe.AddIngredient(ItemID.LunarBar, 78);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

}
