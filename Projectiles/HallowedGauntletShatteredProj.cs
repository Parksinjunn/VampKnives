using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles
{
    public class HallowedGauntletShatteredProj : KnifeProjectile
    {
        bool FramePicked = false;
        int HomingTimer;
        Vector2 OriginalPosition;
        public override void SafeSetDefaults()
        {
            projectile.width = 14;
            projectile.height = 10;
            projectile.friendly = true;
            Main.projFrames[projectile.type] = 6;           
            projectile.penetrate = 1;                       //this is the projectile penetration
            projectile.magic = true;                        //this make the projectile do magic damage
            projectile.tileCollide = true;                 //this make that the projectile does not go thru walls
            projectile.ignoreWater = true;
            projectile.timeLeft = 200;
            projectile.scale = Main.rand.NextFloat(0.75f,1.26f);
        }

        public override void AI()
        {
            projectile.alpha = 0;
            if (FramePicked == false)
            {
                int RandomFrame = Main.rand.Next(0, 6);
                projectile.frame = RandomFrame;
                projectile.rotation = MathHelper.ToRadians(Main.rand.Next(0, 361));
                OriginalPosition = projectile.Center;
                projectile.damage = 0;
                FramePicked = true;
            }
            if(projectile.timeLeft < 150)
            {
                projectile.damage = 3 + Main.rand.Next(0, 5);
            }
            projectile.rotation += MathHelper.ToRadians(Main.rand.Next(-3, 4));
            Lighting.AddLight(projectile.position, new Vector3(0.2f, 0.2f, 0.2f));
            if (projectile.timeLeft < 120 && projectile.timeLeft > 60)
            {
                projectile.rotation += MathHelper.ToRadians(3+((200 - projectile.timeLeft)/60));

                float shootToX = OriginalPosition.X + (float)projectile.width * 0.5f - projectile.Center.X;
                    float shootToY = OriginalPosition.Y - projectile.Center.Y;
                    float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

                if (distance < 2000f)
                {
                    distance = 3f / distance;

                    shootToX *= distance * 5;
                    shootToY *= distance * 5;

                    projectile.velocity.X = shootToX;
                    projectile.velocity.Y = shootToY;
                }
            }
            if(projectile.timeLeft == 59)
            {
                int iteration = Main.rand.Next(1, 361);
                int ProjectileVelocity = 20;
                projectile.velocity = new Vector2(ProjectileVelocity * (float)Math.Cos(iteration / ProjectileVelocity), ProjectileVelocity * (float)Math.Sin(iteration / ProjectileVelocity));
                projectile.tileCollide = false;

                float CircleRadius = 0.85f;
                for (int iteration2 = 0; iteration2 < 360; iteration2++)
                {
                    int DustID3 = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), 1, 1, 15, 0f, 0f, 10, Color.White, 2f);
                    Main.dust[DustID3].noGravity = true;
                    Main.dust[DustID3].velocity = new Vector2(CircleRadius * (float)Math.Cos(iteration2 / CircleRadius), CircleRadius * (float)Math.Sin(iteration2 / CircleRadius));
                }
            }
            if(projectile.timeLeft == 39)
            {
                float CircleRadius = 0.65f;
                for (int iteration = 0; iteration < 360; iteration++)
                {
                    int DustID3 = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), 1, 1, 15, 0f, 0f, 10, Color.White, 2f);
                    Main.dust[DustID3].noGravity = true;
                    Main.dust[DustID3].velocity = new Vector2(CircleRadius * (float)Math.Cos(iteration / CircleRadius), CircleRadius * (float)Math.Sin(iteration / CircleRadius));
                }
            }
            if(projectile.timeLeft == 29)
            {
                float CircleRadius = 0.45f;
                for (int iteration = 0; iteration < 360; iteration++)
                {
                    int DustID3 = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), 1, 1, 15, 0f, 0f, 10, Color.White, 2f);
                    Main.dust[DustID3].noGravity = true;
                    Main.dust[DustID3].velocity = new Vector2(CircleRadius * (float)Math.Cos(iteration / CircleRadius), CircleRadius * (float)Math.Sin(iteration / CircleRadius));
                }
            }
            if(projectile.timeLeft == 9)
            {
                float CircleRadius = 0.25f;
                for (int iteration = 0; iteration < 360; iteration++)
                {
                    int DustID3 = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), 1, 1, 15, 0f, 0f, 10, Color.White, 2f);
                    Main.dust[DustID3].noGravity = true;
                    Main.dust[DustID3].velocity = new Vector2(CircleRadius * (float)Math.Cos(iteration / CircleRadius), CircleRadius * (float)Math.Sin(iteration / CircleRadius));
                }
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.velocity *= 0f;
            projectile.tileCollide = false;
            return false;
        }
        public override bool SafePreKill(int timeLeft)
        {
            float CircleRadius = 0.15f;
            for (int iteration = 0; iteration < 360; iteration++)
            {
                int DustID3 = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), 1, 1, 15, 0f, 0f, 10, Color.White, 2f);
                Main.dust[DustID3].noGravity = true;
                Main.dust[DustID3].velocity = new Vector2(CircleRadius * (float)Math.Cos(iteration / CircleRadius), CircleRadius * (float)Math.Sin(iteration / CircleRadius));
            }
            return base.SafePreKill(timeLeft);
        }
    }
}