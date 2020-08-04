using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles
{
    public class BloomingTerrorSeed : KnifeProjectile
    {
        public override void SafeSetDefaults()
        {
            projectile.Name = "Terror Seed";
            projectile.width = 28;
            projectile.height = 28;
            projectile.scale = 0.7f;
            projectile.friendly = true;
            projectile.penetrate = -1;                       //this is the projectile penetration
            projectile.magic = true;                        //this make the projectile do magic damage
            projectile.tileCollide = true;                 //this make that the projectile does not go thru walls
            projectile.ignoreWater = true;
            projectile.timeLeft = 600;
            aiType = ProjectileID.ThornBall;
            projectile.aiStyle = 14;
        }

        public override void AI()
        {
            //this is projectile dust
            //this make that the projectile faces the right way 
            //projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            projectile.localAI[0] += 1f;
            //projectile.light = .04f;
            //projectile.alpha = (int)projectile.localAI[0] * 2;
        }
    }
}