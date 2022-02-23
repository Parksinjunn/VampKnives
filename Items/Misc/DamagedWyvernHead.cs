using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VampKnives.Items.Misc
{
    public class DamagedWyvernHead : ModItem
    {
        int stack;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Damaged Wyvern Head");
            //Tooltip.SetDefault("");
        }
        public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            if (stack == 1)
            {
                return true;
            }
            if (stack == 2)
            {
                Texture2D texture = mod.GetTexture("Items/Misc/DamagedWyvernHead1");
                spriteBatch.Draw(texture, position, null, Color.White, 0, origin, scale, SpriteEffects.None, 0f);
                return false;
            }
            if (stack == 3)
            {
                Texture2D texture = mod.GetTexture("Items/Misc/DamagedWyvernHead2");
                spriteBatch.Draw(texture, position, null, Color.White, 0, origin, scale, SpriteEffects.None, 0f);
                return false;
            }
            if (stack == 4)
            {
                Texture2D texture = mod.GetTexture("Items/Misc/DamagedWyvernHead3");
                spriteBatch.Draw(texture, position, null, Color.White, 0, origin, scale, SpriteEffects.None, 0f);
                return false;
            }
            if(stack >= 5)
            {
                Texture2D texture = mod.GetTexture("Items/Misc/DamagedWyvernHead4");
                spriteBatch.Draw(texture, position, null, Color.White, 0, origin, scale, SpriteEffects.None, 0f);
                return false;
            }
            else
                return true;
        }
        public override void UpdateInventory(Player player)
        {
            stack = item.stack;
            base.UpdateInventory(player);
        }
        public override void SetDefaults()
        {
            item.maxStack = 30;
            item.value = Item.sellPrice(0, 0, 50, 0);
            item.rare = 11;
        }
    }
}