using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles
{
	public class HallowedGauntletProj : KnifeProjectile
	{
        float VelocityFactor = 1f;
        bool HitTile;
        bool HealedSpawned=false;
        int EffectTimer;

		public override void SafeSetDefaults()
		{
			projectile.width = 18;
			projectile.height = 54;
            projectile.friendly = true;
            projectile.penetrate = 3;                       //this is the projectile penetration
            projectile.hostile = false;
			projectile.magic = true;                        //this make the projectile do magic damage
            projectile.tileCollide = true;                 //this make that the projectile does not go thru walls
			projectile.ignoreWater = true;
            projectile.timeLeft = 300;
            projectile.scale = 0.7f;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 40;
        }

		public override void AI()
		{
            Player owner = Main.player[projectile.owner];
            //this is projectile dust
            int DustID2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width-3, projectile.height-3, 15, 0f, 0f, 10, Color.White, 1f);
            Main.dust[DustID2].noGravity = true;
                                                          //this make that the projectile faces the right way 
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            projectile.localAI[0] += 1f;
            if(HitTile)
            {
                    for (int iteration = 0; iteration < 360; iteration++)
                    {
                        int DustID3 = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), 1, 1, 15, 0f, 0f, 10, Color.White, 2f);
                        Main.dust[DustID3].noGravity = true;
                        Main.dust[DustID3].velocity = new Vector2(VelocityFactor * (float)Math.Cos(iteration / VelocityFactor), VelocityFactor * (float)Math.Sin(iteration / VelocityFactor));
                    }
                    HitTile = false;
                EffectTimer++;
            }
            if(HealedSpawned == false)
            {
                Rectangle rectangle4 = new Rectangle((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height);
                for (int NPCDist = 0; NPCDist < Main.maxNPCs; NPCDist++)
                {
                    if (Main.npc[NPCDist].active && !Main.npc[NPCDist].dontTakeDamage && !Main.npc[NPCDist].friendly)
                    {
                        Rectangle value11 = new Rectangle((int)Main.npc[NPCDist].position.X, (int)Main.npc[NPCDist].position.Y, Main.npc[NPCDist].width, Main.npc[NPCDist].height);
                        if (rectangle4.Intersects(value11))
                        {
                            if (rectangle4.Intersects(value11))
                            {
                                Projectile.NewProjectile(Main.npc[NPCDist].Center.X, Main.npc[NPCDist].Center.Y, 0, 0, mod.ProjectileType("HallowedStealProj"), (int)(projectile.damage * 0.75), 0, owner.whoAmI);
                                HealedSpawned = true;
                            }
                        }
                    }
                }
            }        
        }

        public override void OnHitNPC(NPC n, int damage, float knockback, bool crit)
        {
            Hoods(n);
        }
        public override bool SafePreKill(int timeLeft)
        {
            if (Main.rand.Next(1, 10) == 6)
            {
                Player owner = Main.player[projectile.owner];
                for (int NumPieces = 0; NumPieces < Main.rand.Next(1, 3); NumPieces++)
                {
                    Projectile.NewProjectile(projectile.position, new Vector2(Main.rand.NextFloat(-1.5f, 1.5f), Main.rand.NextFloat(-1.5f, 1.5f)), ModContent.ProjectileType<HallowedGauntletShatteredProj>(), 3 + Main.rand.Next(0, 5), 0f, owner.whoAmI);
                }
            }
            else
            {
                for (int iteration = 0; iteration < 3; iteration++)
                {
                    int Angle = Main.rand.Next(1, 361);
                    int DustVelocity = 5;
                    int DustID3 = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), 1, 1, 15, 0f, 0f, 10, Color.White, 2f);
                    Main.dust[DustID3].noGravity = true;
                    Main.dust[DustID3].velocity = new Vector2(DustVelocity * (float)Math.Cos(Angle / DustVelocity), DustVelocity * (float)Math.Sin(Angle / DustVelocity));
                }
            }
            return base.SafePreKill(timeLeft);
        }
        public override bool SafeOnTileCollide(Vector2 oldVelocity)
        {
            if(Main.rand.Next(1,6) == 3)
            {
                HitTile = true;
                projectile.penetrate = -1;
                projectile.tileCollide = false;
                projectile.velocity = oldVelocity;
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}