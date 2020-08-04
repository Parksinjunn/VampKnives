using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles
{
    public class TrueExcaliburProj : KnifeProjectile
    {
        public override void SafeSetDefaults()
        {
            projectile.width = 22;
            projectile.height = 64;
            projectile.friendly = true;
            projectile.penetrate = 1;                       //this is the projectile penetration
            projectile.hostile = false;
            projectile.magic = true;                        //this make the projectile do magic damage
            projectile.tileCollide = false;                 //this make that the projectile does not go thru walls
            projectile.ignoreWater = true;
            projectile.timeLeft = 300;
        }

        public override void SafeAI()
        {
            //this make that the projectile faces the right way 
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            Lighting.AddLight(projectile.Center, (Main.DiscoR / 255f), (Main.DiscoG / 255f), (Main.DiscoB / 255f));
        }

        public override bool SafePreKill(int timeLeft)
        {
            if (projectile.velocity.X == 0 && projectile.velocity.Y == 0)
            {
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, Main.rand.NextFloat(-20f, 20f), Main.rand.NextFloat(-20f, 20f), 156, projectile.damage / 2, projectile.knockBack, projectile.owner); //Creates a new Projectile
            }
            else
                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, projectile.velocity.X, projectile.velocity.Y, 156, projectile.damage / 2, projectile.knockBack, projectile.owner); //Creates a new Projectile
            return base.SafePreKill(timeLeft); ;
        }
    }
}