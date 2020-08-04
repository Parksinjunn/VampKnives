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
    public class TrueDemonsScourgeProj : KnifeProjectile
    {
        int Delay;
        bool HasChanneled;
        float SpeedMult;
        public override void SafeSetDefaults()
        {
            projectile.width = 16;
            projectile.height = 30;
            projectile.friendly = true;
            projectile.penetrate = 1;                       //projectile is the projectile penetration
            projectile.hostile = false;
            projectile.tileCollide = true;                 //projectile make that the projectile does not go thru walls
            projectile.ignoreWater = false;
            projectile.timeLeft = 300;
            projectile.scale = 0.65f;
            SpeedMult = Main.rand.NextFloat(0.90f, 1.4f);
            Main.projFrames[projectile.type] = 5;
        }
        public override void AI()
        {
            Delay++;
            int num118 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 3.5f);
            Main.dust[num118].noGravity = true;
            Dust dust3 = Main.dust[num118];
            dust3.velocity *= 1.4f;
            num118 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 1.5f);

            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;

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
            Main.PlaySound(SoundID.Item10.WithVolume(0.5f), projectile.position);
            int num4;
            for (int num582 = 0; num582 < 20; num582 = num4 + 1)
            {
                int num583 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, (0f - projectile.velocity.X) * 0.2f, (0f - projectile.velocity.Y) * 0.2f, 100, default(Color), 2f);
                Main.dust[num583].noGravity = true;
                Dust dust = Main.dust[num583];
                dust.velocity *= 2f;
                num583 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, (0f - projectile.velocity.X) * 0.2f, (0f - projectile.velocity.Y) * 0.2f, 100, default(Color), 1f);
                dust = Main.dust[num583];
                dust.velocity *= 2f;
                num4 = num582;
            }
        }
        public override void SafeOnHitNPC(NPC n, int damage, float knockback, bool crit)
        {
            if(n.HasBuff(BuffID.OnFire))
            {
                n.AddBuff(ModContent.BuffType<Buffs.Hellfire>(), Main.rand.Next(240, 480));
            }
            else
            {
                n.AddBuff(BuffID.OnFire,Main.rand.Next(240,480));
            }
        }

        public override bool PreDraw(SpriteBatch sb, Color lightColor) //this is where the animation happens
        {
            projectile.frameCounter++; //increase the frameCounter by one
            if (projectile.frameCounter >= 2) //once the frameCounter has reached 2 - change the 2 to change how fast the projectile animates
            {
                projectile.frame++; //go to the next frame
                projectile.frameCounter = 0; //reset the counter
                if (projectile.frame > 4) //if past the last frame
                    projectile.frame = 0; //go back to the first frame
            }
            return true;
        }
    }
}