using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace VampKnives.Projectiles
{
    public class HarpyProj : KnifeProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 40;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.hostile = false;
            projectile.tileCollide = true;                 //this make that the projectile does not go thru walls
            projectile.ignoreWater = false;
            projectile.timeLeft = 110;
        }
        public override void AI()
        {
            if (Main.rand.NextFloat() < 1f)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = Main.LocalPlayer.Center;
                dust = Main.dust[Terraria.Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width - 3, projectile.height - 3, 45, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 0, new Color(0, 255, 142), 0.8f)];
                dust.noGravity = false;
            }
            //this make that the projectile faces the right way 
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            projectile.localAI[0] += 1f;
            //projectile.light = .04f;
            //projectile.alpha = (int)(projectile.localAI[0] * 2);
        }

        public override void OnHitNPC(NPC n, int damage, float knockback, bool crit)
        {
            Player owner = Main.player[projectile.owner];
            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("HealProj"), (int)(projectile.damage * 0.75), 0, owner.whoAmI);

            for (int x = 0; x < 5; x++)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = Main.LocalPlayer.Center;
                dust = Main.dust[Terraria.Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width + 5, projectile.height + 5, 45, projectile.velocity.X * -0.2f, projectile.velocity.Y * -0.2f, 0, new Color(0, 255, 142), 2f)];
                dust.noGravity = true;
            }
            Hoods(n);
        }
    }
}