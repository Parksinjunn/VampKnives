using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using VampKnives.Items;

namespace VampKnives.Projectiles
{
    public class WyvernProj : KnifeProjectile
    {
        public bool HitNewTarget;
        public int delay = 40;
        public int NumHits;
        public override void SafeSetDefaults()
        {
            projectile.width = 14;
            projectile.height = 40;
            projectile.friendly = true;
            projectile.penetrate = 2;
            projectile.hostile = false;
            projectile.tileCollide = false;                 //this make that the projectile does not go thru walls
            projectile.ignoreWater = false;
            projectile.timeLeft = 320;
        }
        public override void AI()
        {
            for (int g = 0; g < 160 / projectile.timeLeft; g++)
                {
                    Vector2 position = Main.LocalPlayer.Center;
                    Dust dust = Main.dust[Terraria.Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), 1, 1, 45, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 0, new Color(255, 255, 255), 0.8f)];
                    dust.noGravity = false;
                }
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            projectile.localAI[0] += 1f;
            if (projectile.timeLeft < 60)
                projectile.Opacity -= 0.01f;
            for (int NPCDist = 0; NPCDist < 200; NPCDist++)
            {
                if (!Main.npc[NPCDist].friendly)
                {
                    Rectangle rectangle4 = new Rectangle((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height);
                    Rectangle value11 = new Rectangle((int)Main.npc[NPCDist].position.X, (int)Main.npc[NPCDist].position.Y, Main.npc[NPCDist].width, Main.npc[NPCDist].height);
                    if (rectangle4.Intersects(value11))
                    {
                        HitNewTarget = true;
                        delay = 0;
                    }
                }
            }
            if (HitNewTarget)
            {
                if (delay <= 30)
                {
                    delay++;
                    projectile.velocity *= 0.95f;
                }
                else if (delay > 30)
                {
                    for (int i = 0; i < Main.npc.Length; i++)
                    {
                        NPC target = Main.npc[i];
                        if (!target.friendly)
                        {
                            float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
                            float shootToY = target.position.Y - projectile.Center.Y;
                            float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

                            if (distance < 2000f && !target.friendly && target.active)
                            {
                                distance = 3f / distance;

                                shootToX *= distance * 10;
                                shootToY *= distance * 10;

                                projectile.velocity.X = shootToX;
                                projectile.velocity.Y = shootToY;
                            }
                        }
                    }
                }
            }
        }

        public override void OnHitNPC(NPC n, int damage, float knockback, bool crit)
        {
            NumHits++;
            projectile.damage = projectile.damage / NumHits;
            Player owner = Main.player[projectile.owner];
            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("HealProj"), (int)(projectile.damage * 0.75), 0, owner.whoAmI);

            for (int x = 0; x < 5; x++)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = Main.LocalPlayer.Center;
                dust = Main.dust[Terraria.Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width + 5, projectile.height + 5, 45, projectile.velocity.X * -0.5f, projectile.velocity.Y * -0.5f, 0, new Color(255, 255, 255), 2f)];
                dust.noGravity = true;
            }
            Hoods(n);
        }
        //public override bool OnTileCollide(Vector2 oldVelocity)
        //{
        //    Main.NewText("Ricochet: " + ParentWeapon.RicochetChance);
        //    if (ParentWeapon.RicochetChance > 0.5f)
        //    {
        //        Ricochet(oldVelocity);
        //    }
        //    else
        //    {
        //        projectile.Kill();
        //    }
        //    return false;
        //}
    }
}