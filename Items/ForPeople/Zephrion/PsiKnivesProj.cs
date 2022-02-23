using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VampKnives.Projectiles;

namespace VampKnives.Items.ForPeople.Zephrion
{
    public class PsiKnivesProj : KnifeProjectile
    {
        bool HitTile;
        bool HitNPC;
        bool HasDoneEffect;
        float FadePos;
        float LightR = 0f;
        float LightG = 0f;
        float LightB = 0f;
        float RotationStore;
        Vector2 VelocityStore;
        bool RotationStored;
        int DefenseInitiateTime = 210;
        public override void SafeSetDefaults()
        {
            projectile.width = 36;
            projectile.height = 32;
            projectile.friendly = true;
            projectile.penetrate = -1;                       //this is the projectile penetration
            projectile.hostile = false;
            projectile.magic = true;                        //this make the projectile do magic damage
            projectile.tileCollide = true;                 //this make that the projectile does not go thru walls
            projectile.ignoreWater = true;
            projectile.timeLeft = 240;
            Main.projFrames[projectile.type] = 7;
            projectile.scale = 0.95f;
        }

        public override void DrawBehind(int index, List<int> drawCacheProjsBehindNPCsAndTiles, List<int> drawCacheProjsBehindNPCs, List<int> drawCacheProjsBehindProjectiles, List<int> drawCacheProjsOverWiresUI)
        {
            if (HitTile || HitNPC)
            {
                drawCacheProjsBehindNPCsAndTiles.Add(index);
                return;
            }
        }
        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
                // Inflate some target hitboxes if they are beyond 8,8 size
                if (targetHitbox.Width > 8 && targetHitbox.Height > 8)
                {
                    targetHitbox.Inflate(-targetHitbox.Width / 8, -targetHitbox.Height / 8);
                }
                // Return if the hitboxes intersects, which means the knive collides or not
            return projHitbox.Intersects(targetHitbox);
        }
        public bool isStickingToTarget
        {
            get { return projectile.ai[0] == 1f; }
            set { projectile.ai[0] = value ? 1f : 0f; }
        }

