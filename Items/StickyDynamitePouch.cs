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
	public class StickyDynamitePouch : PouchWeapon
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sticky Dynamite Pouch");
			Tooltip.SetDefault("Pouch filled with sticky dynamite that are strung together");
        }
		public override void PouchDefaults()
		{
			item.width = 40;
			item.height = 56;
			item.useTime = 18;
			item.useAnimation = 18;
            item.noUseGraphic = true;
            item.useStyle = 1;
            item.noMelee = true;
			item.value = Item.sellPrice(0,0,54,20);
			item.rare = 1;
			item.UseSound = SoundID.Item39;
			item.autoReuse = true;
            item.shoot = ProjectileID.StickyDynamite;
            item.shootSpeed = 15f;
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Dynamite, 99);
            recipe.AddIngredient(mod.GetItem("EmptyPouch"), 1);
            recipe.AddTile(mod.GetTile("KnifeBench"));
			recipe.SetResult(this);
			recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Dynamite, 50);
            recipe.AddIngredient(mod.GetItem("EmptyPouch"), 1);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Gel, 99);
			recipe.AddIngredient(mod.GetItem("DynamitePouch"), 1);
			recipe.AddTile(mod.GetTile("KnifeBench"));
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Gel, 50);
			recipe.AddIngredient(mod.GetItem("DynamitePouch"), 1);
			recipe.AddTile(mod.GetTile("VampTableTile"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}

}
