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
	public class BeeKnives : KnifeDamageItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bee Knives");
			Tooltip.SetDefault("Knives with an internal compartment \nfilled with bees that explode out on impact");
        }
		public override void SafeSetDefaults()
		{
			item.damage = 12;            
			item.width = 32;
			item.height = 32;
			item.useTime = 15;
			item.useAnimation = 15;
            item.noUseGraphic = true;
            item.useStyle = 1;
            item.noMelee = true;
			item.knockBack = 3;
			item.value = Item.sellPrice(0,0,54,20);
			item.rare = 8;
			item.UseSound = SoundID.Item97;
			item.autoReuse = true;
            item.shoot = mod.ProjectileType("BeeKnifeProj");
            item.shootSpeed = 15f;
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HoneyBlock, 50);
            recipe.AddIngredient(mod.GetItem("IronKnives"), 1);
            recipe.AddTile(mod.GetTile("KnifeBench"));
			recipe.SetResult(this);
			recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HoneyBlock, 35);
            recipe.AddIngredient(mod.GetItem("IronKnives"), 1);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}

}
