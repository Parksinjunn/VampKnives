using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles.DefenseKnivesProj
{
    public class SpectreDefProj : KnifeProjectile
    {
        public bool HasHitEnemy = false;
        public override void SafeSetDefaults()
        {
            projectile.width = 4;
            projectile.height = 4;
            projectile.knockBack = 0;
            projectile.friendly = true;
            projectile.penetrate = 3;
            projectile.tileCollide = false;
            projectile.hostile = false;
            projectile.magic = true;
            projectile.ignoreWater = true;
            projectile.timeLeft = 140;
            projectile.extraUpdates = 3;
        }
        public override void SafeAI()
        {
            int num357 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 212, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 1f);
            Main.dust[num357].noGravity = true;
            Dust dust3 = Main.dust[num357];
            dust3.scale *= 1.75f;
            Dust dust56 = Main.dust[num357];
            dust56.velocity.X = dust56.velocity.X * 2f;
            Dust dust57 = Main.dust[num357];
            dust57.velocity.Y = dust57.velocity.Y * 2f;
            dust3 = Main.dust[num357];
            dust3.scale *= (float)Main.rand.NextDouble();
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

                        shootToX *= distance * 4;
                        shootToY *= distance * 4;

                        projectile.velocity.X = shootToX;
                        projectile.velocity.Y = shootToY;
                    }
                    if (distance < 2f && target.active)
                    {
                        HasHitEnemy = true;
                    }
                }
            }
        }
    }
}