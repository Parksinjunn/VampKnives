using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace VampKnives.Items.SeasonalStuff
{ 
	public class EverscreamsBranch : KnifeDamageItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Everscream's Branch");
            //Tooltip.SetDefault("This mystic tool gives the user the power of the pumpking");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(14, 8));
        }
        public override void SafeSetDefaults()
		{
			item.damage = 18;            
			item.width = 48;
			item.height = 48;
			item.useTime = 15;
			item.useAnimation = 15;
            item.noUseGraphic = true;
            item.useStyle = 5;
            item.noMelee = true;
            item.channel = true;
			item.knockBack = 3;
			item.value = Item.sellPrice(0,0,54,20);
			item.rare = 8;
			//item.UseSound = SoundID.Item97;
			item.autoReuse = false;
            item.shoot = mod.ProjectileType("EverscreamsBranchHeldProj");
            item.shootSpeed = 16f;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            return true;
        }
        //      public override void AddRecipes()
        //{
        //	ModRecipe recipe = new ModRecipe(mod);
        //	recipe.AddIngredient(ItemID.HoneyBlock, 50);
        //          recipe.AddIngredient(mod.GetItem("IronKnives"), 1);
        //          recipe.AddTile(mod.GetTile("KnifeBench"));
        //	recipe.SetResult(this);
        //	recipe.AddRecipe();

        //          recipe = new ModRecipe(mod);
        //          recipe.AddIngredient(ItemID.HoneyBlock, 35);
        //          recipe.AddIngredient(mod.GetItem("IronKnives"), 1);
        //          recipe.AddTile(mod.GetTile("VampTableTile"));
        //          recipe.SetResult(this);
        //          recipe.AddRecipe();
        //      }
    }

}
