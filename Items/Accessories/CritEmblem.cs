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

namespace VampKnives.Items.Accessories
{
    public class CritEmblem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crit Emblem");
            Tooltip.SetDefault("8% increased knife critical strike chance to all damage types\nUsed in upgrading your knives");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 30;
            item.rare = 2;
            item.accessory = true;
            item.maxStack = 20;
            item.value = Item.sellPrice(0, 2, 40, 0);
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            KnifeDamagePlayer modPlayer = KnifeDamagePlayer.ModPlayer(player);
            modPlayer.KnifeCrit += 8;
            player.magicCrit += 8;
            player.meleeCrit += 8;
            player.thrownCrit += 8;
            player.rangedCrit += 8;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 6);
            recipe.AddTile(mod.GetTile("KnifeBench"));
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new SharpCastRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 3);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
