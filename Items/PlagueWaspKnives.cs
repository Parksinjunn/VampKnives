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
	public class PlagueWaspKnives : KnifeItem
	{
        Mod Calamity = ModLoader.GetMod("CalamityMod");

        public override void SetStaticDefaults()
        {
            if (Calamity != null)
            {
                DisplayName.SetDefault("Plague Wasp Knives");
                Tooltip.SetDefault("Life Stealing Knives Covered in Plague Wasps");
            }
            else
            {
                DisplayName.SetDefault("Plague Wasp Knives");
                Tooltip.SetDefault("Please enable Calamity");
            }
        }
		public override void SafeSetDefaults()
		{
			item.damage = 56;            
			item.width = 32;
			item.height = 32;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
            item.noMelee = true;
			item.knockBack = 3;
			item.value = Item.sellPrice(0,56,0,0);
			item.rare = -12;
			item.UseSound = SoundID.Item97;
			item.autoReuse = true;
            item.shoot = mod.ProjectileType("PlagueWaspProj");
            item.shootSpeed = 15f;
        }

        public override void AddRecipes()
		{
            if (Calamity != null)
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(Calamity.GetItem("ToxicHeart"), 1);
                recipe.AddIngredient(ItemID.Stinger, 15);
                recipe.AddIngredient(mod.GetItem("WaspKnives"), 1);
                recipe.AddTile(mod.GetTile("KnifeBench"));
                recipe.SetResult(this);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(Calamity.GetItem("ToxicHeart"), 1);
                recipe.AddIngredient(ItemID.Stinger, 12);
                recipe.AddIngredient(mod.GetItem("WaspKnives"), 1);
                recipe.AddTile(mod.GetTile("VampTableTile"));
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
		}
	}

}
