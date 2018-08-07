using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VampKnives.Items.Materials
{
    public class CorruptionShard : ModItem
    {
        int stack;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Corruption Shard");
            Tooltip.SetDefault("Parts to a bigger picture");
        }
        public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            if (stack == 1)
            {
                return true;
            }
            if (stack == 2)
            {
                Texture2D texture = mod.GetTexture("Items/Materials/CorruptionShard2");
                spriteBatch.Draw(texture, position, null, Color.White, 0, origin, scale, SpriteEffects.None, 0f);
                return false;
            }
            if (stack == 3)
            {
                Texture2D texture = mod.GetTexture("Items/Materials/CorruptionShard3");
                spriteBatch.Draw(texture, position, null, Color.White, 0, origin, scale, SpriteEffects.None, 0f);
                return false;
            }
            if (stack == 4)
            {
                Texture2D texture = mod.GetTexture("Items/Materials/CorruptionShard4");
                spriteBatch.Draw(texture, position, null, Color.White, 0, origin, scale, SpriteEffects.None, 0f);
                return false;
            }
            if (stack >= 5)
            {
                Item.NewItem(Main.LocalPlayer.getRect(), mod.ItemType("CorruptionCrystal"));

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
                item.SetDefaults(mod.ItemType("CorruptionCrystal"));
            }
            base.UpdateInventory(player);
        }
        public override void SetDefaults()
        {
            item.maxStack = 5;
            item.value = Item.sellPrice(0,0,10,0);
            item.rare = 11;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("CrimsonShard"), 1);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}