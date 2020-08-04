using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles
{
    public class StarfuryKnivesProj : KnifeProjectile
    {
        public override void SafeSetDefaults()
        {
            projectile.width = 34;
            projectile.height = 34;
            projectile.friendly = true;
            projectile.penetrate = 1;                       //this is the projectile penetration
            projectile.hostile = false;
            projectile.magic = true;                        //this make the projectile do magic damage
            projectile.tileCollide = false;                 //this make that the projectile does not go thru walls
            projectile.ignoreWater = false;
            projectile.timeLeft = 300;
        }
        int SpriteRotation = 45;
        public override void SafeAI()
        {
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(SpriteRotation); // projectile faces sprite right
            Lighting.AddLight(projectile.Center, 0.2f, 0, 0);
            projectile.alpha = 65;
            int DustID2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width - 3, projectile.height - 3, 60, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 10, new Color(184, 0, 255), 0.75f);
            Main.dust[DustID2].noGravity = true;

            if (projectile.ai[1] == 0f && !Collision.SolidCollision(projectile.position, projectile.width, projectile.height))
            {
                projectile.ai[1] = 1f;
                projectile.netUpdate = true;
            }
            if (projectile.ai[1] != 0f)
            {
                projectile.tileCollide = true;
            }
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item10.WithVolume(.15f), projectile.position);
        }
        public override bool SafeOnTileCollide(Vector2 oldVelocity)
        {
            //Main.PlaySound(SoundID.Tink, (int)projectile.position.X, (int)projectile.position.Y, 1, 0.5f);
            for (int x = 0; x < 7; x++)
            {
                int DustID2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width - 3, projectile.height - 3, 60, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 10, new Color(184, 0, 255), 1.25f);
                Main.dust[DustID2].noGravity = true;
            }
            return true;
        }
    }
}