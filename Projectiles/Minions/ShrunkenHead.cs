using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles.Minions
{
    public class ShrunkenHead : ModProjectile
    {
        public int tileCollide;
        public override void SetDefaults()
        {
            projectile.Name = "Nanites";
            projectile.width = 36;
            projectile.height = 48;
            projectile.scale = 0.7f;
            Main.projFrames[projectile.type] = 4;           //this is projectile frames
            projectile.friendly = true;
            projectile.penetrate = -1;                       //this is the projectile penetration
            projectile.magic = true;                        //this make the projectile do magic damage
            projectile.tileCollide = false;                 //this make that the projectile does not go thru walls
            projectile.ignoreWater = true;
            //aiType = ProjectileID.DeadlySphere;
            //projectile.aiStyle = 66;
        }

        public int delay;
        //Note, you can use this with an NPC to shoot at a Player also
        //For every npc slot in Main.npc
        public override void AI()
        {
            delay++;
            Player player = Main.player[projectile.owner];
            ExamplePlayer modPlayer = player.GetModPlayer<ExamplePlayer>(mod);
            if (delay >= 40)
            {
                delay = 0;
                for (int i = 0; i < 200; i++)
                {
                    //Enemy NPC variable being set
                    NPC target = Main.npc[i];

                    //Getting the shooting trajectory
                    float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
                    float shootToY = target.position.Y - projectile.Center.Y;
                    float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

                    //If the distance between the projectile and the live target is active
                    if (distance < 480f && !target.friendly && target.active)
                    {
                        if (projectile.ai[0] > 4f) //Assuming you are already incrementing this in AI outside of for loop
                        {
                            //Dividing the factor of 3f which is the desired velocity by distance
                            distance = 3f / distance;

                            //Multiplying the shoot trajectory with distance times a multiplier if you so choose to
                            shootToX *= distance * 5;
                            shootToY *= distance * 5;

                            //Shoot projectile and set ai back to 0
                            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, shootToX, shootToY, mod.ProjectileType("ShrunkenHeadProj"), 50, 0, Main.myPlayer, 0f, 0f); //Spawning a projectile
                            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 11); //Bullet noise
                            projectile.ai[0] = 0f;
                        }
                    }
                }
            }
            float RightBound = player.position.X + 50;
            float LeftBound = player.position.X - 50;
            float UpperBound = player.position.Y - player.height - 10;
            float LowerBound = player.position.Y - player.height + 7;
            float shootToX2 = player.position.X + (float)player.width * 0.5f - projectile.Center.X;
            float shootToY2 = player.position.Y - projectile.Center.Y;
            float distance2 = (float)System.Math.Sqrt((double)(shootToX2 * shootToX2 + shootToY2 * shootToY2));
            if (projectile.position.X >= RightBound)
                projectile.velocity.X = -1f;
            if (projectile.position.X <= LeftBound)
                projectile.velocity.X = 1f;
            if (projectile.position.Y <= UpperBound)
                projectile.velocity.Y = 0.5f;
            if (projectile.position.Y >= LowerBound)
                projectile.velocity.Y = -0.5f;
            if (distance2 > 100)
            {
                projectile.velocity.X = player.velocity.X;
                projectile.velocity.Y = player.velocity.Y;
            }
            if (projectile.velocity.X == 0 && projectile.position.X >= RightBound)
                projectile.velocity.X = -0.5f;
            if (projectile.velocity.X == 0 && projectile.position.X <= LeftBound)
                projectile.velocity.X = 0.5f;
            projectile.ai[0] += 1f;
            if (player.dead)
            {
                modPlayer.ShrunkenHead = false;
            }
            //if (modPlayer.ShrunkenHead == false)
            //{
            //    projectile.alpha += 20;
            //    projectile.timeLeft = 60;
            //}
            if(modPlayer.ShrunkenHead)
            {
                projectile.timeLeft = 2;
            }
        }
        public override bool PreDraw(SpriteBatch sb, Color lightColor) //this is where the animation happens
        {
            projectile.frameCounter++; //increase the frameCounter by one
            if (projectile.frameCounter >= 20) //once the frameCounter has reached 3 - change the 10 to change how fast the projectile animates
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