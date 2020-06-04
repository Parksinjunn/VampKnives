using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.MaterialKnives
{
    public class TitaniumKnives : KnifeMaterialItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Titanium Knives");
        }
        public override void SafeSetDefaults()
        {
            item.damage = 12;
            item.width = 48;
            item.height = 48;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = 1;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.knockBack = 3;
            item.value = Item.sellPrice(0, 3, 85, 60);
            item.rare = 8;
            item.UseSound = SoundID.Item39;
            item.shoot = mod.ProjectileType("TitaniumProj");
            item.autoReuse = true;
            item.shootSpeed = 15f;
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
            recipe.AddIngredient(ItemID.TitaniumBar, 8);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new KnifeCastRecipe(mod);
            recipe.AddIngredient(ItemID.TitaniumBar, 6);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

}
