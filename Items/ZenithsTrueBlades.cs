using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using Terraria.DataStructures;
using Terraria.Localization;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items
{
    public class ZenithsTrueBlades : KnifeDamageItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zenith's True Blades");
        }
        public override void SafeSetDefaults()
        {
            item.damage = 145;
            item.width = 64;
            item.height = 64;
            item.useTime = 15;
            item.useAnimation = 15;
            item.noUseGraphic = true;
            item.useStyle = 1;
            item.noMelee = true;
            item.knockBack = 3;
            item.value = Item.sellPrice(1, 20, 20, 0);
            item.rare = 10;
            item.UseSound = SoundID.Item39;
            //item.autoReuse = true;
            item.shoot = mod.ProjectileType("ZenithsTrueBladesProj");
            item.shootSpeed = 15f;
            item.channel = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("NebulaKnives"));
            recipe.AddIngredient(mod.GetItem("VortexKnives"));
            recipe.AddIngredient(mod.GetItem("SolarKnives"));
            recipe.AddIngredient(mod.GetItem("StardustKnives"));
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FragmentSolar, 18);
            recipe.AddIngredient(ItemID.FragmentStardust, 18);
            recipe.AddIngredient(ItemID.FragmentVortex, 18);
            recipe.AddIngredient(ItemID.FragmentNebula, 18);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
            return false;
        }
    }

}
