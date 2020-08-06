using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using VampKnives.Items;
using VampKnives.Tiles;
using static Terraria.ModLoader.ModContent;

namespace VampKnives.UI
{
    internal class BloodAltarUI : UIState
    {
        public static bool visible = false;
        public EntranceButton UpgradeSharpnessButton;
        public EntranceBackgroundPanel Background;
        public UIFlatPanel centerTest;
        public UIImage DamageItem;
        private VanillaItemSlotWrapper _vanillaItemSlot;

        Vector2 ButtonSize = new Vector2(256, 64);

        float BackgroundWidth = 400f;
        float BackgroundHeight = 700f;
        int TextOffset = 35;

        public override void OnInitialize()
        {
            Background = new EntranceBackgroundPanel();

            Background.BackgroundColor = Color.Black;
            Background.BorderColor = Color.DarkGray;
            Background.Width.Set(BackgroundWidth, 0f);
            Background.Height.Set(BackgroundHeight, 0f);
            Background.HAlign = 0.7f; // 1
            Background.VAlign = 0.5f;
            base.Append(Background);

            _vanillaItemSlot = new VanillaItemSlotWrapper(ItemSlot.Context.BankItem, 0.85f)
            {
                HoverText = "Upgrade Slot",
                ValidItemFunc = item => item.IsAir || !item.IsAir && (GetModItem(item.type) is Items.KnifeDamageItem)
            };
            _vanillaItemSlot.HAlign = 0.5f;
            _vanillaItemSlot.VAlign = 0.05f;
            Background.Append(_vanillaItemSlot);

            Texture2D UpgradeButtonTexture = ModContent.GetTexture("VampKnives/UI/RitualOfStone");
            UpgradeSharpnessButton = new EntranceButton(UpgradeButtonTexture, "");
            UpgradeSharpnessButton.VAlign = 0.2f;
            UpgradeSharpnessButton.HAlign = 0.1f;
            UpgradeSharpnessButton.Width.Set(ButtonSize.X, 0f);
            UpgradeSharpnessButton.Height.Set(ButtonSize.Y, 0f);
            UpgradeSharpnessButton.OnClick += new MouseEvent(StoneRitualButtonClicked);
            Background.Append(UpgradeSharpnessButton);

            UIFlatPanel SharpnessUnderline = new UIFlatPanel();
            SharpnessUnderline.BackgroundColor = Color.White;
            SharpnessUnderline.VAlign = -0.2f;
            SharpnessUnderline.HAlign = 0.5f;
            SharpnessUnderline.Width.Set(ButtonSize.X, 0f);
            SharpnessUnderline.Height.Set(6, 0f);
            UpgradeSharpnessButton.Append(SharpnessUnderline);

            UIText Sharpness = new UIText("Sharpness");
            Sharpness.Top.Set(-25, 0f);
            Sharpness.HAlign = 0.5f;
            SharpnessUnderline.Append(Sharpness);

            //Texture2D DamageImage = ModContent.GetTexture("VampKnives/UI/WhetstoneUI");
            //DamageItem = new UIImage(DamageImage);
            //DamageItem.HAlign = 1.3f;
            //DamageItem.VAlign = 0.5f;
            //UpgradeSharpnessButton.Append(DamageItem);
        }
        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            base.DrawSelf(spriteBatch);

            Main.HidePlayerCraftingMenu = false;

            if (!_vanillaItemSlot.Item.IsAir)
            {
                KnifeWeapon UpgradeItem = _vanillaItemSlot.Item.GetGlobalItem<KnifeWeapon>();
            }
        }
        int identifier;
        private void StoneRitualButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if(BloodAltarStorage.RitualOfTheStone.Count < ExamplePlayer.AltarBeingUsed.Count)
            {
                for (int g = 0; g < (ExamplePlayer.AltarBeingUsed.Count - BloodAltarStorage.RitualOfTheStone.Count); g++)
                {
                    BloodAltarStorage.RitualOfTheStone.Add(false);
                }
            }
            //Main.NewText("BoolListLength: " + BloodAltarStorage.RitualOfTheStone.Count);
            //Main.NewText("AltarListLenght: " + ExamplePlayer.AltarBeingUsed.Count);
            ExamplePlayer p = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
            //Main.NewText("Clicked");
            //AltarBeingUsed = new Vector2();
            for(int iterations = 0; iterations < ExamplePlayer.AltarBeingUsed.Count; iterations+=2)
            {
                if(ExamplePlayer.AltarBeingUsed[iterations] == ExamplePlayer.MostRecentClick.X && ExamplePlayer.AltarBeingUsed[iterations+1] == ExamplePlayer.MostRecentClick.Y)
                {
                    //Main.NewText("FoundAltar");
                    identifier = iterations;
                }
                //Main.NewText("Identifier" + identifier);
            }
            if (!BloodAltarStorage.RitualOfTheStone[identifier])
            {
                BloodAltarStorage.RitualOfTheStone[identifier] = true;
            }
            else
            {
                BloodAltarStorage.RitualOfTheStone[identifier] = false;
            }
            //Main.NewText("This altar True? : " + BloodAltarStorage.RitualOfTheStone[identifier]);
        }



        //private void NormalButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        //{
        //    int BuyItem = ModContent.ItemType<Items.Accessories.CritEmblem>();
        //    if (!_vanillaItemSlot.Item.IsAir)
        //    {
        //        KnifeWeapon UpgradeItem = _vanillaItemSlot.Item.GetGlobalItem<KnifeWeapon>();
        //        CritBuyPrice = UpgradeItem.CritPurchases;
        //        for (int i = 0; i < 59; i++)
        //        {
        //            Item item = Main.LocalPlayer.inventory[i];
        //            if (!item.IsAir && item.type == BuyItem && item.stack >= DamageBuyPrice)
        //            {
        //                if (UpgradeItem.CritLevel < 10)
        //                {
        //                    UpgradeItem.CritLevel += 1;
        //                    UpgradeItem.OriginalOwner = Main.LocalPlayer.name;
        //                    Item SavedItem = new Item();
        //                    int SavedItemStack;
        //                    SavedItem = item.Clone();
        //                    SavedItemStack = item.stack;
        //                    item.TurnToAir();
        //                    for (int StackNum = 0; StackNum < SavedItemStack - (CritBuyPrice); StackNum++)
        //                    {
        //                        Main.LocalPlayer.PutItemInInventory(SavedItem.type);
        //                    }
        //                    UpgradeItem.CritPurchases++;
        //                    break;
        //                }
        //                else
        //                {
        //                    Main.NewText("You've maxed out this skill!");
        //                    break;
        //                }
        //            }
        //            else if (item.type != BuyItem && i == 58 && CritBuyPrice != 11)
        //            {
        //                Main.NewText("You don't have enough Crit Emblems, you need: " + (CritBuyPrice));
        //            }
        //            else if (item.type != BuyItem && i == 58 && CritBuyPrice == 11)
        //            {
        //                Main.NewText("You've maxed out this skill!");
        //            }
        //        }
        //    }
        //    else
        //    {
        //        Main.NewText("You need to place an weapon in the item slot!");
        //    }
        //}
    }
}