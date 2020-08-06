using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;

namespace VampKnives.Tiles
{
    public class BloodAltarStorage
    {
        public static List<bool> RitualOfTheStone = new List<bool>();
        static int DustTimer;

        public static void StoneRitual(int i, int j, Player player)
        {
            ExamplePlayer p = player.GetModPlayer<ExamplePlayer>();
            //Main.NewText("RitualRun");
            if (p.BloodPoints > 1)
            {
                DustTimer++;
                if (DustTimer >= 2)
                {
                    p.OvalDust(new Vector2(16 * (i) + 4.5f, 16 * (j - 1) + 4), 2, 0.8f, Color.White, 1, 1f);
                    DustTimer = 0;
                }
                if (Main.tile[i, j - 2].type != TileID.Stone)
                {
                    p.BloodPoints -= 1;
                }
                WorldGen.PlaceTile(i+1, j - 2, TileID.Stone);
            }
        }
    }
}