        // WhoAmI of the current target
        public float targetWhoAmI
        {
            get { return projectile.ai[1]; }
            set { projectile.ai[1] = value; }
        }

        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if(projectile.damage == 12 && !HitTile)
            {
                HitNPC = true;
                projectile.tileCollide = false;
                targetWhoAmI = (float)target.whoAmI; // Set the target whoAmI
                projectile.velocity =
                    (target.Center - projectile.Center) *
                    0.75f; // Change velocity based on delta center of targets (difference between entity centers)
                projectile.netUpdate = true; // netUpdate this knive
                projectile.damage = 0;
            }
            base.ModifyHitNPC(target, ref damage, ref knockback, ref crit, ref hitDirection);
        }
        public override void AI()
        {
            if(projectile.damage == 1 && projectile.timeLeft <= DefenseInitiateTime)
            {
                if(!RotationStored)
                {
                    RotationStore = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) - 1.57f;
                    RotationStored = true;
                }
                if (projectile.frame >= 3)
                {
                    LightR = 0.029f + (projectile.frame / 12f);
                    LightG = 0.045f + (projectile.frame / 12f);
                    LightB = 0.046f + (projectile.frame / 12f);
                }
                Lighting.AddLight(projectile.position, LightR, LightG, LightB);
                projectile.penetrate = 1;
                projectile.frameCounter++;
                if (projectile.frameCounter >= (int)(4f))
                {
                    projectile.frame++;
                    projectile.frameCounter = 0;
                    if (projectile.frame > 3)
                    {
                        projectile.frame = 4;
                        projectile.velocity *= 0f;
                        projectile.rotation = RotationStore;
                    }
                    else
                    {
                        projectile.velocity *= 0.1f;
                        projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
                    }
                }
            }
            else if(projectile.damage == 1 && projectile.timeLeft > DefenseInitiateTime)
            {
                VelocityStore = projectile.velocity;
                projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            }
            else if(projectile.damage == 15 || projectile.damage == 12)
            {
                if (projectile.damage == 15 && !HitTile)
                {
                    projectile.velocity.Y += 0.5f;
                }
                projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
                if (projectile.frame >= 3)
                {
                    LightR = 0.029f + (projectile.frame / 12f);
                    LightG = 0.045f + (projectile.frame / 12f);
                    LightB = 0.046f + (projectile.frame / 12f);
                }
                Lighting.AddLight(projectile.position, LightR, LightG, LightB);
                if (HitTile || HitNPC || projectile.timeLeft <= 90)
                {
                    projectile.frameCounter++;
                    if (projectile.frameCounter == 1)
                    {
                        VelocityStore = projectile.velocity;
                        //Main.NewText("Velocity: " + (VelocityStore * 100));
                    }
                    if (projectile.frameCounter >= (int)(40f))
                    {
                        projectile.frame++;
                        projectile.frameCounter = 36;
                        if (projectile.frame > 6)
                        {
                            projectile.Kill();
                        }
                    }
                    projectile.velocity = projectile.velocity * 0.8f;
                    if (HasDoneEffect == false)
                    {
                        HasDoneEffect = true;
                        for (int i = 0; i < 10; i++)
                        {
                            int DustID2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width - 3, projectile.height - 3, 1, projectile.velocity.X * 0.2f, projectile.velocity.Y * -0.2f, 10, Color.Gray, 1f);
                        }
                    }
                }
            }
            if (HitNPC)
            {
                bool hitEffect = false;
                projectile.localAI[0] += 1f;
                hitEffect = projectile.localAI[0] % 30f == 0f;
                int projTargetIndex = (int)targetWhoAmI;
                if (Main.npc[projTargetIndex].active && !Main.npc[projTargetIndex].dontTakeDamage)
                {
                    projectile.Center = Main.npc[projTargetIndex].Center - projectile.velocity * 2f;
                    projectile.gfxOffY = Main.npc[projTargetIndex].gfxOffY;
                    if (hitEffect)
                    {
                        Main.npc[projTargetIndex].HitEffect(0, 1.0);
                    }
                }
                else 
                {
                    projectile.Kill();
                }
            }
        }
        Vector2 collidePoint;
        public override void Kill(int timeLeft)
        {
            if(HitTile)
                Projectile.NewProjectile(projectile.damage == 1 ? (projectile.Center + (VelocityStore * 8)) : projectile.damage == 12 ? (projectile.Center - (VelocityStore * 8)) : (collidePoint), projectile.damage == 1 ? VelocityStore/16 : projectile.velocity * -0.01f, ModContent.ProjectileType<PsiKnivesProjExplosion>(), 0, 5f, projectile.owner);
            else
            {
                Projectile.NewProjectile(projectile.damage == 1 ? (projectile.Center + (VelocityStore * 8)) : (projectile.Center - (VelocityStore * 8)), projectile.damage == 1 ? VelocityStore/16 : projectile.velocity * -0.01f, ModContent.ProjectileType<PsiKnivesProjExplosion>(), 0, 5f, projectile.owner);
            }
            base.Kill(timeLeft);
        }

        public override bool SafeOnTileCollide(Vector2 oldVelocity)
        {
            //Main.NewText("Velocity: " + projectile.velocity);
            HitTile = true;
            projectile.hide = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            collidePoint = projectile.position;
            //if (projectile.velocity.Y >= 6f || projectile.velocity.Y < -6f)
            //{
            //    projectile.velocity.X *= 0f;
            //}
            //else
            //{
            //    projectile.velocity.Y *= 0f;
            //}
            return false;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            SpriteEffects effects = projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            Texture2D texture = Main.projectileTexture[projectile.type];
            int frameHeight = texture.Height / Main.projFrames[projectile.type];
            int spriteSheetOffset = frameHeight * projectile.frame;
            Player player = Main.player[projectile.owner];
            Vector2 sheetInsertPosition = (projectile.Center + Vector2.UnitY * projectile.gfxOffY - Main.screenPosition).Floor();
            Color drawColor = new Color(255, 255, 255);
            spriteBatch.Draw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), lightColor, projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), projectile.scale, effects, 0f);
            return false;
        }
    }
}