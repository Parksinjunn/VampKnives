﻿using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace VampKnives.Items
{
    public class ShadowKnives : KnifeDamageItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Penumbra");
            Tooltip.SetDefault("Very Dark\nThe knives fall to the ground and bounce back to the user");
        }
        public override void SafeSetDefaults()
        {
            item.damage = 25; //PUT DAMAGE, GENERALLY 1/2 OF COMPONENT'S DAMAGE
            
            item.width = 38;
            item.height = 38;
            item.useTime = 15;
            item.useAnimation = 15;
            item.noUseGraphic = true;
            item.useStyle = 1;
            item.noMelee = true;
            item.knockBack = 3;
            item.value = Item.sellPrice(0,10,40,10); //10000 = 1 gold, 100 silver, or 10000 copper
            item.rare = 11; // -1 = Grey; 0 = White; 1 = Blue; 2 = Green; 3 = Orange; 4 = Light Red
            //5 = Pink; 6 = Light Purple; 7 = Lime; 8 = Yellow; 9 = Cyan; 10 = Red; 11 = Purple
            //-12 = Rainbow; -2 = Amber
            item.UseSound = SoundID.Item39; //Default 39
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("ShadowProj");
            item.shootSpeed = 15f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("LightandDark"), 1);
            recipe.AddIngredient(mod.GetItem("FieryKnives"), 1);
            recipe.AddIngredient(mod.GetItem("JungleKnives"), 1);
            recipe.AddIngredient(mod.GetItem("SengosForgottenBlades"), 1);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("ButchersKnives"), 1);
            recipe.AddIngredient(mod.GetItem("FieryKnives"), 1);
            recipe.AddIngredient(mod.GetItem("JungleKnives"), 1);
            recipe.AddIngredient(mod.GetItem("SengosForgottenBlades"), 1);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("LightandDark"), 1);
            recipe.AddIngredient(mod.GetItem("FieryKnives"), 1);
            recipe.AddIngredient(mod.GetItem("JungleKnives"), 1);
            recipe.AddIngredient(mod.GetItem("SengosForgottenBlades"), 1);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("ButchersKnives"), 1);
            recipe.AddIngredient(mod.GetItem("FieryKnives"), 1);
            recipe.AddIngredient(mod.GetItem("JungleKnives"), 1);
            recipe.AddIngredient(mod.GetItem("SengosForgottenBlades"), 1);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

}
