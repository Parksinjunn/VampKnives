using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VampKnives.UI;
using Terraria.UI;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using VampKnives.Tiles;
using Terraria.ModLoader.IO;

namespace VampKnives
{
    public class VampKnives : Mod
    {
        public static VampKnives Instance { get; private set; }
        public static ModHotKey HoodUpDownHotkey;
        public static ModHotKey SupportHotKey;
        public static ModHotKey VampDashHotKey;
        public static ModHotKey SupportArmorHotKey;
        public static ModHotKey BookHotKey;
        public static int inventoryIndex;
        public UserInterface customRecources;
        public UserInterface customResources2;
        public UserInterface FirstLoadUI;
        public UserInterface StartupInterface;
        private StartupBookUI StartupState;
        private VampBar vampBar;
        private RecipePageState RecipePage;
        private WarningMessage warning;
        //private UserInterface WarningMessage;
        internal UserInterface WarningMessagePerson;
        internal UserInterface VampireUserInterface;
        internal UserInterface VampireUserInterface2;
        public static bool IsAmmoRecipe;
        public static bool IsKnifeRecipe;
        public static bool IsSharpeningRodRecipe;
        public static bool IsPlateRecipe;
        public static bool IsAmmoSculptRecipe;
        public static bool IsKnifeSculptRecipe;
        public static bool IsSharpeningSculptRecipe;
        public static bool HammerInSlot;
        public static bool ChiselInSlot;
        public UserInterface WorkbenchSlots;
        private WorkbenchSlotState WorkbenchSlotPanel;
        internal static UserInterface UpgradePanelUI;
        private UpgradePanel UpgradePanelState;
        internal static UserInterface BloodAltarUIPanel;
        private BloodAltarUI BloodAltarUIState;
        private GameTime _lastUpdateUiGameTime;
        bool MarkForDeletion;
        public static bool UIOpenElsewhere;
        public static float ConfigDamageMult = 1f;
        public static float ConfigHealAmntMult = 1f;
        public static float HealProjectileSpawn = 1f;
        public static float AmmoDefenseDecrease = 1f;

        //public static List<int> BloodAltarPosition = new List<int>();

