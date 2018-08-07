using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.MaterialKnives
{
    public class OrichalcumKnives : KnifeItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Orichalcum Spikes");
            Tooltip.SetDefault("Uses Throwing Knives");
        }
        public override void SafeSetDefaults()
        {
            item.damage = 10;
            item.width = 32;
            item.height = 32;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = 1;
            item.noMelee = true;
            item.knockBack = 3;
            item.value = Item.sellPrice(0,2,76,30);
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
            recipe.AddIngredient(ItemID.OrichalcumBar, 8);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new KnifeCastRecipe(mod);
            recipe.AddIngredient(ItemID.OrichalcumBar, 6);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

}
