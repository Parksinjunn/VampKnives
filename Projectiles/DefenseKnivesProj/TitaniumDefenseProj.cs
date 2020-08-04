using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles.DefenseKnivesProj
{
    public class TitaniumDefenseProj : KnifeProjectile
    {
        int FrameUp;
        int FrameTimer;
        int FrameNumber = 12;
        float RotationMin;
        float RotationMax;
        int RotationVector;
        int RotationTimer;
        int RotationMultiplier=1;
        bool SwitchDirection;
        public override void SafeSetDefaults()
        {
            projectile.width = 22;
            projectile.height = 26;
            projectile.knockBack = 60;
            projectile.friendly = true;
            projectile.tileCollide = false;
            projectile.penetrate = -1;
            projectile.hostile = false;
            projectile.magic = true;
            projectile.ignoreWater = true;
            projectile.timeLeft = 350;
            Main.projFrames[projectile.type] = FrameNumber;           //this is projectile frames
            projectile.rotation = 120f * (float)(Math.PI / 180);
            projectile.Opacity = 0f;
        }
        public override void SafeAI()
        {
            Lighting.AddLight(projectile.Center, 0.58f, 0.41f, 0.98f);

            Player p = Main.player[projectile.owner];

            double deg = (double)projectile.ai[1]*2.5; //The degrees, you can multiply projectile.ai[1] to make it orbit faster, may be choppy depending on the value
            double rad = deg * (Math.PI / 180); //Convert degrees to radians
            double dist = 100; //Distance away from the player

            /*Position the player based on where the player is, the Sin/Cos of the angle times the /
            /distance for the desired distance away from the player minus the projectile's width   /
            /and height divided by two so the center of the projectile is at the right place.     */
            projectile.position.X = p.Center.X - (int)(Math.Cos(rad) * dist) - projectile.width / 2;
            projectile.position.Y = p.Center.Y - (int)(Math.Sin(rad) * dist) - projectile.height / 2;

            //Increase the counter/angle in degrees by 1 point, you can change the rate here too, but the orbit may look choppy depending on the value
            projectile.ai[1] += 1f;
            FrameTimer++;
            if (FrameTimer > 8)
            {
                FrameUp++;
                projectile.frame = FrameUp;
                if (FrameUp > FrameNumber - 2)
                {
                    FrameUp = 0;
                }
                FrameTimer = 0;
            }
            RotationTimer++;
            if(RotationTimer > 2)
            {
                RotationMin = 60f * (float)(Math.PI / 180);
                RotationMax = 180f * (float)(Math.PI / 180);
                projectile.rotation += 0.05f * RotationMultiplier;
                if(projectile.rotation >= RotationMax || projectile.rotation <= RotationMin)
                {
                    SwitchDirection = true;
                }
                if(SwitchDirection)
                {
                    RotationMultiplier *= -1;
                    SwitchDirection = false;
                }
                RotationTimer = 0;
            }
            if(projectile.timeLeft < 60)
            {
                projectile.Opacity *= 0.5f;
            }
            if(projectile.timeLeft > 310)
            {
                projectile.Opacity += 0.2f;
            }
            if(projectile.timeLeft > 60 && projectile.timeLeft < 310)
            {
                projectile.Opacity = 0.7f + (float)(Main.rand.Next(1, 20) / 100);
            }
        }
        public override bool PreKill(int timeLeft)
        {
            
            ProjCount.NumActiveTitanium--;
            return base.PreKill(timeLeft);
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            projectile.timeLeft = 30;
            projectile.hostile = false;
            projectile.friendly = false;
            projectile.magic = false;
            projectile.damage = 0;
        }
    }
}