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

        public override void OnInitialize()
        {

            HammerSlot = new HammerSlot();
            base.Append(HammerSlot);

            ChiselSlot = new ChiselSlot();
            base.Append(ChiselSlot);


        }
        private bool tickPlayed;

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            const int slotX = 100;
            const int slotY = 255;
            int reforgeX = slotX + 70;
            int reforgeY = slotY + 40;
            bool hoveringOverReforgeButton = Main.mouseX > reforgeX - 15 && Main.mouseX < reforgeX + 15 && Main.mouseY > reforgeY - 15 && Main.mouseY < reforgeY + 15 && !PlayerInput.IgnoreMouseInterface;
            Texture2D reforgeTexture = Main.reforgeTexture[hoveringOverReforgeButton ? 1 : 0];
            Main.spriteBatch.Draw(reforgeTexture, new Vector2(reforgeX, reforgeY), null, Color.White, 0f, reforgeTexture.Size() / 2f, 0.8f, SpriteEffects.None, 0f);
            if (hoveringOverReforgeButton)
            {
                Main.hoverItemName = Language.GetTextValue("LegacyInterface.19");
                if (!tickPlayed)
                {
                    Main.PlaySound(SoundID.MenuTick, -1, -1, 1, 1f, 0f);
                }
                tickPlayed = true;
                Main.LocalPlayer.mouseInterface = true;
                if (Main.mouseLeftRelease && Main.mouseLeft)
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
            else
            {
                tickPlayed = false;
            }
        }
    }
}