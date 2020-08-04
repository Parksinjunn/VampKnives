using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles
{
    public class EnchantedKnivesProj : KnifeProjectile
    {
        int EffectTimer;

        public override void SafeSetDefaults()
        {
            Main.projFrames[projectile.type] = 4;
            projectile.width = 34;
            projectile.height = 34;
            projectile.friendly = true;
            projectile.penetrate = 1;                       //this is the projectile penetration
            projectile.hostile = false;
            projectile.magic = true;                        //this make the projectile do magic damage
            projectile.tileCollide = true;                 //this make that the projectile does not go thru walls
            projectile.ignoreWater = true;
            projectile.timeLeft = 300;
            projectile.scale = 0.7f;
        }
        int SpriteRotation = 45;
        public override void SafeAI()
        {
            //this make that the projectile faces the right way 
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(SpriteRotation); // projectile faces sprite right
            Lighting.AddLight(projectile.Center, 0.3f, 0.4f, 0.5f);
        }
        public override bool SafePreKill(int timeLeft)
        {
            if(projectile.velocity.X == 0 && projectile.velocity.Y == 0)
            {
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, Main.rand.NextFloat(-20f,20f), Main.rand.NextFloat(-20f, 20f), 173, projectile.damage / 2, projectile.knockBack, projectile.owner); //Creates a new Projectile
            }
            else
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X, projectile.velocity.Y, 173, projectile.damage / 2, projectile.knockBack, projectile.owner); //Creates a new Projectile
            return base.SafePreKill(timeLeft); ;
        }
        public override bool PreDraw(SpriteBatch sb, Color lightColor) //this is where the animation happens
        {
            projectile.frameCounter++; //increase the frameCounter by one
            if (projectile.frameCounter >= 2) //once the frameCounter has reached 3 - change the 10 to change how fast the projectile animates
            {
                projectile.frame++; //go to the next frame
                projectile.frameCounter = 0; //reset the counter
                if (projectile.frame > 3) //if past the last frame
                    projectile.frame = 0; //go back to the first frame
            }
            return true;
        }
    }
}