using Terraria.UI;
using Terraria.GameContent.UI.Elements;
using VampKnives.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using System;

namespace VampKnives.UI
{
    class TestUI : UIElement
    {
        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            ExamplePlayer p = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
            float percentage = (p.VampCurrent/p.VampMax);
            //Main.NewText("Percentage: "+percentage + "  VampCurrent: " + p.VampCurrent + "  VampMax: " + p.VampMax);
            var innerDimensionsRectangle = GetDimensions().ToRectangle();
            Vector2 drawPosition = innerDimensionsRectangle.BottomLeft() - new Vector2(0, innerDimensionsRectangle.Height * percentage);
            Rectangle sourceRectangle = new Rectangle(0, 0, innerDimensionsRectangle.Width, (int)(innerDimensionsRectangle.Height * percentage));
            Main.spriteBatch.Draw(ModLoader.GetTexture("VampKnives/UI/VampBarFiller"), drawPosition, sourceRectangle, Color.White);
        } 
    }
}