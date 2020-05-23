using Terraria;
using Terraria.ModLoader;
using Terraria.GameInput;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.UI;
using System;
using Terraria.ModLoader.IO;

namespace VampKnives
{
    public class VariableResets : ModWorld
    {
        public override TagCompound Save()
        {
            Projectiles.DefenseKnivesProj.ProjCount.ShroomiteActiveGasCount = 0;
            Projectiles.DefenseKnivesProj.ProjCount.NumActiveAdamantite = 0;
            Projectiles.DefenseKnivesProj.ProjCount.NumActiveTitanium = 0;
            Projectiles.DefenseKnivesProj.ProjCount.NumActiveShroomite = 0;
            return null;
        }
    }
}