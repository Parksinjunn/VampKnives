using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
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
    public class VampTableTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileTable[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.Width = 9;
            TileObjectData.newTile.Height = 7;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 16, 16, 16, 16 };
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinatePadding = 2;
            TileObjectData.newTile.UsesCustomCanPlace = true;
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.Origin = new Point16(4, 6);
            TileObjectData.addTile(Type);
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Vampire Altar\nRight-Click to upgrade your knives");
            disableSmartCursor = true;
            adjTiles = new int[] { TileID.WorkBenches };

            animationFrameHeight = 126;
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
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
            if (frameCounter > 4)
            {
                frameCounter = 0;
                frame++;
                frameCount++;
                if (frame > 14)
                {
                    frame = 0;
                    frameCount = 0;
                }
            }
        }
        public int tileX;
        public int tileY;
        public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
        {
            tileX = Main.tile[i, j].frameX;
            tileY = Main.tile[i, j].frameY;
            if (frameCount > 12)
            {
                if (tileX == 54 && tileY == 54)
                {
                    int DustID2 = Dust.NewDust(new Vector2(i, j) * 16, 0, 21, 73, -6, -6, 10, Color.Red, 0.5f);
                    Main.dust[DustID2].fadeIn = 1.05f;
                    int DustID3 = Dust.NewDust(new Vector2(i, j) * 16, 0, 21, 73, -7, -9, 10, Color.Red, 0.5f);
                    Main.dust[DustID3].fadeIn = 1.05f;
                    int DustID4 = Dust.NewDust(new Vector2(i, j) * 16, 0, 21, 73, -6, -3, 10, Color.Red, 0.5f);
                    Main.dust[DustID4].fadeIn = 1.05f;
                    int DustID5 = Dust.NewDust(new Vector2(i, j) * 16, 0, 21, 224, -8, -4, 10, Color.Red, 1f);
                    Main.dust[DustID5].fadeIn = 1.05f;
                    Main.dust[DustID2].noGravity = true;
                    Main.dust[DustID3].noGravity = true;
                    Main.dust[DustID4].noGravity = true;
                    Main.dust[DustID5].noGravity = true;
                    Main.dust[DustID5].shader = GameShaders.Armor.GetSecondaryShader(58, Main.LocalPlayer);
                }
                if (tileX == 108 && tileY == 54)
                {

                    int DustID2 = Dust.NewDust(new Vector2(i, j) * 16, 0, 21, 73, 6, -6, 10, Color.Red, 0.5f);
                    Main.dust[DustID2].fadeIn = 1.05f;
                    int DustID3 = Dust.NewDust(new Vector2(i, j) * 16, 0, 21, 73, 7, -8, 10, Color.Red, 0.5f);
                    Main.dust[DustID3].fadeIn = 1.05f;
                    int DustID4 = Dust.NewDust(new Vector2(i, j) * 16, 0, 21, 73, 6, -3, 10, Color.Red, 0.5f);
                    Main.dust[DustID4].fadeIn = 1.05f;
                    int DustID5 = Dust.NewDust(new Vector2(i, j) * 16, 0, 21, 224, 8, -4, 10, Color.Red, 1f);
                    Main.dust[DustID5].fadeIn = 1.05f;
                    Main.dust[DustID2].noGravity = true;
                    Main.dust[DustID3].noGravity = true;
                    Main.dust[DustID4].noGravity = true;
                    Main.dust[DustID5].noGravity = true;
                    Main.dust[DustID5].shader = GameShaders.Armor.GetSecondaryShader(58, Main.LocalPlayer);
                }
                if (tileX == 54 && tileY == 90)
                {
                    int DustID2 = Dust.NewDust(new Vector2(i, j) * 16, 0, 21, 73, -8, 0.5f, 10, Color.Red, 0.5f);
                    Main.dust[DustID2].fadeIn = 1.05f;
                    int DustID3 = Dust.NewDust(new Vector2(i, j) * 16, 0, 21, 73, -8, 0.5f, 10, Color.Red, 0.5f);
                    Main.dust[DustID3].fadeIn = 1.05f;
                    int DustID4 = Dust.NewDust(new Vector2(i, j) * 16, 0, 21, 73, -8, 0.5f, 10, Color.Red, 0.5f);
                    Main.dust[DustID4].fadeIn = 1.05f;
                    int DustID5 = Dust.NewDust(new Vector2(i, j) * 16, 0, 21, 224, -8, 0.5f, 10, Color.Red, 1f);
                    Main.dust[DustID5].fadeIn = 1.05f;
                    Main.dust[DustID2].noGravity = true;
                    Main.dust[DustID3].noGravity = true;
                    Main.dust[DustID4].noGravity = true;
                    Main.dust[DustID5].noGravity = true;
                    Main.dust[DustID5].shader = GameShaders.Armor.GetSecondaryShader(58, Main.LocalPlayer);
                }
                if (tileX == 108 && tileY == 90)
                {
                    int DustID2 = Dust.NewDust(new Vector2(i, j) * 16, 0, 21, 73, 8, 0.5f, 10, Color.Red, 0.5f);
                    Main.dust[DustID2].fadeIn = 1.05f;
                    int DustID3 = Dust.NewDust(new Vector2(i, j) * 16, 0, 21, 73, 8, 0.5f, 10, Color.Red, 0.5f);
                    Main.dust[DustID3].fadeIn = 1.05f;
                    int DustID4 = Dust.NewDust(new Vector2(i, j) * 16, 0, 21, 73, 8, 0.5f, 10, Color.Red, 0.5f);
                    Main.dust[DustID4].fadeIn = 1.05f;
                    int DustID5 = Dust.NewDust(new Vector2(i, j) * 16, 0, 21, 224, 8, 0.5f, 10, Color.Red, 1f);
                    Main.dust[DustID5].fadeIn = 1.05f;
                    Main.dust[DustID2].noGravity = true;
                    Main.dust[DustID3].noGravity = true;
                    Main.dust[DustID4].noGravity = true;
                    Main.dust[DustID5].noGravity = true;
                    Main.dust[DustID5].shader = GameShaders.Armor.GetSecondaryShader(58, Main.LocalPlayer);
                }
            }
            return true;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 32, 16, ModContent.ItemType<Items.VampTable>());
        }
        public override bool NewRightClick(int i, int j)
        {
            if (UpgradePanel.visible)
            {
                Main.playerInventory = false;
                UpgradePanel.visible = false;
                Main.PlaySound(SoundID.MenuClose);
            }
            else if (UpgradePanel.visible == false)
            {
                Main.playerInventory = true;
                UpgradePanel.visible = true;
                Main.PlaySound(SoundID.MenuOpen);
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
                    player.showItemIcon2 = ModContent.ItemType<Items.VampTable>();
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