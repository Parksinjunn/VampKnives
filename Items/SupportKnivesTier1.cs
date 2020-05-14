﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items
{
    public class SupportKnivesTier1 : KnifeItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Support Knives 1");
            Tooltip.SetDefault("Its daggers produce orbs that heal other players");
        }
        public override void SafeSetDefaults()
        {
            item.damage = 9;
            item.width = 32;
            item.height = 32;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = 1;
            item.noMelee = true;
            item.knockBack = 2.75f;
            item.value = Item.sellPrice(0, 20, 0, 0);
            item.rare = 8;
            item.UseSound = SoundID.Item39;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("SupportKnivesProj1");
            item.shootSpeed = 15f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("StableCrimsonCrystal"), 1);
            recipe.AddIngredient(mod.GetItem("IronKnives"), 1);
            recipe.AddTile(mod.GetTile("KnifeBench"));
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("StableCrimsonCrystal"), 1);
            recipe.AddIngredient(mod.GetItem("IronKnives"), 1);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

}