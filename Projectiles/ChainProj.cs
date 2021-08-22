using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles
{
    public class ChainProj : KnifeProjectile
    {
        public override void SafeSetDefaults()
        {
            projectile.width = 22;
            projectile.height = 32;
            projectile.friendly = true;
            projectile.penetrate = 6;                       //this is the projectile penetration
            projectile.hostile = false;
            projectile.magic = true;                        //this make the projectile do magic damage
            projectile.tileCollide = true;                 //this make that the projectile does not go thru walls
            projectile.ignoreWater = true;
            projectile.timeLeft = 300;
            projectile.aiStyle = 13;
        }
        //public float rotate = 20;
        public override void AI()
        {
            //this is projectile dust
            //int DustID2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width - 3, projectile.height - 3, 40, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 10, Color.Purple, 1f);
            //Main.dust[DustID2].noGravity = true;
            //this make that the projectile faces the right way 
            //rotate -= 0.008f;
            //projectile.rotation += rotate;
            projectile.localAI[0] += 1f;
            //projectile.light = .04f;
            //projectile.alpha = (int)projectile.localAI[0] * 2;
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
                spriteBatch.Draw(mod.GetTexture("Projectiles/ChainProjChain"), new Vector2(center.X - Main.screenPosition.X, center.Y - Main.screenPosition.Y),
                    new Rectangle(0, 0, 10, 34), Color.DimGray, projRotation,
                    new Vector2(10/2, 34/2), 1f, SpriteEffects.None, 0f);
            }
            return false;
        }
    }
}