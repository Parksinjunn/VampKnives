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
	public class HarvestersSoul : KnifeDamageItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Harvester's Soul");
			Tooltip.SetDefault("This mystic tool gives the user the power of the pumpking");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(10, 5));

		}
		public override void SafeSetDefaults()
		{
			item.damage = 18;            
			item.width = 42;
			item.height = 44;
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
            item.shoot = mod.ProjectileType("HarvestersSoulHeldProj");
            item.shootSpeed = 23f;
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                item.shoot = mod.ProjectileType("HarvestersSoulProj2");
                item.useTime = 24;
                item.useAnimation = 24;
                item.UseSound = SoundID.Item117;
            }
            else
            {
                item.useTime = 2;
                item.useAnimation = 2;
                item.shoot = mod.ProjectileType("HarvestersSoulHeldProj");
                item.UseSound = null;
            }
            return true;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (player.altFunctionUse == 2)
            {
                damage = 52;
                //speedX *= 2f;
                //speedY *= 2f;
                return true;
            }
            else
                return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
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
