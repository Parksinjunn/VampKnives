using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VampKnives.UI;
using Terraria.UI;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace VampKnives
{
    public class VampKnives : Mod
    {
        internal static VampKnives instance;
        public static ModHotKey HoodUpDownHotkey;
        public UserInterface customRecources;
        public UserInterface customResources2;
        private VampBar vampBar;
        private WarningMessage warning;
        //private UserInterface WarningMessage;
        internal UserInterface WarningMessagePerson;
        internal UserInterface VampireUserInterface;
        internal UserInterface VampireUserInterface2;
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
        }
        public override void Load()
        {
            instance = this;
            HoodUpDownHotkey = RegisterHotKey("HoodUpDown", "P");
            if (!Main.dedServ)
            {
                // Add certain equip textures
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

                customRecources = new UserInterface();
                //customResources2 = new UserInterface();
                vampBar = new VampBar();
                VampBar.visible = true;
                customRecources.SetState(vampBar);
                //warning = new WarningMessage();
                //WarningMessage.visible = true;
                //customResources2.SetState(warning);

                VampireUserInterface = new UserInterface();
                VampireUserInterface2 = new UserInterface();


                //WarningMessage = new UserInterface();
                //WarningMessage.SetState(WarningMessage);

                //WarningMessagePerson = new UserInterface();
            }
            base.Load();
        }
        public override void UpdateUI(GameTime gameTime)
        {
            VampireUserInterface?.Update(gameTime);
            VampireUserInterface2?.Update(gameTime);
        }
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int index = layers.FindIndex(layer => layer.Name.Contains("Resource Bars"));
            if(index != -1)
            {
                layers.Insert(index, new LegacyGameInterfaceLayer("VampBars: Blood Resource Bar", delegate
                {
                    if (VampBar.visible)
                    {
                        //Update CustomBars
                        customRecources.Update(Main._drawInterfaceGameTime);
                        vampBar.Draw(Main.spriteBatch);
                    }
                    return true;
                }));
            }
            int inventoryIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Inventory"));
            if (inventoryIndex != -1)
            {
                layers.Insert(inventoryIndex, new LegacyGameInterfaceLayer(
                    "ExampleMod: Example Person UI",
                    delegate
                    {
                        // If the current UIState of the UserInterface is null, nothing will draw. We don't need to track a separate .visible value.
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
            instance = null;
            base.Unload();
        }
        int Packet2 = 22;
        int Packet4 = 44;
        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            int idVariable = reader.ReadInt32();
            if (idVariable == 11)
            {
                bool KeyPressed = reader.ReadBoolean();
                int playerID = reader.ReadInt32();
                ModPacket packet2 = this.GetPacket();
                packet2.Write(Packet2);
                packet2.Write(KeyPressed);
                packet2.Write(playerID);
                packet2.Send(-1, playerID); 
            }
            if (idVariable == Packet2)
            {
                bool KeyPressed2 = reader.ReadBoolean();
                int playerID = reader.ReadInt32();
                Main.player[playerID].GetModPlayer<ExamplePlayer>().HoodIsVisible = KeyPressed2;

            }
            if (idVariable == 33)
            {
                Main.LocalPlayer.GetModPlayer<ExamplePlayer>().NeckProgress++;
            }
            //if (idVariable == Packet4)
            //{
            //    Main.NewText("Packet4 Read");
            //    int playerID = reader.ReadInt32();
            //    Main.player[playerID].GetModPlayer<ExamplePlayer>().NeckProgress += 1;
            //    Main.NewText("Packet4 Sent: " + Main.player[playerID].GetModPlayer<ExamplePlayer>().NeckProgress);
            //}
            base.HandlePacket(reader, whoAmI);
        }
    }
}