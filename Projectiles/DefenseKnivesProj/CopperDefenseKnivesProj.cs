using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles.DefenseKnivesProj
{
    public class CopperDefenseKnivesProj : ReflectiveProj
    {
        int FrameNum;
        public override void SafeSetDefaults()
        {
            NumProjHits = 1;
            ReflectChance = 0.1f;
            projectile.width = 60;
            projectile.height = 14;
            projectile.knockBack = 60;
            projectile.friendly = true;
            projectile.penetrate = NumProjHits;
            projectile.hostile = false;
            projectile.magic = true;
            projectile.ignoreWater = true;
            projectile.timeLeft = 600;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 40;
        }
    }
}