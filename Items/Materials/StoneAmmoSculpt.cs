using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VampKnives.Items.Materials
{
    public class StoneAmmoSculpt : ModItem
    {
        int stack;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sculpted knife ammo");
            Tooltip.SetDefault("Combining five of these sculpts will producea set of knife sculpts fit for a cast");
        }
        public override void HoldItem(Player player)
        {
            stack = item.stack;
        }
        public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            if (stack == 1)
            {
                return true;
            }
            if (stack == 2)
            {
                Texture2D texture = mod.GetTexture("Items/Materials/StoneAmmoSculpt2");
                spriteBatch.Draw(texture, position, null, Color.White, 0, origin, scale, SpriteEffects.None, 0f);
                return false;
            }
            if (stack == 3)
            {
                Texture2D texture = mod.GetTexture("Items/Materials/StoneAmmoSculpt3");
                spriteBatch.Draw(texture, position, null, Color.White, 0, origin, scale, SpriteEffects.None, 0f);
                return false;
            }
            if (stack == 4)
            {
                Texture2D texture = mod.GetTexture("Items/Materials/StoneAmmoSculpt4");
                spriteBatch.Draw(texture, position, null, Color.White, 0, origin, scale, SpriteEffects.None, 0f);
                return false;
            }
            if (stack >= 5)
            {
                Item.NewItem(Main.LocalPlayer.getRect(), ModContent.ItemType<StoneAmmoSculptComplete>());

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
                item.SetDefaults(ModContent.ItemType<StoneAmmoSculptComplete>());
            }
            base.UpdateInventory(player);
        }
        public override void SetDefaults()
        {
            item.maxStack = 5;
            item.value = Item.sellPrice(0,0,0,0);
            item.rare = -1;
        }

        public override void AddRecipes()
        {
            ChiselRecipe recipeC = new ChiselRecipe(mod);
            recipeC.AddIngredient(ItemID.StoneBlock, 6);
            recipeC.SetResult(this);
            recipeC.AddRecipe();

            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 6);
            recipe.AddTile(mod.GetTile("KnifeBench"));
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 4);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}