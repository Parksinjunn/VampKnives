using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.MaterialKnives
{
    public class SilverKnives : KnifeItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Silver Knives");
            Tooltip.SetDefault("Uses Throwing Knives");
        }
        public override void SafeSetDefaults()
        {
            item.damage = 3;
            item.width = 32;
            item.height = 32;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = 1;
            item.noMelee = true;
            item.knockBack = 3;
            item.value = Item.sellPrice(0, 0, 12, 0);
            item.rare = 8;
            item.UseSound = SoundID.Item39;
            item.shoot = mod.ProjectileType("DartAnim");
            item.autoReuse = true;
            item.shootSpeed = 15f;
            item.useAmmo = mod.ItemType("ThrowingKnivesAmmo");
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
            recipe.AddIngredient(ItemID.SilverBar, 8);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new KnifeCastRecipe(mod);
            recipe.AddIngredient(ItemID.SilverBar, 6);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

}
