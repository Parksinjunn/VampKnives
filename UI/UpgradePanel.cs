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
using static Terraria.ModLoader.ModContent;

namespace VampKnives.UI
{
    internal class UpgradePanel : UIState
    {
        public static bool visible = true;
        public EntranceButton UpgradeSharpnessButton;
        public EntranceButton UpgradeCritButton;
        public EntranceButton UpgradeSpecialButton;
        public EntranceButton UpgradeSpecialButton2;
        public EntranceButton UpgradeSpecialButton3;
        public EntranceBackgroundPanel Background;
        public UIFlatPanel centerTest;
        private VanillaItemSlotWrapper _vanillaItemSlot;
        UIText SharpnessUpgradeText1;
        UIText SharpnessUpgradeText2;
        UIText SharpnessUpgradeText3;
        UIText SharpnessUpgradeText4;
        UIText SharpnessUpgradeText5;
        UIText SharpnessUpgradeText6;
        UIText SharpnessUpgradeText7;
        UIText SharpnessUpgradeText8;
        UIText SharpnessUpgradeText9;
        UIText SharpnessUpgradeText10;

        UIText CritUpgradeText1;
        UIText CritUpgradeText2;
        UIText CritUpgradeText3;
        UIText CritUpgradeText4;
        UIText CritUpgradeText5;
        UIText CritUpgradeText6;
        UIText CritUpgradeText7;
        UIText CritUpgradeText8;
        UIText CritUpgradeText9;
        UIText CritUpgradeText10;

        UIText SpecialUpgradeText1;
        UIText SpecialUpgradeText2;
        UIText SpecialUpgradeText3;

        UIImage DamageItem;
        UIImage CritItem;
        UIImage RicochetItem;
        UIImage PenetrateItem;
        UIImage LifeStealItem;

        UIText DamagePrice;
        UIText CritPrice;
        UIText RicochetPrice;
        UIText PenetratePrice;
        UIText LifeStealPrice;

        UITextBox RenameBox;

        Vector2 ButtonSize = new Vector2(120,60);

        float BackgroundWidth = 600f;
        float BackgroundHeight = 700f;
        int TextOffset = 35;

        int Lifesteal;
        float Ricochet;
        int Penetrate;
        int CritBuyPrice = 1;
        int DamageBuyPrice = 1;
        int RicochetBuyPrice = 1;
        int PenetrateBuyPrice = 1;
        int LifeStealBuyPrice = 1;


