using System;
using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles
{
    public class LightningProj : KnifeProjectile
    {
        Vector2 Point1;
        Vector2 Point2;
        Vector2 Point3;
        Vector2 Point4;
        Vector2 Point5;
        Vector2 Point6;
        Vector2 Point7;
        bool HitTile;
        bool InitialShow;
        int InitializedTimeLeft;
        int SoundDelay;
        public override void SafeSetDefaults()
        {
            projectile.width = 96;
            projectile.height = 900;
            projectile.friendly = true;
            projectile.penetrate = 1;                       //this is the projectile penetration
            projectile.hostile = false;
            projectile.magic = true;                        //this make the projectile do magic damage
            projectile.tileCollide = true;                 //this make that the projectile does not go thru walls
            projectile.ignoreWater = false;
            projectile.timeLeft = 200;
        }
        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            projectile.penetrate += 1;
            base.ModifyHitNPC(target, ref damage, ref knockback, ref crit, ref hitDirection);
        }
        public override void AI()
        {
            int HarshnessMin = 60;
            int HarshnessMax = 96;
            int Width = projectile.width;
            int Height = projectile.height;
            int DivisionFactor = 2;
            if(HitTile)
            {
                if (InitialShow == false)
                {
                    Point1 = new Vector2((projectile.position.X + Width / 2) + ((Main.rand.Next(0,2) * 2 -1) * Main.rand.Next(HarshnessMin / DivisionFactor, HarshnessMax / DivisionFactor)), projectile.position.Y);
                    Point2 = new Vector2((projectile.position.X + Width / 2) + ((Main.rand.Next(0,2) * 2 -1) * Main.rand.Next(HarshnessMin / DivisionFactor, HarshnessMax / DivisionFactor)), projectile.position.Y + (Height / 6));
                    Point3 = new Vector2((projectile.position.X + Width / 2) + ((Main.rand.Next(0,2) * 2 -1) * Main.rand.Next(HarshnessMin / DivisionFactor, HarshnessMax / DivisionFactor)), projectile.position.Y + (Height * 2 / 6));
                    Point4 = new Vector2((projectile.position.X + Width / 2) + ((Main.rand.Next(0,2) * 2 -1) * Main.rand.Next(HarshnessMin / DivisionFactor, HarshnessMax / DivisionFactor)), projectile.position.Y + (Height * 3 / 6));
                    Point5 = new Vector2((projectile.position.X + Width / 2) + ((Main.rand.Next(0,2) * 2 -1) * Main.rand.Next(HarshnessMin / DivisionFactor, HarshnessMax / DivisionFactor)), projectile.position.Y + (Height * 4 / 6));
                    Point6 = new Vector2((projectile.position.X + Width / 2) + ((Main.rand.Next(0,2) * 2 -1) * Main.rand.Next(HarshnessMin / DivisionFactor, HarshnessMax / DivisionFactor)), projectile.position.Y + (Height * 5 / 6));
                    Point7 = new Vector2((projectile.position.X + Width / 2) + ((Main.rand.Next(0,2) * 2 -1) * Main.rand.Next(HarshnessMin / DivisionFactor, HarshnessMax / DivisionFactor)), projectile.position.Y + (Height));
                    InitialShow = true;
                    InitializedTimeLeft = projectile.timeLeft;
                }
                else if (projectile.timeLeft == InitializedTimeLeft - 50) 
                {
                    projectile.position.X += Main.rand.Next(-5, 5);
                    Point1 = new Vector2((projectile.position.X + Width / 2) + ((Main.rand.Next(0,2) * 2 -1) * Main.rand.Next(HarshnessMin / DivisionFactor, HarshnessMax / DivisionFactor)), projectile.position.Y);
                    Point2 = new Vector2((projectile.position.X + Width / 2) + ((Main.rand.Next(0,2) * 2 -1) * Main.rand.Next(HarshnessMin / DivisionFactor, HarshnessMax / DivisionFactor)), projectile.position.Y + (Height / 6));
                    Point3 = new Vector2((projectile.position.X + Width / 2) + ((Main.rand.Next(0,2) * 2 -1) * Main.rand.Next(HarshnessMin / DivisionFactor, HarshnessMax / DivisionFactor)), projectile.position.Y + (Height * 2 / 6));
                    Point4 = new Vector2((projectile.position.X + Width / 2) + ((Main.rand.Next(0,2) * 2 -1) * Main.rand.Next(HarshnessMin / DivisionFactor, HarshnessMax / DivisionFactor)), projectile.position.Y + (Height * 3 / 6));
                    Point5 = new Vector2((projectile.position.X + Width / 2) + ((Main.rand.Next(0,2) * 2 -1) * Main.rand.Next(HarshnessMin / DivisionFactor, HarshnessMax / DivisionFactor)), projectile.position.Y + (Height * 4 / 6));
                    Point6 = new Vector2((projectile.position.X + Width / 2) + ((Main.rand.Next(0,2) * 2 -1) * Main.rand.Next(HarshnessMin / DivisionFactor, HarshnessMax / DivisionFactor)), projectile.position.Y + (Height * 5 / 6));
                    Point7 = new Vector2((projectile.position.X + Width / 2) + ((Main.rand.Next(0,2) * 2 -1) * Main.rand.Next(HarshnessMin / DivisionFactor, HarshnessMax / DivisionFactor)), projectile.position.Y + (Height));
                }
                else if (projectile.timeLeft == InitializedTimeLeft - 100)
                {
                    projectile.position.X += Main.rand.Next(-5, 5);
                    Point1 = new Vector2((projectile.position.X + Width / 2) + ((Main.rand.Next(0,2) * 2 -1) * Main.rand.Next(HarshnessMin / DivisionFactor, HarshnessMax / DivisionFactor)), projectile.position.Y);
                    Point2 = new Vector2((projectile.position.X + Width / 2) + ((Main.rand.Next(0,2) * 2 -1) * Main.rand.Next(HarshnessMin / DivisionFactor, HarshnessMax / DivisionFactor)), projectile.position.Y + (Height / 6));
                    Point3 = new Vector2((projectile.position.X + Width / 2) + ((Main.rand.Next(0,2) * 2 -1) * Main.rand.Next(HarshnessMin / DivisionFactor, HarshnessMax / DivisionFactor)), projectile.position.Y + (Height * 2 / 6));
                    Point4 = new Vector2((projectile.position.X + Width / 2) + ((Main.rand.Next(0,2) * 2 -1) * Main.rand.Next(HarshnessMin / DivisionFactor, HarshnessMax / DivisionFactor)), projectile.position.Y + (Height * 3 / 6));
                    Point5 = new Vector2((projectile.position.X + Width / 2) + ((Main.rand.Next(0,2) * 2 -1) * Main.rand.Next(HarshnessMin / DivisionFactor, HarshnessMax / DivisionFactor)), projectile.position.Y + (Height * 4 / 6));
                    Point6 = new Vector2((projectile.position.X + Width / 2) + ((Main.rand.Next(0,2) * 2 -1) * Main.rand.Next(HarshnessMin / DivisionFactor, HarshnessMax / DivisionFactor)), projectile.position.Y + (Height * 5 / 6));
                    Point7 = new Vector2((projectile.position.X + Width / 2) + ((Main.rand.Next(0,2) * 2 -1) * Main.rand.Next(HarshnessMin / DivisionFactor, HarshnessMax / DivisionFactor)), projectile.position.Y + (Height));
                }
                else if (projectile.timeLeft == InitializedTimeLeft - 150)
                {
                    projectile.position.X += Main.rand.Next(-5, 5);
                    Point1 = new Vector2((projectile.position.X + Width / 2) + ((Main.rand.Next(0,2) * 2 -1) * Main.rand.Next(HarshnessMin / DivisionFactor, HarshnessMax / DivisionFactor)), projectile.position.Y);
                    Point2 = new Vector2((projectile.position.X + Width / 2) + ((Main.rand.Next(0,2) * 2 -1) * Main.rand.Next(HarshnessMin / DivisionFactor, HarshnessMax / DivisionFactor)), projectile.position.Y + (Height / 6));
                    Point3 = new Vector2((projectile.position.X + Width / 2) + ((Main.rand.Next(0,2) * 2 -1) * Main.rand.Next(HarshnessMin / DivisionFactor, HarshnessMax / DivisionFactor)), projectile.position.Y + (Height * 2 / 6));
                    Point4 = new Vector2((projectile.position.X + Width / 2) + ((Main.rand.Next(0,2) * 2 -1) * Main.rand.Next(HarshnessMin / DivisionFactor, HarshnessMax / DivisionFactor)), projectile.position.Y + (Height * 3 / 6));
                    Point5 = new Vector2((projectile.position.X + Width / 2) + ((Main.rand.Next(0,2) * 2 -1) * Main.rand.Next(HarshnessMin / DivisionFactor, HarshnessMax / DivisionFactor)), projectile.position.Y + (Height * 4 / 6));
                    Point6 = new Vector2((projectile.position.X + Width / 2) + ((Main.rand.Next(0,2) * 2 -1) * Main.rand.Next(HarshnessMin / DivisionFactor, HarshnessMax / DivisionFactor)), projectile.position.Y + (Height * 5 / 6));
                    Point7 = new Vector2((projectile.position.X + Width / 2) + ((Main.rand.Next(0,2) * 2 -1) * Main.rand.Next(HarshnessMin / DivisionFactor, HarshnessMax / DivisionFactor)), projectile.position.Y + (Height));
                }
                else if (projectile.timeLeft == InitializedTimeLeft - 200)
                {
                    projectile.position.X += Main.rand.Next(-5, 5);
                    Point1 = new Vector2((projectile.position.X + Width / 2) + ((Main.rand.Next(0,2) * 2 -1) * Main.rand.Next(HarshnessMin / DivisionFactor, HarshnessMax / DivisionFactor)), projectile.position.Y);
                    Point2 = new Vector2((projectile.position.X + Width / 2) + ((Main.rand.Next(0,2) * 2 -1) * Main.rand.Next(HarshnessMin / DivisionFactor, HarshnessMax / DivisionFactor)), projectile.position.Y + (Height / 6));
                    Point3 = new Vector2((projectile.position.X + Width / 2) + ((Main.rand.Next(0,2) * 2 -1) * Main.rand.Next(HarshnessMin / DivisionFactor, HarshnessMax / DivisionFactor)), projectile.position.Y + (Height * 2 / 6));
                    Point4 = new Vector2((projectile.position.X + Width / 2) + ((Main.rand.Next(0,2) * 2 -1) * Main.rand.Next(HarshnessMin / DivisionFactor, HarshnessMax / DivisionFactor)), projectile.position.Y + (Height * 3 / 6));
                    Point5 = new Vector2((projectile.position.X + Width / 2) + ((Main.rand.Next(0,2) * 2 -1) * Main.rand.Next(HarshnessMin / DivisionFactor, HarshnessMax / DivisionFactor)), projectile.position.Y + (Height * 4 / 6));
                    Point6 = new Vector2((projectile.position.X + Width / 2) + ((Main.rand.Next(0,2) * 2 -1) * Main.rand.Next(HarshnessMin / DivisionFactor, HarshnessMax / DivisionFactor)), projectile.position.Y + (Height * 5 / 6));
                    Point7 = new Vector2((projectile.position.X + Width / 2) + ((Main.rand.Next(0,2) * 2 -1) * Main.rand.Next(HarshnessMin / DivisionFactor, HarshnessMax / DivisionFactor)), projectile.position.Y + (Height));
                }
                if (projectile.timeLeft == InitializedTimeLeft)
                {
                    Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/LightningStorm").WithVolume(.4f).WithPitchVariance(Main.rand.NextFloat(-0.25f,0.25f)),projectile.position);
                }
                if (projectile.timeLeft == InitializedTimeLeft - 5)
                {
                    for (int x = 0; x < 5; x++)
                    {
                        int DustID4 = Dust.NewDust(new Vector2(Point7.X, Point7.Y), 3, 3, 1, Main.rand.NextFloat(-3, 3), -3f, 10, Color.DimGray, 0.75f);
                        Main.dust[DustID4].noGravity = true;
                    }
                }
                else if (projectile.timeLeft == InitializedTimeLeft - 55)
                {
                    for (int x = 0; x < 5; x++)
                    {
                        int DustID = Dust.NewDust(new Vector2(Point7.X, Point7.Y), 3, 3, 1, Main.rand.NextFloat(-3,3), -3f, 10, Color.DimGray, 0.75f);
                        Main.dust[DustID].noGravity = true;
                    }
                }
                else if (projectile.timeLeft == InitializedTimeLeft - 105)
                {
                    for (int x = 0; x < 5; x++)
                    {
                        int DustID3 = Dust.NewDust(new Vector2(Point7.X, Point7.Y), 3, 3, 1, -3f, -3f, 10, Color.DimGray, 0.75f);
                        Main.dust[DustID3].noGravity = true;
                    }
                }
                else if (projectile.timeLeft == InitializedTimeLeft - 155)
                {
                    for (int x = 0; x < 5; x++)
                    {
                        int DustID3 = Dust.NewDust(new Vector2(Point7.X, Point7.Y), 3, 3, 1, -3f, -3f, 10, Color.DimGray, 0.75f);
                        Main.dust[DustID3].noGravity = true;
                    }
                }
                else if (projectile.timeLeft == InitializedTimeLeft - 205)
                {
                    for (int x = 0; x < 5; x++)
                    {
                        int DustID3 = Dust.NewDust(new Vector2(Point7.X, Point7.Y), 3, 3, 1, -3f, -3f, 10, Color.DimGray, 0.75f);
                        Main.dust[DustID3].noGravity = true;
                    }
                }

                for (int iterations = 0; iterations < 5; iterations++)
                {
                    float RandomSizeVar = Main.rand.NextFloat(1f, 2.8f);
                    //1 to 2
                    float RandomSpeed = Main.rand.NextFloat(-0.05f, 0.05f);
                    int Dust1x2 = Dust.NewDust(new Vector2(Point1.X, Point1.Y), 1, 1, 15, 0f, 0f, 10, Color.White, 1f + RandomSizeVar);
                    Main.dust[Dust1x2].noGravity = true;
                    float shootToX1x2 = Point2.X - Point1.X;
                    float shootToY1x2 = Point2.Y - Point1.Y;
                    float distance1x2 = (float)System.Math.Sqrt((double)(shootToX1x2 * shootToX1x2 + shootToY1x2 * shootToY1x2));
                    distance1x2 = 3f / distance1x2;
                    shootToX1x2 *= distance1x2 * (3f) + RandomSpeed;
                    shootToY1x2 *= distance1x2 * (3f) + RandomSpeed;
                    Main.dust[Dust1x2].velocity.X = shootToX1x2;
                    Main.dust[Dust1x2].velocity.Y = shootToY1x2;

                    //2 to 3
                    int Dust2x3 = Dust.NewDust(new Vector2(Point2.X, Point2.Y), 1, 1, 15, 0f, 0f, 10, Color.White, 1f + RandomSizeVar);
                    Main.dust[Dust2x3].noGravity = true;
                    float shootToX2x3 = Point3.X - Point2.X;
                    float shootToY2x3 = Point3.Y - Point2.Y;
                    float distance2x3 = (float)System.Math.Sqrt((double)(shootToX2x3 * shootToX2x3 + shootToY2x3 * shootToY2x3));
                    distance2x3 = 3f / distance2x3;
                    shootToX2x3 *= distance2x3 * (3f) + RandomSpeed;
                    shootToY2x3 *= distance2x3 * (3f) + RandomSpeed;
                    Main.dust[Dust2x3].velocity.X = shootToX2x3;
                    Main.dust[Dust2x3].velocity.Y = shootToY2x3;

                    //3 to 4
                    int Dust3x4 = Dust.NewDust(new Vector2(Point3.X, Point3.Y), 1, 1, 15, 0f, 0f, 10, Color.White, 1f + RandomSizeVar);
                    Main.dust[Dust3x4].noGravity = true;
                    float shootToX3x4 = Point4.X - Point3.X;
                    float shootToY3x4 = Point4.Y - Point3.Y;
                    float distance3x4 = (float)System.Math.Sqrt((double)(shootToX3x4 * shootToX3x4 + shootToY3x4 * shootToY3x4));
                    distance3x4 = 3f / distance3x4;
                    shootToX3x4 *= distance3x4 * (3f) + RandomSpeed;
                    shootToY3x4 *= distance3x4 * (3f) + RandomSpeed;
                    Main.dust[Dust3x4].velocity.X = shootToX3x4;
                    Main.dust[Dust3x4].velocity.Y = shootToY3x4;

                    //4 to 5
                    int Dust4x5 = Dust.NewDust(new Vector2(Point4.X, Point4.Y), 1, 1, 15, 0f, 0f, 10, Color.White, 1f + RandomSizeVar);
                    Main.dust[Dust4x5].noGravity = true;
                    float shootToX4x5 = Point5.X - Point4.X;
                    float shootToY4x5 = Point5.Y - Point4.Y;
                    float distance4x5 = (float)System.Math.Sqrt((double)(shootToX4x5 * shootToX4x5 + shootToY4x5 * shootToY4x5));
                    distance4x5 = 3f / distance4x5;
                    shootToX4x5 *= distance4x5 * (3f) + RandomSpeed;
                    shootToY4x5 *= distance4x5 * (3f) + RandomSpeed;
                    Main.dust[Dust4x5].velocity.X = shootToX4x5;
                    Main.dust[Dust4x5].velocity.Y = shootToY4x5;

                    //5 to 6
                    int Dust5x6 = Dust.NewDust(new Vector2(Point5.X, Point5.Y), 1, 1, 15, 0f, 0f, 10, Color.White, 1f + RandomSizeVar);
                    Main.dust[Dust5x6].noGravity = true;
                    float shootToX5x6 = Point6.X - Point5.X;
                    float shootToY5x6 = Point6.Y - Point5.Y;
                    float distance5x6 = (float)System.Math.Sqrt((double)(shootToX5x6 * shootToX5x6 + shootToY5x6 * shootToY5x6));
                    distance5x6 = 3f / distance5x6;
                    shootToX5x6 *= distance5x6 * (3f) + RandomSpeed;
                    shootToY5x6 *= distance5x6 * (3f) + RandomSpeed;
                    Main.dust[Dust5x6].velocity.X = shootToX5x6;
                    Main.dust[Dust5x6].velocity.Y = shootToY5x6;

                    int Dust6x7 = Dust.NewDust(new Vector2(Point6.X, Point6.Y), 1, 1, 15, 0f, 0f, 10, Color.White, 1f + RandomSizeVar);
                    Main.dust[Dust6x7].noGravity = true;
                    float shootToX6x7 = Point7.X - Point6.X;
                    float shootToY6x7 = Point7.Y - Point6.Y;
                    float distance6x7 = (float)System.Math.Sqrt((double)(shootToX6x7 * shootToX6x7 + shootToY6x7 * shootToY6x7));
                    distance6x7 = 3f / distance6x7;
                    shootToX6x7 *= distance6x7 * (2.5f) + RandomSpeed;
                    shootToY6x7 *= distance6x7 * (2.5f) + RandomSpeed;
                    Main.dust[Dust6x7].velocity.X = shootToX6x7;
                    Main.dust[Dust6x7].velocity.Y = shootToY6x7;

                    if (Main.rand.Next(1, 11) == 4)
                    {
                        Dust SparkDust;

                        int SparkPlace = Main.rand.Next(1, 7);
                        for (int SoMuchDust = 0; SoMuchDust < 5; SoMuchDust++)
                        {
                            if (SparkPlace == 1)
                            {
                                SparkDust = Main.dust[Dust.NewDust(new Vector2(Point2.X, Point2.Y), 1, 1, 15, Main.rand.NextFloat(-4f, 4f) * Main.dust[Dust1x2].velocity.X, Main.rand.NextFloat(-4f, 4f), 10, Color.White, 1f)];
                                SparkDust.noGravity = true;
                            }
                            else if (SparkPlace == 2)
                            {
                                SparkDust = Main.dust[Dust.NewDust(new Vector2(Point3.X, Point3.Y), 1, 1, 15, Main.rand.NextFloat(-4f, 4f) * Main.dust[Dust2x3].velocity.X, Main.rand.NextFloat(-4f, 4f), 10, Color.White, 1f)];
                                SparkDust.noGravity = true;
                            }
                            else if (SparkPlace == 3)
                            {
                                SparkDust = Main.dust[Dust.NewDust(new Vector2(Point4.X, Point4.Y), 1, 1, 15, Main.rand.NextFloat(-4f, 4f) * Main.dust[Dust3x4].velocity.X, Main.rand.NextFloat(-4f, 4f), 10, Color.White, 1f)];
                                SparkDust.noGravity = true;
                            }
                            else if (SparkPlace == 4)
                            {
                                SparkDust = Main.dust[Dust.NewDust(new Vector2(Point5.X, Point5.Y), 1, 1, 15, Main.rand.NextFloat(-4f, 4f) * Main.dust[Dust4x5].velocity.X, Main.rand.NextFloat(-4f, 4f), 10, Color.White, 1f)];
                                SparkDust.noGravity = true;
                            }
                            else if (SparkPlace == 5)
                            {
                                SparkDust = Main.dust[Dust.NewDust(new Vector2(Point6.X, Point6.Y), 1, 1, 15, Main.rand.NextFloat(-4f, 4f) * Main.dust[Dust5x6].velocity.X, Main.rand.NextFloat(-4f, 4f), 10, Color.White, 1f)];
                                SparkDust.noGravity = true;
                            }
                            else if (SparkPlace == 6)
                            {
                                SparkDust = Main.dust[Dust.NewDust(new Vector2(Point7.X, Point7.Y), 1, 1, 15, Main.rand.NextFloat(-4f, 4f) * Main.dust[Dust6x7].velocity.X, Main.rand.NextFloat(-4f, 4f), 10, Color.White, 1f)];
                                SparkDust.noGravity = true;
                            }
                        }
                    }
                }
                Lighting.AddLight(projectile.Center, 0.6f, 0.6f, 0.6f);
                projectile.alpha = 65;
            }
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item10.WithVolume(.15f), projectile.position);
            DefenseKnivesProj.ProjCount.LightningActiveCount -= 1;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            //Main.PlaySound(SoundID.Tink, (int)projectile.position.X, (int)projectile.position.Y, 1, 0.5f);
            for (int x = 0; x < 5; x++)
            {
                int DustID2 = Dust.NewDust(new Vector2(Point7.X, Point7.Y), 3, 3, 1, -2f, -2f, 10, Color.Brown, 1f);
                Main.dust[DustID2].noGravity = true;
            }
            projectile.velocity *= 0f;
            projectile.tileCollide = false;
            HitTile = true;
            return false;
        }
    }
}