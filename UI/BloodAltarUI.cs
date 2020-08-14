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
        public EntranceButton ClaimButton;
        public EntranceButton CloseButton;
        public EntranceButton RitualOfStoneButton;
        public EntranceButton RoEStone;
        public EntranceButton RoEDirt;
        public EntranceButton RoESand;
        public EntranceButton RoESilt;
        public EntranceButton RoESnow;
        public EntranceButton RitualOfTheMinerButton;
        public EntranceButton CopperTinButton;
        public EntranceButton IronLeadButton;
        public EntranceButton SilverTungstenButton;
        public EntranceButton GoldPlatinumButton;
        public EntranceButton MeteoriteButton;
        public EntranceButton DemoniteCrimtaneButton;
        public EntranceButton HellstoneButton;
        public EntranceButton CobaltPalladiumButton;
        public EntranceButton MythrilOrichalcumButton;
        public EntranceButton AdamantiteTitaniumButton;
        public EntranceButton ChlorophyteButton;
        public EntranceButton LuminiteButton;
        public EntranceButton RitualOfMidasButton;
        public EntranceButton CopperCoinButton;
        public EntranceButton SilverCoinButton;
        public EntranceButton GoldCoinButton;
        public EntranceButton PlatinumCoinButton;
        public EntranceBackgroundPanel Background;
        public UIFlatPanel centerTest;
        public UIImage EarthActive;
        public UIImage MinerActive;
        public UIImage MidasActive;
        public UIText OwnerActiveText;
        public UIText EarthActiveText;
        public UIText MinerActiveText;
        public UIText MidasActiveText;
        private VanillaItemSlotWrapper _vanillaItemSlot;

        string EarthText = "None";
        string MinerText = "None";
        string MidasText = "None";
        string OwnerText = "Owner: ";
        Vector2 ButtonSize = new Vector2(256, 66);

        float BackgroundWidth = 400f;
        float BackgroundHeight = 700f;
        int TextOffset = 35;

        float RoSButtonVPos = 0.1f;
        float RoMButtonVPos = 0.25f;
        float RoMiButtonVPos = 0.5f;
        float RoMButtonsVPos1 = 0.35f;
        float RoMButtonsVPos2 = 0.4f;

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

            ClaimButton = new EntranceButton(ModContent.GetTexture("VampKnives/UI/ClaimButton"), "Claim this altar (you pay for the rituals performed at this altar)");
            ClaimButton.VAlign = 0.015f;
            ClaimButton.HAlign = 0.05f;
            ClaimButton.Width.Set(128, 0f);
            ClaimButton.Height.Set(33, 0f);
            ClaimButton.OnClick += new MouseEvent(ClaimButtonClicked);
            Background.Append(ClaimButton);

            CloseButton = new EntranceButton(ModContent.GetTexture("VampKnives/UI/CloseButton"), "Close the UI");
            CloseButton.VAlign = 0.015f;
            CloseButton.HAlign = 0.95f;
            CloseButton.Width.Set(32, 0f);
            CloseButton.Height.Set(32, 0f);
            CloseButton.OnClick += new MouseEvent(CloseButtonClicked);
            Background.Append(CloseButton);

            //_vanillaItemSlot = new VanillaItemSlotWrapper(ItemSlot.Context.BankItem, 0.85f)
            //{
            //    HoverText = "Upgrade Slot",
            //    ValidItemFunc = item => item.IsAir || !item.IsAir && (GetModItem(item.type) is Items.KnifeDamageItem)
            //};
            //_vanillaItemSlot.HAlign = 0.5f;
            //_vanillaItemSlot.VAlign = 0.05f;
            //Background.Append(_vanillaItemSlot);

            RitualOfStoneButton = new EntranceButton(ModContent.GetTexture("VampKnives/UI/RitualOfEarth"), "Perform the ritual of the earth, summon any of these five materials for 1 bp each");
            RitualOfStoneButton.VAlign = RoSButtonVPos;
            RitualOfStoneButton.HAlign = 0.5f;
            RitualOfStoneButton.Width.Set(ButtonSize.X, 0f);
            RitualOfStoneButton.Height.Set(ButtonSize.Y, 0f);
            RitualOfStoneButton.OnClick += new MouseEvent(StoneRitualButtonClicked);
            Background.Append(RitualOfStoneButton);

            RoEStone = new EntranceButton(ModContent.GetTexture("VampKnives/UI/StoneButton"), "");
            RoEStone.VAlign = 1.5f;
            RoEStone.HAlign = 0.1f;
            RoEStone.Width.Set(32, 0f);
            RoEStone.Height.Set(32, 0f);
            RoEStone.OnClick += new MouseEvent(StoneButtonClicked);
            RitualOfStoneButton.Append(RoEStone);

            RoEDirt = new EntranceButton(ModContent.GetTexture("VampKnives/UI/DirtButton"), "");
            RoEDirt.VAlign = 1.5f;
            RoEDirt.HAlign = 0.3f;
            RoEDirt.Width.Set(32, 0f);
            RoEDirt.Height.Set(32, 0f);
            RoEDirt.OnClick += new MouseEvent(DirtButtonClicked);
            RitualOfStoneButton.Append(RoEDirt);

            RoESand = new EntranceButton(ModContent.GetTexture("VampKnives/UI/SandButton"), "");
            RoESand.VAlign = 1.5f;
            RoESand.HAlign = 0.5f;
            RoESand.Width.Set(32, 0f);
            RoESand.Height.Set(32, 0f);
            RoESand.OnClick += new MouseEvent(SandButtonClicked);
            RitualOfStoneButton.Append(RoESand);

            RoESilt = new EntranceButton(ModContent.GetTexture("VampKnives/UI/SiltButton"), "");
            RoESilt.VAlign = 1.5f;
            RoESilt.HAlign = 0.7f;
            RoESilt.Width.Set(32, 0f);
            RoESilt.Height.Set(32, 0f);
            RoESilt.OnClick += new MouseEvent(SiltButtonClicked);
            RitualOfStoneButton.Append(RoESilt);

            RoESnow = new EntranceButton(ModContent.GetTexture("VampKnives/UI/SnowButton"), "");
            RoESnow.VAlign = 1.5f;
            RoESnow.HAlign = 0.9f;
            RoESnow.Width.Set(32, 0f);
            RoESnow.Height.Set(32, 0f);
            RoESnow.OnClick += new MouseEvent(SnowButtonClicked);
            RitualOfStoneButton.Append(RoESnow);

            RitualOfTheMinerButton = new EntranceButton(ModContent.GetTexture("VampKnives/UI/RitualOfTheMiner"), "Perform the ritual of the miner");
            RitualOfTheMinerButton.VAlign = RoMButtonVPos;
            RitualOfTheMinerButton.HAlign = 0.5f;
            RitualOfTheMinerButton.Width.Set(ButtonSize.X, 0f);
            RitualOfTheMinerButton.Height.Set(ButtonSize.Y, 0f);
            RitualOfTheMinerButton.OnClick += new MouseEvent(MinerRitualButtonClicked);
            Background.Append(RitualOfTheMinerButton);

            CopperTinButton = new EntranceButton(ModContent.GetTexture("VampKnives/UI/CopperTinButton"), "Copper/Tin: 1bp");
            CopperTinButton.VAlign = RoMButtonsVPos1;
            CopperTinButton.HAlign = 0f;
            CopperTinButton.Width.Set(32, 0f);
            CopperTinButton.Height.Set(32, 0f);
            CopperTinButton.OnClick += new MouseEvent(CopperTinButtonClicked);
            Background.Append(CopperTinButton);

            IronLeadButton = new EntranceButton(ModContent.GetTexture("VampKnives/UI/IronLeadButton"), "Iron/Lead: 2bp");
            IronLeadButton.VAlign = RoMButtonsVPos1;
            IronLeadButton.HAlign = 0.2f;
            IronLeadButton.Width.Set(32, 0f);
            IronLeadButton.Height.Set(32, 0f);
            IronLeadButton.OnClick += new MouseEvent(IronLeadButtonClicked);
            Background.Append(IronLeadButton);

            SilverTungstenButton = new EntranceButton(ModContent.GetTexture("VampKnives/UI/SilverTungstenButton"), "Silver/Tungsten: 4bp");
            SilverTungstenButton.VAlign = RoMButtonsVPos1;
            SilverTungstenButton.HAlign = 0.4f;
            SilverTungstenButton.Width.Set(32, 0f);
            SilverTungstenButton.Height.Set(32, 0f);
            SilverTungstenButton.OnClick += new MouseEvent(SilverTungstenButtonClicked);
            Background.Append(SilverTungstenButton);

            GoldPlatinumButton = new EntranceButton(ModContent.GetTexture("VampKnives/UI/GoldPlatinumButton"), "Gold/Platinum: 8bp");
            GoldPlatinumButton.VAlign = RoMButtonsVPos1;
            GoldPlatinumButton.HAlign = 0.6f;
            GoldPlatinumButton.Width.Set(32, 0f);
            GoldPlatinumButton.Height.Set(32, 0f);
            GoldPlatinumButton.OnClick += new MouseEvent(GoldPlatinumButtonClicked);
            Background.Append(GoldPlatinumButton);

            MeteoriteButton = new EntranceButton(ModContent.GetTexture("VampKnives/UI/MeteoriteButton"), "Meteorite: 12bp");
            MeteoriteButton.VAlign = RoMButtonsVPos1;
            MeteoriteButton.HAlign = 0.8f;
            MeteoriteButton.Width.Set(32, 0f);
            MeteoriteButton.Height.Set(32, 0f);
            MeteoriteButton.OnClick += new MouseEvent(MeteoriteButtonClicked);
            Background.Append(MeteoriteButton);

            DemoniteCrimtaneButton = new EntranceButton(ModContent.GetTexture("VampKnives/UI/DemoniteCrimtaneButton"), "Demonite/Crimtane: 16bp");
            DemoniteCrimtaneButton.VAlign = RoMButtonsVPos1;
            DemoniteCrimtaneButton.HAlign = 1f;
            DemoniteCrimtaneButton.Width.Set(32, 0f);
            DemoniteCrimtaneButton.Height.Set(32, 0f);
            DemoniteCrimtaneButton.OnClick += new MouseEvent(DemoniteCrimtaneButtonClicked);
            Background.Append(DemoniteCrimtaneButton);

            HellstoneButton = new EntranceButton(ModContent.GetTexture("VampKnives/UI/HellstoneButton"), "Hellstone: 24bp");
            HellstoneButton.VAlign = RoMButtonsVPos2;
            HellstoneButton.HAlign = 0f;
            HellstoneButton.Width.Set(32, 0f);
            HellstoneButton.Height.Set(32, 0f);
            HellstoneButton.OnClick += new MouseEvent(HellstoneButtonClicked);
            Background.Append(HellstoneButton);

            CobaltPalladiumButton = new EntranceButton(ModContent.GetTexture("VampKnives/UI/CobaltPalladiumButton"), "Cobalt/Palladium: 50bp");
            CobaltPalladiumButton.VAlign = RoMButtonsVPos2;
            CobaltPalladiumButton.HAlign = 0.2f;
            CobaltPalladiumButton.Width.Set(32, 0f);
            CobaltPalladiumButton.Height.Set(32, 0f);
            CobaltPalladiumButton.OnClick += new MouseEvent(CobaltPalladiumButtonClicked);
            Background.Append(CobaltPalladiumButton);

            MythrilOrichalcumButton = new EntranceButton(ModContent.GetTexture("VampKnives/UI/MythrilOrichalcumButton"), "Mythril/Orichalcum: 75bp");
            MythrilOrichalcumButton.VAlign = RoMButtonsVPos2;
            MythrilOrichalcumButton.HAlign = 0.4f;
            MythrilOrichalcumButton.Width.Set(32, 0f);
            MythrilOrichalcumButton.Height.Set(32, 0f);
            MythrilOrichalcumButton.OnClick += new MouseEvent(MythrilOrichalcumButtonClicked);
            Background.Append(MythrilOrichalcumButton);

            AdamantiteTitaniumButton = new EntranceButton(ModContent.GetTexture("VampKnives/UI/AdamantiteTitaniumButton"), "Adamantite/Titanium: 100bp");
            AdamantiteTitaniumButton.VAlign = RoMButtonsVPos2;
            AdamantiteTitaniumButton.HAlign = 0.6f;
            AdamantiteTitaniumButton.Width.Set(32, 0f);
            AdamantiteTitaniumButton.Height.Set(32, 0f);
            AdamantiteTitaniumButton.OnClick += new MouseEvent(AdamantiteTitaniumButtonClicked);
            Background.Append(AdamantiteTitaniumButton);

            ChlorophyteButton = new EntranceButton(ModContent.GetTexture("VampKnives/UI/ChlorophyteButton"), "Chlorophyte: 150bp");
            ChlorophyteButton.VAlign = RoMButtonsVPos2;
            ChlorophyteButton.HAlign = 0.8f;
            ChlorophyteButton.Width.Set(32, 0f);
            ChlorophyteButton.Height.Set(32, 0f);
            ChlorophyteButton.OnClick += new MouseEvent(ChlorophyteButtonClicked);
            Background.Append(ChlorophyteButton);

            LuminiteButton = new EntranceButton(ModContent.GetTexture("VampKnives/UI/LuminiteButton"), "Luminite: 300bp");
            LuminiteButton.VAlign = RoMButtonsVPos2;
            LuminiteButton.HAlign = 1f;
            LuminiteButton.Width.Set(32, 0f);
            LuminiteButton.Height.Set(32, 0f);
            LuminiteButton.OnClick += new MouseEvent(LuminiteButtonClicked);
            Background.Append(LuminiteButton);

            UIFlatPanel SharpnessUnderline = new UIFlatPanel();
            SharpnessUnderline.BackgroundColor = Color.White;
            SharpnessUnderline.VAlign = -0.2f;
            SharpnessUnderline.HAlign = 0.5f;
            SharpnessUnderline.Width.Set(ButtonSize.X, 0f);
            SharpnessUnderline.Height.Set(6, 0f);
            //RitualOfStoneButton.Append(SharpnessUnderline);

            UIText Sharpness = new UIText("Rituals");
            Sharpness.Top.Set(-25, 0f);
            Sharpness.HAlign = 0.5f;
            //SharpnessUnderline.Append(Sharpness);

            Texture2D ActiveImage = ModContent.GetTexture("VampKnives/UI/ActiveButton");
            EarthActive = new UIImage(ActiveImage);
            EarthActive.HAlign = 0f;
            EarthActive.VAlign = RoSButtonVPos+0.01f;
            Background.Append(EarthActive);

            OwnerActiveText = new UIText(OwnerText);
            OwnerActiveText.HAlign = 0.6f;
            OwnerActiveText.VAlign = 0.025f;
            Background.Append(OwnerActiveText);

            EarthActiveText = new UIText("None");
            EarthActiveText.HAlign = 1f;
            EarthActiveText.VAlign = RoSButtonVPos + 0.01f;
            Background.Append(EarthActiveText);

            MinerActive = new UIImage(ActiveImage);
            MinerActive.HAlign = 0f;
            MinerActive.VAlign = RoMButtonVPos + 0.01f;
            Background.Append(MinerActive);

            MinerActiveText = new UIText("None");
            MinerActiveText.HAlign = 1f;
            MinerActiveText.VAlign = RoMButtonVPos + 0.01f;
            Background.Append(MinerActiveText);

            MidasActive = new UIImage(ActiveImage);
            MidasActive.HAlign = 0f;
            MidasActive.VAlign = RoMiButtonVPos - 0.01f;
            Background.Append(MidasActive);

            MidasActiveText = new UIText("None");
            MidasActiveText.HAlign = 1f;
            MidasActiveText.VAlign = RoMiButtonVPos - 0.01f;
            Background.Append(MidasActiveText);

            RitualOfMidasButton = new EntranceButton(ModContent.GetTexture("VampKnives/UI/RitualOfMidasButton"),"");
            RitualOfMidasButton.HAlign = 0.5f;
            RitualOfMidasButton.VAlign = RoMiButtonVPos;
            RitualOfMidasButton.OnClick += new MouseEvent(MidasRitualButtonClicked);
            Background.Append(RitualOfMidasButton);

            CopperCoinButton = new EntranceButton(ModContent.GetTexture("VampKnives/UI/CopperCoinButton"), "");
            CopperCoinButton.VAlign = 1.5f;
            CopperCoinButton.HAlign = 0.2f;
            CopperCoinButton.Width.Set(32, 0f);
            CopperCoinButton.Height.Set(32, 0f);
            CopperCoinButton.OnClick += new MouseEvent(CopperCoinButtonClick);
            RitualOfMidasButton.Append(CopperCoinButton);

            SilverCoinButton = new EntranceButton(ModContent.GetTexture("VampKnives/UI/SilverCoinButton"), "");
            SilverCoinButton.VAlign = 1.5f;
            SilverCoinButton.HAlign = 0.4f;
            SilverCoinButton.Width.Set(32, 0f);
            SilverCoinButton.Height.Set(32, 0f);
            SilverCoinButton.OnClick += new MouseEvent(SilverCoinButtonClick);
            RitualOfMidasButton.Append(SilverCoinButton);

            GoldCoinButton = new EntranceButton(ModContent.GetTexture("VampKnives/UI/GoldCoinButton"), "");
            GoldCoinButton.VAlign = 1.5f;
            GoldCoinButton.HAlign = 0.6f;
            GoldCoinButton.Width.Set(32, 0f);
            GoldCoinButton.Height.Set(32, 0f);
            GoldCoinButton.OnClick += new MouseEvent(GoldCoinButtonClick);
            RitualOfMidasButton.Append(GoldCoinButton);

            PlatinumCoinButton = new EntranceButton(ModContent.GetTexture("VampKnives/UI/PlatinumCoinButton"), "");
            PlatinumCoinButton.VAlign = 1.5f;
            PlatinumCoinButton.HAlign = 0.8f;
            PlatinumCoinButton.Width.Set(32, 0f);
            PlatinumCoinButton.Height.Set(32, 0f);
            PlatinumCoinButton.OnClick += new MouseEvent(PlatinumCoinButtonClick);
            RitualOfMidasButton.Append(PlatinumCoinButton);
        }
        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            ExamplePlayer p = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
            Texture2D ActiveImage = ModContent.GetTexture("VampKnives/UI/ActiveButton");
            Texture2D InActiveImage = ModContent.GetTexture("VampKnives/UI/InactiveButton");
            for (int iterations = 0; iterations < VampireWorld.AltarBeingUsed.Count; iterations += 2)
            {
                if (VampireWorld.AltarBeingUsed[iterations] == VampireWorld.MostRecentClick.X && VampireWorld.AltarBeingUsed[iterations + 1] == VampireWorld.MostRecentClick.Y)
                {
                    identifier = iterations;
                }
            }
            if (!VampireWorld.RitualOfTheStone[identifier])
            {
                EarthActive.SetImage(InActiveImage);
            }
            else
            {
                EarthActive.SetImage(ActiveImage);
            }
            if(!VampireWorld.RitualOfTheMiner[identifier])
            {
                MinerActive.SetImage(InActiveImage);
            }
            else
            {
                MinerActive.SetImage(ActiveImage);
            }
            if(!VampireWorld.RitualOfMidas[identifier])
            {
                MidasActive.SetImage(InActiveImage);
            }
            else
            {
                MidasActive.SetImage(ActiveImage);
            }
            EarthActiveText.SetText(EarthText);
            MinerActiveText.SetText(MinerText);
            MidasActiveText.SetText(MidasText);
            for (int i = 0; i < VampireWorld.AltarBeingUsed.Count; i++)
            {
                if(VampireWorld.AltarBeingUsed[i] == VampireWorld.MostRecentClick.X && VampireWorld.AltarBeingUsed[i+1] == VampireWorld.MostRecentClick.Y)
                {
                    OwnerText = "Owner: " + Main.player[VampireWorld.AltarOwner[i]].name;
                }
            }
            OwnerActiveText.SetText(OwnerText);

            base.DrawSelf(spriteBatch);

            Main.HidePlayerCraftingMenu = false;

            //if (!_vanillaItemSlot.Item.IsAir)
            //{
            //    KnifeWeapon UpgradeItem = _vanillaItemSlot.Item.GetGlobalItem<KnifeWeapon>();
            //}
        }
        private void ClaimButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            ExamplePlayer p = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
            for (int i = 0; i < VampireWorld.AltarBeingUsed.Count; i++)
            {
                if (VampireWorld.AltarBeingUsed[i] == VampireWorld.MostRecentClick.X && VampireWorld.AltarBeingUsed[i + 1] == VampireWorld.MostRecentClick.Y)
                {
                    VampireWorld.AltarOwner[i] = Main.LocalPlayer.whoAmI;
                }
            }
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                p.SendPackage = true;
            }
        }
        private void CloseButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            BloodAltarUI.visible = false;
        }
        int identifier;
        private void StoneRitualButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            ExamplePlayer p = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
            //Main.NewText("BoolListLength: " + VampireWorld.RitualOfTheStone.Count);
            //Main.NewText("AltarListLenght: " + VampireWorld.AltarBeingUsed.Count);
            //Main.NewText("Clicked");
            for(int iterations = 0; iterations < VampireWorld.AltarBeingUsed.Count; iterations+=2)
            {
                if(VampireWorld.AltarBeingUsed[iterations] == VampireWorld.MostRecentClick.X && VampireWorld.AltarBeingUsed[iterations+1] == VampireWorld.MostRecentClick.Y)
                {
                    //Main.NewText("FoundAltar");
                    identifier = iterations;
                    //p = Main.player[VampireWorld.AltarOwner[iterations]].GetModPlayer<ExamplePlayer>();
                    //Main.NewText("LocalPlayer: " + Main.LocalPlayer.name);
                    //Main.NewText("AltarOwner: " + Main.player[VampireWorld.AltarOwner[iterations]]);
                }
                //Main.NewText("Identifier" + identifier);
            }
            if (VampireWorld.RitualOfTheMiner[identifier])
            {
                Main.NewText("Please turn off the ritual of the Miner");
            }
            else  if(VampireWorld.RitualOfMidas[identifier])
            {
                Main.NewText("Please turn off the ritual of Midas");
            }
            else if(VampireWorld.RitualOfTheStone[identifier])
            {
                VampireWorld.RitualOfTheStone[identifier] = false;
                if (Main.netMode == 0)
                {
                    WorldGen.KillTile(VampireWorld.AltarBeingUsed[identifier] + 1, VampireWorld.AltarBeingUsed[identifier + 1] - 2);
                    WorldGen.KillTile(VampireWorld.AltarBeingUsed[identifier] + 1, VampireWorld.AltarBeingUsed[identifier + 1] - 1, false, false, true);
                }
                else
                {
                    p.SendKillPackage = true;
                }
            }
            else if (p.BloodPoints <= 1)
            {
                Main.NewText("You have too few blood points!");
            }
            else
            {
                VampireWorld.RitualOfTheStone[identifier] = true;
                if (Main.netMode == NetmodeID.MultiplayerClient)
                {
                    p.SendPackage = true;
                }
            }

            //Main.NewText("This altar True? : " + VampireWorld.RitualOfTheStone[identifier]);
        }

        private void StoneButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            ExamplePlayer p = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
            for (int iterations = 0; iterations < VampireWorld.AltarBeingUsed.Count; iterations += 2)
            {
                if (VampireWorld.AltarBeingUsed[iterations] == VampireWorld.MostRecentClick.X && VampireWorld.AltarBeingUsed[iterations + 1] == VampireWorld.MostRecentClick.Y)
                {
                    identifier = iterations;
                }
            }
            VampireWorld.RoEType[identifier] = TileID.Stone;
            EarthText = "Stone";
        }

        private void DirtButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            ExamplePlayer p = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
            for (int iterations = 0; iterations < VampireWorld.AltarBeingUsed.Count; iterations += 2)
            {
                if (VampireWorld.AltarBeingUsed[iterations] == VampireWorld.MostRecentClick.X && VampireWorld.AltarBeingUsed[iterations + 1] == VampireWorld.MostRecentClick.Y)
                {
                    identifier = iterations;
                }
            }
            VampireWorld.RoEType[identifier] = TileID.Dirt;
            EarthText = "Dirt";
        }

        private void SandButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            ExamplePlayer p = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
            for (int iterations = 0; iterations < VampireWorld.AltarBeingUsed.Count; iterations += 2)
            {
                if (VampireWorld.AltarBeingUsed[iterations] == VampireWorld.MostRecentClick.X && VampireWorld.AltarBeingUsed[iterations + 1] == VampireWorld.MostRecentClick.Y)
                {
                    identifier = iterations;
                }
            }
            VampireWorld.RoEType[identifier] = TileID.Sand;
            EarthText = "Sand";
        }

        private void SiltButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            ExamplePlayer p = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
            for (int iterations = 0; iterations < VampireWorld.AltarBeingUsed.Count; iterations += 2)
            {
                if (VampireWorld.AltarBeingUsed[iterations] == VampireWorld.MostRecentClick.X && VampireWorld.AltarBeingUsed[iterations + 1] == VampireWorld.MostRecentClick.Y)
                {
                    identifier = iterations;
                }
            }
            VampireWorld.RoEType[identifier] = TileID.Silt;
            EarthText = "Silt";
        }

        private void SnowButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            ExamplePlayer p = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
            for (int iterations = 0; iterations < VampireWorld.AltarBeingUsed.Count; iterations += 2)
            {
                if (VampireWorld.AltarBeingUsed[iterations] == VampireWorld.MostRecentClick.X && VampireWorld.AltarBeingUsed[iterations + 1] == VampireWorld.MostRecentClick.Y)
                {
                    identifier = iterations;
                }
            }
            VampireWorld.RoEType[identifier] = TileID.SnowBlock;
            EarthText = "Snow";
        }

        private void MinerRitualButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            ExamplePlayer p = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
            for (int iterations = 0; iterations < VampireWorld.AltarBeingUsed.Count; iterations += 2)
            {
                if (VampireWorld.AltarBeingUsed[iterations] == VampireWorld.MostRecentClick.X && VampireWorld.AltarBeingUsed[iterations + 1] == VampireWorld.MostRecentClick.Y)
                {
                    identifier = iterations;
                    //p = Main.player[VampireWorld.AltarOwner[iterations]].GetModPlayer<ExamplePlayer>();
                }
            }
            if (VampireWorld.RitualOfTheStone[identifier])
            {
                Main.NewText("Please turn off the ritual of the earth");
            }
            else if (VampireWorld.RitualOfMidas[identifier])
            {
                Main.NewText("Please turn off the ritual of Midas");
            }
            else if(!NPC.downedMechBossAny)
            {
                Main.NewText("You need to kill a mechanical boss before performing this ritual");
            }
            else if (p.BloodPoints <= 1)
            {
                Main.NewText("You have too few blood points!");
            }
            else if(!VampireWorld.RitualOfTheMiner[identifier])
            {
                VampireWorld.RitualOfTheMiner[identifier] = true;
                if (Main.netMode == NetmodeID.MultiplayerClient)
                {
                    p.SendPackage = true;
                }
            }
            else
            {
                VampireWorld.RitualOfTheMiner[identifier] = false;
                if (Main.netMode == 0)
                {
                    WorldGen.KillTile(VampireWorld.AltarBeingUsed[identifier] + 1, VampireWorld.AltarBeingUsed[identifier + 1] - 2);
                    WorldGen.KillTile(VampireWorld.AltarBeingUsed[identifier] + 1, VampireWorld.AltarBeingUsed[identifier + 1] - 1, false, false, true);
                }
                else
                {
                    p.SendKillPackage = true;
                }
            }
        }
        private void CopperTinButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            ExamplePlayer p = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
            for (int iterations = 0; iterations < VampireWorld.AltarBeingUsed.Count; iterations += 2)
            {
                if (VampireWorld.AltarBeingUsed[iterations] == VampireWorld.MostRecentClick.X && VampireWorld.AltarBeingUsed[iterations + 1] == VampireWorld.MostRecentClick.Y)
                {
                    identifier = iterations;
                }
            }
            if (VampireWorld.RoMType[identifier] == TileID.Copper)
            {
                WorldGen.KillTile(VampireWorld.AltarBeingUsed[identifier] + 1, VampireWorld.AltarBeingUsed[identifier + 1] - 2);
                VampireWorld.RoMType[identifier] = TileID.Tin;
                MinerText = "Tin";
            }
            else
            {
                WorldGen.KillTile(VampireWorld.AltarBeingUsed[identifier] + 1, VampireWorld.AltarBeingUsed[identifier + 1] - 2);
                VampireWorld.RoMType[identifier] = TileID.Copper;
                MinerText = "Copper";
            }

        }
        private void IronLeadButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            ExamplePlayer p = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
            for (int iterations = 0; iterations < VampireWorld.AltarBeingUsed.Count; iterations += 2)
            {
                if (VampireWorld.AltarBeingUsed[iterations] == VampireWorld.MostRecentClick.X && VampireWorld.AltarBeingUsed[iterations + 1] == VampireWorld.MostRecentClick.Y)
                {
                    identifier = iterations;
                }
            }
            if (VampireWorld.RoMType[identifier] == TileID.Iron)
            {
                WorldGen.KillTile(VampireWorld.AltarBeingUsed[identifier] + 1, VampireWorld.AltarBeingUsed[identifier + 1] - 2);
                VampireWorld.RoMType[identifier] = TileID.Lead;
                MinerText = "Lead";
            }
            else
            {
                WorldGen.KillTile(VampireWorld.AltarBeingUsed[identifier] + 1, VampireWorld.AltarBeingUsed[identifier + 1] - 2);
                VampireWorld.RoMType[identifier] = TileID.Iron;
                MinerText = "Iron";
            }

        }
        private void SilverTungstenButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            ExamplePlayer p = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
            for (int iterations = 0; iterations < VampireWorld.AltarBeingUsed.Count; iterations += 2)
            {
                if (VampireWorld.AltarBeingUsed[iterations] == VampireWorld.MostRecentClick.X && VampireWorld.AltarBeingUsed[iterations + 1] == VampireWorld.MostRecentClick.Y)
                {
                    identifier = iterations;
                }
            }
            if (VampireWorld.RoMType[identifier] == TileID.Silver)
            {
                WorldGen.KillTile(VampireWorld.AltarBeingUsed[identifier] + 1, VampireWorld.AltarBeingUsed[identifier + 1] - 2);
                VampireWorld.RoMType[identifier] = TileID.Tungsten;
                MinerText = "Tungsten";
            }
            else
            {
                WorldGen.KillTile(VampireWorld.AltarBeingUsed[identifier] + 1, VampireWorld.AltarBeingUsed[identifier + 1] - 2);
                VampireWorld.RoMType[identifier] = TileID.Silver;
                MinerText = "Silver";
            }

        }
        private void GoldPlatinumButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            ExamplePlayer p = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
            for (int iterations = 0; iterations < VampireWorld.AltarBeingUsed.Count; iterations += 2)
            {
                if (VampireWorld.AltarBeingUsed[iterations] == VampireWorld.MostRecentClick.X && VampireWorld.AltarBeingUsed[iterations + 1] == VampireWorld.MostRecentClick.Y)
                {
                    identifier = iterations;
                }
            }
            if (VampireWorld.RoMType[identifier] == TileID.Gold)
            {
                WorldGen.KillTile(VampireWorld.AltarBeingUsed[identifier] + 1, VampireWorld.AltarBeingUsed[identifier + 1] - 2);
                VampireWorld.RoMType[identifier] = TileID.Platinum;
                MinerText = "Platinum";
            }
            else
            {
                WorldGen.KillTile(VampireWorld.AltarBeingUsed[identifier] + 1, VampireWorld.AltarBeingUsed[identifier + 1] - 2);
                VampireWorld.RoMType[identifier] = TileID.Gold;
                MinerText = "Gold";
            }

        }
        private void MeteoriteButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            ExamplePlayer p = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
            for (int iterations = 0; iterations < VampireWorld.AltarBeingUsed.Count; iterations += 2)
            {
                if (VampireWorld.AltarBeingUsed[iterations] == VampireWorld.MostRecentClick.X && VampireWorld.AltarBeingUsed[iterations + 1] == VampireWorld.MostRecentClick.Y)
                {
                    identifier = iterations;
                }
            }
            WorldGen.KillTile(VampireWorld.AltarBeingUsed[identifier] + 1, VampireWorld.AltarBeingUsed[identifier + 1] - 2);
            VampireWorld.RoMType[identifier] = TileID.Meteorite;
            MinerText = "Meteorite";

        }
        private void DemoniteCrimtaneButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            ExamplePlayer p = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
            for (int iterations = 0; iterations < VampireWorld.AltarBeingUsed.Count; iterations += 2)
            {
                if (VampireWorld.AltarBeingUsed[iterations] == VampireWorld.MostRecentClick.X && VampireWorld.AltarBeingUsed[iterations + 1] == VampireWorld.MostRecentClick.Y)
                {
                    identifier = iterations;
                }
            }
            if (VampireWorld.RoMType[identifier] == TileID.Demonite)
            {
                WorldGen.KillTile(VampireWorld.AltarBeingUsed[identifier] + 1, VampireWorld.AltarBeingUsed[identifier + 1] - 2);
                VampireWorld.RoMType[identifier] = TileID.Crimtane;
                MinerText = "Crimtane";
            }
            else
            {
                WorldGen.KillTile(VampireWorld.AltarBeingUsed[identifier] + 1, VampireWorld.AltarBeingUsed[identifier + 1] - 2);
                VampireWorld.RoMType[identifier] = TileID.Demonite;
                MinerText = "Demonite";
            }

        }
        private void HellstoneButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            ExamplePlayer p = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
            for (int iterations = 0; iterations < VampireWorld.AltarBeingUsed.Count; iterations += 2)
            {
                if (VampireWorld.AltarBeingUsed[iterations] == VampireWorld.MostRecentClick.X && VampireWorld.AltarBeingUsed[iterations + 1] == VampireWorld.MostRecentClick.Y)
                {
                    identifier = iterations;
                }
            }
            WorldGen.KillTile(VampireWorld.AltarBeingUsed[identifier] + 1, VampireWorld.AltarBeingUsed[identifier + 1] - 2);
            VampireWorld.RoMType[identifier] = TileID.Hellstone;
            MinerText = "Hellstone";

        }
        private void CobaltPalladiumButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (!ExamplePlayer.HasHeldTier1)
            {
                Main.NewText("You need to mine palladium or cobalt before performing this ritual");
            }
            else
            {
                ExamplePlayer p = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
                for (int iterations = 0; iterations < VampireWorld.AltarBeingUsed.Count; iterations += 2)
                {
                    if (VampireWorld.AltarBeingUsed[iterations] == VampireWorld.MostRecentClick.X && VampireWorld.AltarBeingUsed[iterations + 1] == VampireWorld.MostRecentClick.Y)
                    {
                        identifier = iterations;
                    }
                }
                if (VampireWorld.RoMType[identifier] == TileID.Cobalt)
                {
                    WorldGen.KillTile(VampireWorld.AltarBeingUsed[identifier] + 1, VampireWorld.AltarBeingUsed[identifier + 1] - 2);
                    VampireWorld.RoMType[identifier] = TileID.Palladium;
                    MinerText = "Palladium";
                }
                else
                {
                    WorldGen.KillTile(VampireWorld.AltarBeingUsed[identifier] + 1, VampireWorld.AltarBeingUsed[identifier + 1] - 2);
                    VampireWorld.RoMType[identifier] = TileID.Cobalt;
                    MinerText = "Cobalt";
                }
            }
        }
        private void MythrilOrichalcumButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (!ExamplePlayer.HasHeldTier2)
            {
                Main.NewText("You need to mine orichalcum or mythril before performing this ritual");
            }
            else
            {
                ExamplePlayer p = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
                for (int iterations = 0; iterations < VampireWorld.AltarBeingUsed.Count; iterations += 2)
                {
                    if (VampireWorld.AltarBeingUsed[iterations] == VampireWorld.MostRecentClick.X && VampireWorld.AltarBeingUsed[iterations + 1] == VampireWorld.MostRecentClick.Y)
                    {
                        identifier = iterations;
                    }
                }
                if (VampireWorld.RoMType[identifier] == TileID.Mythril)
                {
                    WorldGen.KillTile(VampireWorld.AltarBeingUsed[identifier] + 1, VampireWorld.AltarBeingUsed[identifier + 1] - 2);
                    VampireWorld.RoMType[identifier] = TileID.Orichalcum;
                    MinerText = "Orichalcum";
                }
                else
                {
                    WorldGen.KillTile(VampireWorld.AltarBeingUsed[identifier] + 1, VampireWorld.AltarBeingUsed[identifier + 1] - 2);
                    VampireWorld.RoMType[identifier] = TileID.Mythril;
                    MinerText = "Mythril";
                }
            }
        }
        private void AdamantiteTitaniumButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (!ExamplePlayer.HasHeldTier3)
            {
                Main.NewText("You need to mine titanium or adamantite before performing this ritual");
            }
            else
            {
                ExamplePlayer p = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
                for (int iterations = 0; iterations < VampireWorld.AltarBeingUsed.Count; iterations += 2)
                {
                    if (VampireWorld.AltarBeingUsed[iterations] == VampireWorld.MostRecentClick.X && VampireWorld.AltarBeingUsed[iterations + 1] == VampireWorld.MostRecentClick.Y)
                    {
                        identifier = iterations;
                    }
                }
                if (VampireWorld.RoMType[identifier] == TileID.Adamantite)
                {
                    WorldGen.KillTile(VampireWorld.AltarBeingUsed[identifier] + 1, VampireWorld.AltarBeingUsed[identifier + 1] - 2);
                    VampireWorld.RoMType[identifier] = TileID.Titanium;
                    MinerText = "Titanium";
                }
                else
                {
                    WorldGen.KillTile(VampireWorld.AltarBeingUsed[identifier] + 1, VampireWorld.AltarBeingUsed[identifier + 1] - 2);
                    VampireWorld.RoMType[identifier] = TileID.Adamantite;
                    MinerText = "Adamantite";
                }
            }
        }
        private void ChlorophyteButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (!NPC.downedPlantBoss)
            {
                Main.NewText("You need to kill plantera before performing this ritual");
            }
            else
            {
                ExamplePlayer p = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
                for (int iterations = 0; iterations < VampireWorld.AltarBeingUsed.Count; iterations += 2)
                {
                    if (VampireWorld.AltarBeingUsed[iterations] == VampireWorld.MostRecentClick.X && VampireWorld.AltarBeingUsed[iterations + 1] == VampireWorld.MostRecentClick.Y)
                    {
                        identifier = iterations;
                    }
                }
                WorldGen.KillTile(VampireWorld.AltarBeingUsed[identifier] + 1, VampireWorld.AltarBeingUsed[identifier + 1] - 2);
                VampireWorld.RoMType[identifier] = TileID.Chlorophyte;
                MinerText = "Chlorophyte";
            }
        }
        private void LuminiteButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (!NPC.downedPlantBoss)
            {
                Main.NewText("You need to kill the moon lord before performing this ritual");
            }
            else
            {
                ExamplePlayer p = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
                for (int iterations = 0; iterations < VampireWorld.AltarBeingUsed.Count; iterations += 2)
                {
                    if (VampireWorld.AltarBeingUsed[iterations] == VampireWorld.MostRecentClick.X && VampireWorld.AltarBeingUsed[iterations + 1] == VampireWorld.MostRecentClick.Y)
                    {
                        identifier = iterations;
                    }
                }
                WorldGen.KillTile(VampireWorld.AltarBeingUsed[identifier] + 1, VampireWorld.AltarBeingUsed[identifier + 1] - 2);
                VampireWorld.RoMType[identifier] = TileID.LunarOre;
                MinerText = "Luminite";
            }
        }
        private void MidasRitualButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            ExamplePlayer p = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
            for (int iterations = 0; iterations < VampireWorld.AltarBeingUsed.Count; iterations += 2)
            {
                if (VampireWorld.AltarBeingUsed[iterations] == VampireWorld.MostRecentClick.X && VampireWorld.AltarBeingUsed[iterations + 1] == VampireWorld.MostRecentClick.Y)
                {
                    identifier = iterations;
                    //p = Main.player[VampireWorld.AltarOwner[iterations]].GetModPlayer<ExamplePlayer>();
                }
            }
            if (VampireWorld.RitualOfTheStone[identifier])
            {
                Main.NewText("Please turn off the ritual of the earth");
            }
            else if (VampireWorld.RitualOfTheMiner[identifier])
            {
                Main.NewText("Please turn off the ritual of the miner");
            }
            else if (p.BloodPoints <= 1)
            {
                Main.NewText("You have too few blood points!");
            }
            else if (!VampireWorld.RitualOfMidas[identifier])
            {
                VampireWorld.RitualOfMidas[identifier] = true;
            }
            else
            {
                VampireWorld.RitualOfMidas[identifier] = false;
            }
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                p.SendPackage = true;
            }
        }
        private void CopperCoinButtonClick(UIMouseEvent evt, UIElement listeningElement)
        {
            ExamplePlayer p = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
            for (int iterations = 0; iterations < VampireWorld.AltarBeingUsed.Count; iterations += 2)
            {
                if (VampireWorld.AltarBeingUsed[iterations] == VampireWorld.MostRecentClick.X && VampireWorld.AltarBeingUsed[iterations + 1] == VampireWorld.MostRecentClick.Y)
                {
                    identifier = iterations;
                }
            }
            VampireWorld.RoMiType[identifier] = ItemID.CopperCoin;
            MidasText = "Copper";
        }
        private void SilverCoinButtonClick(UIMouseEvent evt, UIElement listeningElement)
        {
            ExamplePlayer p = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
            for (int iterations = 0; iterations < VampireWorld.AltarBeingUsed.Count; iterations += 2)
            {
                if (VampireWorld.AltarBeingUsed[iterations] == VampireWorld.MostRecentClick.X && VampireWorld.AltarBeingUsed[iterations + 1] == VampireWorld.MostRecentClick.Y)
                {
                    identifier = iterations;
                }
            }
            VampireWorld.RoMiType[identifier] = ItemID.SilverCoin;
            MidasText = "Silver";
        }
        private void GoldCoinButtonClick(UIMouseEvent evt, UIElement listeningElement)
        {
            ExamplePlayer p = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
            for (int iterations = 0; iterations < VampireWorld.AltarBeingUsed.Count; iterations += 2)
            {
                if (VampireWorld.AltarBeingUsed[iterations] == VampireWorld.MostRecentClick.X && VampireWorld.AltarBeingUsed[iterations + 1] == VampireWorld.MostRecentClick.Y)
                {
                    identifier = iterations;
                }
            }
            VampireWorld.RoMiType[identifier] = ItemID.GoldCoin;
            MidasText = "Gold";
        }
        private void PlatinumCoinButtonClick(UIMouseEvent evt, UIElement listeningElement)
        {
            ExamplePlayer p = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
            for (int iterations = 0; iterations < VampireWorld.AltarBeingUsed.Count; iterations += 2)
            {
                if (VampireWorld.AltarBeingUsed[iterations] == VampireWorld.MostRecentClick.X && VampireWorld.AltarBeingUsed[iterations + 1] == VampireWorld.MostRecentClick.Y)
                {
                    identifier = iterations;
                }
            }
            VampireWorld.RoMiType[identifier] = ItemID.PlatinumCoin;
            MidasText = "Platinum";
        }
    }
}