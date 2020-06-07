using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles
{
    public class MandibleSummonProj : KnifeProjectile
    {
        public int tileCollide;
        public override void SafeSetDefaults()
        {
            projectile.Name = "buggzy";
            projectile.width = 40;
            projectile.height = 62;
            projectile.scale = 0.5f;
            Main.projFrames[projectile.type] = 6;           //this is projectile frames
            projectile.friendly = true;
            projectile.penetrate = -1;                       //this is the projectile penetration
            projectile.magic = true;                        //this make the projectile do magic damage
            projectile.tileCollide = false;                 //this make that the projectile does not go thru walls
            projectile.ignoreWater = true;
            projectile.timeLeft = 600;
            //aiType = ProjectileID.DeadlySphere;
            //projectile.aiStyle = 66;
        }
        public bool hit = false;
        float velocityXStored;
        float velocityYStored;
        float distance;
        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            if (hit == false)
            {
                int ran1 = Main.rand.Next(50,201);
                int ran2 = ran1 - 49;
                for (int i = ran2; i < ran1; i++)
                {

                    projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
                    NPC target = Main.npc[i];
                    //If the npc is hostile
                    if (target.friendly == false)
                    {
                        //Get the shoot trajectory from the projectile and target
                        float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
                        float shootToY = target.position.Y - projectile.Center.Y;
                        distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

                        //If the distance between the live targeted npc and the projectile is less than 480 pixels
                        if (distance < 500f && !target.friendly && target.active && distance >= target.width / 2)
                        {
                            if (distance < target.width / 2)
                                goto hitNPC;
                            //Divide the factor, 3f, which is the desired velocity
                            distance = 3f / distance;

                            //Multiply the distance by a multiplier if you wish the projectile to have go faster
                            shootToX *= distance * 5;
                            shootToY *= distance * 5;

                            //Set the velocities to the shoot values
                            projectile.velocity.X = shootToX;
                            projectile.velocity.Y = shootToY;
                            velocityXStored = projectile.velocity.X;
                            velocityYStored = projectile.velocity.Y;
                        }
                    }
                }
            }
            hitNPC:
            if (hit == true)
            {
                projectile.velocity.X = velocityXStored;
                projectile.velocity.Y = Math.Abs(velocityYStored) * -1;
                projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            }
            if (projectile.velocity.Y == 0)
                projectile.velocity.Y = -25;
        }
        //public int healamnt;
        public override void OnHitNPC(NPC n, int damage, float knockback, bool crit)
        {
            hit = true;
            projectile.velocity.X = velocityXStored;
            projectile.velocity.Y = Math.Abs(velocityYStored) * -1;
        }
        public override bool PreDraw(SpriteBatch sb, Color lightColor) //this is where the animation happens
        {
            projectile.frameCounter++; //increase the frameCounter by one
            if (projectile.frameCounter >= 20) //once the frameCounter has reached 3 - change the 10 to change how fast the projectile animates
            {
                projectile.frame++; //go to the next frame
                projectile.frameCounter = 0; //reset the counter
                if (projectile.frame > 5) //if past the last frame
                    projectile.frame = 0; //go back to the first frame
            }
            return true;
        }
    }
}