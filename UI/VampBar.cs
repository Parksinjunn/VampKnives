using Terraria.UI;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace VampKnives.UI
{
    internal class VampBar : UIState
    {
        public static bool visible = false;
        public UIPanel VampMainPanel;
        public UIPanel RecipePage;

        public override void OnInitialize()
        {

            VampMainPanel = new UIPanel();
            VampMainPanel.SetPadding(0);
            VampMainPanel.Left.Set(Main.screenWidth - Main.screenWidth / 4, 0f);
            VampMainPanel.Top.Set(0f, 0f);
            VampMainPanel.Width.Set(55f, 0f);
            VampMainPanel.Height.Set(88f, 0f);
            VampMainPanel.BackgroundColor = new Color(0, 0, 0);

            VampMainPanel.OnMouseDown += new UIElement.MouseEvent(DragStart);
            VampMainPanel.OnMouseUp += new UIElement.MouseEvent(DragEnd);

            var BgTexture = ModContent.GetTexture("VampKnives/UI/VampBarBg");
            UIImage VampBarBg = new UIImage(BgTexture);
            VampBarBg.Width.Set(57, 0f);
            VampBarBg.Height.Set(93, 0f);

            var BarTexture = ModContent.GetTexture("VampKnives/UI/VampBar");
            UIImage VampBar = new UIImage(BarTexture);
            VampBar.Width.Set(57, 0f);
            VampBar.Height.Set(93, 0f);

            //UIFlatPanel barBackground = new UIFlatPanel();
            //barBackground.Left.Set(0f, 0f);
            //barBackground.Top.Set(0f, 0f);
            //barBackground.BackgroundColor = new Color(55, 0, 0, 255);
            //barBackground.Width.Set(55, 0f);
            //barBackground.Height.Set(88, 0f);
            VampMainPanel.Append(VampBarBg);

            ResourceBar bp = new ResourceBar(ResourceBarMode.BP, 88, 55);
            bp.Left.Set(0f, 0f);
            bp.Top.Set(0f, 0f);
            VampMainPanel.Append(bp);

            VampMainPanel.Append(VampBar);

            RecipePage = new UIPanel();
            RecipePage.Left.Set(Main.screenWidth + Main.screenHeight / 2, 0f);
            RecipePage.Width.Set(800f,0f);
            RecipePage.Height.Set(1080f, 0f);

            var RecipePageTexture = ModContent.GetTexture("VampKnives/UI/RecipePaper");
            UIImage RecipePageTex = new UIImage(RecipePageTexture);
            RecipePageTex.Width.Set(800f, 0f);
            RecipePageTex.Height.Set(1080f, 0f);
            RecipePage.Append(RecipePageTex);
            base.Append(VampMainPanel);
        }

        Vector2 offset;
        public bool dragging = false;
        private void DragStart(UIMouseEvent evt, UIElement listeningElement)
        {
            offset = new Vector2(evt.MousePosition.X - VampMainPanel.Left.Pixels, evt.MousePosition.Y - VampMainPanel.Top.Pixels);
            dragging = true;
        }

        private void DragEnd(UIMouseEvent evt, UIElement listeningElement)
        {
            Vector2 end = evt.MousePosition;
            dragging = false;

            VampMainPanel.Left.Set(end.X - offset.X, 0f);
            VampMainPanel.Top.Set(end.Y - offset.Y, 0f);

            Recalculate();
        }
        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            Vector2 MousePosition = new Vector2((float)Main.mouseX, (float)Main.mouseY);
            if (VampMainPanel.ContainsPoint(MousePosition))
            {
                Main.LocalPlayer.mouseInterface = true;
            }
            if (dragging)
            {
                VampMainPanel.Left.Set(MousePosition.X - offset.X, 0f);
                VampMainPanel.Top.Set(MousePosition.Y - offset.Y, 0f);
                Recalculate();
            }
        }
    }
}