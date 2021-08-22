using Microsoft.Xna.Framework;
using Terraria;
using System.Collections.Generic;
using System;
using VampKnives.Projectiles.DefenseKnivesProj;

namespace VampKnives.Projectiles
{
    public class HorsemansKnivesProj : KnifeProjectile
    {
        bool HitTile;
        bool HasDoneEffect;
        bool PumpkinsSpawned;
        float VelocityFactor = 2f;
        int ActiveTargets;
        int HitCount;
        List<int> TargetIDs = new List<int>();

        public override void SafeSetDefaults()
        {
            ProjCount.PumpkinActiveCount++;
            projectile.width = 54;
            projectile.height = 54;
            projectile.friendly = true;
            projectile.penetrate = 1;                       //this is the projectile penetration
            projectile.hostile = false;
            projectile.magic = true;                        //this make the projectile do magic damage
            projectile.tileCollide = true;                 //this make that the projectile does not go thru walls
            projectile.ignoreWater = true;
            projectile.timeLeft = 300;
            projectile.scale = 0.6f;
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
            Lighting.AddLight(projectile.Center, (255 / 255f), (117 / 255f), (24 / 255f));
            if (!ZenithActive)
            {
                projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(SpriteRotation); // projectile faces sprite right
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
            }

            if (Main.rand.Next(1, (int)(200 * (float)Math.Log(10 * ProjCount.GetPumpkinActiveCount()))) == 90)
            {
                for (int i = 0; i < 200; i++)
                {
                    if (Main.npc[i].CanBeChasedBy())
                    {
                        ActiveTargets++;
                        TargetIDs.Add(i);
                        //Main.NewText("ID: " + i);
                    }
                }
                //Main.NewText("ActiveTargets: " + ActiveTargets);
                //Main.NewText("TargetIDs Stored: " + TargetIDs.Count);
                for (int i = 0; i < TargetIDs.Count; i++)
                {
                    //Main.NewText("FinalID: " + TargetIDs[i]);
                    if (!Main.npc[TargetIDs[i]].active)
                    {
                        TargetIDs.RemoveAt(i);
                        i++;
                    }
                    if (Main.rand.Next(1, ActiveTargets) <= 2)
                    {
                        int logicCheckScreenHeight = Main.LogicCheckScreenHeight;
                        int logicCheckScreenWidth = Main.LogicCheckScreenWidth;
                        int num = Main.rand.Next(100, 300);
                        int num2 = Main.rand.Next(100, 300);
                        num = ((Main.rand.Next(2) != 0) ? (num + (logicCheckScreenWidth / 2 - num)) : (num - (logicCheckScreenWidth / 2 + num)));
                        num2 = ((Main.rand.Next(2) != 0) ? (num2 + (logicCheckScreenHeight / 2 - num2)) : (num2 - (logicCheckScreenHeight / 2 + num2)));
                        num += (int)projectile.position.X;
                        num2 += (int)projectile.position.Y;
                        float num3 = 40f;
                        Vector2 vector = new Vector2((float)num, (float)num2);
                        float num4 = Main.npc[TargetIDs[i]].position.X - vector.X;
                        float num5 = Main.npc[TargetIDs[i]].position.Y - vector.Y;
                        float num6 = (float)Math.Sqrt((double)(num4 * num4 + num5 * num5));
                        num6 = num3 / num6;
                        num4 *= num6;
                        num5 *= num6;
                        Projectile.NewProjectile((float)num, (float)num2, num4, num5, 321, projectile.damage / 2, projectile.knockBack, projectile.owner, (float)TargetIDs[i], 0f);
                    }
                }
                ActiveTargets = 0;
                TargetIDs.Clear();
            }
            if(HitCount > 4)
            {
                projectile.Kill();
            }
        }
        public override bool SafePreKill(int timeLeft)
        {
            ProjCount.PumpkinActiveCount--;
            return base.SafePreKill(timeLeft);
        }
        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            projectile.penetrate++;
            HitCount++;
        }
        public override bool SafeOnTileCollide(Vector2 oldVelocity)
        {
                HitTile = true;
                projectile.hide = true;
                projectile.penetrate = 1;
                projectile.tileCollide = false;
                projectile.velocity = oldVelocity;
                projectile.timeLeft = 60;
            return false;
        }
    }
}