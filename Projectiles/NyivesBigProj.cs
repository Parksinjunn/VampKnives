using Microsoft.Xna.Framework;
using Terraria;
using System.Collections.Generic;

namespace VampKnives.Projectiles
{
    public class NyivesBigProj : KnifeProjectile
    {
        bool HitTile;
        bool HasDoneEffect;
        float VelocityFactor = 2f;
        int HitCount;

        public override void SafeSetDefaults()
        {
            projectile.width = 48;
            projectile.height = 48;
            projectile.friendly = true;
            projectile.penetrate = 1;                       //this is the projectile penetration
            projectile.hostile = false;
            projectile.magic = true;                        //this make the projectile do magic damage
            projectile.tileCollide = true;                 //this make that the projectile does not go thru walls
            projectile.ignoreWater = true;
            projectile.timeLeft = 300;
            projectile.scale = 0.8f;
        }
        int SpriteRotation = 45;

        public override void DrawBehind(int index, List<int> drawCacheProjsBehindNPCsAndTiles, List<int> drawCacheProjsBehindNPCs, List<int> drawCacheProjsBehindProjectiles, List<int> drawCacheProjsOverWiresUI)
        {
            if (HitTile) 
            {      
                drawCacheProjsBehindNPCsAndTiles.Add(index);
                return;
            }
        }

        public override void SafeAI()
        {
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(SpriteRotation); // projectile faces sprite right
            Lighting.AddLight(projectile.Center, (Main.DiscoR / 255f), (Main.DiscoG / 255f), (Main.DiscoB / 255f));
            if (HitTile)
            {
                projectile.velocity = projectile.velocity * 0.55f;
                if (HasDoneEffect == false)
                {
                    HasDoneEffect = true;
                    for (int i = 0; i < 10; i++)
                    {
                        int DustID2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width - 3, projectile.height - 3, 1, projectile.velocity.X * 0.2f, projectile.velocity.Y * -0.2f, 10, Color.Gray, 1f);
                    }
                }
            }
            if(HitCount > 10)
            {
                projectile.Kill();
            }
        }
        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            projectile.penetrate++;
            HitCount++;
        }
        public override void OnHitNPC(NPC n, int damage, float knockback, bool crit)
        {
            Player owner = Main.player[projectile.owner];
            if (HitCount == 1)
            {
                if (Main.rand.Next(0, HealProjChanceScale) <= HealProjChance)
                {
                    Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("HealProj"), (int)(projectile.damage * 0.75), 0, owner.whoAmI);
                }
                Hoods(n);
            }
        }
        public override bool SafeOnTileCollide(Vector2 oldVelocity)
        {
                HitTile = true;
                projectile.hide = true;
                projectile.penetrate = 1;
                projectile.tileCollide = false;
                projectile.velocity = oldVelocity;
                projectile.timeLeft = 90;
            return false;
        }
    }
}