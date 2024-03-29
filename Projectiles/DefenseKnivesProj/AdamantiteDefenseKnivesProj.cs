﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles.DefenseKnivesProj
{
    public class AdamantiteDefenseKnivesProj : ReflectiveProj
    {
        public override void SafeSetDefaults()
        {
            NumProjHits = 6;
            ReflectChance = 1.5f;
            ProjCount.NumActiveAdamantite++;
            IsAdamantite = true;
            projectile.width = 60;
            projectile.height = 28;
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