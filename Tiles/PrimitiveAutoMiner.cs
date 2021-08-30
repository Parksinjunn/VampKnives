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
    public class PrimitiveAutoMiner : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = false;
            TileObjectData.newTile.Width = 1;
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.Origin = new Point16(0, 0);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinatePadding = 2;
            //TileObjectData.newTile.HookCheck = new PlacementHook(CanPlace, -1, 0, true);
            //TileObjectData.newTile.UsesCustomCanPlace = true;
            //TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(Hook_AfterPlacement, -1, 0, false);
            TileObjectData.addTile(Type);
            ModTranslation text = CreateMapEntryName();
            text.SetDefault("Vampire Knives Expanded");
            AddMapEntry(new Color(153, 107, 61), text);
            dustType = 7;
            drop = mod.ItemType("PrimitiveAutoMinerItem");
        }
        public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
        {
            int frameX = 0;
            int frameY = 0;
            if (WorldGen.InWorld(i - 1, j) && Main.tile[i - 1, j].active())
            {
                frameX += 18;
            }
            if (WorldGen.InWorld(i + 1, j) && Main.tile[i + 1, j].active())
            {
                frameX += 36;
            }
            if (WorldGen.InWorld(i, j - 1) && Main.tile[i, j - 1].active())
            {
                frameY += 18;
            }
            if (WorldGen.InWorld(i, j + 1) && Main.tile[i, j + 1].active())
            {
                frameY += 36;
            }
            Main.tile[i, j].frameX = (short)frameX;
            Main.tile[i, j].frameY = (short)frameY;
            return false;
        }
        //public override void RandomUpdate(int i, int j)
        //{
        //    bool fail = false;
        //    bool effectOnly = false;
        //    bool noItems = false;
        //    if (WorldGen.InWorld(i - 1, j) && Main.tile[i - 1, j].active() && Main.tile[i - 1, j].type != ModContent.TileType<BloodAltar>())
        //    {
        //        Main.NewText("Tile to the West");
        //        KillTile(i - 1, j, ref fail, ref effectOnly, ref noItems);
        //    }
        //    if (WorldGen.InWorld(i + 1, j) && Main.tile[i + 1, j].active() && Main.tile[i + 1, j].type != ModContent.TileType<BloodAltar>())
        //    {
        //        Main.NewText("Tile to the East");
        //        KillTile(i + 1, j, ref fail, ref effectOnly, ref noItems);
        //    }
        //    if (WorldGen.InWorld(i, j - 1) && Main.tile[i, j - 1].active() && Main.tile[i, j - 1].type != ModContent.TileType<BloodAltar>())
        //    {
        //        Main.NewText("Tile to the North");
        //        KillTile(i, j - 1, ref fail, ref effectOnly, ref noItems);
        //    }
        //    if (WorldGen.InWorld(i, j + 1) && Main.tile[i, j + 1].active() && Main.tile[i, j + 1].type != ModContent.TileType<BloodAltar>())
        //    {
        //        Main.NewText("Tile to the South");
        //        KillTile(i, j + 1, ref fail, ref effectOnly, ref noItems);
        //    }
        //}
        public override void DrawEffects(int i, int j, SpriteBatch spriteBatch, ref Color drawColor, ref int nextSpecialDrawIndex)
        {
            bool fail = false;
            bool effectOnly = false;
            bool noItems = false;
            if (WorldGen.InWorld(i - 1, j) && Main.tile[i - 1, j].active() && Main.tile[i - 1, j].type != ModContent.TileType<BloodAltar>())
            {
                WorldGen.KillTile(i - 1, j, fail, effectOnly, noItems);
            }
            if (WorldGen.InWorld(i + 1, j) && Main.tile[i + 1, j].active() && Main.tile[i + 1, j].type != ModContent.TileType<BloodAltar>())
            {
                WorldGen.KillTile(i + 1, j, fail, effectOnly, noItems);
            }
            if (WorldGen.InWorld(i, j - 1) && Main.tile[i, j - 1].active() && Main.tile[i, j - 1].type != ModContent.TileType<BloodAltar>())
            {
                WorldGen.KillTile(i, j - 1, fail, effectOnly, noItems);
            }
            if (WorldGen.InWorld(i, j + 1) && Main.tile[i, j + 1].active() && Main.tile[i, j + 1].type != ModContent.TileType<BloodAltar>())
            {
                WorldGen.KillTile(i, j + 1, fail, effectOnly, noItems);
            }
        }
    }
}