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
	public class JungleKnives : KnifeDamageItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Viney Knives");
			Tooltip.SetDefault("Knives made of jungle material that poison enemies");
        }
		public override void SafeSetDefaults()
		{
            item.damage = 7;    
			item.width = 32;
			item.height = 32;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.knockBack = 3;
            item.value = Item.sellPrice(0, 0, 25, 45) ;
			item.rare = 8;
			item.UseSound = SoundID.Item45;
			item.autoReuse = true;
            item.shoot = mod.ProjectileType("JungleKnivesProj");
            item.shootSpeed = 15f;
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.JungleSpores, 16);
            recipe.AddIngredient(ItemID.Stinger, 16);
            recipe.AddTile(mod.GetTile("KnifeBench"));
			recipe.SetResult(this);
			recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.JungleSpores, 12);
            recipe.AddIngredient(ItemID.Stinger, 12);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}

}
