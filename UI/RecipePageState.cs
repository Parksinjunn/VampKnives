using Terraria.UI;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace VampKnives.UI
{
    internal class RecipePageState : UIState
    {
        public static bool visible = false;
        public UIElement RecipePage;

        public static bool IsKnifeRecipe;
        public static bool IsAmmoRecipe;
        public static bool IsSharpeningRodRecipe;
        public static bool IsPlateRecipe;
        public static bool IsAmmoSculptRecipe;
        public static bool IsKnifeSculptRecipe;
        public static bool IsSharpeningSculptRecipe;

        int TextureWidth = 730;
        int TextureHeight = 1050;


        public override void OnInitialize()
        {
            RecipePage = new UIElement();
            RecipePage.Top.Set(0f, 0f);
            RecipePage.Width.Set(TextureWidth, 0f);
            RecipePage.Height.Set(TextureHeight, 0f);
            RecipePage.Left.Set(Main.screenWidth - ((Main.screenWidth / 2) + (TextureWidth/2)), 0f);
            base.Append(RecipePage);
        }
        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            Vector2 drawPosition = new Vector2(Main.screenWidth - ((Main.screenWidth / 2) + (TextureWidth / 2)), 0f);
            Rectangle sourceRectangle = new Rectangle(0, 0, TextureWidth, TextureHeight);
            if (IsKnifeRecipe)
                Main.spriteBatch.Draw(ModContent.GetTexture("VampKnives/UI/OldPaperKnifeCastHQ"), drawPosition, sourceRectangle, Color.White);
            if (IsAmmoRecipe)
                Main.spriteBatch.Draw(ModContent.GetTexture("VampKnives/UI/OldPaperKnifeAmmoCastHQ"), drawPosition, sourceRectangle, Color.White);
            if(IsSharpeningRodRecipe)
                Main.spriteBatch.Draw(ModContent.GetTexture("VampKnives/UI/OldPaperSharpeningRodCastHQ"), drawPosition, sourceRectangle, Color.White);
            if (IsPlateRecipe)
                Main.spriteBatch.Draw(ModContent.GetTexture("VampKnives/UI/RecipeCastHQ"), drawPosition, sourceRectangle, Color.White);
            if (IsAmmoSculptRecipe)
                Main.spriteBatch.Draw(ModContent.GetTexture("VampKnives/UI/StoneAmmoSculptRecipe"), drawPosition, sourceRectangle, Color.White);
            if (IsKnifeSculptRecipe)
                Main.spriteBatch.Draw(ModContent.GetTexture("VampKnives/UI/StoneSculptRecipeHQ"), drawPosition, sourceRectangle, Color.White);
            if (IsSharpeningSculptRecipe)
                Main.spriteBatch.Draw(ModContent.GetTexture("VampKnives/UI/StoneRodSculptRecipe"), drawPosition, sourceRectangle, Color.White);

            base.DrawSelf(spriteBatch);
        }
    }
}