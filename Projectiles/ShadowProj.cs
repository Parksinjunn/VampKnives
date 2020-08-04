using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles
{
    public class ShadowProj : KnifeProjectile
    {
        public override void SafeSetDefaults()
        {
            projectile.Name = "Shadow Knives";
            projectile.width = 38;
            projectile.height = 38;
            projectile.friendly = true;
            projectile.penetrate = 6;                       //this is the projectile penetration
            Main.projFrames[projectile.type] = 4;           //this is projectile frames
            projectile.hostile = false;
            projectile.magic = true;                        //this make the projectile do magic damage
            projectile.tileCollide = true;                 //this make that the projectile does not go thru walls
            projectile.ignoreWater = true;
            projectile.timeLeft = 300;
            aiType = ProjectileID.BloodyMachete;
            projectile.aiStyle = 3;
        }

        public override void SafeAI()
        {
            //this is projectile dust
            int DustID2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width - 3, projectile.height - 3, 40, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 10, Color.Purple, 1f);
            Main.dust[DustID2].noGravity = true;
        }

        public override bool PreDraw(SpriteBatch sb, Color lightColor) //this is where the animation happens
        {
            projectile.frameCounter++; //increase the frameCounter by one
            if (projectile.frameCounter >= 3) //once the frameCounter has reached 3 - change the 10 to change how fast the projectile animates
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