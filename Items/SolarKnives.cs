using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items
{
    public class SolarKnives : KnifeDamageItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Solar Knives");
        }
        public override void SafeSetDefaults()
        {
            item.damage = 64;
            item.width = 32;
            item.height = 32;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = 1;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.knockBack = 4;
            item.value = Item.sellPrice(0, 10, 50, 40);
            item.rare = -11;
            item.UseSound = SoundID.Item39;
            item.shoot = mod.ProjectileType("SolarProj");
            item.autoReuse = true;
            item.shootSpeed = 15f;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach (TooltipLine line2 in tooltips)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.text = "[c/FF3300:So][c/FF470A:la][c/FF5C14:r] [c/FF701F:Kn][c/FF8529:iv][c/FF9933:es]";
                }
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FragmentSolar, 18);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

}
