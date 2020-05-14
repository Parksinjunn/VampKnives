using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles
{
    public class ResilienceKnivesProj : ModProjectile
    {
        public float shootToX;
        public float shootToY;
        public float OwnerPositionX;
        public float OwnerPositionY;
        public float distance;
        public bool Hit;
        List<Projectile> killlist = new List<Projectile>();
        public override void SetDefaults()
        {
            projectile.width = 56;
            projectile.height = 34;
            projectile.knockBack = 60;
            projectile.friendly = true;
            projectile.penetrate = 5;                     
            projectile.hostile = false;
            projectile.magic = true;                 
            projectile.ignoreWater = true;
            projectile.timeLeft = 600;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 40;

        }
        public bool StopRotation = false;
        public bool GotPlayerPosition = false;
        public Vector2 ProjectileBack;
        public Vector2 ProjectileFront;
        int ProjHits = 0;
        bool Stopped = false;
        public override void AI()
        {
            ProjectileBack = new Vector2( (projectile.Center.X - ((float)Math.Sin(projectile.rotation) * projectile.width / 2)), projectile.Center.Y + ((float)Math.Cos(projectile.rotation) * projectile.height / 2));
            ProjectileFront = new Vector2((projectile.Center.X + ((float)Math.Sin(projectile.rotation) * projectile.width / 2)), projectile.Center.Y - ((float)Math.Cos(projectile.rotation) * projectile.height / 2));
            //int dust = Dust.NewDust(ProjectileBack, 1, 1, 175, 0f, 0f, 0, default(Color), 1.5f);
            //Main.dust[dust].noGravity = true;
            //Main.dust[dust].velocity *= 0;
            //int dust2 = Dust.NewDust(ProjectileFront, 1, 1, 180, 0f, 0f, 0, Color.Blue, 1.5f);
            //Main.dust[dust2].noGravity = true;
            //Main.dust[dust2].velocity *= 0;
            //int dust3 = Dust.NewDust(projectile.Hitbox.TopRight(), 1, 1, 183, 0f, 0f, 0, Color.Blue, 1.5f);
            //Main.dust[dust3].noGravity = true;
            //Main.dust[dust3].velocity *= 0;
            //int dust4 = Dust.NewDust(projectile.Hitbox.TopLeft(), 1, 1, 183, 0f, 0f, 0, Color.Blue, 1.5f);
            //Main.dust[dust4].noGravity = true;
            //Main.dust[dust4].velocity *= 0;

            Player owner = Main.player[projectile.owner];
            Random rand = new Random();
            if (GotPlayerPosition == false)
            {
                OwnerPositionX = owner.position.X + (float)owner.width * 0.5f;
                OwnerPositionY = owner.position.Y + (owner.height / 2);
                GotPlayerPosition = true;
            }
            //projectile.localAI[0] += 1f;

            //CODE ADAPTED FROM werickson24's ShieldMod. This projectile behavior is heavily based on his work!
            for (int s = 0; s < 1000; s++)
            {
                if (Main.projectile[s].active && Main.projectile[s].hostile)/* && !Array.Exists(blacklist, element => element == Main.projectile[s].type))*/
                {
                    Projectile ProJ = Main.projectile[s];
                    if (Colliding(projectile.Hitbox, ProJ.Hitbox) == true)
                    {
                        for (int b = 0; b < 10; b++)
                        {
                            double YRand = rand.Next(1, 5)*rand.NextDouble();
                            double XRand = rand.Next(1, 3)*rand.NextDouble();
                            int numdust2 = Dust.NewDust(ProJ.position, 6, 6, 25, 0f, 0f, 100, Color.Brown, 1f);
                            Dust ProjHitDust = Main.dust[numdust2];
                            ProjHitDust.velocity = new Vector2((0.01f) * -ProJ.velocity.X * (float)(b/XRand), (0.1f) * -ProJ.velocity.Y * (float)(b/YRand));
                            ProjHitDust.noGravity = false;
                        }
                        ProjHits += 1;
                        ProJ.Kill();
                        if(ProjHits > 5)
                        {
                            projectile.Kill();
                            for (int num641 = 0; num641 < 50; num641++)
                            {
                                int numdust = Dust.NewDust(projectile.Center, 6, 6, 268, 0f, 0f, 100, Color.Brown, 1f);
                                Dust projdust = Main.dust[numdust];
                                float num646 = projdust.velocity.X;
                                float y3 = projdust.velocity.Y;
                                if (num646 == 0f && y3 == 0f)
                                {
                                    num646 = 1f;
                                }
                                float num647 = (float)Math.Sqrt(num646 * num646 + y3 * y3);
                                num647 = 4f / num647;
                                num646 *= num647;
                                y3 *= num647;
                                projdust.velocity *= 0.5f;
                                projdust.velocity.X += num646;
                                projdust.scale = 1.3f;
                            }
                        }

                        //if (killlist.Contains(ProJ))
                        //{
                        //    killlist.Remove(ProJ);
                        //    ProJ.Kill();
                        //}
                        //else
                        //{
                        //    for (int num641 = 0; num641 < 80; num641++)
                        //    {
                        //        int numdust = Dust.NewDust(new Vector2(ProJ.position.X, ProJ.position.Y), 6, 6, 272, 0f, 0f, 100, default(Color), 1f);
                        //        Dust projdust = Main.dust[numdust];
                        //        float num646 = projdust.velocity.X;
                        //        float y3 = projdust.velocity.Y;
                        //        if (num646 == 0f && y3 == 0f)
                        //        {
                        //            num646 = 1f;
                        //        }
                        //        float num647 = (float)Math.Sqrt(num646 * num646 + y3 * y3);
                        //        num647 = 4f / num647;
                        //        num646 *= num647;
                        //        y3 *= num647;
                        //        projdust.velocity *= 0.5f;
                        //        projdust.velocity.X += num646;
                        //        projdust.velocity.Y += y3;
                        //        projdust.scale = 1.3f;
                        //        projdust.noGravity = true;
                        //    }
                        //    ProJ.velocity = new Vector2(-ProJ.velocity.X, -ProJ.velocity.Y);
                        //    killlist.Add(ProJ);
                        //}
                    }
                }
            }
            for (int i = 0; i < 200; i++)
            {
                shootToX = OwnerPositionX - projectile.Center.X;
                shootToY = OwnerPositionY - projectile.Center.Y;
                distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));
                if (StopRotation == false)
                {
                    projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
                }
                if (distance > 200f && owner.active)
                {
                    projectile.velocity = new Vector2(0,0);
                    StopRotation = true;
                }
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.velocity *= 0.5f;
            return false;
        }
        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            bool flag;
            Vector2 clamped = Vector2.Clamp(projectile.Center, targetHitbox.Left(), targetHitbox.Right());
            if (PosHit(clamped))
            {
                flag = Math.Pow(20, 2) > Vector2.DistanceSquared(projectile.Center, clamped);
            }
            else
            {
                flag = false;
            }
            return flag;
        }

        public bool PosHit(Vector2 targetPosition)
        {
            if (WorldGen.SolidTile((int)targetPosition.X / 16, (int)targetPosition.Y / 16))
            {
                return false;
            }
            Vector2 vector = Vector2.Clamp(targetPosition, new Vector2(projectile.Center.X - 16, projectile.Center.Y - 16), new Vector2(projectile.Center.X + 16, projectile.Center.Y + 16));
            bool flag = Collision.CanHitLine(vector, 0, 0, targetPosition, 0, 0);
            if (!flag)
            {
                Vector2 v = targetPosition - vector;
                Vector2 spinningpoint = v.SafeNormalize(Vector2.UnitY);
                Vector2 value = Vector2.Lerp(vector, targetPosition, 0.5f);
                Vector2 vector2 = value + spinningpoint.RotatedBy(1.5707963705062866, default(Vector2)) * v.Length() * 0.15f;
                if (Collision.CanHitLine(vector, 0, 0, vector2, 0, 0) && Collision.CanHitLine(vector2, 0, 0, targetPosition, 0, 0))
                {
                    flag = true;
                }
                if (!flag)
                {
                    Vector2 vector3 = value + spinningpoint.RotatedBy(-1.5707963705062866, default(Vector2)) * v.Length() * 0.15f;
                    if (Collision.CanHitLine(vector, 0, 0, vector3, 0, 0) && Collision.CanHitLine(vector3, 0, 0, targetPosition, 0, 0))
                    {
                        flag = true;
                    }
                }
            }
            return flag;
        }

        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            knockback = 60;
            double DirChk = target.Center.X - projectile.Center.X;
            if (DirChk > 0)
            {
                hitDirection = 1;
            }
            else
            {
                hitDirection = -1;
            }
        }
    }
}