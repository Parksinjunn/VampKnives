using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using static Terraria.ModLoader.ModContent;

namespace VampKnives.UI
{
    internal class EntranceDamageSettingsPanel : UIState
    {
        public static bool visible = true;
        public EntranceButton Legacy;
        public EntranceButton Normal;
        public EntranceButton Unforgiving;
        public EntranceBackgroundPanel Background;

        float BackgroundWidth = 400f;
        float BackgroundHeight = 100f;

        public override void OnInitialize()
        {
            Background = new EntranceBackgroundPanel();

            Background.BackgroundColor = Color.Black;
            Background.BorderColor = Color.Red;
            Background.Top.Set(Main.screenHeight/2 - (BackgroundHeight/2), 0f);
            Background.Width.Set(BackgroundWidth,0f);
            Background.Height.Set(BackgroundHeight, 0f);
            Background.Left.Set(Main.screenWidth - ((Main.screenWidth / 2) + (BackgroundWidth / 2)), 0f);
            base.Append(Background);

            Texture2D LegacyButtonTexture = ModContent.GetTexture("VampKnives/UI/Legacy");
            Legacy = new EntranceButton(LegacyButtonTexture, "Play with the previous values of high health and low damage");
            Legacy.Left.Set((BackgroundWidth * 0.333333f)/1.3f - 32, 0f);
            Legacy.Top.Set((BackgroundHeight/2) - 32, 0f);
            Legacy.Width.Set(32, 0f);
            Legacy.Height.Set(32, 0f);
            // UIHoverImageButton doesn't do anything when Clicked. Here we assign a method that we'd like to be called when the button is clicked.
            Legacy.OnClick += new MouseEvent(LegacyButtonClicked);
            Background.Append(Legacy);

            Texture2D NormalButtonTexture = ModContent.GetTexture("VampKnives/UI/Normal");
            Normal = new EntranceButton(NormalButtonTexture, "Play with the new values of high damage and lowered life-steal. \n This is the recommended setting and the most balanced");
            Normal.Left.Set((BackgroundWidth * 0.6666666666f)/1.3f - 32, 0f);
            Normal.Top.Set((BackgroundHeight / 2) - 40, 0f);
            Normal.Width.Set(32, 0f);
            Normal.Height.Set(40, 0f);
            // UIHoverImageButton doesn't do anything when Clicked. Here we assign a method that we'd like to be called when the button is clicked.
            Normal.OnClick += new MouseEvent(NormalButtonClicked);
            Background.Append(Normal);

            Texture2D UnforgivingButtonTexture = ModContent.GetTexture("VampKnives/UI/Unforgiving");
            Unforgiving = new EntranceButton(UnforgivingButtonTexture, "Weapons have lower damage and life steal, and armor piercing is reduced greatly");
            Unforgiving.Left.Set((BackgroundWidth * 1f)/1.3f - 40, 0f);
            Unforgiving.Top.Set((BackgroundHeight / 2) - 48, 0f);
            Unforgiving.Width.Set(40, 0f);
            Unforgiving.Height.Set(48, 0f);
            // UIHoverImageButton doesn't do anything when Clicked. Here we assign a method that we'd like to be called when the button is clicked.
            Unforgiving.OnClick += new MouseEvent(UnforgivingButtonClicked);
            Background.Append(Unforgiving);

        }
        private void LegacyButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            VampKnives.ChosenDifficulty = true;
            VampKnives.Legacy = true;
            VampKnives.Normal = false;
            VampKnives.Unforgiving = false;
            visible = false;
        }
        private void NormalButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            VampKnives.ChosenDifficulty = true;
            VampKnives.Legacy = false;
            VampKnives.Normal = true;
            VampKnives.Unforgiving = false;
            visible = false;
        }
        private void UnforgivingButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            VampKnives.ChosenDifficulty = true;
            VampKnives.Legacy = false;
            VampKnives.Normal = false;
            VampKnives.Unforgiving = true;
            visible = false;
        }
    }
}