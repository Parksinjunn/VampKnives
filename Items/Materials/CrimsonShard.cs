using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.Materials
{
    public class CrimsonShard : ModItem
    {
        int stack;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crimson Shard");
            Tooltip.SetDefault("Parts to a bigger picture");
        }

        public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            if (stack == 1)
            {
                return true;
            }
            if(stack == 2)
            {
                Texture2D texture = mod.GetTexture("Items/Materials/CrimsonShard2");
                spriteBatch.Draw(texture, position, null, Color.White, 0, origin, scale, SpriteEffects.None, 0f);
                return false;
            }
            if(stack == 3)
            {
                Texture2D texture = mod.GetTexture("Items/Materials/CrimsonShard3");
                spriteBatch.Draw(texture, position, null, Color.White, 0, origin, scale, SpriteEffects.None, 0f);
                return false; 
            }
            if(stack == 4)
            {
                Texture2D texture = mod.GetTexture("Items/Materials/CrimsonShard4");
                spriteBatch.Draw(texture, position, null, Color.White, 0, origin, scale, SpriteEffects.None, 0f);
                return false;
            }
            if (stack == 5)
            {
                Item.NewItem(Main.LocalPlayer.getRect(), ModContent.ItemType<CrimsonCrystal>());

                return false;
            }
            else
                return true;
        }
        public override void UpdateInventory(Player player)
        {
            stack = item.stack;
            if (item.stack == 5)
            {
                item.SetDefaults(ModContent.ItemType<CrimsonCrystal>());
            }
            base.UpdateInventory(player);
        }
        public override void SetDefaults()
        {
            item.maxStack = 5;
            item.value = 1000;
            item.rare = 10;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("CorruptionShard"), 1);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}