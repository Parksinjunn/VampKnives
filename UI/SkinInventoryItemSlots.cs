using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameInput;
using Terraria.ModLoader;
using Terraria.UI;
using VampKnives.NPCs;
using static Terraria.ModLoader.ModContent;
using VampKnives.Items.Accessories;

namespace VampKnives.UI
{
    internal class SkinInventoryItemSlots : UIElement
    {
        public delegate Item GetItem(int slot, ref int context);
        private GetItem getItem;
        internal Item Item;

        private readonly int _context;
        private readonly float _scale;
        internal Func<Item, bool> ValidItemFunc;

        public SkinInventoryItemSlots(int Iteration, int context = ItemSlot.Context.ShopItem, float scale = 1f)
        {
            VampireNecklaceType VNType = Main.LocalPlayer.GetModPlayer<VampireNecklaceType>();
            _context = ItemSlot.Context.ShopItem;
            _scale = scale;
            Item = new Item();
            Main.NewText("" + context);

            switch(Iteration)
            {
                case 0:
                    if (VNType.PlayerProgress >= 1)
                        Item.SetDefaults(ModContent.ItemType<Items.Accessories.VampNecklaces.VampNecklaceSlime>());
                    break;
                case 1:
                    if (VNType.PlayerProgress >= 2)
                        Item.SetDefaults(ModContent.ItemType<Items.Accessories.VampNecklaces.VampNecklaceEye>());
                    break;
                case 2:
                    if (VNType.PlayerProgress >= 3)
                        Item.SetDefaults(ModContent.ItemType<Items.Accessories.VampNecklaces.VampNecklaceEow>());
                    break;
                case 3:
                    if (VNType.PlayerProgress >= 3)
                    {
                        Item.SetDefaults(ModContent.ItemType<Items.Accessories.VampNecklaces.VampNecklaceBrain>());
                    }
                    break;
                case 4:
                    if (VNType.PlayerProgress >= 4)
                    {
                        Item.SetDefaults(ModContent.ItemType<Items.Accessories.VampNecklaces.VampNecklaceBee>());
                    }
                    break;
                case 5:
                    if (VNType.PlayerProgress >= 5)
                        Item.SetDefaults(ModContent.ItemType<Items.Accessories.VampNecklaces.VampNecklaceSkeletron>());
                    break;
                case 6:
                    if (VNType.PlayerProgress >= 6)
                        Item.SetDefaults(ModContent.ItemType<Items.Accessories.VampNecklaces.VampNecklaceWof>());
                    break;
                case 7:
                    if (VNType.PlayerProgress >= 7)
                        Item.SetDefaults(ModContent.ItemType<Items.Accessories.VampNecklaces.VampNecklaceDestroyer>());
                    break;
                case 8:
                    if (VNType.PlayerProgress >= 8)
                        Item.SetDefaults(ModContent.ItemType<Items.Accessories.VampNecklaces.VampNecklaceTwins>());
                    break;
                case 9:
                    if (VNType.PlayerProgress >= 9)
                        Item.SetDefaults(ModContent.ItemType<Items.Accessories.VampNecklaces.VampNecklaceSkeletronPrime>());
                    break;
                case 10:
                    if (VNType.PlayerProgress >= 10)
                        Item.SetDefaults(ModContent.ItemType<Items.Accessories.VampNecklaces.VampNecklacePlantera>());
                    break;
                case 11:
                    if (VNType.PlayerProgress >= 11)
                        Item.SetDefaults(ModContent.ItemType<Items.Accessories.VampNecklaces.VampNecklaceGolem>());
                    break;
                case 12:
                    if (VNType.PlayerProgress >= 12)
                        Item.SetDefaults(ModContent.ItemType<Items.Accessories.VampNecklaces.VampNecklaceDukeFishron>());
                    break;
                case 13:
                    if (VNType.PlayerProgress >= 13)
                        Item.SetDefaults(ModContent.ItemType<Items.Accessories.VampNecklaces.VampNecklaceCultist>());
                    break;
                case 14:
                    if (VNType.PlayerProgress >= 14)
                        Item.SetDefaults(ModContent.ItemType<Items.Accessories.VampNecklaces.VampNecklaceMoonLord>());
                    break;
                case 15:
                    Item.SetDefaults(ModContent.ItemType<Items.Accessories.VampNecklace>());
                    break;
                default:
                    Item.SetDefaults(0);
                    break;
            }
            Width.Set(Main.inventoryBack9Texture.Width * scale, 0f);
            Height.Set(Main.inventoryBack9Texture.Height * scale, 0f);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            //float oldScale = Main.inventoryScale;
            Main.inventoryScale = _scale;
            Rectangle rectangle = GetDimensions().ToRectangle();

            if (ContainsPoint(Main.MouseScreen) && !PlayerInput.IgnoreMouseInterface)
            {
                Main.LocalPlayer.mouseInterface = true;
                if (ValidItemFunc == null || ValidItemFunc(Main.mouseItem))
                {
                    ItemSlot.Handle(ref Item, _context);
                    if (Main.mouseLeftRelease && Main.mouseLeft)
                    {
                        SkinInventory.IsBought = true;
                        GetInstance<VampKnives>().VampireUserInterface.SetState(null);
                        GetInstance<VampKnives>().VampireUserInterface2.SetState(null);
                        Main.LocalPlayer.talkNPC = 0;
                    }
                }
            }
            Vector2 sideMove = new Vector2(50, 0);
            Vector2 downMove = new Vector2(0, 50);
            ItemSlot.Draw(spriteBatch, ref Item, _context, rectangle.TopLeft());

            //Main.inventoryScale = oldScale;
        }
    }
}