        public static int SharpnessUpgradeCounter;
        public static int CritUpgradeCounter;
        public static int SpecialUpgradeCounter;
        bool Error;
        string ErrorMessage;
        int ErrorTimer;
        //public static ModPacket MyPacket;
        //public static int MyPacketIdentifier;
        //private UserInterface VampBarInterface;
        //public VampBar vampbar;
        //private VampResource VampResource;
        public VampKnives()
        {
            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(this);
            ModRecipe recipe2 = new ModRecipe(this);
            ModRecipe recipe3 = new ModRecipe(this);
            ModRecipe recipe4 = new ModRecipe(this);
            ModRecipe recipe5 = new ModRecipe(this);
            ModRecipe recipe6 = new ModRecipe(this);
            ModRecipe recipe7 = new ModRecipe(this);
            ModRecipe recipe8 = new ModRecipe(this);
            ModRecipe recipe9 = new ModRecipe(this);
            ModRecipe recipe10 = new ModRecipe(this);
            ModRecipe recipe11 = new ModRecipe(this);
            recipe.AddIngredient(this.GetItem("IronKnives"), 1);
            recipe.AddIngredient(ItemID.CrimsonKey, 1);
            recipe.AddTile(this.GetTile("KnifeBench"));
            recipe.SetResult(ItemID.VampireKnives);
            recipe.AddRecipe();
            recipe2.AddIngredient(this.GetItem("WeakVampireKnives"), 1);
            recipe2.AddIngredient(this.GetItem("LivingTissue"), 1);
            recipe2.AddTile(this.GetTile("KnifeBench"));
            recipe2.SetResult(ItemID.VampireKnives);
            recipe2.AddRecipe();
            recipe3.AddIngredient(ItemID.GlowingMushroom, 1);
            recipe3.AddIngredient(ItemID.BottledWater, 1);
            recipe3.AddTile(TileID.AlchemyTable);
            recipe3.SetResult(ItemID.LesserManaPotion);
            recipe3.AddRecipe();
            recipe4.AddIngredient(this.GetItem("Chisel"), 1);
            recipe4.AddTile(TileID.Furnaces);
            recipe4.SetResult(ItemID.IronBar);
            recipe4.AddRecipe();
            recipe5.AddIngredient(this.GetItem("Hammer"), 1);
            recipe5.AddTile(TileID.Furnaces);
            recipe5.SetResult(ItemID.IronBar, 1);
            recipe5.AddRecipe();
            recipe6.AddIngredient(this.GetItem("DartCast"));
            recipe6.AddTile(TileID.Furnaces);
            recipe6.SetResult(ItemID.IronBar, 3);
            recipe6.AddRecipe();
            recipe7.AddIngredient(this.GetItem("IronKnivesMold"));
            recipe7.AddTile(TileID.Furnaces);
            recipe7.SetResult(ItemID.IronBar, 3);
            recipe7.AddRecipe();
            recipe8.AddIngredient(this.GetItem("Chisel"), 1);
            recipe8.AddTile(TileID.Furnaces);
            recipe8.SetResult(ItemID.LeadBar);
            recipe8.AddRecipe();
            recipe9.AddIngredient(this.GetItem("Hammer"), 1);
            recipe9.AddTile(TileID.Furnaces);
            recipe9.SetResult(ItemID.LeadBar, 1);
            recipe9.AddRecipe();
            recipe10.AddIngredient(this.GetItem("DartCast"));
            recipe10.AddTile(TileID.Furnaces);
            recipe10.SetResult(ItemID.LeadBar, 3);
            recipe10.AddRecipe();
            recipe11.AddIngredient(this.GetItem("IronKnivesMold"));
            recipe11.AddTile(TileID.Furnaces);
            recipe11.SetResult(ItemID.LeadBar, 3);
            recipe11.AddRecipe();
            recipe11 = new ModRecipe(this);
            recipe11.AddIngredient(this.GetItem("SharpeningRodCast"));
            recipe11.AddTile(TileID.Furnaces);
            recipe11.SetResult(ItemID.LeadBar, 3);
            recipe11.AddRecipe();
            recipe11 = new ModRecipe(this);
            recipe11.AddIngredient(this.GetItem("SharpeningRodCast"));
            recipe11.AddTile(TileID.Furnaces);
            recipe11.SetResult(ItemID.IronBar, 3);
            recipe11.AddRecipe();
            //LIVINGFIREBLOCK
            recipe11 = new ModRecipe(this);
            recipe11.AddIngredient(ItemID.HellstoneBrick, 5);
            recipe11.AddIngredient(ItemID.Fireblossom);
            recipe11.needLava = true;
            recipe11.SetResult(ItemID.LivingFireBlock, 5);
            recipe11.AddRecipe();
            recipe11 = new ModRecipe(this);
            recipe11.AddIngredient(ItemID.HellstoneBrick, 25);
            recipe11.AddIngredient(ItemID.Fireblossom, 5);
            recipe11.AddTile(TileID.Hellforge);
            recipe11.SetResult(ItemID.LivingFireBlock, 5);
            recipe11.AddRecipe();

            HammerRecipe HammerConvertRecipe = new HammerRecipe(this);
            //Sand
            HammerConvertRecipe.AddIngredient(ItemID.StoneBlock, 6);
            HammerConvertRecipe.AddTile(this.GetTile("KnifeBench"));
            HammerConvertRecipe.SetResult(ItemID.SandBlock, 5);
            HammerConvertRecipe.AddRecipe();
            HammerConvertRecipe = new HammerRecipe(this);
            HammerConvertRecipe.AddIngredient(ItemID.StoneBlock, 6);
            HammerConvertRecipe.AddTile(this.GetTile("VampTableTile"));
            HammerConvertRecipe.SetResult(ItemID.SandBlock, 5);
            HammerConvertRecipe.AddRecipe();
            //Silt
            HammerConvertRecipe = new HammerRecipe(this);
            HammerConvertRecipe.AddIngredient(ItemID.StoneBlock, 3);
            HammerConvertRecipe.AddIngredient(ItemID.DirtBlock, 3);
            HammerConvertRecipe.AddTile(this.GetTile("KnifeBench"));
            HammerConvertRecipe.SetResult(ItemID.SiltBlock, 5);
            HammerConvertRecipe.AddRecipe();
            HammerConvertRecipe = new HammerRecipe(this);
            HammerConvertRecipe.AddIngredient(ItemID.StoneBlock, 3);
            HammerConvertRecipe.AddIngredient(ItemID.DirtBlock, 3);
            HammerConvertRecipe.AddTile(this.GetTile("VampTableTile"));
            HammerConvertRecipe.SetResult(ItemID.SiltBlock, 5);
            HammerConvertRecipe.AddRecipe();

            HammerAndChiselRecipe ConvertRecipe = new HammerAndChiselRecipe(this);
            //Marble
            ConvertRecipe.AddIngredient(ItemID.PearlstoneBlock, 3);
            ConvertRecipe.AddTile(this.GetTile("KnifeBench"));
            ConvertRecipe.SetResult(ItemID.Marble, 2);
            ConvertRecipe.AddRecipe();
            ConvertRecipe = new HammerAndChiselRecipe(this);
            ConvertRecipe.AddIngredient(ItemID.PearlstoneBlock, 3);
            ConvertRecipe.AddTile(this.GetTile("VampTableTile"));
            ConvertRecipe.SetResult(ItemID.Marble, 2);
            ConvertRecipe.AddRecipe();
            //Granite
            ConvertRecipe = new HammerAndChiselRecipe(this);
            ConvertRecipe.AddIngredient(ItemID.Obsidian);
            ConvertRecipe.AddIngredient(ItemID.CrimstoneBlock, 5);
            ConvertRecipe.AddTile(this.GetTile("KnifeBench"));
            ConvertRecipe.SetResult(ItemID.Granite, 5);
            ConvertRecipe.AddRecipe();
            ConvertRecipe = new HammerAndChiselRecipe(this);
            ConvertRecipe.AddIngredient(ItemID.Obsidian);
            ConvertRecipe.AddIngredient(ItemID.EbonstoneBlock, 5);
            ConvertRecipe.AddTile(this.GetTile("KnifeBench"));
            ConvertRecipe.SetResult(ItemID.Granite, 5);
            ConvertRecipe.AddRecipe();
            ConvertRecipe = new HammerAndChiselRecipe(this);
            ConvertRecipe.AddIngredient(ItemID.Obsidian);
            ConvertRecipe.AddIngredient(ItemID.CrimstoneBlock, 5);
            ConvertRecipe.AddTile(this.GetTile("VampTableTile"));
            ConvertRecipe.SetResult(ItemID.Granite, 5);
            ConvertRecipe.AddRecipe();
            ConvertRecipe = new HammerAndChiselRecipe(this);
            ConvertRecipe.AddIngredient(ItemID.Obsidian);
            ConvertRecipe.AddIngredient(ItemID.EbonstoneBlock, 5);
            ConvertRecipe.AddTile(this.GetTile("VampTableTile"));
            ConvertRecipe.SetResult(ItemID.Granite, 5);
            ConvertRecipe.AddRecipe();
        }
        int SoulsRitualDelay;
        //public override void MidUpdateTimeWorld()
        //{
        //    VampPlayer p = Main.LocalPlayer.GetModPlayer<VampPlayer>();
        //    for (int iterations = 0; iterations < VampireWorld.AltarBeingUsed.Count; iterations += 2)
        //    {

