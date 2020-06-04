using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles.Ammo
{
    public abstract class AmmoProjectile : KnifeProjectile
    {
        public float ArmorPiercingMult = 1f;
        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 34;
            projectile.friendly = true;
            projectile.penetrate = 3;                       //this is the projectile penetration
            projectile.hostile = false;
            projectile.tileCollide = true;                 //this make that the projectile does not go thru walls
            projectile.ignoreWater = false;
            projectile.timeLeft = 300;
        }
        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            projectile.localAI[0] += 1f;
            //projectile.light = .04f;
            //projectile.alpha = (int)projectile.localAI[0] * 2;
        }

        public override void OnHitNPC(NPC n, int damage, float knockback, bool crit)
        {
            //Main.NewText("Defense 1: " + n.defense);
            Hoods(n);
            if(VampKnives.Normal || VampKnives.Legacy)
            {
                n.defense = (int)(n.defense / (1.05f * ArmorPiercingMult));
            }
            if(VampKnives.Unforgiving)
            {
                n.defense = (int)(n.defense / (1.00001f));
            }
            //Main.NewText("Defense 2: " + n.defense);
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Main.PlaySound(SoundID.Tink, (int)projectile.position.X, (int)projectile.position.Y, 1, 0.5f);
            int DustID2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width - 3, projectile.height - 3, 1, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 10, Color.Gray, 1f);
            return true;
        }
    }
}