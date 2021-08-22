using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items
{
    public class Scimitars : KnifeDamageItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Scimitars");
        }
        public override void SafeSetDefaults()
        {
            item.damage = 22;
            item.width = 32;
            item.height = 32;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = 1;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.knockBack = 4;
            item.value = Item.sellPrice(0, 12, 50, 40);
            item.rare = -11;
            item.UseSound = SoundID.Item39;
            item.shoot = mod.ProjectileType("ScimitarProj");
            item.autoReuse = true;
            item.shootSpeed = 15f;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach (TooltipLine line2 in tooltips)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.text = "[c/D4AF37:Scimitars]";
                }
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DyeTradersScimitar, 1);
            recipe.AddIngredient(ItemID.VampireKnives, 1);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

}
