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
    public class Maracas : KnifeDamageItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Maracas");
            Tooltip.SetDefault("Just some pretty slick maracas");
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
            //item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Maracas");
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("MaracasHeldProj");
            item.shootSpeed = 9f;
        }
    }
    public class MaracasSound : KnifeDamageItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Maracas (Sound)");
            Tooltip.SetDefault("These maracas hold the pure soul of a Puerto-Rican demon\n[Make sure your music is on]");
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
            item.shoot = mod.ProjectileType("MaracasHeldProj");
            item.shootSpeed = 9f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("MaracasSound"));
            recipe.AddTile(mod.GetTile("KnifeBench"));
            recipe.SetResult(mod.GetItem("Maracas"));
            recipe.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(mod.GetItem("MaracasSound"));
            recipe2.AddTile(mod.GetTile("VampTableTile"));
            recipe2.SetResult(mod.GetItem("Maracas"));
            recipe2.AddRecipe();

            ModRecipe recipe3 = new ModRecipe(mod);
            recipe3.AddIngredient(mod.GetItem("Maracas"), 1);
            recipe3.AddTile(mod.GetTile("KnifeBench"));
            recipe3.SetResult(mod.GetItem("MaracasSound"));
            recipe3.AddRecipe();

            ModRecipe recipe4 = new ModRecipe(mod);
            recipe4.AddIngredient(mod.GetItem("Maracas"), 1);
            recipe4.AddTile(mod.GetTile("VampTableTile"));
            recipe4.SetResult(mod.GetItem("MaracasSound"));
            recipe4.AddRecipe();
        }
    }
}
