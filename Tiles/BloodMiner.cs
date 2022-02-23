using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace VampKnives.Tiles
{
    public class BloodMiner : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileSolid[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = false;
            TileObjectData.newTile.Width = 1;
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.Origin = new Point16(0, 0);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinatePadding = 2;
            TileObjectData.newTile.UsesCustomCanPlace = true;
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
            TileObjectData.addTile(Type);
            ModTranslation text = CreateMapEntryName();
            text.SetDefault("Vampire Knives Expanded");
            disableSmartCursor = true;
        }
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 16, 32, ModContent.ItemType<Items.Misc.BloodMinerItem>());
        }
        public override void DrawEffects(int i, int j, SpriteBatch spriteBatch, ref Color drawColor, ref int nextSpecialDrawIndex)
        {
            bool fail = false;
            bool effectOnly = false;
            bool noItems = false;
            if ((Main.tile[i, j].frameX == 36 || Main.tile[i, j].frameX == 54 || Main.tile[i, j].frameX == 72) && Main.tile[i - 1, j].active() && Main.tile[i, j + 1].type == Type && Main.tile[i - 1, j].type != ModContent.TileType<BloodAltar>() && Main.tile[i, j - 1].type != Type)
            {
                WorldGen.KillTile(i - 1, j, fail, effectOnly, noItems);
                if (Main.netMode != NetmodeID.SinglePlayer)
                {
                    NetMessage.SendData(MessageID.TileChange, -1, -1, null, 0, (float)i - 1, (float)j, 0f, 0, 0, 0);
                }
            }
            if ((Main.tile[i, j].frameX == 18 || Main.tile[i, j].frameX == 54 || Main.tile[i, j].frameX == 72) && Main.tile[i + 1, j].active() && Main.tile[i, j + 1].type == Type && Main.tile[i + 1, j].type != ModContent.TileType<BloodAltar>() && Main.tile[i, j - 1].type != Type)
            {
                WorldGen.KillTile(i + 1, j, fail, effectOnly, noItems);
                if (Main.netMode != NetmodeID.SinglePlayer)
                {
                    NetMessage.SendData(MessageID.TileChange, -1, -1, null, 0, (float)i + 1, (float)j, 0f, 0, 0, 0);
                }
            }
            if ((Main.tile[i, j].frameX == 0 || Main.tile[i,j].frameX == 72) && Main.tile[i, j - 1].active() && Main.tile[i, j - 1].type != ModContent.TileType<BloodAltar>() && Main.tile[i, j + 1].type == Type && Main.tile[i, j - 1].type != Type)
            {
                WorldGen.KillTile(i, j - 1, fail, effectOnly, noItems);
                if (Main.netMode != NetmodeID.SinglePlayer)
                {
                    NetMessage.SendData(MessageID.TileChange, -1, -1, null, 0, (float)i, (float)j - 1, 0f, 0, 0, 0);
                }
            }
        }
        public override bool Slope(int i, int j)
        {
            Main.tile[i, j].frameX += 18;
            if (Main.tile[i, j].frameX >= 90)
            {
                Main.tile[i, j].frameX = 0;
            }
            if (Main.tile[i, j + 1].type == Type)
                Main.tile[i, j + 1].frameX = Main.tile[i, j].frameX;
            NetMessage.SendTileSquare(Main.myPlayer, i, j, 2);
            return false;
        }
        //public override bool NewRightClick(int i, int j)
        //{
        //    Player player = Main.LocalPlayer;
        //    Tile tile = Main.tile[i, j];
        //    return base.NewRightClick(i, j);
        //}
    }
}