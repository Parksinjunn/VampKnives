using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;
using Terraria;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using static Terraria.ModLoader.ModContent;

namespace VampKnives.UI
{
    internal class WorkbenchSlotState : UIState
    {
        public static bool visible = false;
        public HammerSlot HammerSlot;
        public ChiselSlot ChiselSlot;
        public EntranceBackgroundPanel Background;
        public EntranceButton UpgradeButton;


        public override void OnInitialize()
        {
            Background = new EntranceBackgroundPanel();
            Background.BackgroundColor = Color.Black;
            Background.BorderColor = Color.DarkGray;
            Background.Left.Set(150,0);
            Background.Top.Set(270,0) ;
            Background.Height.Set(50f, 0);
            Background.Width.Set(50f, 0);
            base.Append(Background);

            UpgradeButton = new EntranceButton(ModContent.GetTexture("VampKnives/UI/ReforgeButton"), "Upgrade");
            UpgradeButton.VAlign = 0.5f;
            UpgradeButton.HAlign = 0.5f;
            UpgradeButton.Height.Set(32, 0f);
            UpgradeButton.Width.Set(32, 0f);
            UpgradeButton.OnClick += new MouseEvent(OnUpgradeHit);
            Background.Append(UpgradeButton);

            HammerSlot = new HammerSlot();
            HammerSlot.Left.Set(-110, 0);
            HammerSlot.Top.Set(-9, 0);
            Background.Append(HammerSlot);

            ChiselSlot = new ChiselSlot();
            ChiselSlot.Left.Set(-60, 0);
            ChiselSlot.Top.Set(-9, 0) ;
            Background.Append(ChiselSlot);


        }
        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            base.DrawSelf(spriteBatch);
            Main.HidePlayerCraftingMenu = false;
        }

        private void OnUpgradeHit(UIMouseEvent evt, UIElement listeningElement)
        {
            if (UpgradePanel.visible)
            {
                UpgradePanel.visible = false;
                Main.PlaySound(SoundID.MenuClose);
            }
            else if (UpgradePanel.visible == false)
            {
                UpgradePanel.visible = true;
                Main.PlaySound(SoundID.MenuOpen);
            }
        }
    }
}