        //        //Main.NewText("RitualOfTheStone: " + (VampireWorld.RitualOfTheStone[iterations], VampireWorld.RitualOfTheStone[iterations + 1]));
        //        //if (p.BloodPoints <= 1)
        //        //{
        //        //    Error = true;
        //        //    ErrorMessage = "Not Enough blood points";
        //        //}
        //        if ((VampireWorld.RitualOfTheStone[iterations] && VampireWorld.RitualOfTheMiner[iterations]) || (VampireWorld.RitualOfTheStone[iterations] && VampireWorld.RitualOfMidas[iterations]) || (VampireWorld.RitualOfTheMiner[iterations] && VampireWorld.RitualOfMidas[iterations]))
        //        {
        //            VampireWorld.RitualOfTheStone[iterations] = false;
        //            VampireWorld.RitualOfTheMiner[iterations] = false;
        //            VampireWorld.RitualOfMidas[iterations] = false;
        //            if (Main.netMode == NetmodeID.MultiplayerClient)
        //            {
        //                p.SendPackage = true;
        //            }
        //        }
        //        if (VampireWorld.RoEType[iterations] == TileID.AmberGemspark && VampireWorld.RitualOfTheStone[iterations] == true)
        //        {
        //            Error = true;
        //            ErrorMessage = "Please choose a material";
        //        }
        //        if (VampireWorld.RitualOfTheStone[iterations] == true && Error != true)
        //        {
        //            //Main.NewText("Working!");
        //            if (Main.netMode != NetmodeID.MultiplayerClient)
        //            {
        //                StoneRitual((int)VampireWorld.AltarBeingUsed[iterations], (int)VampireWorld.AltarBeingUsed[iterations + 1], Main.player[VampireWorld.AltarOwner[iterations]], VampireWorld.RoEType[iterations]);
        //            }
        //            else
        //            {
        //                this.Logger.Warn("Stone Ritual Sent to server");
        //                ModPacket StoneRitualOn = this.GetPacket();
        //                StoneRitualOn.Write(StoneRitualRecieve);
        //                StoneRitualOn.Write(iterations);
        //                StoneRitualOn.Write(VampireWorld.AltarOwner[iterations]);
        //                StoneRitualOn.Write(VampireWorld.AltarBeingUsed[iterations] + 1);
        //                StoneRitualOn.Write(VampireWorld.AltarBeingUsed[iterations + 1] - 2);
        //                StoneRitualOn.Write(VampireWorld.RoEType[iterations]);
        //                StoneRitualOn.Send();
        //            }
        //        }
        //        if (VampireWorld.RoMType[iterations] == TileID.AmberGemspark && VampireWorld.RitualOfTheMiner[iterations] == true)
        //        {
        //            Error = true;
        //            ErrorMessage = "Please choose a material";
        //        }
        //        if (VampireWorld.RitualOfTheMiner[iterations] == true && Error != true)
        //        {
        //            if (Main.netMode != NetmodeID.MultiplayerClient)
        //            {
        //                MinerRitual((int)VampireWorld.AltarBeingUsed[iterations], (int)VampireWorld.AltarBeingUsed[iterations + 1], Main.player[VampireWorld.AltarOwner[iterations]], VampireWorld.RoMType[iterations]);
        //            }
        //            else
        //            {
        //                ModPacket MinerRitualOn = this.GetPacket();
        //                MinerRitualOn.Write(MinerRitualRecieve);
        //                MinerRitualOn.Write(iterations);
        //                MinerRitualOn.Write(VampireWorld.AltarOwner[iterations]);
        //                MinerRitualOn.Write(VampireWorld.AltarBeingUsed[iterations] + 1);
        //                MinerRitualOn.Write(VampireWorld.AltarBeingUsed[iterations + 1] - 2);
        //                MinerRitualOn.Write(VampireWorld.RoMType[iterations]);
        //                MinerRitualOn.Send();
        //            }
        //        }
        //        if (VampireWorld.RitualOfMidas[iterations] == true && Error != true)
        //        {
        //            if (Main.netMode != NetmodeID.MultiplayerClient)
        //            {
        //                MidasRitual((int)VampireWorld.AltarBeingUsed[iterations], (int)VampireWorld.AltarBeingUsed[iterations + 1], Main.player[VampireWorld.AltarOwner[iterations]], VampireWorld.RoMiType[iterations]);
        //            }
        //            else
        //            {
        //                ModPacket MidasRitualOn = this.GetPacket();
        //                MidasRitualOn.Write(MidasRitualRecieve);
        //                MidasRitualOn.Write(iterations);
        //                MidasRitualOn.Write(VampireWorld.AltarOwner[iterations]);
        //                MidasRitualOn.Write(VampireWorld.AltarBeingUsed[iterations] + 1);
        //                MidasRitualOn.Write(VampireWorld.AltarBeingUsed[iterations + 1] - 2);
        //                MidasRitualOn.Write(VampireWorld.RoMiType[iterations]);
        //                MidasRitualOn.Send();
        //            }
        //        }
        //        if (VampireWorld.RoSoTypeAndDelay[iterations] == 69 && VampireWorld.RitualOfSouls[iterations] == true)
        //        {
        //            Error = true;
        //            ErrorMessage = "The blood crystal is empty";
        //        }
        //        if (VampireWorld.RitualOfSouls[iterations] == true && !Error)
        //        {
        //            Main.NewText("Delay: " + SoulsRitualDelay);
        //            if (SoulsRitualDelay >= VampireWorld.RoSoTypeAndDelay[iterations + 1])
        //            {
        //                SoulsRitualDelay = 0;
        //                NPC.NewNPC((VampireWorld.AltarBeingUsed[iterations] + 1) * 16, (VampireWorld.AltarBeingUsed[iterations + 1] + 1) * 16, VampireWorld.RoSoTypeAndDelay[iterations]);
        //                Main.NewText("Spawned");
        //            }
        //            SoulsRitualDelay++;
        //        }
        //    }
        //    if (Error)
        //    {
        //        Main.NewText("Error!");
        //    }
        //    if (UI.BloodAltarUI.visible)
        //        ErrorTimer++;
        //    if (Error == true && ErrorTimer > 120)
        //    {
        //        Main.NewText("" + ErrorMessage);
        //        Error = false;
        //        ErrorTimer = 0;
        //    }
        //    if (p.BloodPoints <= 1)
        //    {
        //        p.TurnOffRituals(Main.LocalPlayer);
        //    }
        //}
        public override void Load()
        {
            Instance = this;
            HoodUpDownHotkey = RegisterHotKey("Pull hood up or down", "P");
            SupportHotKey = RegisterHotKey("Key to add/remove support debuff", "L");
            VampDashHotKey = RegisterHotKey("Double tap to transform into a bat for a few seconds(Requires vampiric armor)", "D");
            SupportArmorHotKey = RegisterHotKey("Key to use the support armor's buff", "C");
            BookHotKey = RegisterHotKey("Key to open the in-game guide", "H");
            if (!Main.dedServ)
            {
                //AddEquipTexture(null, EquipType.Legs, "ExampleRobe_Legs", "ExampleMod/Items/Armor/ExampleRobe_Legs");
                AddEquipTexture(new Items.Armor.PyroHead(), null, EquipType.Head, "PyroHead", "VampKnives/Items/Armor/PyromancersHood_Head");
                AddEquipTexture(new Items.Armor.DPyroHead(), null, EquipType.Head, "DPyroHead", "VampKnives/Items/Armor/DarkPyromancersHood_Head");
                AddEquipTexture(new Items.Armor.TransmuterHead(), null, EquipType.Head, "TransmuterHead", "VampKnives/Items/Armor/TransmutersHood_Head");
                AddEquipTexture(new Items.Armor.InvokerHead(), null, EquipType.Head, "InvokerHead", "VampKnives/Items/Armor/InvokersHood_Head");
                AddEquipTexture(new Items.Armor.TechnomancerHead(), null, EquipType.Head, "TechnomancerHead", "VampKnives/Items/Armor/TechnomancersHood_Head");
                AddEquipTexture(new Items.Armor.PartyHead(), null, EquipType.Head, "PartyHead", "VampKnives/Items/Armor/PartyHood_Head");
                AddEquipTexture(new Items.Armor.ShamanHead(), null, EquipType.Head, "ShamanHead", "VampKnives/Items/Armor/ShamansHood_Head");
                AddEquipTexture(new Items.Armor.WitchDoctorHead(), null, EquipType.Head, "WitchDoctorHead", "VampKnives/Items/Armor/WitchDoctorHood_Head");
                AddEquipTexture(new Items.Armor.MageHead(), null, EquipType.Head, "MageHead", "VampKnives/Items/Armor/MagesHood_Head");
                AddEquipTexture(null, EquipType.Head, "BatTransform", "VampKnives/Items/Armor/BatTransform");
                AddEquipTexture(null, EquipType.Head, "BatTransformHidden", "VampKnives/Items/Armor/BatTransformHidden");
                AddEquipTexture(null, EquipType.Wings, "BatFlyMovement", "VampKnives/Items/Armor/BatFlyMovement");
                AddEquipTexture(null, EquipType.Wings, "BatWingsHidden", "VampKnives/Items/Armor/BatWingsHidden");
                AddEquipTexture(null, EquipType.Head, "VeiTransformHead", "VampKnives/Items/VtuberItems/SuccubusHeartCorset_Head");
                AddEquipTexture(null, EquipType.Body, "VeiTransformBody", "VampKnives/Items/VtuberItems/SuccubusHeartCorset_Body", "VampKnives/Items/VtuberItems/SuccubusHeartCorset_Arms");
                AddEquipTexture(null, EquipType.Legs, "VeiTransformLegs", "VampKnives/Items/VtuberItems/SuccubusHeartCorset_Legs");
                AddEquipTexture(null, EquipType.Head, "NyanTransformHead", "VampKnives/Items/VtuberItems/GamerHeadphones_Head");
                AddEquipTexture(null, EquipType.Body, "NyanTransformBody", "VampKnives/Items/VtuberItems/GamerHeadphones_Body", "VampKnives/Items/VtuberItems/GamerHeadphones_Arms");
                AddEquipTexture(null, EquipType.Legs, "NyanTransformLegs", "VampKnives/Items/VtuberItems/GamerHeadphones_Legs"); 
                AddEquipTexture(null, EquipType.Head, "MouseTransformHead", "VampKnives/Items/VtuberItems/DemonLoli_Head");
                AddEquipTexture(null, EquipType.Body, "MouseTransformBody", "VampKnives/Items/VtuberItems/DemonLoli_Body", "VampKnives/Items/VtuberItems/DemonLoli_Arms");
                AddEquipTexture(null, EquipType.Legs, "MouseTransformLegs", "VampKnives/Items/VtuberItems/DemonLoli_Legs");
                customRecources = new UserInterface();
                customResources2 = new UserInterface();
                FirstLoadUI = new UserInterface();
                vampBar = new VampBar();
                VampBar.visible = true;
                RecipePage = new RecipePageState();
                customResources2.SetState(RecipePage);
                customRecources.SetState(vampBar);
                VampireUserInterface = new UserInterface();
                VampireUserInterface2 = new UserInterface();

                WorkbenchSlots = new UserInterface();
                WorkbenchSlotPanel = new WorkbenchSlotState();
                WorkbenchSlots.SetState(WorkbenchSlotPanel);

                UpgradePanelUI = new UserInterface();
                //UpgradePanelState = new UpgradePanel();
                //UpgradePanelUI.SetState(UpgradePanelState);

                BloodAltarUIPanel = new UserInterface();
                //BloodAltarUIState = new BloodAltarUI();
                //BloodAltarUIPanel.SetState(BloodAltarUIState);

                StartupInterface = new UserInterface();
                StartupState = new StartupBookUI();
                StartupInterface.SetState(StartupState);
            }
            if (Main.netMode != NetmodeID.Server)
            {
                Ref<Effect> shaderRef = new Ref<Effect>(GetEffect("Effects/MilkShader"));
                GameShaders.Misc["Technique1"] = new MiscShaderData(shaderRef, "ArmorBasic").UseColor(new Vector3(Color.Brown.R/255f, Color.Brown.G/255f, Color.Brown.B/255f));
            }
            base.Load();
        }
        public override void UpdateMusic(ref int music, ref MusicPriority priority)
        {
            if (Main.myPlayer == -1 || Main.gameMenu || !Main.LocalPlayer.active)
            {
                return;
            }
            if (Main.LocalPlayer.HeldItem.type == ModContent.ItemType<Items.VtuberItems.MaracasSound>() && Main.LocalPlayer.controlUseItem)
                music = this.GetSoundSlot(SoundType.Music, "Sounds/Music/MaracasNormal");
        }
        public override void UpdateUI(GameTime gameTime)
        {
            _lastUpdateUiGameTime = gameTime;
            if (UpgradePanelUI?.CurrentState != null)
            {
                UpgradePanelUI.Update(gameTime);
            }
            if(BloodAltarUIPanel?.CurrentState != null)
            {
                BloodAltarUIPanel.Update(gameTime);
            }
            VampireUserInterface?.Update(gameTime);
            VampireUserInterface2?.Update(gameTime);
            if (IsKnifeRecipe)
            {
                RecipePageState.IsAmmoRecipe = false;
                RecipePageState.IsKnifeRecipe = true;
                RecipePageState.IsSharpeningRodRecipe = false;
                RecipePageState.IsPlateRecipe = false;
                RecipePageState.IsAmmoSculptRecipe = false;
                RecipePageState.IsKnifeSculptRecipe = false;
                RecipePageState.IsSharpeningSculptRecipe = false;
            }
            else if (IsAmmoRecipe)
            {
                RecipePageState.IsAmmoRecipe = true;
                RecipePageState.IsKnifeRecipe = false;
                RecipePageState.IsSharpeningRodRecipe = false;
                RecipePageState.IsPlateRecipe = false;
                RecipePageState.IsAmmoSculptRecipe = false;
                RecipePageState.IsKnifeSculptRecipe = false;
                RecipePageState.IsSharpeningSculptRecipe = false;
            }
            else if (IsSharpeningRodRecipe)
            {
                RecipePageState.IsAmmoRecipe = false;
                RecipePageState.IsKnifeRecipe = false;
                RecipePageState.IsSharpeningRodRecipe = true;
                RecipePageState.IsPlateRecipe = false;
                RecipePageState.IsAmmoSculptRecipe = false;
                RecipePageState.IsKnifeSculptRecipe = false;
                RecipePageState.IsSharpeningSculptRecipe = false;
            }
            else if (IsPlateRecipe)
            {
                RecipePageState.IsAmmoRecipe = false;
                RecipePageState.IsKnifeRecipe = false;
                RecipePageState.IsSharpeningRodRecipe = false;
                RecipePageState.IsPlateRecipe = true;
                RecipePageState.IsAmmoSculptRecipe = false;
                RecipePageState.IsKnifeSculptRecipe = false;
                RecipePageState.IsSharpeningSculptRecipe = false;
            }
            else if (IsAmmoSculptRecipe)
            {
                RecipePageState.IsAmmoRecipe = false;
                RecipePageState.IsKnifeRecipe = false;
                RecipePageState.IsSharpeningRodRecipe = false;
                RecipePageState.IsPlateRecipe = false;
                RecipePageState.IsAmmoSculptRecipe = true;
                RecipePageState.IsKnifeSculptRecipe = false;
                RecipePageState.IsSharpeningSculptRecipe = false;
            }
            else if (IsKnifeSculptRecipe)
            {
                RecipePageState.IsAmmoRecipe = false;
                RecipePageState.IsKnifeRecipe = false;
                RecipePageState.IsSharpeningRodRecipe = false;
                RecipePageState.IsPlateRecipe = false;
                RecipePageState.IsAmmoSculptRecipe = false;
                RecipePageState.IsKnifeSculptRecipe = true;
                RecipePageState.IsSharpeningSculptRecipe = false;
            }
            else if (IsSharpeningSculptRecipe)
            {
                RecipePageState.IsAmmoRecipe = false;
                RecipePageState.IsKnifeRecipe = false;
                RecipePageState.IsSharpeningRodRecipe = false;
                RecipePageState.IsPlateRecipe = false;
                RecipePageState.IsAmmoSculptRecipe = false;
                RecipePageState.IsKnifeSculptRecipe = false;
                RecipePageState.IsSharpeningSculptRecipe = true;
            }
            else
            {
                IsKnifeRecipe = false;
                IsAmmoRecipe = false;
                IsSharpeningRodRecipe = false;
                IsPlateRecipe = false;
                IsAmmoSculptRecipe = false;
                IsKnifeSculptRecipe = false;
                IsSharpeningSculptRecipe = false;
            }
        }
        bool PacketWorking;
        public override void PreSaveAndQuit()
        {
            //Calls Deactivate and drops the item
            if (UpgradePanelUI.CurrentState != null)
            {
                UpgradePanelUI.SetState(null);
            }
            if (BloodAltarUIPanel.CurrentState != null)
            {
                BloodAltarUIPanel.SetState(null);
            }
        }
        internal static void OpenUpgradeUI()
        {
            UpgradePanel ui = new UpgradePanel();
            UIState state = new UIState();
            state.Append(ui);
            UpgradePanelUI.SetState(state);
        }

