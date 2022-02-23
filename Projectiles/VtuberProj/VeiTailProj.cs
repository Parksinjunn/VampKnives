using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles.VtuberProj
{
    public class VeiTailProj : KnifeProjectile
    {
        bool IsLatched;
        int LatchTarget;
        public override void SafeSetDefaults()
        {
            projectile.width = 18;
            projectile.height = 36;
            projectile.friendly = true;
            projectile.penetrate = -1;                       //this is the projectile penetration
            projectile.hostile = false;
            projectile.magic = true;                        //this make the projectile do magic damage
            projectile.tileCollide = true;                 //this make that the projectile does not go thru walls
            projectile.ignoreWater = true;
            projectile.timeLeft = 300;
            projectile.aiStyle = 13;
        }
        public override void AI()
        {
            if (IsLatched)
            {
                Main.npc[LatchTarget].AddBuff(ModContent.BuffType<Buffs.VTuberBuffs.Latched>(), 90);
                Vector2 vector31 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
                float DistX = Main.player[projectile.owner].Center.X - vector31.X;
                float DistY = Main.player[projectile.owner].Center.Y - vector31.Y;
                float Distance = (float)Math.Sqrt((double)(DistX * DistX + DistY * DistY));
                if (Distance > 40f)
                {
                    Main.npc[LatchTarget].position = projectile.position;
                }
                else
                {
                    IsLatched = false;
                }
            }
            base.AI();
        }
        public override void SafeOnHitNPC(NPC n, int damage, float knockback, bool crit)
        {
            if (IsLatched == false && !n.boss)
            {
                IsLatched = true;
                LatchTarget = n.whoAmI;
                n.GetGlobalNPC<NPCs.MyGlobalNPC>().FallDamage = 0;
            }
        }
        public override void SafeModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            damage = 69;
        }
        public override bool PreDrawExtras(SpriteBatch spriteBatch)
        {
            Vector2 playerCenter = Main.player[projectile.owner].MountedCenter;
            Vector2 center = projectile.Center;
            Vector2 distToProj = playerCenter - projectile.Center;
            float projRotation = distToProj.ToRotation() - 1.57f;
            float distance = distToProj.Length();
            while (distance > 30f && !float.IsNaN(distance))
            {
                distToProj.Normalize();                 //get unit vector
                distToProj *= 24f;                      //speed = 24
                center += distToProj;                   //update draw position
                distToProj = playerCenter - center;    //update distance
                distance = distToProj.Length();

                //Draw chain
                spriteBatch.Draw(mod.GetTexture("Projectiles/VtuberProj/VeiTailProj_Chain"), new Vector2(center.X - Main.screenPosition.X, center.Y - Main.screenPosition.Y),
                    new Rectangle(0, 0, 18, 36), Color.DimGray, projRotation,
                    new Vector2(18/2, 36/2), 1f, SpriteEffects.None, 0f);
            }
            return false;
        }
    }
}