using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles
{
    public class ExcaliburProj : KnifeProjectile
    {
        public override void SafeSetDefaults()
        {
            projectile.width = 38;
            projectile.height = 38;
            projectile.friendly = true;
            projectile.penetrate = 1;                       //this is the projectile penetration
            projectile.hostile = false;
            projectile.magic = true;                        //this make the projectile do magic damage
            projectile.tileCollide = true;                 //this make that the projectile does not go thru walls
            projectile.ignoreWater = true;
            projectile.timeLeft = 300;
        }
        int SpriteRotation = 45;
        public override void SafeAI()
        {
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(SpriteRotation); // projectile faces sprite right
        }
    }
}