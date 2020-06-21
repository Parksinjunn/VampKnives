using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles
{
    public class ManaHeal : KnifeProjectile
    {
        public override void SetDefaults()
        {
            projectile.Name = "Mana Healing";
            projectile.width = 2;
            projectile.height = 2;
            projectile.friendly = false;
            projectile.penetrate = 1;                       //this is the projectile penetration
            projectile.hostile = false;
            projectile.magic = true;                        //this make the projectile do magic damage
            projectile.tileCollide = false;                 //this make that the projectile does not go thru walls
            projectile.ignoreWater = true;
            projectile.timeLeft = 300;
        }

        public override void AI()
        {
            //this is projectile dust
                Dust dust;
                dust = Terraria.Dust.NewDustPerfect(new Vector2(projectile.position.X, projectile.position.Y), 135, new Vector2(projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f), 10, new Color(255, 0, 0), 2.5f);
                dust.noGravity = true;

            int DustID2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width - 3, projectile.height - 3, 135, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 255, Color.LightBlue, 2.5f);
            Main.dust[DustID2].noGravity = true;
            //this make that the projectile faces the right way 
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            projectile.localAI[0] += 1f;
            //projectile.light = .04f;
            //projectile.alpha = (int)projectile.localAI[0] * 2;

            for (int i = 0; i < 200; i++)
            {
                Player owner = Main.player[projectile.owner];
                //Get the shoot trajectory from the projectile and target
                float shootToX = owner.position.X + (float)owner.width * 0.5f - projectile.Center.X;
                float shootToY = owner.position.Y - projectile.Center.Y;
                float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

                //If the distance between the live targeted player and the projectile is less than 480 pixels
                if (distance < 2000f && owner.active)
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
                float distanceX = owner.position.X - projectile.position.X;
                float distanceY = owner.position.Y - projectile.position.Y;
                if (distance < 50f && projectile.position.X < owner.position.X + owner.width && projectile.position.X + projectile.width > owner.position.X && projectile.position.Y < owner.position.Y + owner.height && projectile.position.Y + projectile.height > owner.position.Y)
                {
                    owner.statMana += projectile.damage;
                    owner.ManaEffect(projectile.damage);
                    projectile.Kill();
                    break;
                }
            }
        }
    }
}
//For all of the NPC slots in Main.npc
//Note, you can replace NPC with other entities such as Projectiles and Players
