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

namespace VampKnives.Items.MaterialKnives
{
    public class ChlorophyteKnives : KnifeItem
    {
        public override void SetStaticDefaults()
        {
                DisplayName.SetDefault("Chlorophyte Knives");
                Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(15, 10));
        }
        public override void SafeSetDefaults()
        {
            item.damage = 15;
            item.width = 34;
            item.height = 34;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = 1;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.knockBack = 3;
            item.value = Item.sellPrice(0, 4, 30, 20);
            item.rare = 8;
            item.UseSound = SoundID.Item39;
            item.shoot = mod.ProjectileType("ChlorophyteProj");
            item.autoReuse = true;
            item.shootSpeed = 15f;
        }

        public override void AddRecipes()
        {
            KnifeCastRecipe recipe = new KnifeCastRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 8);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new KnifeCastRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 6);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

}
