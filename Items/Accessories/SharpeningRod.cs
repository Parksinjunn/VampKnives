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
    public class SharpeningRod : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sharpening Rod");
            Tooltip.SetDefault("30% increase knife damage"+
                "\n15% increased knife critical strike chance");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.rare = 2;
            item.accessory = true;
            item.value = Item.sellPrice(0, 3, 50, 0);
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            KnifeDamagePlayer modPlayer = KnifeDamagePlayer.ModPlayer(player);
            modPlayer.knifeDamageMult += 0.3f;
            modPlayer.KnifeCrit += 15;
            crafted = true;
        }
        public override bool CloneNewInstances
        {
            get
            {
                return true;
            }
        }
        public bool crafted;
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
        ExamplePlayer p = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
            TooltipLine line = new TooltipLine(mod, "Face", "Requires a Knife Cast");
            line.overrideColor = new Color(86, 86, 86);
            if (crafted == false)
                tooltips.Add(line);
        }
        public override void OnCraft(Recipe recipe)
        {
            crafted = true;
        }
        public override void UpdateInventory(Player player)
        {
            crafted = true;
        }
        public override void AddRecipes()
        {
            SharpCastRecipe recipe = new SharpCastRecipe(mod);
            recipe.AddIngredient(ItemID.LunarBar, 6);
            recipe.AddTile(mod.GetTile("KnifeBench"));
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new SharpCastRecipe(mod);
            recipe.AddIngredient(ItemID.LunarBar, 3);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
