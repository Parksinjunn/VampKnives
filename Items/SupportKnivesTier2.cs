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
    public class SupportKnivesTier2 : KnifeItemSupportScaler
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tier 2 Support Knives");
            Tooltip.SetDefault("Its daggers produce powerful orbs that heal other players");
        }
        public override void SafeSetDefaults()
        {
            item.damage = 23;
            item.width = 40;
            item.height = 40;
            item.useTime = 15;
            item.useAnimation = 15;
            item.noUseGraphic = true;
            item.useStyle = 1;
            item.noMelee = true;
            item.knockBack = 2.75f;
            item.rare = 9;
            item.UseSound = SoundID.Item39;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("SupportKnivesProj2");
            item.shootSpeed = 15f;
        }
        //Made with silver and hallowed bars
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("SupportKnivesTier1"), 1);
            recipe.AddIngredient(ItemID.HallowedBar, 17);
            recipe.AddTile(mod.GetTile("KnifeBench"));
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe.AddIngredient(mod.GetItem("SupportKnivesTier1"), 1);
            recipe.AddIngredient(ItemID.HallowedBar, 15);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

}
