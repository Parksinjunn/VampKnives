using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles
{
	public class PlagueWasp : KnifeProjectile
	{
		public override void SafeSetDefaults()
		{
			projectile.Name = "Plague Wasp";
            projectile.friendly = true;
            projectile.penetrate = -1;                      
            projectile.hostile = false;
			projectile.magic = true;
            projectile.tileCollide = true;
			projectile.ignoreWater = true;
            projectile.timeLeft = 300;
            //projectile.CloneDefaults(ProjectileID.Bee);
            //projectile.aiStyle = ProjectileID.Bee;
            projectile.width = 34;
            projectile.height = 34;
            Main.projFrames[projectile.type] = 6;       
        }

        public override void SafeAI()
        {
            for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];
                //If the npc is hostile
                if (!target.friendly)
                {
                    //Get the shoot trajectory from the projectile and target
                    float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
                    float shootToY = target.position.Y - projectile.Center.Y;
                    float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

                    //If the distance between the live targeted npc and the projectile is less than 480 pixels
                    if (distance < 800f && !target.friendly && target.active)
                    {
                        //Divide the factor, 3f, which is the desired velocity
                        distance = 3f / distance;

                        //Multiply the distance by a multiplier if you wish the projectile to have go faster
                        shootToX *= distance * 5;
                        shootToY *= distance * 5;

                        //Set the velocities to the shoot values
                        projectile.velocity.X = shootToX;
                        projectile.velocity.Y = shootToY;
                    }
                }
            }
        }
        public override void SafeOnHitNPC(NPC n, int damage, float knockback, bool crit)
        {
            Mod Calamity = ModLoader.GetMod("CalamityMod");
            n.AddBuff(20, 600);
            if (Calamity != null)
                n.AddBuff(Calamity.BuffType("Plague"), 600); //poisoned 10        
        }

        public override bool SafeOnTileCollide(Vector2 OldVelocity)
        {
            projectile.velocity *= -1;
            return false;
        }

        public override bool PreDraw(SpriteBatch sb, Color lightColor) //this is where the animation happens
        {
            projectile.frameCounter++; //increase the frameCounter by one
            if (projectile.frameCounter >= 5) //once the frameCounter has reached 3 - change the 10 to change how fast the projectile animates
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