        internal static void CloseUpgradeUI()
        {
            UpgradePanelUI.SetState(null);
        }

        internal static void OpenBloodAltarUI()
        {
            BloodAltarUI ui = new BloodAltarUI();
            UIState state = new UIState();
            state.Append(ui);
            BloodAltarUIPanel.SetState(state);
        }

        internal static void CloseBloodAltarUI()
        {
            BloodAltarUIPanel.SetState(null);
        }
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int index = layers.FindIndex(layer => layer.Name.Contains("Vanilla: Mouse Text"));
            if (index != -1)
            {
                layers.Insert(index, new LegacyGameInterfaceLayer("VampBars: Blood Resource Bar", delegate
                {
                    if (VampBar.visible)
                    {
                        customRecources.Update(Main._drawInterfaceGameTime);
                        vampBar.Draw(Main.spriteBatch);
                    }
                    if (RecipePageState.visible)
                    {
                        customResources2.Update(Main._drawInterfaceGameTime);
                        RecipePage.Draw(Main.spriteBatch);
                    }
                    if (WorkbenchSlotState.visible)
                    {
                        WorkbenchSlots.Update(Main._drawInterfaceGameTime);
                        WorkbenchSlotPanel.Draw(Main.spriteBatch);
                    }
                    if (_lastUpdateUiGameTime != null && UpgradePanelUI.CurrentState != null)
                    {
                        UpgradePanelUI.Draw(Main.spriteBatch, _lastUpdateUiGameTime);
                        //UpgradePanelState.Draw(Main.spriteBatch);
                    }
                    if (_lastUpdateUiGameTime != null && BloodAltarUIPanel.CurrentState != null)
                    {
                        BloodAltarUIPanel.Draw(Main.spriteBatch, _lastUpdateUiGameTime);
                        //BloodAltarUIState.Draw(Main.spriteBatch);
                    }
                    if (StartupBookUI.visible)
                    {
                        StartupInterface.Update(Main._drawInterfaceGameTime);
                        StartupState.Draw(Main.spriteBatch);
                    }
                    return true;
                }));
                if (Main.playerInventory == false && WorkbenchSlotState.visible)
                {
                    WorkbenchSlotState.visible = false;
                }
                if (Main.playerInventory == false && UpgradePanel.visible)
                {
                    UpgradePanel.visible = false;
                }
                if (Main.playerInventory == false && BloodAltarUI.visible)
                {
                    BloodAltarUI.visible = false;
                }
                if (Main.playerInventory == true && StartupBookUI.visible)
                {
                    StartupBookUI.visible = false;
                }
            }
            inventoryIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Inventory"));
            if (inventoryIndex != -1)
            {
                layers.Insert(inventoryIndex, new LegacyGameInterfaceLayer(
                    "Skin shop UI",
                    delegate
                    {
                        VampireUserInterface.Draw(Main.spriteBatch, new GameTime());
                        VampireUserInterface2.Draw(Main.spriteBatch, new GameTime());
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
        }
        public override void Unload()
        {
            HoodUpDownHotkey = null;
            SupportHotKey = null;
            VampDashHotKey = null;
            SupportArmorHotKey = null;
            BookHotKey = null;
            Instance = null;
            if(!Main.dedServ)
            {
                UpgradePanelUI = null;
                BloodAltarUIPanel = null;
            }
            base.Unload();
        }
        public static int OwnerRecieve = 1;
        int OwnerSend = 2;
        public static int ResetSpaceServer = 3;
        int ResetSpaceMPClient = 4;
        public static int SyncBloodPoints = 5;
        public static int RitualCostRecieveMPClient = 6;
        public static int StoneRitualRecieveMPClient = 7;
        public static int MinerRitualRecieveMPClient = 8;
        public static int MidasRitualRecieveMPClient = 9;
        public static int SoulsRitualRecieveMPClient = 10;
        public static int SoulItemSync = 11;
        int SoulItemSyncClient = 12;
        public static int HoodServerRecieve = 20;
        int HoodSendToClient = 21;
        public static int SendBloodPoints = 22;
        public static int SyncSupportHealsServer = 23;
        int SyncSupportHealsClient = 24;
        public static int BatTransformRecieve = 25;
        int BatTransformSend = 26;
        public static int VeiTransormRecieve = 27;
        int VeiTransformSend = 28;
        public static int NyanTransformRecieve = 29;
        int NyanTransformSend = 30;
        public static int MouseTransformRecieve = 31;
        int MouseTransformSend = 32;
        public static int SupportArmorRecieve = 33;
        int SupportArmorSend = 34;

        int DustType;
        int DustTimer;

        internal ModPacket GetPacket(MessageType type, int capacity)
        {
            ModPacket packet = GetPacket(capacity + 1);
            packet.Write((byte)type);
            return packet;
        }

        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            //MessageType message = (MessageType)reader.ReadByte();
            //switch (message)
            //{
            //    case MessageType.AltarMessage:
            //        this.GetTileEntity<Tiles.BloodAltarTE>(reader.ReadInt32())?.RecieveAltarMessage(reader, whoAmI);
            //        //Main.NewText("Recieved on Server");
            //        break;
            //}
            int idVariable = reader.ReadInt32();
            if (idVariable == HoodServerRecieve)
            {
                bool KeyPressed = reader.ReadBoolean();
                int playerID = reader.ReadInt32();
                ModPacket packet2 = this.GetPacket();
                packet2.Write(HoodSendToClient);
                packet2.Write(KeyPressed);
                packet2.Write(playerID);
                packet2.Send(-1, playerID);
            }
            if (idVariable == HoodSendToClient)
            {
                bool KeyPressed2 = reader.ReadBoolean();

                int playerID = reader.ReadInt32();
                Main.player[playerID].GetModPlayer<VampPlayer>().HoodIsVisible = KeyPressed2;
            }
            if (idVariable == SendBloodPoints)
            {
                Main.LocalPlayer.GetModPlayer<VampPlayer>().NeckProgress++;
            }

            if (idVariable == SyncSupportHealsServer)
            {
                int Owner = reader.ReadInt32();
                int Decision = reader.ReadInt32();
                int SyncLifeAmount = reader.ReadInt32();
                bool BuffState = Main.player[Owner].HasBuff(ModContent.BuffType<Buffs.TrueSupportDebuff>());
                ModPacket packet5 = this.GetPacket();
                packet5.Write(SyncSupportHealsClient);
                packet5.Write(Decision);
                packet5.Write(SyncLifeAmount);
                packet5.Write(Owner);
                packet5.Write(BuffState);
                packet5.Send(-1, Owner);
            }
            if (idVariable == SyncSupportHealsClient)
            {
                int Decision = reader.ReadInt32();
                int SyncLifeAmount = reader.ReadInt32();
                int Owner = reader.ReadInt32();
                bool BuffState = reader.ReadBoolean();
                if (BuffState)
                    Main.player[Owner].AddBuff(ModContent.BuffType<Buffs.TrueSupportDebuff>(), 60);
                Main.player[Decision].statLife += (SyncLifeAmount);
                if (SyncLifeAmount >= 1)
                    Main.player[Decision].HealEffect(SyncLifeAmount, false);
            }
            if (idVariable == BatTransformRecieve)
            {
                bool Transform = reader.ReadBoolean();
                bool HasTablet = reader.ReadBoolean();
                int playerID = reader.ReadInt32();
                ModPacket packet = this.GetPacket();
                packet.Write(BatTransformSend);
                packet.Write(Transform);
                packet.Write(HasTablet);
                packet.Write(playerID);
                packet.Send(-1, playerID);
            }
            if (idVariable == BatTransformSend)
            {
                bool Transform = reader.ReadBoolean();
                bool HasTablet = reader.ReadBoolean();
                int playerID = reader.ReadInt32();
                Main.player[playerID].GetModPlayer<VampPlayer>().Transform = Transform;
                Main.player[playerID].GetModPlayer<VampPlayer>().HasTabletEquipped = HasTablet;
            }
            if (idVariable == VeiTransormRecieve)
            {
                bool VeiTransform = reader.ReadBoolean();
                int PlayerID = reader.ReadInt32();
                ModPacket packet = this.GetPacket();
                packet.Write(VeiTransformSend);
                packet.Write(VeiTransform);
                packet.Write(PlayerID);
                packet.Send(-1, PlayerID);
            }
            if (idVariable == VeiTransformSend)
            {
                bool VeiTransform = reader.ReadBoolean();
                int playerID = reader.ReadInt32();
                Main.player[playerID].GetModPlayer<VampPlayer>().VeiTransform = VeiTransform;
            }
            if (idVariable == NyanTransformRecieve)
            {
                bool NyanTransform = reader.ReadBoolean();
                int PlayerID = reader.ReadInt32();
                ModPacket packet = this.GetPacket();
                packet.Write(NyanTransformSend);
                packet.Write(NyanTransform);
                packet.Write(PlayerID);
                packet.Send(-1, PlayerID);
            }
            if (idVariable == NyanTransformSend)
            {
                bool NyanTransform = reader.ReadBoolean();
                int PlayerID = reader.ReadInt32();
                Main.player[PlayerID].GetModPlayer<VampPlayer>().NyanTransform = NyanTransform;
            }
            if (idVariable == MouseTransformRecieve)
            {
                bool MouseTransform = reader.ReadBoolean();
                int PlayerID = reader.ReadInt32();
                ModPacket packet = this.GetPacket();
                packet.Write(MouseTransformSend);
                packet.Write(MouseTransform);
                packet.Write(PlayerID);
                packet.Send(-1, PlayerID);
            }
            if (idVariable == MouseTransformSend)
            {
                bool MouseTransform = reader.ReadBoolean();
                int PlayerID = reader.ReadInt32();
                Main.player[PlayerID].GetModPlayer<VampPlayer>().MouseTransform = MouseTransform;
            }
            if (idVariable == SupportArmorRecieve)
            {
                int PlayerToBuff = reader.ReadInt32();
                int BuffCountStore = reader.ReadInt32();
                int PlayerID = reader.ReadInt32();
                ModPacket packet = this.GetPacket();
                packet.Write(SupportArmorSend);
                packet.Write(PlayerToBuff);
                packet.Write(BuffCountStore);
                packet.Send(-1, PlayerID);
            }
            if (idVariable == SupportArmorSend)
            {
                int PlayerToBuff = reader.ReadInt32();
                int BuffCountStore = reader.ReadInt32();
                Main.player[PlayerToBuff].AddBuff(ModContent.BuffType<Buffs.SupportBuff>(), 600);
                Main.player[PlayerToBuff].GetModPlayer<VampPlayer>().BuffCountStore = BuffCountStore;
            }

            /* RITUAL NETCODE */
            if (idVariable == OwnerRecieve)
            {
                int ID = reader.ReadInt32();
                int OwnerID = reader.ReadInt32();

                this.GetTileEntity<BloodAltarTE>(ID).RitualOwner = OwnerID;
                ModPacket packet = this.GetPacket();
                packet.Write(OwnerSend);
                packet.Write(ID);
                packet.Write(OwnerID);
                packet.Send(-1, OwnerID);
            }
            if (idVariable == OwnerSend)
            {
                int ID = reader.ReadInt32();
                int OwnerID = reader.ReadInt32();
                this.GetTileEntity<BloodAltarTE>(ID).RitualOwner = OwnerID;
            }
            if (idVariable == ResetSpaceServer)
            {
                short PosX = reader.ReadInt16();
                short PosY = reader.ReadInt16();

                WorldGen.KillTile(PosX + 1, PosY - 2, false, false, false);
                WorldGen.KillTile(PosX + 1, PosY - 1, false, false, true);

                NetMessage.SendData(MessageID.TileChange, -1, -1, null, 0, (float)PosX + 1, (float)PosY - 1, 0f, 0, 0, 0);
                NetMessage.SendData(MessageID.TileChange, -1, -1, null, 0, (float)PosX + 1, (float)PosY - 2, 0f, 0, 0, 0);

                ModPacket packet = this.GetPacket();
                packet.Write(ResetSpaceMPClient);
                packet.Write(PosX);
                packet.Write(PosY);
                packet.Send(-1, -1);
            }
            if (idVariable == ResetSpaceMPClient)
            {
                int PosX = reader.ReadInt16();
                int PosY = reader.ReadInt16();

                WorldGen.KillTile(PosX + 1, PosY - 2, false, false, false);
                WorldGen.KillTile(PosX + 1, PosY - 1, false, false, true);

            }
            if (idVariable == RitualCostRecieveMPClient)
            {
                int Cost = reader.ReadInt32();
                int Owner = reader.ReadInt32();
                Main.player[Owner].GetModPlayer<VampPlayer>().BloodPoints -= Cost;
            }
            if (idVariable == SyncBloodPoints)
            {
                int BloodPoints = reader.ReadInt32();
                int Owner = reader.ReadInt32();

                Main.player[Owner].GetModPlayer<VampPlayer>().BloodPoints = BloodPoints;
            }
            if (idVariable == StoneRitualRecieveMPClient)
            {
                int ID = reader.ReadInt32();
                bool RitualOfTheStone = reader.ReadBoolean();
                int Owner = reader.ReadInt32();
                ushort tileid = reader.ReadUInt16();

                this.GetTileEntity<BloodAltarTE>(ID).RitualOfTheStone = RitualOfTheStone;
                this.GetTileEntity<BloodAltarTE>(ID).RitualOwner = Owner;
                this.GetTileEntity<BloodAltarTE>(ID).RoSType = tileid;
            }
            if(idVariable == MinerRitualRecieveMPClient)
            {
                int ID = reader.ReadInt32();
                bool RitualOfTheMiner = reader.ReadBoolean();
                int Owner = reader.ReadInt32();
                ushort tileid = reader.ReadUInt16();

                this.GetTileEntity<BloodAltarTE>(ID).RitualOfTheMiner = RitualOfTheMiner;
                this.GetTileEntity<BloodAltarTE>(ID).RitualOwner = Owner;
                this.GetTileEntity<BloodAltarTE>(ID).RoMinType = tileid;
            }
            if (idVariable == MidasRitualRecieveMPClient)
            {
                int ID = reader.ReadInt32();
                bool RitualOfMidas = reader.ReadBoolean();
                int Owner = reader.ReadInt32();
                short ItemID = reader.ReadInt16();

                this.GetTileEntity<BloodAltarTE>(ID).RitualOfMidas = RitualOfMidas;
                this.GetTileEntity<BloodAltarTE>(ID).RitualOwner = Owner;
                this.GetTileEntity<BloodAltarTE>(ID).RoMidType = ItemID;
            }
            if (idVariable == SoulsRitualRecieveMPClient)
            {
                int ID = reader.ReadInt32();
                bool RitualOfSouls = reader.ReadBoolean();
                int Owner = reader.ReadInt32();
                int NPCID = reader.ReadInt32();
                int Delay = reader.ReadInt32();
                //ItemIO.Receive(reader, true);

                this.GetTileEntity<BloodAltarTE>(ID).RitualOfSouls = RitualOfSouls;
                this.GetTileEntity<BloodAltarTE>(ID).RitualOwner = Owner;
                this.GetTileEntity<BloodAltarTE>(ID).RoSoType = NPCID;
                this.GetTileEntity<BloodAltarTE>(ID).RoSoDelay = Delay;
                //this.GetTileEntity<BloodAltarTE>(ID).BloodCrystal = ItemIO.Receive(reader, true);
            }
            base.HandlePacket(reader, whoAmI);
        }
        internal enum MessageType
        {
            AltarMessage
        }
    }
}