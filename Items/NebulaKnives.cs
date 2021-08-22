using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items
{
    public class NebulaKnives : KnifeDamageItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nebula Knives");
            Tooltip.SetDefault("Crafted from pure nebula, spawns a nebula blaze upon hitting an enemy");
        }
        public override void SafeSetDefaults()
        {
            item.damage = 68;
            item.width = 32;
            item.height = 32;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = 1;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.knockBack = 4;
            item.value = Item.sellPrice(0, 10, 50, 40);
            item.rare = 11;
            item.UseSound = SoundID.Item39;
            item.shoot = mod.ProjectileType("NebulaProj");
            item.autoReuse = true;
            item.shootSpeed = 15f;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach (TooltipLine line2 in tooltips)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.text = "[c/E00BEB:Ne][c/C10BCC:bu][c/A20BAD:la] [c/830A8D:Kn][c/640A6E:iv][c/450A4F:es]";
                }
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FragmentNebula, 18);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

}
