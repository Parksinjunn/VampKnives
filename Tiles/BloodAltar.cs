using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using VampKnives.UI;

namespace VampKnives.Tiles
{
    public class BloodAltar : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            //Main.tileTable[Type] = true;
            Main.tileLavaDeath[Type] = false;
            Main.tileSolid[Type] = true;
            TileObjectData.newTile.Width = 3;
            TileObjectData.newTile.Height = 1;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16 };
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinatePadding = 2;
            TileObjectData.newTile.UsesCustomCanPlace = true;
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
            //TileObjectData.newTile.Origin = new Point16(4, 6);
            TileObjectData.addTile(Type);
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Vampire Altar\nRight-Click to upgrade your knives");
            disableSmartCursor = true;
            //adjTiles = new int[] { TileID.WorkBenches };

            animationFrameHeight = 18;
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
        public override void PlaceInWorld(int i, int j, Item item)
        {
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                ExamplePlayer p = Main.player[item.owner].GetModPlayer<ExamplePlayer>();
                p.SendPackage = true;
            }
        }

        //public override void NearbyEffects(int i, int j, bool closer)
        //{
        //    for(int x = 0; x < Main.maxItems; x++)
        //    {
        //        if(Main.item[x].type == ItemID.DirtBlock)
        //        {
        //            Item item = Main.item[x];
        //            Vector2 TilePosition = new Vector2(i * 16, j * 16);
        //            Vector2 vector31 = new Vector2(item.position.X + (float)item.width * 0.5f, item.position.Y + (float)item.height * 0.5f);
        //            float num500 = TilePosition.X - vector31.X;
        //            float num501 = TilePosition.Y - vector31.Y;
        //            float num502 = (float)Math.Sqrt((double)(num500 * num500 + num501 * num501));
        //            if(num502 < 200f)
        //            {
        //                Main.NewText("BOOM");
        //            }
        //        }
        //    }
        //}
        bool identifier;
        public override bool CanKillTile(int i, int j, ref bool blockDamaged)
        {
            identifier = false;
            for (int iterations = 0; iterations < VampireWorld.AltarBeingUsed.Count; iterations += 2)
            {
                if (VampireWorld.RitualOfTheStone[iterations] || VampireWorld.RitualOfTheMiner[iterations] || VampireWorld.RitualOfMidas[iterations])
                {
                    identifier = true;
                }
            }
            if (Main.player[0].HeldItem.type == ItemID.CopperPickaxe && identifier == false)
            {
                blockDamaged = true;
                return true;
            }
            else
            {
                blockDamaged = false;
                return false;
            }
        }
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            Tile tile = Main.tile[i, j];
            if (tile.frameX == 72 && tile.frameY == 54)
            {
                r = 0.40f;
                g = 0.0f;
                b = 0.0f;
            }
        }

        public int frameCount;
        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            frameCounter++;
            if (frameCounter > 6)
            {
                frameCounter = 0;
                frame++;
                frameCount++;
                if (frame > 4)
                {
                    frame = 0;
                    frameCount = 0;
                }
            }
        }

        public int tileX;
        public int tileY;
        int FrameTimeCounter = -1; //FIGURE OUT OFFSET ISSUES
        int Offset;
        short CalculatedOffset;
        public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
        {
            ExamplePlayer p = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
            if (p.BloodPoints >= 2000)
            {
                Offset = 360;
            }
            else if (p.BloodPoints >= 1500)
            {
                Offset = 270;
            }
            else if (p.BloodPoints >= 1000)
            {
                Offset = 180;
            }
            else if (p.BloodPoints >= 500)
            {
                Offset = 90;
            }
            else if (p.BloodPoints < 500)
            {
                Offset = 0;
            }
                CalculatedOffset = (short)(Offset);
            Main.tile[i, j].frameY = CalculatedOffset;
            return true;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 32, 16, ModContent.ItemType<Items.BloodAltarItem>());
            //for(int g = 0; g < VampireWorld.AltarBeingUsed.Count; g++)
            //{
            //    if(VampireWorld.AltarBeingUsed[g] == i && VampireWorld.AltarBeingUsed[g+1] == j)
            //    {
            //        //VampireWorld.AltarBeingUsed.RemoveAt(g);
            //        //VampireWorld.AltarBeingUsed.RemoveAt(g + 1);
            //        //VampireWorld.RitualOfTheStone.RemoveAt(g);
            //        //VampireWorld.RitualOfTheStone.RemoveAt(g + 1);
            //        //VampireWorld.RitualOfTheMiner.RemoveAt(g);
            //        //VampireWorld.RitualOfTheMiner.RemoveAt(g + 1);
            //        //VampireWorld.RitualOfMidas.RemoveAt(g);
            //        //VampireWorld.RitualOfMidas.RemoveAt(g + 1);
            //        //VampireWorld.RoEType.RemoveAt(g);
            //        //VampireWorld.RoEType.RemoveAt(g + 1);
            //        //VampireWorld.RoMType.RemoveAt(g);
            //        //VampireWorld.RoMType.RemoveAt(g + 1);
            //        //VampireWorld.RoMiType.RemoveAt(g);
            //        //VampireWorld.RoMiType.RemoveAt(g + 1);
            //    }
            //}
            //Main.NewText("TileCount: " + VampireWorld.AltarBeingUsed.Count);
        }
        bool CanBeAdded;

        bool CurrentlyOpen;

        public override bool NewRightClick(int i, int j)
        {
            //Main.NewText("Currently Open: " + CurrentlyOpen);
            if(BloodAltarUI.visible == false)
            {
                CurrentlyOpen = false;
            }
            ExamplePlayer p = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
            Tile tile = Framing.GetTileSafely(i, j);
            Point16 topLeft = new Point16(i, j) - new Point16(tile.frameX / 18, 0);
            //Main.NewText("AltarList: (" + topLeft.X + "," + topLeft.Y + ")");
            if (BloodAltarUI.visible)
            {
                Main.playerInventory = false;
                BloodAltarUI.visible = false;
                Main.PlaySound(SoundID.MenuClose);
                CurrentlyOpen = false;
            }
            else if (BloodAltarUI.visible == false && CurrentlyOpen == false)
            {
                CurrentlyOpen = true;
                //Main.NewText("ListSize: " + ExamplePlayer.AltarBeingUsed.Count);
                VampireWorld.MostRecentClick = new Vector2(topLeft.X, topLeft.Y);
                for (int b = 0; b < VampireWorld.AltarBeingUsed.Count; b += 2)
                {
                    //Main.NewText("AltarList: (" + VampireWorld.AltarBeingUsed[b] + "," + VampireWorld.AltarBeingUsed[b + 1] + ")");
                    if (VampireWorld.AltarBeingUsed[b] == topLeft.X && VampireWorld.AltarBeingUsed[b + 1] == topLeft.Y)
                    {
                        //Main.NewText("Already in list");
                        CanBeAdded = false;
                    }
                }
                if (VampireWorld.AltarBeingUsed.Count == 0)
                {
                    VampireWorld.AltarBeingUsed.Add(topLeft.X);
                    VampireWorld.AltarBeingUsed.Add(topLeft.Y);
                    VampireWorld.RitualOfTheStone.Add(false);
                    VampireWorld.RitualOfTheStone.Add(false);
                    VampireWorld.RoEType.Add(TileID.AmberGemspark);
                    VampireWorld.RoEType.Add(TileID.AmberGemspark);
                    VampireWorld.RitualOfTheMiner.Add(false);
                    VampireWorld.RitualOfTheMiner.Add(false);
                    VampireWorld.RoMType.Add(TileID.AmberGemspark);
                    VampireWorld.RoMType.Add(TileID.AmberGemspark);
                    VampireWorld.RitualOfMidas.Add(false);
                    VampireWorld.RitualOfMidas.Add(false);
                    VampireWorld.RoMiType.Add(ItemID.CopperCoin);
                    VampireWorld.RoMiType.Add(ItemID.CopperCoin);
                    VampireWorld.AltarOwner.Add(Main.LocalPlayer.whoAmI);
                    VampireWorld.AltarOwner.Add(Main.LocalPlayer.whoAmI);

                    if(Main.netMode == NetmodeID.MultiplayerClient)
                    {
                        //mod.Logger.Warn("SendingChanges");
                        ModPacket RitualClientSend = mod.GetPacket();
                        RitualClientSend.Write(VampKnives.AltarPressedRecieveLists);
                        RitualClientSend.Write(VampireWorld.AltarBeingUsed.Count);
                        for (int g = 0; g < VampireWorld.AltarBeingUsed.Count; g++)
                        {
                            RitualClientSend.Write(VampireWorld.AltarBeingUsed[g]);
                            RitualClientSend.Write(VampireWorld.RitualOfTheStone[g]);
                            RitualClientSend.Write(VampireWorld.RoEType[g]);
                            RitualClientSend.Write(VampireWorld.RitualOfTheMiner[g]);
                            RitualClientSend.Write(VampireWorld.RoMType[g]);
                            RitualClientSend.Write(VampireWorld.RitualOfMidas[g]);
                            RitualClientSend.Write(VampireWorld.RoMiType[g]);
                            RitualClientSend.Write(VampireWorld.AltarOwner[g]);
                        }
                        RitualClientSend.Write(Main.LocalPlayer.whoAmI);
                        RitualClientSend.Send();
                    }

                    List<int> AltarBeingUsedList = new List<int>();
                    for (int g = 0; g < VampireWorld.AltarBeingUsed.Count; g++)
                    {
                        AltarBeingUsedList.Add(VampireWorld.AltarBeingUsed[g]);
                    }
                    //Main.NewText("Altar Length: " + AltarBeingUsedList.Count);
                }
                else if (CanBeAdded == true)
                {
                    VampireWorld.AltarBeingUsed.Add(topLeft.X);
                    VampireWorld.AltarBeingUsed.Add(topLeft.Y);
                    VampireWorld.RitualOfTheStone.Add(false);
                    VampireWorld.RitualOfTheStone.Add(false);
                    VampireWorld.RoEType.Add(TileID.AmberGemspark);
                    VampireWorld.RoEType.Add(TileID.AmberGemspark);
                    VampireWorld.RitualOfTheMiner.Add(false);
                    VampireWorld.RitualOfTheMiner.Add(false);
                    VampireWorld.RoMType.Add(TileID.AmberGemspark);
                    VampireWorld.RoMType.Add(TileID.AmberGemspark);
                    VampireWorld.RitualOfMidas.Add(false);
                    VampireWorld.RitualOfMidas.Add(false);
                    VampireWorld.RoMiType.Add(ItemID.CopperCoin);
                    VampireWorld.RoMiType.Add(ItemID.CopperCoin);
                    VampireWorld.AltarOwner.Add(Main.LocalPlayer.whoAmI);
                    VampireWorld.AltarOwner.Add(Main.LocalPlayer.whoAmI);

                    if (Main.netMode == NetmodeID.MultiplayerClient)
                    {
                        //mod.Logger.Warn("SendingChanges");
                        ModPacket RitualClientSend = mod.GetPacket();
                        RitualClientSend.Write(VampKnives.AltarPressedRecieveLists);
                        //Main.NewText("ListNum: " + v.AltarPressedRecieveLists);
                        RitualClientSend.Write(VampireWorld.AltarBeingUsed.Count);
                        for (int g = 0; g < VampireWorld.AltarBeingUsed.Count; g++)
                        {
                            RitualClientSend.Write(VampireWorld.AltarBeingUsed[g]);
                            RitualClientSend.Write(VampireWorld.RitualOfTheStone[g]);
                            RitualClientSend.Write(VampireWorld.RoEType[g]);
                            RitualClientSend.Write(VampireWorld.RitualOfTheMiner[g]);
                            RitualClientSend.Write(VampireWorld.RoMType[g]);
                            RitualClientSend.Write(VampireWorld.RitualOfMidas[g]);
                            RitualClientSend.Write(VampireWorld.RoMiType[g]);
                            RitualClientSend.Write(VampireWorld.AltarOwner[g]);
                        }
                        RitualClientSend.Write(Main.LocalPlayer.whoAmI);
                        RitualClientSend.Send();
                    }
                    //List<int> AltarBeingUsedList = new List<int>();
                    //for (int g = 0; g < VampireWorld.AltarBeingUsed.Count; g++)
                    //{
                    //    AltarBeingUsedList.Add(VampireWorld.AltarBeingUsed[g]);
                    //}
                    //mod.Logger.Debug("Altar Length: " + AltarBeingUsedList.Count);
                }
                //Main.NewText("ListSize: " + VampireWorld.AltarBeingUsed.Count);
                //Main.NewText("MostRecent: "+ VampireWorld.MostRecentClick);
                Main.playerInventory = true;
                BloodAltarUI.visible = true;
                Main.PlaySound(SoundID.MenuOpen);
                CanBeAdded = true;
            }
            return true;
        }

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;
            Tile tile = Main.tile[i, j];
            int left = i;
            int top = j;
            if (tile.frameX % 36 != 0)
            {
                left--;
            }
            if (tile.frameY != 0)
            {
                top--;
            }
            int chest = Chest.FindChest(left, top);
            player.showItemIcon2 = -1;
            if (chest < 0)
            {
                player.showItemIconText = "Vampire Altar\nRight-Click to upgrade your knives";
            }
            else
            {
                player.showItemIconText = Main.chest[chest].name.Length > 0 ? Main.chest[chest].name : "Vampire Altar\nRight-Click to upgrade your knives";
                if (player.showItemIconText == "Vampire Altar\nRight-Click to upgrade your knives")
                {
                    player.showItemIcon2 = ModContent.ItemType<Items.BloodAltarItem>();
                    player.showItemIconText = "";
                }
            }
            player.noThrow = 2;
            player.showItemIcon = true;
        }

        public override void MouseOverFar(int i, int j)
        {
            MouseOver(i, j);
            Player player = Main.LocalPlayer;
            if (player.showItemIconText == "")
            {
                player.showItemIcon = false;
                player.showItemIcon2 = 0;
            }
        }
    }
}