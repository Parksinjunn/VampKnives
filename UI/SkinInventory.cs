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
    internal class SkinInventory : UIState
    {
        private VanillaItemSlotWrapper _vanillaItemSlot;
        public static bool IsBought = false;
        public static bool ItemPresent = false;
        public override void OnInitialize()
        {
            IsBought = false;
            _vanillaItemSlot = new VanillaItemSlotWrapper(ItemSlot.Context.BankItem, 0.85f)
            {
                Left = { Pixels = 50 },
                Top = { Pixels = 270 },
                ValidItemFunc = item => item.IsAir || !item.IsAir && (GetModItem(item.type) is Items.Accessories.VampNecklace)
            };
            // Here we limit the items that can be placed in the slot. We are fine with placing an empty item in or a non-empty item that can be prefixed. Calling Prefix(-3) is the way to know if the item in question can take a prefix or not.
            Append(_vanillaItemSlot);
        }

        // OnDeactivate is called when the UserInterface switches to a different state. In this mod, we switch between no state (null) and this state (ExamplePersonUI).
        // Using OnDeactivate is useful for clearing out Item slots and returning them to the player, as we do here.
        public override void OnDeactivate()
        {
            VampireNecklaceType VNType = Main.LocalPlayer.GetModPlayer<VampireNecklaceType>();
            if (IsBought && VNType.CheckHolding())
            {
                if (!_vanillaItemSlot.Item.IsAir)
                {
                    _vanillaItemSlot.Item.TurnToAir();
                }
            }
            else
            {
                    Main.LocalPlayer.QuickSpawnClonedItem(_vanillaItemSlot.Item, _vanillaItemSlot.Item.stack);
                    _vanillaItemSlot.Item.TurnToAir();
            }
        }

        // We use Update to handle automatically closing our UI when the player is no longer talking to our Example Person NPC.
        public override void Update(GameTime gameTime)
        {
            // Don't delete this or the UIElements attached to this UIState will cease to function.
            base.Update(gameTime);

            // talkNPC is the index of the NPC the player is currently talking to. By checking talkNPC, we can tell when the player switches to another NPC or closes the NPC chat dialog.
            if (Main.LocalPlayer.talkNPC == -1 || Main.npc[Main.LocalPlayer.talkNPC].type != NPCType<VampireNPC>())
            {
                // When that happens, we can set the state of our UserInterface to null, thereby closing this UIState. This will trigger OnDeactivate above.
                GetInstance<VampKnives>().VampireUserInterface.SetState(null);
                GetInstance<VampKnives>().VampireUserInterface2.SetState(null);
            }
        }

        private bool tickPlayed;
        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            base.DrawSelf(spriteBatch);

            Main.HidePlayerCraftingMenu = true;

            if (!_vanillaItemSlot.Item.IsAir)
            {
                if (ItemLoader.PreReforge(_vanillaItemSlot.Item))
                {
                    GetInstance<VampKnives>().VampireUserInterface2.SetState(new UI.SkinInventory2());
                }
            }
            else
            {
                GetInstance<VampKnives>().VampireUserInterface2.SetState(null);
            }
        }
    }
}