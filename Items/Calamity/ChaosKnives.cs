using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using Terraria.DataStructures;
using Terraria.Localization;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.Calamity
{
	public class ChaosKnives : KnifeItem
	{
        Mod Calamity = ModLoader.GetMod("CalamityMod");

        public override void SetStaticDefaults()
        {
            if (Calamity != null)
            {
                DisplayName.SetDefault("Chaos Knives");
                Tooltip.SetDefault("The flame burns in your hand");
            }
            else
            {
                DisplayName.SetDefault("Chaos Knives");
                Tooltip.SetDefault("Please enable Calamity");
            }
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 12));
        }
        public override void SafeSetDefaults()
		{
			item.damage = 45;
			item.width = 32;
			item.height = 32;
			item.useTime = 15;
			item.useAnimation = 15;
            item.noUseGraphic = true;
            item.useStyle = 1;
            item.noMelee = true;
			item.knockBack = 3;
			item.value = Item.sellPrice(0,23,25,40);
			item.rare = 8;
			item.UseSound = SoundID.Item39;
			item.autoReuse = true;
            item.shoot = mod.ProjectileType("ChaosKnivesProj");
            item.shootSpeed = 15f;
        }

        public override void AddRecipes()
        {
            if (Calamity != null)
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ModLoader.GetMod("CalamityMod"), "CoreofChaos", 8);
                recipe.AddIngredient(ItemID.VampireKnives, 1);
                recipe.AddTile(mod.GetTile("KnifeBench"));
                recipe.SetResult(this);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ModLoader.GetMod("CalamityMod"), "CoreofChaos", 5);
                recipe.AddIngredient(ItemID.VampireKnives, 1);
                recipe.AddTile(mod.GetTile("VampTableTile"));
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
    }

}
