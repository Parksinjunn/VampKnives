using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VampKnives.Items.Ammo;

namespace VampKnives.Items.MaterialKnives
{
    public class DemoniteKnives : KnifeMaterialItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Demonite Knives");
            Tooltip.SetDefault("Decreases the defense of hit enemies");
        }
        public override void SafeSetDefaults()
        {
            item.damage = 5;
            item.width = 32;
            item.height = 32;
            item.useTime = 15;
            item.useAnimation = 15;
            item.noUseGraphic = true;
            item.useStyle = 1;
            item.noMelee = true;
            item.knockBack = 3;
            item.value = Item.sellPrice(0, 0, 35, 40);
            item.rare = 8;
            item.UseSound = SoundID.Item39;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("DartAnim");
            item.shootSpeed = 15f;
            item.useAmmo = ModContent.ItemType<ThrowingKnivesAmmo>();
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
            KnifeCastRecipe recipe = new KnifeCastRecipe(mod);
            recipe.AddIngredient(ItemID.DemoniteBar, 8);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new KnifeCastRecipe(mod);
            recipe.AddIngredient(ItemID.DemoniteBar, 6);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

}
