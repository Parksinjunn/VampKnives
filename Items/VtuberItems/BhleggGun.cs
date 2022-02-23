using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace VampKnives.Items.VtuberItems
{
    public class BhleggGun : KnifeDamageItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bhlegg Gun");
            Tooltip.SetDefault("A bubble gun infused with the power of an eldrich horror");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(7, 4));
            Item.staff[item.type] = true;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            return true;
        }

        public override void SafeSetDefaults()
        {
            item.damage = 47;
            item.width = 66;
            item.height = 56;
            item.useTime = 15;
            item.useAnimation = 15;
            item.channel = true;
            item.scale = 0.75f;
            item.useStyle = 5;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.knockBack = 3;
            item.value = Item.sellPrice(0, 12, 48, 16);
            item.rare = 8;
            //item.UseSound = SoundID.Item39;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("BhleggGunProj");
            item.shootSpeed = 9f;
        }
    }
    public class BhleggGunSound : KnifeDamageItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bhlegg Gun (Sound)");
            Tooltip.SetDefault("A bubble gun infused with the powers of an ancient eldrich horror and a seal");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(7, 4));
            Item.staff[item.type] = true;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            return true;
        }

        public override void SafeSetDefaults()
        {
            item.damage = 47;
            item.width = 66;
            item.height = 56;
            item.useTime = 15;
            item.useAnimation = 15;
            item.channel = true;
            item.scale = 0.75f;
            item.useStyle = 5;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.knockBack = 3;
            item.value = Item.sellPrice(0, 12, 48, 16);
            item.rare = 5;
            //item.UseSound = SoundID.Item39;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("BhleggGunProj");
            item.shootSpeed = 9f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("BhleggGunSound"));
            recipe.AddTile(mod.GetTile("KnifeBench"));
            recipe.SetResult(mod.GetItem("BhleggGun"));
            recipe.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(mod.GetItem("BhleggGunSound"));
            recipe2.AddTile(mod.GetTile("VampTableTile"));
            recipe2.SetResult(mod.GetItem("BhleggGun"));
            recipe2.AddRecipe();

            ModRecipe recipe3 = new ModRecipe(mod);
            recipe3.AddIngredient(mod.GetItem("BhleggGun"), 1);
            recipe3.AddTile(mod.GetTile("KnifeBench"));
            recipe3.SetResult(mod.GetItem("BhleggGunSound"));
            recipe3.AddRecipe();

            ModRecipe recipe4 = new ModRecipe(mod);
            recipe4.AddIngredient(mod.GetItem("BhleggGun"), 1);
            recipe4.AddTile(mod.GetTile("VampTableTile"));
            recipe4.SetResult(mod.GetItem("BhleggGunSound"));
            recipe4.AddRecipe();
        }
    }
}
