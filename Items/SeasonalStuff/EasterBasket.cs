using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using VampKnives.Items.DefenseKnives;

namespace VampKnives.Items.SeasonalStuff
{ 
	public class EasterBasket : KnifeDefenseItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Easter Basket");
			//Tooltip.SetDefault("This mystic tool gives the user the power of the pumpking");
		}
		public override void SafeSetDefaults()
		{
			item.damage = 18;            
			item.width = 36;
			item.height = 38;
			item.useTime = 20;
			item.useAnimation = 20;
            item.noUseGraphic = true;
            item.useStyle = 1;
            item.noMelee = true;
			item.knockBack = 3;
			item.value = Item.sellPrice(0,0,54,20);
			item.rare = 8;
			item.UseSound = SoundID.Item39;
			item.autoReuse = false;
            item.shoot = mod.ProjectileType("EasterBasketProj");
            item.shootSpeed = 9f;
        }
        public override void AddRecipes()
        {

        }
    }

}
