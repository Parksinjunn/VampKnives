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
	public class HallowedGauntlet : KnifeDamageItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hallowed Knives");
			Tooltip.SetDefault("Life and mana stealing knives that chip upon contact and fire off in random directions");
            Item.staff[item.type] = true;
        }
        public override void SafeSetDefaults()
		{
			item.damage = 42;
			item.width = 52;
			item.height = 52;
			item.useTime = 15;
			item.useAnimation = 15;
            item.scale = 0.65f;
            item.channel = true;
            item.useStyle = 5;
            item.noMelee = true;
			item.knockBack = 3;
			item.value = Item.sellPrice(0,0,68,52);
			item.rare = 8;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
            item.shoot = mod.ProjectileType("HallowedGauntletProj");
            item.shootSpeed = 15f;
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.UnicornHorn, 5);
            recipe.AddIngredient(ItemID.HallowedBar, 14);
            recipe.AddIngredient(ItemID.SoulofLight, 20);
            recipe.AddIngredient(ModContent.ItemType<ManaKnivesAnimated>());
            recipe.AddIngredient(ModContent.ItemType<Items.Materials.StableCrimsonCrystal>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Materials.StableCorruptionCrystal>(), 1);
            recipe.AddTile(mod.GetTile("KnifeBench"));
			recipe.SetResult(this);
			recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.UnicornHorn, 5);
            recipe.AddIngredient(ItemID.HallowedBar, 10);
            recipe.AddIngredient(ItemID.SoulofLight, 14);
            recipe.AddIngredient(ModContent.ItemType<ManaKnivesAnimated>());
            recipe.AddIngredient(ModContent.ItemType<Items.Materials.StableCrimsonCrystal>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Materials.StableCorruptionCrystal>(), 1);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