        public override void OnInitialize()
        {
            Background = new EntranceBackgroundPanel();

            Background.BackgroundColor = Color.Black;
            Background.BorderColor = Color.DarkGray;
            Background.Width.Set(BackgroundWidth, 0f);
            Background.Height.Set(BackgroundHeight, 0f);
            Background.HAlign = Background.VAlign = 0.5f; // 1
            base.Append(Background);

            _vanillaItemSlot = new VanillaItemSlotWrapper(ItemSlot.Context.BankItem, 0.85f)
            {
                HoverText = "Upgrade Slot",
                ValidItemFunc = item => item.IsAir || !item.IsAir && (GetModItem(item.type) is Items.KnifeDamageItem)
            };
            _vanillaItemSlot.HAlign = 0.5f;
            _vanillaItemSlot.VAlign = 0.05f;
            Background.Append(_vanillaItemSlot);

            //RenameBox = new UITextBox("");
            //RenameBox.Width.Set(ButtonSize.X, 0f);
            //RenameBox.VAlign = 0.05f;
            //RenameBox.HAlign = 0.1f;
            //Background.Append(RenameBox);

            UIFlatPanel SharpnessUnderline = new UIFlatPanel();
            SharpnessUnderline.BackgroundColor = Color.White;
            SharpnessUnderline.VAlign = 0.2f;
            SharpnessUnderline.HAlign = 0.1f;
            SharpnessUnderline.Width.Set(ButtonSize.X, 0f);
            SharpnessUnderline.Height.Set(6, 0f);
            Background.Append(SharpnessUnderline);

            UIText Sharpness = new UIText("Sharpness");
            Sharpness.Top.Set(-25, 0f);
            Sharpness.HAlign = 0.5f;
            SharpnessUnderline.Append(Sharpness);

            SharpnessUpgradeText1 = new UIText("1) +10% Damage");
            SharpnessUpgradeText1.TextColor = Color.Gray;
            SharpnessUpgradeText1.Top.Set(TextOffset, 0f);
            SharpnessUpgradeText1.HAlign = 0.5f;
            SharpnessUnderline.Append(SharpnessUpgradeText1);

            SharpnessUpgradeText2 = new UIText("2) +20% Damage");
            SharpnessUpgradeText2.TextColor = Color.Gray;
            SharpnessUpgradeText2.Top.Set(TextOffset * 2, 0f);
            SharpnessUpgradeText2.HAlign = 0.5f;
            SharpnessUnderline.Append(SharpnessUpgradeText2);

            SharpnessUpgradeText3 = new UIText("3) +30% Damage");
            SharpnessUpgradeText3.TextColor = Color.Gray;
            SharpnessUpgradeText3.Top.Set(TextOffset * 3, 0f);
            SharpnessUpgradeText3.HAlign = 0.5f;
            SharpnessUnderline.Append(SharpnessUpgradeText3);

            SharpnessUpgradeText4 = new UIText("4) +40% Damage");
            SharpnessUpgradeText4.TextColor = Color.Gray;
            SharpnessUpgradeText4.Top.Set(TextOffset * 4, 0f);
            SharpnessUpgradeText4.HAlign = 0.5f;
            SharpnessUnderline.Append(SharpnessUpgradeText4);

            SharpnessUpgradeText5 = new UIText("5) +50% Damage");
            SharpnessUpgradeText5.TextColor = Color.Gray;
            SharpnessUpgradeText5.Top.Set(TextOffset * 5, 0f);
            SharpnessUpgradeText5.HAlign = 0.5f;
            SharpnessUnderline.Append(SharpnessUpgradeText5);

            SharpnessUpgradeText6 = new UIText("6) +60% Damage");
            SharpnessUpgradeText6.TextColor = Color.Gray;
            SharpnessUpgradeText6.Top.Set(TextOffset * 6, 0f);
            SharpnessUpgradeText6.HAlign = 0.5f;
            SharpnessUnderline.Append(SharpnessUpgradeText6);

            SharpnessUpgradeText7 = new UIText("7) +70% Damage");
            SharpnessUpgradeText7.TextColor = Color.Gray;
            SharpnessUpgradeText7.Top.Set(TextOffset * 7, 0f);
            SharpnessUpgradeText7.HAlign = 0.5f;
            SharpnessUnderline.Append(SharpnessUpgradeText7);

            SharpnessUpgradeText8 = new UIText("8) +80% Damage");
            SharpnessUpgradeText8.TextColor = Color.Gray;
            SharpnessUpgradeText8.Top.Set(TextOffset * 8, 0f);
            SharpnessUpgradeText8.HAlign = 0.5f;
            SharpnessUnderline.Append(SharpnessUpgradeText8);

            SharpnessUpgradeText9 = new UIText("9) +90% Damage");
            SharpnessUpgradeText9.TextColor = Color.Gray;
            SharpnessUpgradeText9.Top.Set(TextOffset * 9, 0f);
            SharpnessUpgradeText9.HAlign = 0.5f;
            SharpnessUnderline.Append(SharpnessUpgradeText9);

            SharpnessUpgradeText10 = new UIText("10) +100% Damage");
            SharpnessUpgradeText10.TextColor = Color.Gray;
            SharpnessUpgradeText10.Top.Set(TextOffset * 10, 0f);
            SharpnessUpgradeText10.HAlign = 0.5f;
            SharpnessUnderline.Append(SharpnessUpgradeText10);

            UIFlatPanel CritUnderline = new UIFlatPanel();
            CritUnderline.BackgroundColor = Color.White;
            CritUnderline.VAlign = 0.2f;
            CritUnderline.HAlign = 0.5f;
            CritUnderline.Width.Set(ButtonSize.X, 0f);
            CritUnderline.Height.Set(6, 0f);
            Background.Append(CritUnderline);

            UIText Crit = new UIText("Crit");
            Crit.Top.Set(-25, 0f);
            Crit.HAlign = 0.5f;
            CritUnderline.Append(Crit);

            CritUpgradeText1 = new UIText("1) 2% Crit chance");
            CritUpgradeText1.TextColor = Color.Gray;
            CritUpgradeText1.Top.Set(TextOffset, 0f);
            CritUpgradeText1.HAlign = 0.5f;
            CritUnderline.Append(CritUpgradeText1);

            CritUpgradeText2 = new UIText("2) 3% Crit chance");
            CritUpgradeText2.TextColor = Color.Gray;
            CritUpgradeText2.Top.Set(TextOffset * 2, 0f);
            CritUpgradeText2.HAlign = 0.5f;
            CritUnderline.Append(CritUpgradeText2);

            CritUpgradeText3 = new UIText("3) 5% Crit chance");
            CritUpgradeText3.TextColor = Color.Gray;
            CritUpgradeText3.Top.Set(TextOffset * 3, 0f);
            CritUpgradeText3.HAlign = 0.5f;
            CritUnderline.Append(CritUpgradeText3);

            CritUpgradeText4 = new UIText("4) 7% Crit chance");
            CritUpgradeText4.TextColor = Color.Gray;
            CritUpgradeText4.Top.Set(TextOffset * 4, 0f);
            CritUpgradeText4.HAlign = 0.5f;
            CritUnderline.Append(CritUpgradeText4);

            CritUpgradeText5 = new UIText("5) 10% Crit chance");
            CritUpgradeText5.TextColor = Color.Gray;
            CritUpgradeText5.Top.Set(TextOffset * 5, 0f);
            CritUpgradeText5.HAlign = 0.5f;
            CritUnderline.Append(CritUpgradeText5);

            CritUpgradeText6 = new UIText("6) 12% Crit chance");
            CritUpgradeText6.TextColor = Color.Gray;
            CritUpgradeText6.Top.Set(TextOffset * 6, 0f);
            CritUpgradeText6.HAlign = 0.5f;
            CritUnderline.Append(CritUpgradeText6);

            CritUpgradeText7 = new UIText("7) 13% Crit chance");
            CritUpgradeText7.TextColor = Color.Gray;
            CritUpgradeText7.Top.Set(TextOffset * 7, 0f);
            CritUpgradeText7.HAlign = 0.5f;
            CritUnderline.Append(CritUpgradeText7);

            CritUpgradeText8 = new UIText("8) 18% Crit chance");
            CritUpgradeText8.TextColor = Color.Gray;
            CritUpgradeText8.Top.Set(TextOffset * 8, 0f);
            CritUpgradeText8.HAlign = 0.5f;
            CritUnderline.Append(CritUpgradeText8);

            CritUpgradeText9 = new UIText("9) 19% Crit chance");
            CritUpgradeText9.TextColor = Color.Gray;
            CritUpgradeText9.Top.Set(TextOffset * 9, 0f);
            CritUpgradeText9.HAlign = 0.5f;
            CritUnderline.Append(CritUpgradeText9);

            CritUpgradeText10 = new UIText("10) 20% Crit chance");
            CritUpgradeText10.TextColor = Color.Gray;
            CritUpgradeText10.Top.Set(TextOffset * 10, 0f);
            CritUpgradeText10.HAlign = 0.5f;
            CritUnderline.Append(CritUpgradeText10);

            UIFlatPanel SpecialUnderline = new UIFlatPanel();
            SpecialUnderline.BackgroundColor = Color.White;
            SpecialUnderline.VAlign = 0.2f;
            SpecialUnderline.HAlign = 0.9f;
            SpecialUnderline.Width.Set(ButtonSize.X, 0f);
            SpecialUnderline.Height.Set(6, 0f);
            Background.Append(SpecialUnderline);

            UIText Special = new UIText("Special");
            Special.Top.Set(-25, 0f);
            Special.HAlign = 0.5f;
            SpecialUnderline.Append(Special);

            Texture2D UpgradeButtonTexture = ModContent.GetTexture("VampKnives/UI/UpgradeButton");
            UpgradeSharpnessButton = new EntranceButton(UpgradeButtonTexture, "");
            UpgradeSharpnessButton.VAlign = 0.9f;
            UpgradeSharpnessButton.HAlign = 0.1f;
            UpgradeSharpnessButton.Width.Set(ButtonSize.X, 0f);
            UpgradeSharpnessButton.Height.Set(ButtonSize.Y, 0f);
            UpgradeSharpnessButton.OnClick += new MouseEvent(LegacyButtonClicked);
            Background.Append(UpgradeSharpnessButton);

            UpgradeCritButton = new EntranceButton(UpgradeButtonTexture, "");
            UpgradeCritButton.VAlign = 0.9f;
            UpgradeCritButton.HAlign = 0.5f;
            UpgradeCritButton.Width.Set(ButtonSize.X, 0f);
            UpgradeCritButton.Height.Set(ButtonSize.Y, 0f);
            UpgradeCritButton.OnClick += new MouseEvent(NormalButtonClicked);
            Background.Append(UpgradeCritButton);

            UpgradeSpecialButton = new EntranceButton(UpgradeButtonTexture, "");
            UpgradeSpecialButton.VAlign = 0.4f;
            UpgradeSpecialButton.HAlign = 0.9f;
            UpgradeSpecialButton.Width.Set(ButtonSize.X, 0f);
            UpgradeSpecialButton.Height.Set(ButtonSize.Y, 0f);
            UpgradeSpecialButton.OnClick += new MouseEvent(UnforgivingButtonClicked);
            Background.Append(UpgradeSpecialButton);

            UpgradeSpecialButton2 = new EntranceButton(UpgradeButtonTexture, "");
            UpgradeSpecialButton2.VAlign = 0.65f;
            UpgradeSpecialButton2.HAlign = 0.9f;
            UpgradeSpecialButton2.Width.Set(ButtonSize.X, 0f);
            UpgradeSpecialButton2.Height.Set(ButtonSize.Y, 0f);
            UpgradeSpecialButton2.OnClick += new MouseEvent(SpecialButton2Clicked);
            Background.Append(UpgradeSpecialButton2);

            UpgradeSpecialButton3 = new EntranceButton(UpgradeButtonTexture, "");
            UpgradeSpecialButton3.VAlign = 0.9f;
            UpgradeSpecialButton3.HAlign = 0.9f;
            UpgradeSpecialButton3.Width.Set(ButtonSize.X, 0f);
            UpgradeSpecialButton3.Height.Set(ButtonSize.Y, 0f);
            UpgradeSpecialButton3.OnClick += new MouseEvent(SpecialButton3Clicked);
            Background.Append(UpgradeSpecialButton3);

            Texture2D DamageImage = ModContent.GetTexture("VampKnives/UI/WhetstoneUI");
            DamageItem = new UIImage(DamageImage);
            DamageItem.HAlign = 1.3f;
            DamageItem.VAlign = 0.5f;
            UpgradeSharpnessButton.Append(DamageItem);

            Texture2D CritImage = ModContent.GetTexture("VampKnives/UI/CritEmblemUI");
            CritItem = new UIImage(CritImage);
            CritItem.HAlign = 1.3f;
            CritItem.VAlign = 0.5f;
            UpgradeCritButton.Append(CritItem);

            Texture2D RicochetImage = ModContent.GetTexture("VampKnives/UI/RicochetEssenceUI");
            RicochetItem = new UIImage(RicochetImage);
            RicochetItem.HAlign = 1.3f;
            RicochetItem.VAlign = 0.5f;
            UpgradeSpecialButton.Append(RicochetItem);

            Texture2D PenetrateImage = ModContent.GetTexture("VampKnives/UI/PiercingTipUI");
            PenetrateItem = new UIImage(PenetrateImage);
            PenetrateItem.HAlign = 1.3f;
            PenetrateItem.VAlign = 0.5f;
            UpgradeSpecialButton2.Append(PenetrateItem);

            Texture2D LifestealImage = ModContent.GetTexture("VampKnives/UI/StableCrimsonCrystalUI");
            LifeStealItem = new UIImage(LifestealImage);
            LifeStealItem.HAlign = 1.3f;
            LifeStealItem.VAlign = 0.5f;
            UpgradeSpecialButton3.Append(LifeStealItem);

            DamagePrice = new UIText("x" + DamageBuyPrice);
            DamagePrice.HAlign = 1.25f;
            DamagePrice.VAlign = 0.5f;
            DamageItem.Append(DamagePrice);

            CritPrice = new UIText("x" + CritBuyPrice);
            CritPrice.HAlign = 1.25f;
            CritPrice.VAlign = 0.5f;
            CritItem.Append(CritPrice);

            RicochetPrice = new UIText("x" + RicochetBuyPrice);
            RicochetPrice.HAlign = 1.25f;
            RicochetPrice.VAlign = 0.5f;
            RicochetItem.Append(RicochetPrice);

            PenetratePrice = new UIText("x" + PenetrateBuyPrice);
            PenetratePrice.HAlign = 1.25f;
            PenetratePrice.VAlign = 0.5f;
            PenetrateItem.Append(PenetratePrice);

            LifeStealPrice = new UIText("x" + LifeStealBuyPrice);
            LifeStealPrice.HAlign = 1.25f;
            LifeStealPrice.VAlign = 0.5f;
            LifeStealItem.Append(LifeStealPrice);

            SpecialUpgradeText1 = new UIText("+1% chance to shoot\na knife that ricochets\n   Current chance: " + Ricochet);
            SpecialUpgradeText1.TextColor = Color.Gray;
            SpecialUpgradeText1.Top.Set(-((TextOffset * 2) + TextOffset / 3), 0f);
            SpecialUpgradeText1.HAlign = 0.5f;
            UpgradeSpecialButton.Append(SpecialUpgradeText1);

            SpecialUpgradeText2 = new UIText("+1 to number of enemies\n   the knife penetrates\n     Current number: " + Penetrate);
            SpecialUpgradeText2.TextColor = Color.Gray;
            SpecialUpgradeText2.Top.Set(-((TextOffset * 2)+TextOffset/3), 0f);
            SpecialUpgradeText2.HAlign = 0.5f;
            UpgradeSpecialButton2.Append(SpecialUpgradeText2);

            SpecialUpgradeText3 = new UIText("+1 increase to knife\n       lifesteal\n Current increase: " + Lifesteal);
            SpecialUpgradeText3.TextColor = Color.Gray;
            SpecialUpgradeText3.Top.Set(-((TextOffset * 2) + TextOffset / 3), 0f);
            SpecialUpgradeText3.HAlign = 0.5f;
            UpgradeSpecialButton3.Append(SpecialUpgradeText3);
        }
        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            base.DrawSelf(spriteBatch);

