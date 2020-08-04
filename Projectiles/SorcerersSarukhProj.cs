using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VampKnives.NPCs;

namespace VampKnives.Projectiles
{
    public class SorcerersSarukhProj : KnifeProjectile
    {
        int Delay;
        bool HasChanneled;
        float SpeedMult;
        public override void SafeSetDefaults()
        {
            projectile.width = 22;
            projectile.height = 22;
            projectile.friendly = true;
            projectile.penetrate = 1;                       //projectile is the projectile penetration
            projectile.hostile = false;
            projectile.tileCollide = true;                 //projectile make that the projectile does not go thru walls
            projectile.ignoreWater = true;
            projectile.timeLeft = 300;
            projectile.scale = 0.65f;
            SpeedMult = Main.rand.NextFloat(0.90f, 1.4f);
        }
        public override void AI()
        {
            Delay++;
            if (projectile.soundDelay == 0 && Math.Abs(projectile.velocity.X) + Math.Abs(projectile.velocity.Y) > 2f)
            {
                projectile.soundDelay = 10;
                Main.PlaySound(SoundID.Item9.WithVolume(0.5f), projectile.position);
            }
            int num121 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 15, 0f, 0f, 100, default(Color), 2f);
            Dust dust3 = Main.dust[num121];
            dust3.velocity *= 0.3f;
            Main.dust[num121].position.X = projectile.position.X + (float)(projectile.width / 2) + 4f + (float)Main.rand.Next(-4, 5);
            Main.dust[num121].position.Y = projectile.position.Y + (float)(projectile.height / 2) + (float)Main.rand.Next(-4, 5);
            Main.dust[num121].noGravity = true;

            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            //projectile.localAI[0] += 1f;
            if (projectile.velocity.X == 0f && projectile.velocity.Y == 0f)
            {
                HasChanneled = true;
            }

