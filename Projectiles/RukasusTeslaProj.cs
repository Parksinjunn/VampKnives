using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles
{
    public class RukasusTeslaProj : KnifeProjectile
    {
        public override void SafeSetDefaults()
        {
            projectile.Name = "Rukasus Tesla";
            projectile.width = 14;
            projectile.height = 32;
            projectile.friendly = true;
            projectile.penetrate = 1;                       //this is the projectile penetration
            Main.projFrames[projectile.type] = 4;           //this is projectile frames
            projectile.hostile = false;
            projectile.magic = true;                        //this make the projectile do magic damage
            projectile.tileCollide = true;                 //this make that the projectile does not go thru walls
            projectile.ignoreWater = false;
            projectile.timeLeft = 300;
        }

        public override void SafeAI()
        {
            //this is projectile dust
            int DustID2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width - 3, projectile.height - 3, 20, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 10, Color.LightBlue, 0.5f);
            Main.dust[DustID2].noGravity = false;
            //this make that the projectile faces the right way 
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            projectile.localAI[0] += 1f;
            //projectile.light = .04f;
            //projectile.alpha = (int)projectile.localAI[0] * 2;

        }

        public override void SafeOnHitNPC(NPC n, int damage, float knockback, bool crit)
        {
            n.AddBuff(BuffID.Electrified, 240);

            int speedX = 15;
            int speedY = 15;
            int numProjectiles2 = 18;
            Random random = new Random();
            int ran = random.Next(320, 360);
            float spread = MathHelper.ToRadians(ran);
            float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
            double startAngle = Math.Atan2(speedX, speedY) - spread / 2;
            double deltaAngle = spread / (float)numProjectiles2;
            double offsetAngle;

            for (int j = 0; j < numProjectiles2; j++)
            {
                offsetAngle = startAngle + deltaAngle * j;
                Projectile.NewProjectile(n.position.X, n.position.Y, baseSpeed * (float)Math.Sin(offsetAngle), baseSpeed * (float)Math.Cos(offsetAngle), mod.ProjectileType("RukasusTeslaProj"), 15, 1);
            }
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