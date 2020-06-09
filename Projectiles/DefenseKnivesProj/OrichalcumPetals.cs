using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles.DefenseKnivesProj
{
    public class OrichalcumPetals : KnifeProjectile
    {
        public int ran;
        public int ranD;
        public bool HasHitEnemy = false;
        public override void SafeSetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.knockBack = 0;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.hostile = false;
            projectile.magic = true;
            projectile.ignoreWater = true;
            projectile.timeLeft = 70;
            Main.projFrames[projectile.type] = 3;           //this is projectile frames
        }
        public override void AI()
        {
            //int numdust2 = Dust.NewDust(projectile.position, 6, 6, 26, 0f, 0f, 100, Color.Red, 1f);
            //Dust ProjHitDust = Main.dust[numdust2];
            for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];
                if (!target.friendly)
                {
                    float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
                    float shootToY = target.position.Y - projectile.Center.Y;
                    float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

                    if (distance > 2f && !target.friendly && target.active && HasHitEnemy == false)
                    {
                        distance = 3f / distance;

                        shootToX *= distance * 10;
                        shootToY *= distance * 10;

                        projectile.velocity.X = shootToX;
                        projectile.velocity.Y = shootToY;
                    }
                    if(distance < 2f && target.active)
                    {
                        HasHitEnemy = true;
                    }
                }
            }
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
            return base.PreKill(timeLeft);
        }
    }
}