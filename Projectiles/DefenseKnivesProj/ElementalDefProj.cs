using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles.DefenseKnivesProj
{
    public class ElementalDefProj : KnifeProjectile
    {
        public int FrameCount = 8;
        public int FrameCounter;
        public int FrameDelay;
        public override void SafeSetDefaults()
        {
            projectile.width = 14;
            projectile.height = 16;
            projectile.knockBack = 0;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.tileCollide = true;
            projectile.hostile = false;
            projectile.magic = true;
            projectile.ignoreWater = false;
            projectile.timeLeft = 220;
            Main.projFrames[projectile.type] = FrameCount;           //this is projectile frames
        }
        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            FrameDelay++;
            if (FrameDelay > 6)
            {
                FrameCounter++;
                projectile.frame = FrameCounter;
                int numdust = Dust.NewDust(projectile.Hitbox.Bottom(), 1, 1, 6, -projectile.velocity.X, -projectile.velocity.Y, 100, Color.Orange, 1f+(float)(Main.rand.NextDouble()));
                Dust projdust = Main.dust[numdust];
                if (FrameCounter >= FrameCount - 1)
                {
                    FrameCounter = 0;
                }
                FrameDelay = 0;
            }
            if (projectile.timeLeft <= 20)
            {
                projectile.Opacity *= 0.95f;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(ModContent.BuffType<Buffs.Hellfire>(),240);
        }
        public override void Kill(int timeLeft)
        {
            for (int NumDust = 0; NumDust < 50; NumDust++)
            {
                int numdust = Dust.NewDust(projectile.Hitbox.Bottom(), 1, 1, 6, -projectile.velocity.X, -projectile.velocity.Y, 100, default(Color), (float)(Main.rand.NextDouble()));
                Dust projdust = Main.dust[numdust];
            }
        }
    }
}