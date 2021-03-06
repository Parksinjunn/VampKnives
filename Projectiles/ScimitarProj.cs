﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles
{
    public class ScimitarProj : KnifeProjectile
    {
        bool Instantiated = false;
        public override void SafeSetDefaults()
        {
            Main.projFrames[projectile.type] = 6;
            projectile.width = 38;
            projectile.height = 38;
            projectile.friendly = true;
            projectile.penetrate = 6;                       //this is the projectile penetration
            projectile.hostile = false;
            projectile.magic = true;                        //this make the projectile do magic damage
            projectile.tileCollide = true;                 //this make that the projectile does not go thru walls
            projectile.ignoreWater = false;
            projectile.timeLeft = 300;
        }
        int SpriteRotation = 45;
        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation()+MathHelper.ToRadians(SpriteRotation); // projectile faces sprite right
            projectile.localAI[0] += 1f;
            //projectile.light = .04f;
            //projectile.alpha = (int)projectile.localAI[0] * 2;
        }

        public override bool PreDraw(SpriteBatch sb, Color lightColor) //this is where the animation happens
        {
            if(Instantiated == false)
            {
                projectile.frame = Main.rand.Next(0, 5);
                Instantiated = true;
            }
            projectile.frameCounter++; //increase the frameCounter by one
            if (projectile.frameCounter >= 2) //once the frameCounter has reached 3 - change the 10 to change how fast the projectile animates
            {
                projectile.frame++; //go to the next frame
                projectile.frameCounter = 0; //reset the counter
                if (projectile.frame > 5) //if past the last frame
                    projectile.frame = 0; //go back to the first frame
            }
            return true;
        }

        public override void SafeOnHitNPC(NPC n, int damage, float knockback, bool crit)
        {
            n.AddBuff(ModContent.BuffType<Buffs.BleedingOut2>(), 300);
        }
        public override bool SafeOnTileCollide(Vector2 oldVelocity)
        {
            Main.PlaySound(SoundID.Tink, (int)projectile.position.X, (int)projectile.position.Y, 1, 0.5f);
            int DustID2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width - 3, projectile.height - 3, 1, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 10, Color.Gray, 1f);
            return true;
        }
    }
}