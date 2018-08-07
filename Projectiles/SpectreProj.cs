using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using VampKnives.NPCs;

namespace VampKnives.Projectiles
{
    public class SpectreProj : KnifeProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 24;
            projectile.height = 34;
            projectile.friendly = true;
            Main.projFrames[projectile.type] = 6;           //this is projectile frames
            projectile.penetrate = 2;
            projectile.hostile = false;
            projectile.tileCollide = false;                 //this make that the projectile does not go thru walls
            projectile.ignoreWater = true;
            projectile.timeLeft = 110;
        }
        public override void AI()
        {
            if (Main.rand.NextFloat() < 1f)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = Main.LocalPlayer.Center;
                dust = Main.dust[Terraria.Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width - 3, projectile.height - 3, 106, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 0, new Color(0, 255, 142), 1f)];
                dust.noGravity = true;
                dust.fadeIn = 0.5f;
                dust.shader = GameShaders.Armor.GetSecondaryShader(24, Main.LocalPlayer);
            }
            Lighting.AddLight(projectile.Center, 0f, 0.50f, 0.3f);

            //this make that the projectile faces the right way 
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            projectile.frameCounter++; //increase the frameCounter by one
            if (projectile.frameCounter >= 3) //once the frameCounter has reached 3 - change the 10 to change how fast the projectile animates
            {
                projectile.frame++; //go to the next frame
                projectile.frameCounter = 0; //reset the counter
                if (projectile.frame > 5) //if past the last frame
                    projectile.frame = 0; //go back to the first frame
            }
            projectile.localAI[0] += 1f;
            //projectile.light = .04f;
            projectile.alpha = (int)(projectile.localAI[0] * 2);
        }

        public override void OnHitNPC(NPC n, int damage, float knockback, bool crit)
        {
            Player owner = Main.player[projectile.owner];
            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("HealProj"), (int)(projectile.damage * 0.75), 0, owner.whoAmI);

            for (int x = 0; x < 10; x++)
            {
                    Dust dust;
                    // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                    Vector2 position = Main.LocalPlayer.Center;
                    dust = Main.dust[Terraria.Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width + 5, projectile.height + 5, 106, projectile.velocity.X * -0.2f, projectile.velocity.Y * -0.2f, 0, new Color(0, 255, 142), 2f)];
                    dust.noGravity = true;
                    dust.shader = GameShaders.Armor.GetSecondaryShader(24, Main.LocalPlayer);
            }
            Hoods(n);
        }

        public override bool PreKill(int timeLeft)
        {
            for (int x = 0; x < 18; x++)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = Main.LocalPlayer.Center;
                dust = Main.dust[Terraria.Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width + 5, projectile.height + 5, 106, projectile.velocity.X * -0.2f, projectile.velocity.Y * -0.2f, 0, new Color(0, 255, 142), 2f)];
                dust.noGravity = true;
                dust.shader = GameShaders.Armor.GetSecondaryShader(24, Main.LocalPlayer);
            }
            return base.PreKill(timeLeft);
        }
    }
}