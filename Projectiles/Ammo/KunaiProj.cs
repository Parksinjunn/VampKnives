using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles.Ammo
{
    public class KunaiProj : AmmoProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 32;
            projectile.friendly = true;
            projectile.penetrate = 1;                       //this is the projectile penetration
            projectile.hostile = false;
            projectile.scale = 0.5f;
            projectile.tileCollide = true;                 //this make that the projectile does not go thru walls
            projectile.ignoreWater = false;
            projectile.timeLeft = 300;
            ArmorPiercingMult = 1.1f;
        }
        public float rotate = 20;
        public override void AI()
        {
            rotate -= 0.008f;
            projectile.rotation += rotate;
            projectile.localAI[0] += 1f;
            //projectile.light = .04f;
            //projectile.alpha = (int)projectile.localAI[0] * 2;
        }
    }
}