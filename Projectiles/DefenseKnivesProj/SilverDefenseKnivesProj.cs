﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles.DefenseKnivesProj
{
    public class SilverDefenseKnivesProj : ReflectiveProj
    {
        int FrameNum;
        public override void SafeSetDefaults()
        {
            NumProjHits = 3;
            ReflectChance = 0.75f;
            projectile.width = 60;
            projectile.height = 18;
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