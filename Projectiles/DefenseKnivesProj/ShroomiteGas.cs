using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles.DefenseKnivesProj
{
    public class ShroomiteGas : KnifeProjectile
    {
        public int FrameCount = 8;
        public int FrameCounter;
        public int FrameDelay;
        public int RotationFactor;
        public static int Width = 40;
        public static int Height = 40;
        public bool HasHitEnemy = false;
        public override void SetDefaults()
        {
            projectile.width = Width;
            projectile.height = Height;
            projectile.knockBack = 0;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.hostile = false;
            projectile.magic = true;
            projectile.ignoreWater = true;
            projectile.timeLeft = 220;
            Main.projFrames[projectile.type] = FrameCount;           //this is projectile frames
            projectile.Opacity = 0;
            ProjCount.ShroomiteActiveGasCount++;
            projectile.scale *= 1.4f + (float)Main.rand.NextDouble();
            RotationFactor = Main.rand.Next(-1, 1)/10;
        }
        public override void AI()
        {
            FrameDelay++;
            if (FrameDelay > 10)
            {
                FrameCounter++;
                projectile.frame = FrameCounter;
                if (FrameCounter >= FrameCount - 1)
                {
                    FrameCounter = 0;
                }
                FrameDelay = 0;
            }
            projectile.rotation += MathHelper.ToRadians(RotationFactor);

            if (projectile.timeLeft >= 180)
            {
                projectile.Opacity += 0.1f;
            }
            if(projectile.timeLeft < 180 && projectile.timeLeft > 60)
            {
                projectile.Opacity += (float)(Main.rand.Next(-15,15)/100);
            }
            if (projectile.timeLeft <= 60)
            {
                projectile.Opacity *= 0.95f;
            }

            float ScaleMultiplier = (float)(Main.rand.Next(1, 5) / 300f);
            projectile.scale += ScaleMultiplier;
            float OffsetX = (projectile.width * projectile.scale/2);
            float OffsetY = (projectile.height * projectile.scale/2);
            Rectangle rectangle4 = new Rectangle((int)(projectile.position.X - OffsetX), (int)(projectile.position.Y - OffsetY), (int)(projectile.width * projectile.scale), (int)(projectile.height * projectile.scale));
            int numdust = Dust.NewDust(rectangle4.TopLeft(), rectangle4.Width, rectangle4.Height, 16, 0f, 0f, 100, Color.PowderBlue, (float)(Main.rand.NextDouble()));
            Dust projdust = Main.dust[numdust];
            projdust.noGravity = true;
            for (int NPCDist = 0; NPCDist < 200; NPCDist++)
            {
                if (Main.npc[NPCDist].active && !Main.npc[NPCDist].dontTakeDamage && Main.npc[NPCDist].lifeMax > 1 && !Main.npc[NPCDist].friendly)
                {
                    Rectangle value11 = new Rectangle((int)Main.npc[NPCDist].position.X, (int)Main.npc[NPCDist].position.Y, Main.npc[NPCDist].width, Main.npc[NPCDist].height);
                    if (rectangle4.Intersects(value11))
                    {
                        Main.npc[NPCDist].AddBuff(ModContent.BuffType<Buffs.ShroomitePoison>(), 240);
                    }
                }
            }
            for (int PlayerDist = 0; PlayerDist < Main.ActivePlayersCount; PlayerDist++)
            {
                if(Main.player[PlayerDist].active)
                {
                    Rectangle value11 = new Rectangle((int)Main.player[PlayerDist].position.X, (int)Main.player[PlayerDist].position.Y, Main.player[PlayerDist].width, Main.player[PlayerDist].height);
                    if (rectangle4.Intersects(value11))
                    {
                        Main.player[PlayerDist].AddBuff(ModContent.BuffType<Buffs.ShroomiteBuff>(), 240);
                        Main.player[PlayerDist].armorEffectDrawShadow = true;
                    }
                }
            }
        }
        public override void Kill(int timeLeft)
        {
            ProjCount.ShroomiteActiveGasCount--;
        }
    }
}