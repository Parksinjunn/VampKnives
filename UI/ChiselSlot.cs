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
using VampKnives.Items.Accessories;

namespace VampKnives.UI
{
    internal class ChiselSlot : UIState
    {
        private VanillaItemSlotWrapper _vanillaItemSlot;
        public static bool ItemPresent = false;
        public override void OnInitialize()
        {
            _vanillaItemSlot = new VanillaItemSlotWrapper(ItemSlot.Context.BankItem, 0.85f)
            {
                Left = { Pixels = 100 },
                Top = { Pixels = 270 },
                HoverText = "Chisel Slot",
                ValidItemFunc = item => item.IsAir || !item.IsAir && (GetModItem(item.type) is Items.Materials.Chisel)
            };
            // Here we limit the items that can be placed in the slot. We are fine with placing an empty item in or a non-empty item that can be prefixed. Calling Prefix(-3) is the way to know if the item in question can take a prefix or not.
            Append(_vanillaItemSlot);
        }

        private bool tickPlayed;
        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            base.DrawSelf(spriteBatch);

            Main.HidePlayerCraftingMenu = false;

            if (!_vanillaItemSlot.Item.IsAir)
            {
                VampKnives.ChiselInSlot = true;

            }
            else
            {
                VampKnives.ChiselInSlot = false;
            }
        }
    }
}