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
    public class PrimitiveAutoMiner : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
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
            Item.NewItem(i * 16, j * 16, 16, 32, ModContent.ItemType<Items.Misc.PrimitiveAutoMinerItem>());
        }
        public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
        {
            int frameX = 0;
            if (WorldGen.InWorld(i - 1, j - 1) && Main.tile[i - 1, j].active())
            {
                frameX += 36;
            }
            if (WorldGen.InWorld(i + 1, j - 1) && Main.tile[i + 1, j].active())
            {
                frameX += 18;
            }
            if (WorldGen.InWorld(i, j - 2) && Main.tile[i, j - 1].active())
            {
                frameX += 18;
            }
            Main.tile[i, j].frameX = (short)frameX;
            return true;
        }
        public override void DrawEffects(int i, int j, SpriteBatch spriteBatch, ref Color drawColor, ref int nextSpecialDrawIndex)
        {
            bool fail = false;
            bool effectOnly = false;
            bool noItems = false;
            VampPlayer p = Main.LocalPlayer.GetModPlayer<VampPlayer>();
            if (WorldGen.InWorld(i - 1, j - 1) && Main.tile[i - 1, j - 1].active() && Main.tile[i - 1, j - 1].type != ModContent.TileType<BloodAltar>() && Main.tile[i - 1, j - 1].type != ModContent.TileType<PrimitiveAutoMiner>() && Main.tile[i - 1, j - 1].type != ModContent.TileType<BloodMiner>())
            {
                WorldGen.KillTile(i - 1, j - 1, fail, effectOnly, noItems);
                if(Main.netMode != NetmodeID.SinglePlayer)
                {
                    NetMessage.SendData(MessageID.TileChange, -1, -1, null, 0, (float)i - 1, (float)j - 1, 0f, 0, 0, 0);
                }
            }
            if (WorldGen.InWorld(i + 1, j - 1) && Main.tile[i + 1, j - 1].active() && Main.tile[i + 1, j - 1].type != ModContent.TileType<BloodAltar>() && Main.tile[i + 1, j - 1].type != ModContent.TileType<PrimitiveAutoMiner>() && Main.tile[i + 1, j - 1].type != ModContent.TileType<BloodMiner>())
            {
                WorldGen.KillTile(i + 1, j - 1, fail, effectOnly, noItems);
                if (Main.netMode != NetmodeID.SinglePlayer)
                {
                    NetMessage.SendData(MessageID.TileChange, -1, -1, null, 0, (float)i + 1, (float)j - 1, 0f, 0, 0, 0);
                }
            }
            if (WorldGen.InWorld(i, j - 2) && Main.tile[i, j - 2].active() && Main.tile[i, j - 2].type != ModContent.TileType<BloodAltar>() && Main.tile[i, j - 2].type != ModContent.TileType<PrimitiveAutoMiner>() && Main.tile[i, j - 2].type != ModContent.TileType<BloodMiner>())
            {
                WorldGen.KillTile(i, j - 2, fail, effectOnly, noItems);
                if (Main.netMode != NetmodeID.SinglePlayer)
                {
                    NetMessage.SendData(MessageID.TileChange, -1, -1, null, 0, (float)i, (float)j - 2, 0f, 0, 0, 0);
                }
            }
        }
    }
}