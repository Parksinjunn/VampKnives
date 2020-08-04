using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles
{
    public class WrathfulStarProj : KnifeProjectile
    {
        public override void SafeSetDefaults()
        {
            projectile.width = 64;
            projectile.height = 64;
            projectile.friendly = true;
            projectile.penetrate = 1;                       //this is the projectile penetration
            projectile.hostile = false;
            projectile.magic = true;                        //this make the projectile do magic damage
            projectile.tileCollide = true;                 //this make that the projectile does not go thru walls
            projectile.ignoreWater = false;
            projectile.timeLeft = 300;
            projectile.scale = 0.6f;
        }
        int SpriteRotation = 45;
        public override void SafeAI()
        {

            if (projectile.soundDelay == 0)
            {
                projectile.soundDelay = 20 + Main.rand.Next(40);
                Main.PlaySound(SoundID.Item9, projectile.position);
            }
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(SpriteRotation); // projectile faces sprite right
            //Lighting.AddLight(projectile.Center, 0.8f, 0.8f, 0.8f);
            //int DustID2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width - 3, projectile.height - 3, 60, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 10, new Color(184, 0, 255), 0.75f);
            //Main.dust[DustID2].noGravity = true;

            if (Main.rand.Next(16) == 0)
            {
                Vector2 value3 = Vector2.UnitX.RotatedByRandom(1.5707963705062866).RotatedBy((double)projectile.velocity.ToRotation(), default(Vector2));
                int num66 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 58, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f, 150, default(Color), 1.2f);
                Main.dust[num66].velocity = value3 * 0.66f;
                Main.dust[num66].position = projectile.Center + value3 * 12f;
            }
            if (Main.rand.Next(48) == 0)
            {
                int num67 = Gore.NewGore(projectile.Center, new Vector2(projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f), 16, 1f);
                Gore gore = Main.gore[num67];
                gore.velocity *= 0.66f;
                gore = Main.gore[num67];
                gore.velocity += projectile.velocity * 0.3f;
            }
        }
        public override void Kill(int timeLeft)
        {
            for (int num540 = 0; num540 < 10; num540++)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, 58, projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 150, default(Color), 1.2f);
            }
            Main.PlaySound(SoundID.Item10.WithVolume(.15f), projectile.position);
            Gore.NewGore(projectile.position, new Vector2(projectile.velocity.X * 0.05f, projectile.velocity.Y * 0.05f), 16, 1f);
        }
    }
}