            Main.HidePlayerCraftingMenu = false;

            if (!_vanillaItemSlot.Item.IsAir)
            {
                KnifeWeapon UpgradeItem = _vanillaItemSlot.Item.GetGlobalItem<KnifeWeapon>();

                Lifesteal = UpgradeItem.LifeStealBonus;
                Penetrate = UpgradeItem.PenetrationBonus;
                Ricochet = UpgradeItem.RicochetChance;

                SpecialUpgradeText1.SetText("+1% chance to shoot\na knife that ricochets\n   Current chance: " + Math.Truncate((Ricochet*100)) + "%");
                SpecialUpgradeText2.SetText("+1 to number of enemies\n   the knife penetrates\n     Current number: " + Penetrate);
                SpecialUpgradeText3.SetText("+1 increase to knife\n       lifesteal\n Current increase: " + Lifesteal);

                DamageBuyPrice = UpgradeItem.DamagePurchases;
                CritBuyPrice = UpgradeItem.CritPurchases;
                RicochetBuyPrice = UpgradeItem.RicochetPurchases;
                PenetrateBuyPrice = UpgradeItem.PenetrationPurchases;
                LifeStealBuyPrice = UpgradeItem.LifeStealPurchases;

                DamagePrice.SetText("x" + (DamageBuyPrice));
                CritPrice.SetText("x" + (CritBuyPrice));
                RicochetPrice.SetText("x" + (RicochetBuyPrice));
                PenetratePrice.SetText("x" + (PenetrateBuyPrice));
                LifeStealPrice.SetText("x" + (LifeStealBuyPrice));

                if(DamageBuyPrice == 11)
                {
                    DamagePrice.SetText("Maxed");
                }
                if(CritBuyPrice == 11)
                {
                    CritPrice.SetText("Maxed");
                }
                if (RicochetBuyPrice == 102)
                {
                    RicochetPrice.SetText("Maxed");
                }
                if (PenetrateBuyPrice == 11)
                {
                    PenetratePrice.SetText("Maxed");
                }
                if (LifeStealBuyPrice == 26)
                {
                    LifeStealPrice.SetText("Maxed");
                }

                if (Ricochet != 0)
                {
                    SpecialUpgradeText1.TextColor = Color.White;
                }
                if (Penetrate != 0)
                {
                    SpecialUpgradeText2.TextColor = Color.White;
                }
                if (Lifesteal != 0)
                {
                    SpecialUpgradeText3.TextColor = Color.White;
                }

                if (UpgradeItem.DamageLevel >= 1)
                {
                    SharpnessUpgradeText1.TextColor = Color.White;
                }
                if (UpgradeItem.DamageLevel >= 2)
                {
                    SharpnessUpgradeText2.TextColor = Color.White;
                }
                if (UpgradeItem.DamageLevel >= 3)
                {
                    SharpnessUpgradeText3.TextColor = Color.White;
                }
                if (UpgradeItem.DamageLevel >= 4)
                {
                    SharpnessUpgradeText4.TextColor = Color.White;
                }
                if (UpgradeItem.DamageLevel >= 5)
                {
                    SharpnessUpgradeText5.TextColor = Color.White;
                }
                if (UpgradeItem.DamageLevel >= 6)
                {
                    SharpnessUpgradeText6.TextColor = Color.White;
                }
                if (UpgradeItem.DamageLevel >= 7)
                {
                    SharpnessUpgradeText7.TextColor = Color.White;
                }
                if (UpgradeItem.DamageLevel >= 8)
                {
                    SharpnessUpgradeText8.TextColor = Color.White;
                }
                if (UpgradeItem.DamageLevel >= 9)
                {
                    SharpnessUpgradeText9.TextColor = Color.White;
                }
                if (UpgradeItem.DamageLevel >= 10)
                {
                    SharpnessUpgradeText10.TextColor = Color.White;
                }

                if (UpgradeItem.CritLevel >= 1)
                {
                    CritUpgradeText1.TextColor = Color.White;
                }
                if (UpgradeItem.CritLevel >= 2)
                {
                    CritUpgradeText2.TextColor = Color.White;
                }
                if (UpgradeItem.CritLevel >= 3)
                {
                    CritUpgradeText3.TextColor = Color.White;
                }
                if (UpgradeItem.CritLevel >= 4)
                {
                    CritUpgradeText4.TextColor = Color.White;
                }
                if (UpgradeItem.CritLevel >= 5)
                {
                    CritUpgradeText5.TextColor = Color.White;
                }
                if (UpgradeItem.CritLevel >= 6)
                {
                    CritUpgradeText6.TextColor = Color.White;
                }
                if (UpgradeItem.CritLevel >= 7)
                {
                    CritUpgradeText7.TextColor = Color.White;
                }
                if (UpgradeItem.CritLevel >= 8)
                {
                    CritUpgradeText8.TextColor = Color.White;
                }
                if (UpgradeItem.CritLevel >= 9)
                {
                    CritUpgradeText9.TextColor = Color.White;
                }
                if (UpgradeItem.CritLevel >= 10)
                {
                    CritUpgradeText10.TextColor = Color.White;
                }

                if (VampKnives.SpecialUpgradeCounter >= 1)
                {
                    SpecialUpgradeText1.TextColor = Color.White;
                }
                if (VampKnives.SpecialUpgradeCounter >= 2)
                {
                    SpecialUpgradeText2.TextColor = Color.White;
                }
                if (VampKnives.SpecialUpgradeCounter >= 3)
                {
                    SpecialUpgradeText3.TextColor = Color.White;
                }
            }
            else
            {
                SharpnessUpgradeText1.TextColor = Color.Gray;
                SharpnessUpgradeText2.TextColor = Color.Gray;
                SharpnessUpgradeText3.TextColor = Color.Gray;
                SharpnessUpgradeText4.TextColor = Color.Gray;
                SharpnessUpgradeText5.TextColor = Color.Gray;
                SharpnessUpgradeText6.TextColor = Color.Gray;
                SharpnessUpgradeText7.TextColor = Color.Gray;
                SharpnessUpgradeText8.TextColor = Color.Gray;
                SharpnessUpgradeText9.TextColor = Color.Gray;
                SharpnessUpgradeText10.TextColor = Color.Gray;

                CritUpgradeText1.TextColor = Color.Gray;
                CritUpgradeText2.TextColor = Color.Gray;
                CritUpgradeText3.TextColor = Color.Gray;
                CritUpgradeText4.TextColor = Color.Gray;
                CritUpgradeText5.TextColor = Color.Gray;
                CritUpgradeText6.TextColor = Color.Gray;
                CritUpgradeText7.TextColor = Color.Gray;
                CritUpgradeText8.TextColor = Color.Gray;
                CritUpgradeText9.TextColor = Color.Gray;
                CritUpgradeText10.TextColor = Color.Gray;

                SpecialUpgradeText1.TextColor = Color.Gray;
                SpecialUpgradeText2.TextColor = Color.Gray;
                SpecialUpgradeText3.TextColor = Color.Gray;

                DamagePrice.SetText("x1");
                CritPrice.SetText("x1");
                RicochetPrice.SetText("x1");
                PenetratePrice.SetText("x1");
                LifeStealPrice.SetText("x1");
            }
        }
        private void LegacyButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            int BuyItem = ModContent.ItemType<Items.Accessories.Whetstone>();
            if (!_vanillaItemSlot.Item.IsAir)
            {
                KnifeWeapon UpgradeItem = _vanillaItemSlot.Item.GetGlobalItem<KnifeWeapon>();
                DamageBuyPrice = UpgradeItem.DamagePurchases;
                for (int i = 0; i < 59; i++)
                {
                    Item item = Main.LocalPlayer.inventory[i];
                    if (!item.IsAir && item.type == BuyItem && item.stack >= DamageBuyPrice)
                    {
                        if (UpgradeItem.DamageLevel < 10)
                        {
                            UpgradeItem.DamageLevel += 1;
                            UpgradeItem.OriginalOwner = Main.LocalPlayer.name;
                            Item SavedItem = new Item();
                            int SavedItemStack;
                            SavedItem = item.Clone();
                            SavedItemStack = item.stack;
                            item.TurnToAir();
                            for (int StackNum = 0; StackNum < SavedItemStack - (DamageBuyPrice); StackNum++)
                            {
                                Main.LocalPlayer.PutItemInInventory(SavedItem.type);
                            }
                            UpgradeItem.DamagePurchases++;
                            break;
                        }
                        else
                        {
                            Main.NewText("You've maxed out this skill!");
                            break;
                        }
                    }
                    else if (item.type != BuyItem && i == 58 && DamageBuyPrice != 11)
                    {
                        Main.NewText("You don't have enough Whetstones, you need: " + (DamageBuyPrice));
                    }
                    else if (item.type != BuyItem && i == 58 && DamageBuyPrice == 11)
                    {
                        Main.NewText("You've maxed out this skill!");
                    }
                }
            }
            else
            {
                Main.NewText("You need to place an weapon in the item slot!");
            }
        }
        private void NormalButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            int BuyItem = ModContent.ItemType<Items.Accessories.CritEmblem>();
            if (!_vanillaItemSlot.Item.IsAir)
            {
                KnifeWeapon UpgradeItem = _vanillaItemSlot.Item.GetGlobalItem<KnifeWeapon>();
                CritBuyPrice = UpgradeItem.CritPurchases;
                for (int i = 0; i < 59; i++)
                {
                    Item item = Main.LocalPlayer.inventory[i];
                    if (!item.IsAir && item.type == BuyItem && item.stack >= DamageBuyPrice)
                    {
                        if (UpgradeItem.CritLevel < 10)
                        {
                            UpgradeItem.CritLevel += 1;
                            UpgradeItem.OriginalOwner = Main.LocalPlayer.name;
                            Item SavedItem = new Item();
                            int SavedItemStack;
                            SavedItem = item.Clone();
                            SavedItemStack = item.stack;
                            item.TurnToAir();
                            for (int StackNum = 0; StackNum < SavedItemStack - (CritBuyPrice); StackNum++)
                            {
                                Main.LocalPlayer.PutItemInInventory(SavedItem.type);
                            }
                            UpgradeItem.CritPurchases++;
                            break;
                        }
                        else
                        {
                            Main.NewText("You've maxed out this skill!");
                            break;
                        }
                    }
                    else if (item.type != BuyItem && i == 58 && CritBuyPrice != 11)
                    {
                        Main.NewText("You don't have enough Crit Emblems, you need: " + (CritBuyPrice));
                    }
                    else if (item.type != BuyItem && i == 58 && CritBuyPrice == 11)
                    {
                        Main.NewText("You've maxed out this skill!");
                    }
                }
            }
            else
            {
                Main.NewText("You need to place an weapon in the item slot!");
            }
        }
        private void UnforgivingButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            int BuyItem = ModContent.ItemType<Items.Materials.RicochetEssence>();
            if (!_vanillaItemSlot.Item.IsAir)
            {
                KnifeWeapon UpgradeItem = _vanillaItemSlot.Item.GetGlobalItem<KnifeWeapon>();
                RicochetBuyPrice = UpgradeItem.RicochetPurchases;
                for (int i = 0; i < 59; i++)
                {
                    Item item = Main.LocalPlayer.inventory[i];
                    if (!item.IsAir && item.type == BuyItem && item.stack >= RicochetBuyPrice)
                    {
                        if (UpgradeItem.RicochetChance < 1.00f)
                        {
                            UpgradeItem.RicochetChance += 0.01f;
                            UpgradeItem.OriginalOwner = Main.LocalPlayer.name;
                            Item SavedItem = new Item();
                            int SavedItemStack;
                            SavedItem = item.Clone();
                            SavedItemStack = item.stack;
                            item.TurnToAir();
                            for (int StackNum = 0; StackNum < SavedItemStack - (RicochetBuyPrice); StackNum++)
                            {
                                Main.LocalPlayer.PutItemInInventory(SavedItem.type);
                            }
                            UpgradeItem.RicochetPurchases++;
                            break;
                        }
                        else
                        {
                            Main.NewText("You've maxed out this skill!");
                            break;
                        }
                    }
                    else if(item.type != BuyItem && i == 58 && RicochetBuyPrice != 102)
                    {
                        Main.NewText("You don't have enough Ricochet Essence, you need: " + (RicochetBuyPrice));
                    }
                    else if(item.type != BuyItem && i == 58 && RicochetBuyPrice == 102)
                    {
                        Main.NewText("You've maxed out this skill!");
                    }
                }
            }
            else
            {
                Main.NewText("You need to place an weapon in the item slot!");
            }
        }
        private void SpecialButton2Clicked(UIMouseEvent evt, UIElement listeningElement)
        {
            int BuyItem = ModContent.ItemType<Items.Materials.PiercingTip>();
            if (!_vanillaItemSlot.Item.IsAir)
            {
                if(_vanillaItemSlot.Item.type == ModContent.ItemType<CorruptionNestKnives>() || _vanillaItemSlot.Item.type == ModContent.ItemType<CrimsonNestKnives>() || _vanillaItemSlot.Item.type == ModContent.ItemType<ButchersKnives>())
                {
                    Main.NewText("You cannot add penetration to this weapon");
                }
                else
                {
                    KnifeWeapon UpgradeItem = _vanillaItemSlot.Item.GetGlobalItem<KnifeWeapon>();
                    PenetrateBuyPrice = UpgradeItem.PenetrationPurchases;
                    for (int i = 0; i < 59; i++)
                    {
                        Item item = Main.LocalPlayer.inventory[i];
                        if (!item.IsAir && item.type == BuyItem && item.stack >= PenetrateBuyPrice)
                        {
                            if (UpgradeItem.PenetrationBonus < 10)
                            {
                                UpgradeItem.PenetrationBonus += 1;
                                UpgradeItem.OriginalOwner = Main.LocalPlayer.name;
                                Item SavedItem = new Item();
                                int SavedItemStack;
                                SavedItem = item.Clone();
                                SavedItemStack = item.stack;
                                item.TurnToAir();
                                for (int StackNum = 0; StackNum < SavedItemStack - (PenetrateBuyPrice); StackNum++)
                                {
                                    Main.LocalPlayer.PutItemInInventory(SavedItem.type);
                                }
                                UpgradeItem.PenetrationPurchases++;
                                break;
                            }
                            else
                            {
                                Main.NewText("You've maxed out this skill!");
                                break;
                            }
                        }
                        else if (item.type != BuyItem && i == 58 && PenetrateBuyPrice != 11)
                        {
                            Main.NewText("You don't have enough Piercing Tips, you need: " + (PenetrateBuyPrice));
                        }
                        else if (item.type != BuyItem && i == 58 && PenetrateBuyPrice == 11)
                        {
                            Main.NewText("You've maxed out this skill!");
                        }
                    }
                }
            }
            else
            {
                Main.NewText("You need to place an weapon in the item slot!");
            }
        }
        private void SpecialButton3Clicked(UIMouseEvent evt, UIElement listeningElement)
        {
            int BuyItem = ModContent.ItemType<Items.Materials.StableCrimsonCrystal>();
            if (!_vanillaItemSlot.Item.IsAir)
            {
                KnifeWeapon UpgradeItem = _vanillaItemSlot.Item.GetGlobalItem<KnifeWeapon>();
                LifeStealBuyPrice = UpgradeItem.LifeStealPurchases;
                for (int i = 0; i < 59; i++)
                {
                    Item item = Main.LocalPlayer.inventory[i];
                    if (!item.IsAir && item.type == BuyItem && item.stack >= LifeStealBuyPrice)
                    {
                        if (UpgradeItem.LifeStealBonus < 25)
                        {
                            UpgradeItem.LifeStealBonus += 1;
                            UpgradeItem.OriginalOwner = Main.LocalPlayer.name;
                            Item SavedItem = new Item();
                            int SavedItemStack;
                            SavedItem = item.Clone();
                            SavedItemStack = item.stack;
                            item.TurnToAir();
                            for (int StackNum = 0; StackNum < SavedItemStack - (LifeStealBuyPrice); StackNum++)
                            {
                                Main.LocalPlayer.PutItemInInventory(SavedItem.type);
                            }
                            UpgradeItem.LifeStealPurchases++;
                            break;
                        }
                        else
                        {
                            Main.NewText("You've maxed out this skill!");
                            break;
                        }
                    }
                    else if (item.type != BuyItem && i == 58 && LifeStealBuyPrice != 26)
                    {
                        Main.NewText("You don't have enough Stable Crimson Crystals, you need: " + (LifeStealBuyPrice));
                    }
                    else if (item.type != BuyItem && i == 58 && LifeStealBuyPrice == 26)
                    {
                        Main.NewText("You've maxed out this skill!");
                    }
                }
            }
            else
            {
                Main.NewText("You need to place an weapon in the item slot!");
            }
        }
    }
}