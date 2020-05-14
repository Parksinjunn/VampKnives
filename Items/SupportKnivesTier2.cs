using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items
{
    public class SupportKnivesTier2 : KnifeItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Support Knives 2");
            Tooltip.SetDefault("Its daggers produce orbs that heal other players");
        }
        public override void SafeSetDefaults()
        {
            item.damage = 29;
            item.width = 40;
            item.height = 40;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = 1;
            item.noMelee = true;
            item.knockBack = 2.75f;
            item.value = Item.sellPrice(0, 20, 0, 0);
            item.rare = 8;
            item.UseSound = SoundID.Item39;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("SupportKnivesProj2");
            item.shootSpeed = 15f;
        }

        //public override void AddRecipes()
        //{
        //    ModRecipe recipe = new ModRecipe(mod);
        //    recipe.AddIngredient(ItemID.VampireKnives, 1);
        //    recipe.AddTile(mod.GetTile("KnifeBench"));
        //    recipe.SetResult(this);
        //    recipe.AddRecipe();

        //    recipe.AddIngredient(this);
        //    recipe.AddTile(mod.GetTile("KnifeBench"));
        //    recipe.SetResult(ItemID.VampireKnives);
        //    recipe.AddRecipe();
        //}
    }

}
