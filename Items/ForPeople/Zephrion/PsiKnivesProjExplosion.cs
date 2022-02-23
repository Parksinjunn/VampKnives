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
    public class PsiKnivesProjExplosion : KnifeProjectile
    {
        int Type;
        public override void SafeSetDefaults()
        {
            projectile.width = 58;
            projectile.height = 132;
            projectile.Hitbox.Inflate(30, 50);
            projectile.friendly = true;
            projectile.penetrate = 1;                    
            projectile.hostile = false;
            projectile.magic = true;                       
            projectile.tileCollide = false;                
            projectile.ignoreWater = true;
            projectile.timeLeft = 300;
            Main.projFrames[projectile.type] = 14;
            projectile.scale = 0.90f;
            HealProjChance = 0;
            Type = Main.rand.Next(0, 4);
            if (Type == 2 || Type == 3)
            {
                projectile.frame = 8;
            }
        }
        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
                projectile.penetrate = -1;
                projectile.friendly = false;
                projectile.damage = 0;
                projectile.localNPCHitCooldown = projectile.timeLeft + 1;
            base.ModifyHitNPC(target, ref damage, ref knockback, ref crit, ref hitDirection);
        }
        public override void AI()
        {
            //this is projectile dust
            //int DustID2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width - 3, projectile.height - 3, 158, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 10, Color.LightBlue, 1f);
            //Main.dust[DustID2].noGravity = true;
            if ((projectile.frame == 1 && (Type == 0 || Type == 1)) || (projectile.frame == 8 && (Type == 2 || Type == 3)))
            {
                projectile.damage = 128;
            }
            else
                projectile.damage = 0;

            if (Type == 1 || Type == 3)
                projectile.spriteDirection = -1;
            else
                projectile.spriteDirection = 1;
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;

            Lighting.AddLight(projectile.Center, 0.48f, 0.9f, 0.9f);
            projectile.frameCounter++;
            if (Type == 0 || Type == 1)
            {
                if (projectile.frameCounter >= (int)(6f))
                {
                    projectile.frame++;
                    projectile.frameCounter = 0;
                    if (projectile.frame > 6)
                    {
                        projectile.Kill();
                    }
                }
            }
            if (Type == 2 || Type == 3)
            {
                if (projectile.frameCounter >= (int)(6f))
                {
                    projectile.frame++;
                    projectile.frameCounter = 0;
                    if (projectile.frame > 13)
                    {
                        projectile.Kill();
                    }
                }
            }
            
        }
    }
}