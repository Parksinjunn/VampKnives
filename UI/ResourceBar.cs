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
    internal enum ResourceBarMode
    {
        BP
    }
    class ResourceBar : UIElement
    {
        private ResourceBarMode stat;
        private float width;
        private float height;
        private UIImage currentBar;
        private UIImageFramed OpacityLayer;
        private UIText text;
        public float percentage=0;
        public int frameCounter;
        public int frame;
        public int direction=1;
        public float calc;

        public ResourceBar(ResourceBarMode stat, int height, int width)
        {
            this.stat = stat;
            this.width = width;
            this.height = height;
        }

        public override void OnInitialize()
        {
            Height.Set(height, 0f);
            Width.Set(width, 0f);

            text = new UIText("0");
            text.Width.Set(width, 0f);
            text.Height.Set(height, 0f);
            text.Top.Set(height / 2 + text.MinHeight.Pixels / 2, 0f);

            base.Append(text);
        }
        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            ExamplePlayer p = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();

            calc = (p.VampCurrent / p.VampMax);
            if (calc > 1)
                calc = 1;
            if(percentage < calc)
            percentage += 0.007f;
            if (percentage > calc)
                percentage = calc;

            if (percentage > 1)
                percentage = 1;
            //Main.NewText("Percentage: "+percentage + "  Calc: " + calc);
            var innerDimensionsRectangle = GetDimensions().ToRectangle();
            Vector2 drawPosition = innerDimensionsRectangle.BottomLeft() - new Vector2(0, innerDimensionsRectangle.Height * percentage);
            Rectangle sourceRectangle = new Rectangle(0, 0, innerDimensionsRectangle.Width, (int)(innerDimensionsRectangle.Height * percentage));


            frameCounter++; //increase the frameCounter by one
            if (frameCounter >= 7) //once the frameCounter has reached 3 - change the 10 to change how fast the projectile animates
            {
                frameCounter = 0; //reset the counter
                if (frame > 3) //if past the last frame
                    direction = -1; //go back to the first frame
                if (frame < 1)
                    direction = 1;
                frame += direction; //go to the next frame
            }
            //Main.NewText("" + frame);
            if (frame == 0)
                Main.spriteBatch.Draw(ModLoader.GetTexture("VampKnives/UI/0"), drawPosition, sourceRectangle, Color.White);
            if (frame == 1)
                Main.spriteBatch.Draw(ModLoader.GetTexture("VampKnives/UI/1"), drawPosition, sourceRectangle, Color.White);
            if (frame == 2)
                Main.spriteBatch.Draw(ModLoader.GetTexture("VampKnives/UI/2"), drawPosition, sourceRectangle, Color.White);
            if (frame == 3)
                Main.spriteBatch.Draw(ModLoader.GetTexture("VampKnives/UI/3"), drawPosition, sourceRectangle, Color.White);
            if (frame == 4)
                Main.spriteBatch.Draw(ModLoader.GetTexture("VampKnives/UI/4"), drawPosition, sourceRectangle, Color.White);
        }
        public override void Update(GameTime gameTime)
        {
            ExamplePlayer p = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
            switch (stat)
            {
                case ResourceBarMode.BP:
                    text.SetText("" + (int)(calc * p.VampMax));
                    break;

                default:
                    break;
            }
            base.Update(gameTime);
        }
    }
}