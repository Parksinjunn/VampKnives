using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace VampKnives.Items
{
    public class CrimsonNestKnives : KnifeDamageItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crimson Nest");
            Tooltip.SetDefault("Nest filled with larval crimera");
        }
        public override void SafeSetDefaults()
        {
            item.damage = 22; 
            item.width = 80;
            item.height = 80;
            item.useTime = 15;
            item.useAnimation = 15;
            item.noUseGraphic = true;
            item.useStyle = 1;
            item.noMelee = true;
            item.knockBack = 3;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = 6;
            item.UseSound = SoundID.Item39; 
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("CrimsonNestKnivesProj");
            item.shootSpeed = 15f;
            item.scale = 0.25f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bladetongue);
            recipe.AddIngredient(ItemID.CrimtaneBar, 12);
            recipe.AddTile(mod.GetTile("KnifeBench"));
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bladetongue);
            recipe.AddIngredient(ItemID.CrimtaneBar, 7);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

}
