using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles
{
    public class DaedalusStormbladesProj : KnifeProjectile
    {
        public override void SafeSetDefaults()
        {
            projectile.width = 26;
            projectile.height = 54;
            projectile.friendly = true;
            projectile.penetrate = 1;                       //this is the projectile penetration
            projectile.hostile = false;
            projectile.magic = true;                        //this make the projectile do magic damage
            projectile.tileCollide = false;                 //this make that the projectile does not go thru walls
            projectile.ignoreWater = false;
            projectile.timeLeft = 300;
        }
        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            Lighting.AddLight(projectile.Center, 0.05f, 0.1f, 0.2f);
            projectile.alpha = 65;
            int DustID2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width - 3, projectile.height - 3, 15, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 10, Color.White, 1f);
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
            Main.PlaySound(SoundID.Item10.WithVolume(.05f), projectile.position);
            if(DefenseKnivesProj.ProjCount.GetLightningActiveCount() <= 1)
            {
                if (Main.raining)
                {
                    if (Main.rand.Next(1, 101) >= 95)
                    {
                        Player owner = Main.player[projectile.owner];
                        Projectile.NewProjectile(projectile.position.X, projectile.position.Y - 390, 0, 20f, mod.ProjectileType("LightningProj"), (int)(projectile.damage * 0.65), 0, owner.whoAmI);
                        DefenseKnivesProj.ProjCount.LightningActiveCount += 1;
                    }
                }
                else
                {
                    if (Main.rand.Next(1, 101) == 50)
                    {
                        Player owner = Main.player[projectile.owner];
                        Projectile.NewProjectile(projectile.position.X, projectile.position.Y - 390, 0, 20f, mod.ProjectileType("LightningProj"), (int)(projectile.damage * 0.45), 0, owner.whoAmI);
                        DefenseKnivesProj.ProjCount.LightningActiveCount += 1;
                    }
                }
            }
        }
        public override void OnHitNPC(NPC n, int damage, float knockback, bool crit)
        {
            Player owner = Main.player[projectile.owner];
            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("HealProj"), (int)(projectile.damage * 0.75), 0, owner.whoAmI);
            Hoods(n);
        }
        public override bool SafeOnTileCollide(Vector2 oldVelocity)
        {
            //Main.PlaySound(SoundID.Tink, (int)projectile.position.X, (int)projectile.position.Y, 1, 0.5f);
            for (int x = 0; x < 7; x++)
            {
                int DustID2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width - 3, projectile.height - 3, 15, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 10, Color.White, 0.75f);
                Main.dust[DustID2].noGravity = true;
            }
            return true;
        }
    }
}