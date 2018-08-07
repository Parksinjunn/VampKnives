using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles
{
    public class NaniteProjectile : ModProjectile
    {
        public int tileCollide;
        public override void SetDefaults()
        {
            projectile.Name = "Nanites";
            projectile.width = 26;
            projectile.height = 26;
            projectile.scale = 0.7f;
            Main.projFrames[projectile.type] = 8;           //this is projectile frames
            projectile.friendly = true;
            projectile.penetrate = -1;                       //this is the projectile penetration
            projectile.magic = true;                        //this make the projectile do magic damage
            projectile.tileCollide = false;                 //this make that the projectile does not go thru walls
            projectile.ignoreWater = true;
            projectile.timeLeft = 600;
            //aiType = ProjectileID.DeadlySphere;
            projectile.aiStyle = 66;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];
                //If the npc is hostile
                if (target.friendly == false)
                {
                    //Get the shoot trajectory from the projectile and target
                    float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
                    float shootToY = target.position.Y - projectile.Center.Y;
                    float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

                    //If the distance between the live targeted npc and the projectile is less than 480 pixels
                    if (distance < 480f && !target.friendly && target.active && distance > 120)
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
            if (projectile.velocity.X == 0)
                projectile.velocity.X = Main.rand.Next(-4, 9);
            if (projectile.velocity.Y == 0)
                projectile.velocity.Y = Main.rand.Next(-3, 8);
            float distanceX = player.position.X - projectile.position.X;
            float distanceY = player.position.Y - projectile.position.Y;
            if (distanceX >= 800 || distanceY >= 800)
            {
                projectile.position.X = player.position.X;
                projectile.position.Y = player.position.Y;
            }
        }
        //public int healamnt;
        //public override void OnHitNPC(NPC n, int damage, float knockback, bool crit)
        //{
        //    Player owner = Main.player[projectile.owner];
        //    healamnt = healamnt + (int)(projectile.damage * .075);
        //    if (healamnt >= 1)
        //    {
        //        Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, 305, 0, projectile.knockBack); //Creates a new Projectile
        //        owner.statLife += healamnt; //Gives 7.5% of the damage dealt
        //        owner.HealEffect(healamnt, true); //Shows you have healed by that amount of health
        //        owner.statMana += healamnt; //Gives 7.5% of the damage dealt
        //        owner.ManaEffect(healamnt);
        //    }
        //    //n.AddBuff(BuffID.BUFFIDHERE, 300);
        //}
        public override bool PreDraw(SpriteBatch sb, Color lightColor) //this is where the animation happens
        {
            projectile.frameCounter++; //increase the frameCounter by one
            if (projectile.frameCounter >= 7) //once the frameCounter has reached 3 - change the 10 to change how fast the projectile animates
            {
                projectile.frame++; //go to the next frame
                projectile.frameCounter = 0; //reset the counter
                if (projectile.frame > 7) //if past the last frame
                    projectile.frame = 0; //go back to the first frame
            }
            return true;
        }
    }
}