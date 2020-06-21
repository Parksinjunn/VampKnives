using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles
{
    public class TerraKnivesProj : KnifeProjectile
    {
        bool HitTile;
        float VelocityFactor = 2f;
        int EffectTimer;

        public override void SafeSetDefaults()
        {
            projectile.width = 22;
            projectile.height = 64;
            projectile.friendly = true;
            projectile.penetrate = 1;                       //this is the projectile penetration
            projectile.hostile = false;
            projectile.magic = true;                        //this make the projectile do magic damage
            projectile.tileCollide = true;                 //this make that the projectile does not go thru walls
            projectile.ignoreWater = true;
            projectile.timeLeft = 300;
            projectile.scale = 0.7f;
        }

        public override void AI()
        {
            projectile.localAI[0] += 1f;
            //this make that the projectile faces the right way 
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            Lighting.AddLight(projectile.Center, 0, (Main.DiscoG / 255f), 0);
            if (HitTile)
            {
                for (int iteration = 0; iteration < 360; iteration++)
                {
                    int DustID3 = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), 1, 1, 15, 0f, 0f, 10, new Color(0,255,0), 2f);
                    Main.dust[DustID3].noGravity = true;
                    Main.dust[DustID3].velocity = new Vector2(VelocityFactor * (float)Math.Cos(iteration / VelocityFactor), VelocityFactor * (float)Math.Sin(iteration / VelocityFactor));
                }
                HitTile = false;
                EffectTimer++;
            }
        }
        public override bool PreKill(int timeLeft)
        {
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X, projectile.velocity.Y, 132, projectile.damage / 2, projectile.knockBack, projectile.owner); //Creates a new Projectile
            return base.PreKill(timeLeft); ;
        }
        public override void OnHitNPC(NPC n, int damage, float knockback, bool crit)
        {
            Player owner = Main.player[projectile.owner];
                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("HealProj"), (int)(projectile.damage * 0.75), 0, owner.whoAmI);

            Hoods(n);
        }
        public override bool SafeOnTileCollide(Vector2 oldVelocity)
        {
            HitTile = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.velocity = oldVelocity;
            projectile.timeLeft = 10;
            return false;
        }
    }
}