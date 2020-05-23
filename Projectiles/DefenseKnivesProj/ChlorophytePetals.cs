using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles.DefenseKnivesProj
{
    public class ChlorophytePetals : KnifeProjectile
    {
        public int ran;
        public int ranD;
        public int DustType = 200;
        public bool HasHitEnemy = false;
        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 16;
            projectile.knockBack = 0;
            projectile.friendly = true;
            projectile.penetrate = 3;
            projectile.tileCollide = true;
            projectile.hostile = false;
            projectile.magic = true;
            projectile.ignoreWater = true;
            projectile.timeLeft = 140;
            Main.projFrames[projectile.type] = 3;           //this is projectile frames
        }
        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            int numdust2 = Dust.NewDust(projectile.position, 1, 1, DustType, 0f, 0f, 100, Color.DeepPink, (float)Main.rand.NextDouble());
            Dust ProjDustTrail = Main.dust[numdust2];
            ProjDustTrail.noGravity = true;
            if (ranD == 0)
            {
                ran = Main.rand.Next(0, 3);
                ranD = 1;
            }
            if (ran == 0)
                projectile.frame = 0;
            if (ran == 1)
                projectile.frame = 1;
            if (ran == 2)
                projectile.frame = 2;
        }
        public override bool PreKill(int timeLeft)
        {
            ranD = 0;
            for(int boom = 0; boom < 50; boom++)
            {
                int numdust2 = Dust.NewDust(projectile.Center, 8, 8, DustType, 0f, 0f, 100, Color.DeepPink, (float)Main.rand.NextDouble());
                Dust ProjDustDeath = Main.dust[numdust2];
                ProjDustDeath.noGravity = false;
            }
            return base.PreKill(timeLeft);
        }
    }
}