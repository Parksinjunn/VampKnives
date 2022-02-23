using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using VampKnives.NPCs;

namespace VampKnives.Projectiles.VtuberProj
{
    public class MaracasProj : KnifeProjectile
    {
        public override void SafeSetDefaults()
        {
            projectile.width = 28;
            projectile.height = 32;
            projectile.friendly = true;
            Main.projFrames[projectile.type] = 6;           //this is projectile frames
            projectile.penetrate = 1;
            projectile.hostile = false;
            projectile.tileCollide = true;                 //this make that the projectile does not go thru walls
            projectile.ignoreWater = true;
            projectile.timeLeft = 110;
            projectile.frame = Main.rand.Next(0, 6);
            projectile.scale = Main.rand.NextFloat(0.5f, 0.8f);
            projectile.rotation = Main.rand.NextFloat(0f, (float)Math.PI/2);
        }
        public override void AI()
        {
            if (projectile.frame == 0 || projectile.frame == 1 || projectile.frame == 2)
            {
                Lighting.AddLight(projectile.Center, 0.6f, 0.475f, 0.50f);
            }
            if (projectile.frame == 3 || projectile.frame == 4 || projectile.frame == 5)
            {
                Lighting.AddLight(projectile.Center, 0.6f, 0.1f, 0.6f);
            }
            //projectile.alpha = 32;
        }
        public override bool SafePreKill(int timeLeft)
        {
            if (projectile.frame == 0 || projectile.frame == 1 || projectile.frame == 2)
            {
                for (int x = 0; x < 4; x++)
                {
                    VampPlayer.OvalDust(projectile.Center, projectile.width / 8, projectile.height / 8, Color.Pink, 141, 1.3f, true);
                }
            }
            if (projectile.frame == 3 || projectile.frame == 4 || projectile.frame == 5)
            {
                for (int x = 0; x < 4; x++)
                {
                    VampPlayer.OvalDust(projectile.Center, projectile.width / 8, projectile.height / 8, Color.MediumPurple, 141, 1.3f, true);
                }
            }

            return base.SafePreKill(timeLeft);
        }
    }
}