using Terraria.UI;
using Terraria.GameContent.UI.Elements;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace VampKnives.UI
{
    internal class StartupBookUI : UIState
    {
        public static bool visible = false;
        public EntranceButton WikiButton;
        public EntranceButton DiscordButton;
        public UIImage StartupPage;
        public static bool IsStartupBook;

        int TextureWidth = 1310;
        int TextureHeight = 730;

        public override void OnInitialize()
        {
            StartupPage = new UIImage(ModContent.GetTexture("VampKnives/UI/StartupBook0"));
            StartupPage.Width.Set(TextureWidth, 0f);
            StartupPage.Height.Set(TextureHeight, 0f);
            StartupPage.HAlign = StartupPage.VAlign = 0.5f; // 1

            WikiButton = new EntranceButton(ModContent.GetTexture("VampKnives/UI/WikiButton"), "Close the UI");
            WikiButton.VAlign = 0.295f;
            WikiButton.HAlign = 0.755f;
            WikiButton.Width.Set(84, 0f);
            WikiButton.Height.Set(26, 0f);
            WikiButton.OnClick += new MouseEvent(WikiButtonClicked);

            DiscordButton = new EntranceButton(ModContent.GetTexture("VampKnives/UI/DiscordButton"), "Close the UI");
            DiscordButton.VAlign = 0.481f;
            DiscordButton.HAlign = 0.645f;
            DiscordButton.Width.Set(105, 0f);
            DiscordButton.Height.Set(26, 0f);
            DiscordButton.OnClick += new MouseEvent(DiscordButtonClicked);

            StartupPage.Append(DiscordButton);
            StartupPage.Append(WikiButton);
            base.Append(StartupPage);
        }
        private void WikiButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            System.Diagnostics.Process.Start("https://docs.google.com/document/d/1kVwmvvQcZPYC08ncjWf0Gw8YqshHZC5BTo0eOPckjOs/edit?usp=sharing");
        }
        private void DiscordButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            System.Diagnostics.Process.Start("https://discord.gg/vzQHD6PfkD");
        }
    }
}