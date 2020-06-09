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
    public class ResilienceKnivesProj : ReflectiveProj
    {
        public override void SafeSetDefaults()
        {
            NumProjHits = 60;
            projectile.width = 56;
            projectile.height = 34;
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