using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles.Ammo
{
    public class ToothProj : KnifeProjectile
    {
        public int ran;
        public override void SetDefaults()
        {
            projectile.width = 26;
            projectile.height = 40;
            projectile.friendly = true;
            projectile.penetrate = 1;                       //this is the projectile penetration
            projectile.hostile = false;
            Main.projFrames[projectile.type] = 3;           //this is projectile frames
            projectile.tileCollide = true;                 //this make that the projectile does not go thru walls
            projectile.ignoreWater = false;
            projectile.scale = 0.55f;
            projectile.timeLeft = 300;
            ran = Main.rand.Next(0,3);
        }
        public override void AI()
        {
            //this is projectile dust
            //this make that the projectile faces the right way 
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            projectile.localAI[0] += 1f;

            if (ran == 0)
                projectile.frame = 0;
            if (ran == 1)
                projectile.frame = 1;
            if (ran == 2)
                projectile.frame = 2;
        }

        public override void OnHitNPC(NPC n, int damage, float knockback, bool crit)
        {
            Hoods(n);
        }
        public override void Kill(int timeLeft)
        {
            timeLeft = 60;
            base.Kill(timeLeft);
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Main.PlaySound(SoundID.Dig, (int)projectile.position.X, (int)projectile.position.Y, 1, 0.5f);
            projectile.tileCollide = false;
            projectile.timeLeft = 60;
            projectile.velocity *= new Vector2(0.002f, 0.002f);
            return true;
        }
    }
}