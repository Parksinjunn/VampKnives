using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace VampKnives.Items.BossDrops
{
	public class LuminiteKnives : KnifeDamageItem
	{
        Mod Calamity = ModLoader.GetMod("CalamityMod");

        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hand of the Moon Lord");
			Tooltip.SetDefault("Life Stealing Knives Crafted from Fragments of the Moon Lord himself");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(52, 13));
        }
        public override void SafeSetDefaults()
		{
			item.damage = 126;            
			item.width = 66;
			item.height = 66;
            item.useTime = 12;
            item.useAnimation = 12;
            item.noUseGraphic = true;
            item.useStyle = 1;
            item.noMelee = true;
			item.knockBack = 3;
			item.value = Item.sellPrice(0,45,0,0);
			item.rare = 9;
			item.UseSound = SoundID.Item39;
			item.autoReuse = true;
            item.shoot = mod.ProjectileType("LuminiteKnifeProj");
            item.shootSpeed = 17f;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            int R=102;
            int G=255;
            int B=255;
            bool GDecrease = false;
            bool RDecrease = false;
            if (R >= 102)
                RDecrease = true;
            if (R <= 51)
                RDecrease = false;
            if (RDecrease)
                R++;
            if (!RDecrease)
                R--;

            if (G >= 255)
                GDecrease = true;
            if (G <= 102)
                GDecrease = false;
            if (GDecrease)
                G++;
            if (!GDecrease)
                G--;
            foreach (TooltipLine line2 in tooltips)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = new Color(R, G, B);
                }
                if (line2.mod == "Terraria" && line2.Name == "Damage")
                {
                    line2.overrideColor = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB);
                }
                if (line2.mod == "Terraria" && line2.Name == "CritChance")
                {
                    line2.overrideColor = new Color(Main.DiscoG, Main.DiscoR, Main.DiscoB);
                }
                if (line2.mod == "Terraria" && line2.Name == "Speed")
                {
                    line2.overrideColor = new Color(Main.DiscoB, Main.DiscoR, Main.DiscoG);
                }
                if (line2.mod == "Terraria" && line2.Name == "Knockback")
                {
                    line2.overrideColor = new Color(Main.DiscoG, Main.DiscoB, Main.DiscoR);
                }
                if (line2.mod == "Terraria" && line2.Name == "Tooltip0")
                {
                    line2.overrideColor = new Color(Main.DiscoR, Main.DiscoB, Main.DiscoG);
                }
            }
        }
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar, 20);
            recipe.AddIngredient(ItemID.FragmentVortex, 8);
            recipe.AddIngredient(ItemID.FragmentNebula, 8);
            recipe.AddIngredient(ItemID.FragmentSolar, 8);
            recipe.AddIngredient(ItemID.FragmentStardust, 8);
            recipe.AddIngredient(ItemID.VampireKnives, 1);
            recipe.AddTile(mod.GetTile("KnifeBench"));
            recipe.SetResult(this);
			recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LunarBar, 15);
            recipe.AddIngredient(ItemID.FragmentVortex, 5);
            recipe.AddIngredient(ItemID.FragmentNebula, 5);
            recipe.AddIngredient(ItemID.FragmentSolar, 5);
            recipe.AddIngredient(ItemID.FragmentStardust, 5);
            recipe.AddIngredient(ItemID.VampireKnives, 1);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();

            if (Calamity != null)
            {
                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.LunarBar, 15);
                recipe.AddIngredient(ModLoader.GetMod("CalamityMod"), "GalacticaSingularity", 8);
                recipe.AddIngredient(ItemID.VampireKnives, 1);
                recipe.AddTile(mod.GetTile("VampTableTile"));
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
	}

}
