using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.MaterialKnives
{
    public class DemoniteKnives : KnifeItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Demonite Knives");
            Tooltip.SetDefault("Uses Throwing Knives");
        }
        public override void SafeSetDefaults()
        {
            item.damage = 5;
            item.width = 32;
            item.height = 32;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = 1;
            item.noMelee = true;
            item.knockBack = 3;
            item.value = Item.sellPrice(0, 0, 35, 40);
            item.rare = 8;
            item.UseSound = SoundID.Item39;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("DartAnim");
            item.shootSpeed = 15f;
            item.useAmmo = mod.ItemType("ThrowingKnivesAmmo");
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
