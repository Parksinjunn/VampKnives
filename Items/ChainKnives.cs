using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace VampKnives.Items
{
    public class ChainKnives : KnifeDamageItem
    {
        ////TO CALL A MOD
        //Mod Calamity = ModLoader.GetMod("CalamityMod");
        public override void SetStaticDefaults()
        {
            //Defaults
            DisplayName.SetDefault("Chain Knives");
            Tooltip.SetDefault("Blades attatched to large chains that retract upon hitting a target");
        }
        public override void SafeSetDefaults()
        {
            item.damage = 28; //PUT DAMAGE, GENERALLY 1/2 OF COMPONENT'S DAMAGE
            item.width = 66;
            item.height = 52;
            item.autoReuse = true;
            item.useStyle = 5;
            item.useTurn = true;
            item.channel = true;
            item.useAnimation = 4;
            item.useTime = 4;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.knockBack = 3;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 10; // -1 = Grey; 0 = White; 1 = Blue; 2 = Green; 3 = Orange; 4 = Light Red
            //5 = Pink; 6 = Light Purple; 7 = Lime; 8 = Yellow; 9 = Cyan; 10 = Red; 11 = Purple
            //-12 = Rainbow; -2 = Amber
            item.UseSound = SoundID.Item39; //Default 39
            item.shoot = mod.ProjectileType("ChainProj");
            item.shootSpeed = 24f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChainGuillotines,2);
            recipe.AddTile(mod.GetTile("KnifeBench"));
            recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChainKnife, 5);
            recipe.AddIngredient(ItemID.GoldBar, 5);
            recipe.AddTile(mod.GetTile("KnifeBench"));
            recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GoldBar, 5);
            recipe.AddIngredient(ItemID.IronBar, 40);
            recipe.anyIronBar = true;
            recipe.AddIngredient(ItemID.SilverBar, 20);
            recipe.AddTile(mod.GetTile("KnifeBench"));
            recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PlatinumBar, 5);
            recipe.AddIngredient(ItemID.IronBar, 40);
            recipe.anyIronBar = true;
            recipe.AddIngredient(ItemID.TungstenBar, 20);
            recipe.AddTile(mod.GetTile("KnifeBench"));
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChainGuillotines, 1);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChainKnife, 4);
            recipe.AddIngredient(ItemID.GoldBar, 3);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GoldBar, 3);
            recipe.AddIngredient(ItemID.IronBar, 20);
            recipe.anyIronBar = true;
            recipe.AddIngredient(ItemID.SilverBar, 10);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PlatinumBar, 3);
            recipe.AddIngredient(ItemID.IronBar, 20);
            recipe.anyIronBar = true;
            recipe.AddIngredient(ItemID.TungstenBar, 10);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

}
