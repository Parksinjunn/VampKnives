using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VampKnives;

namespace VampKnives.Projectiles.DefenseKnivesProj
{
    public class ProjCount
    {
        public static int MaxActive = 40;
        public static int NumberActive;
        public static int NumActiveAdamantite;
        public static int NumActiveTitanium;
        public static int NumActiveShroomite;
        public static int ShroomiteIterator;
        public static int ShroomiteActiveGasCount;

        public static int GetActiveAdamantite()
        {
            return NumActiveAdamantite;
        }
        public static int GetActiveTitanium()
        {
            return NumActiveTitanium;
        }
        public static int GetActiveShroomite()
        {
            return NumActiveShroomite;
        }
        public static int GetShroomiteIterator()
        {
            return ShroomiteIterator;
        }
        public static int GetActiveShroomiteGasCount()
        {
            return ShroomiteActiveGasCount;
        }
        public static int GetActiveConut()
        {
            return NumberActive;
        }
    }
}