using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VampKnives.Projectiles.DefenseKnivesProj;

namespace VampKnives.Projectiles.SeasonalProj
{
    public class EasterBasketProj : ReflectiveProj
    {
        public override void SafeSetDefaults()
        {
            NumProjHits = 6;
            ReflectChance = 0f;
            projectile.width = 60;
            projectile.height = 12;
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