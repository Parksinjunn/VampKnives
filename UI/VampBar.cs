using Terraria.UI;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace VampKnives.UI
{
    internal class VampBar : UIState
    {
        public static bool visible = false;
        public UIPanel VampMainPanel;
        public UIPanel BloodPointsCounter;
        public UIText BloodPointsNum;
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

            BloodPointsCounter = new UIPanel();
            //BloodPointsCounter.SetPadding(0);
            BloodPointsCounter.HAlign = 0.5f;
            BloodPointsCounter.VAlign = 1.3f;
            BloodPointsCounter.Width.Set(200f, 0f);
            BloodPointsCounter.Height.Set(20f, 0f);
            BloodPointsCounter.BackgroundColor = new Color(0, 0, 0);
            VampMainPanel.Append(BloodPointsCounter);

            BloodPointsNum = new UIText("");
            BloodPointsNum.HAlign = 0.5f;
            BloodPointsNum.VAlign = 0.5f;
            BloodPointsCounter.Append(BloodPointsNum);


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
            base.Append(VampMainPanel);
        }
        public override void Update(GameTime gameTime)
        {
            VampPlayer p = Main.LocalPlayer.GetModPlayer<VampPlayer>();
            if(p.BloodPoints <= 9999)
                BloodPointsNum.SetText("" + p.BloodPoints);
            else if (p.BloodPoints > 9999)
                BloodPointsNum.SetText("" + Math.Truncate((double)(p.BloodPoints/1000)) + "K");
            else if (p.BloodPoints > 999999)
                BloodPointsNum.SetText("" + Math.Truncate((double)(p.BloodPoints / 1000000)) + "M");
            base.Update(gameTime);
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