            if (Main.myPlayer == projectile.owner && projectile.ai[0] == 0f && Delay > 4)
            {
                projectile.rotation += (float)projectile.direction * 0.8f;
                if (Main.player[projectile.owner].channel)
                {
                    projectile.rotation += (float)projectile.direction * 0.8f;
                    float num146 = 12f;
                    Vector2 vector10 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
                    projectile.rotation += (float)projectile.direction * 0.8f;
                    float num147 = (float)Main.mouseX + Main.screenPosition.X - vector10.X;
                    projectile.rotation += (float)projectile.direction * 0.8f;
                    float num148 = (float)Main.mouseY + Main.screenPosition.Y - vector10.Y;
                    projectile.rotation += (float)projectile.direction * 0.8f;
                    if (Main.player[projectile.owner].gravDir == -1f)
                    {
                        num148 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - vector10.Y;
                        projectile.rotation += (float)projectile.direction * 0.8f;
                    }
                    float num149 = (float)Math.Sqrt((double)(num147 * num147 + num148 * num148));
                    num149 = (float)Math.Sqrt((double)(num147 * num147 + num148 * num148));
                    if (num149 > num146)
                    {
                        projectile.rotation += (float)projectile.direction * 0.8f;
                        num149 = num146 / num149;
                        num147 *= num149;
                        num148 *= num149;
                        int num150 = (int)(num147 * 1000f);
                        int num151 = (int)(projectile.velocity.X * 1000f);
                        projectile.rotation += (float)projectile.direction * 0.8f;
                        int num152 = (int)(num148 * 1000f);
                        int num153 = (int)(projectile.velocity.Y * 1000f);
                        projectile.rotation += (float)projectile.direction * 0.8f;
                        if (num150 != num151 || num152 != num153)
                        {
                            projectile.rotation += (float)projectile.direction * 0.8f;
                            projectile.netUpdate = true;
                            projectile.rotation += (float)projectile.direction * 0.8f;
                        }
                        projectile.velocity.X = num147;
                        projectile.rotation += (float)projectile.direction * 0.8f;
                        projectile.velocity.Y = num148;
                        projectile.rotation += (float)projectile.direction * 0.8f;
                    }
                    else
                    {
                        projectile.rotation += (float)projectile.direction * 0.8f;
                        int num154 = (int)(num147 * 1000f);
                        int num155 = (int)(projectile.velocity.X * 1000f);
                        projectile.rotation += (float)projectile.direction * 0.8f;
                        int num156 = (int)(num148 * 1000f);
                        int num157 = (int)(projectile.velocity.Y * 1000f);
                        projectile.rotation += (float)projectile.direction * 0.8f;
                        if (num154 != num155 || num156 != num157)
                        {
                            projectile.rotation += (float)projectile.direction * 0.8f;
                            projectile.netUpdate = true;
                            projectile.rotation += (float)projectile.direction * 0.8f;
                        }
                        projectile.velocity.X = num147;
                        projectile.rotation += (float)projectile.direction * 0.8f;
                        projectile.velocity.Y = num148;
                        projectile.rotation += (float)projectile.direction * 0.8f;
                    }
                    projectile.rotation += (float)projectile.direction * 0.8f;
                    projectile.velocity *= SpeedMult;
                }
                else if (HasChanneled)
                {
                    projectile.rotation += (float)projectile.direction * 0.8f;
                    if (projectile.ai[0] == 0f)
                    {
                        projectile.ai[0] = 1f;
                        projectile.rotation += (float)projectile.direction * 0.8f;
                        projectile.netUpdate = true;
                        projectile.rotation += (float)projectile.direction * 0.8f;
                        float num158 = 12f;
                        Vector2 vector11 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
                        float num159 = (float)Main.mouseX + Main.screenPosition.X - vector11.X;
                        projectile.rotation += (float)projectile.direction * 0.8f;
                        float num160 = (float)Main.mouseY + Main.screenPosition.Y - vector11.Y;
                        projectile.rotation += (float)projectile.direction * 0.8f;
                        if (Main.player[projectile.owner].gravDir == -1f)
                        {
                            num160 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - vector11.Y;
                            projectile.rotation += (float)projectile.direction * 0.8f;
                        }
                        float num161 = (float)Math.Sqrt((double)(num159 * num159 + num160 * num160));
                        if (num161 == 0f)
                        {
                            vector11 = new Vector2(Main.player[projectile.owner].position.X + (float)(Main.player[projectile.owner].width / 2), Main.player[projectile.owner].position.Y + (float)(Main.player[projectile.owner].height / 2));
                            projectile.rotation += (float)projectile.direction * 0.8f;
                            num159 = projectile.position.X + (float)projectile.width * 0.5f - vector11.X;
                            projectile.rotation += (float)projectile.direction * 0.8f;
                            num160 = projectile.position.Y + (float)projectile.height * 0.5f - vector11.Y;
                            projectile.rotation += (float)projectile.direction * 0.8f;
                            num161 = (float)Math.Sqrt((double)(num159 * num159 + num160 * num160));
                        }
                        num161 = num158 / num161;
                        num159 *= num161;
                        num160 *= num161;
                        projectile.velocity.X = num159;
                        projectile.rotation += (float)projectile.direction * 0.8f;
                        projectile.velocity.Y = num160;
                        projectile.rotation += (float)projectile.direction * 0.8f;
                        if (projectile.velocity.X == 0f && projectile.velocity.Y == 0f)
                        {
                            projectile.Kill();
                        }
                    }
                    projectile.rotation += (float)projectile.direction * 0.8f;
                }
                projectile.rotation += (float)projectile.direction * 0.8f;
            }
            projectile.rotation += (float)projectile.direction * 0.8f;
            if (projectile.velocity.X != 0f || projectile.velocity.Y != 0f)
            {
                projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) - 2.355f;
                projectile.rotation += (float)projectile.direction * 0.8f;
            }
            projectile.rotation += (float)projectile.direction * 0.8f;
            if (projectile.velocity.Y > 16f)
            {
                projectile.velocity.Y = 16f;
                projectile.rotation += (float)projectile.direction * 0.8f;
            }
        }
        public override void Kill(int timeLeft)
        {
            if (projectile.penetrate == 1)
            {
                projectile.maxPenetrate = -1;
                projectile.penetrate = -1;
                int num590 = 60;
                projectile.position.X = projectile.position.X - (float)(num590 / 2);
                projectile.position.Y = projectile.position.Y - (float)(num590 / 2);
                projectile.width += num590;
                projectile.height += num590;
                projectile.tileCollide = false;
                projectile.velocity *= 0.01f;
                projectile.Damage();
                projectile.scale = 0.01f;
            }
            projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
            projectile.width = 10;
            projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
            projectile.height = 10;
            projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
            Main.PlaySound(SoundID.Item10.WithVolume(0.5f), projectile.position);
            int num4;
            for (int num591 = 0; num591 < 20; num591 = num4 + 1)
            {
                int num592 = Dust.NewDust(new Vector2(projectile.position.X - projectile.velocity.X, projectile.position.Y - projectile.velocity.Y), projectile.width, projectile.height, 15, 0f, 0f, 100, default(Color), 2f);
                Main.dust[num592].noGravity = true;
                Dust dust = Main.dust[num592];
                dust.velocity *= 2f;
                num592 = Dust.NewDust(new Vector2(projectile.position.X - projectile.velocity.X, projectile.position.Y - projectile.velocity.Y), projectile.width, projectile.height, 15, 0f, 0f, 100, default(Color), 1f);
                num4 = num591;
            }
        }
    }
}