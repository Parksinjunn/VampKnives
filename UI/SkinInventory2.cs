using VampKnives.NPCs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria.UI.Chat;
using static Terraria.ModLoader.ModContent;

namespace VampKnives.UI
{
    internal class SkinInventory2 : UIState
    {
        private SkinInventoryItemSlots _vanillaItemSlot;

        public override void OnInitialize()
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 2; y++)
                {
                    int ItemType = 8*y+x;
                    _vanillaItemSlot = new SkinInventoryItemSlots(ItemType, ItemSlot.Context.ChestItem, 0.85f)
                    {
                        Left = { Pixels = 20 + (x * 50) },
                        Top = { Pixels = 500 + (y * 50) },
                        ValidItemFunc = item => item.IsAir || !item.IsAir
                    };
                    Append(_vanillaItemSlot);
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            if(Main.LocalPlayer.talkNPC == 0)
            {
                GetInstance<VampKnives>().VampireUserInterface2.SetState(null);
            }
            base.Update(gameTime);
        }

        private bool tickPlayed;
        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            base.DrawSelf(spriteBatch);

            Main.HidePlayerCraftingMenu = true;

            //const int slotX = 50;
            //const int slotY = 270;
            //if (!_vanillaItemSlot.Item.IsAir)
            //{

            //}
            //else
            //{

            //}
        }
    }
}