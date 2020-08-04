using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles
{
	public class VampiricPrismProj : KnifeProjectile
	{
		public override void SafeSetDefaults()
		{
			projectile.width = 18;
			projectile.height = 38;
            projectile.friendly = true;
            projectile.penetrate = 1;                       //this is the projectile penetration
            projectile.hostile = false;
			projectile.magic = true;                        //this make the projectile do magic damage
            projectile.tileCollide = true;                 //this make that the projectile does not go thru walls
			projectile.ignoreWater = true;
            projectile.timeLeft = 300;
          		}

		public override void AI()
		{
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            Lighting.AddLight(projectile.Center, 0.5f, 0, 0);
        }

        public override void OnHitNPC(NPC n, int damage, float knockback, bool crit)
        {
            Player owner = Main.player[projectile.owner];
            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("HealProj"), (int)(projectile.damage * 0.55), 0, owner.whoAmI);
            Hoods(n);
        }
    }
}