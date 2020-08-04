using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using VampKnives.Items;
using VampKnives.Projectiles.DefenseKnivesProj;

namespace VampKnives.Projectiles
{
    public class ZenithsTrueBladesProj : KnifeProjectile
    {
        int ZenithCount;
        public static int SpawnTimer;
        int ProjType;
        public override void SafeSetDefaults()
        {
            projectile.width = 2;
            projectile.height = 2;
            projectile.friendly = false;
            projectile.penetrate = -1;
            projectile.hostile = false;
            projectile.tileCollide = false;                 //this make that the projectile does not go thru walls
            projectile.ignoreWater = true;
            projectile.timeLeft = 100;
            for (int iterations = 0; iterations < Main.maxProjectiles; iterations++)
            {
                if (Main.projectile[iterations].type == ModContent.ProjectileType<ZenithsTrueBladesProj>() && Main.projectile[iterations].active)
                {
                    ZenithCount++;
                }
            }
            //Main.NewText("ZenithCount: " + ZenithCount);
            if (ZenithCount > 1)
            {
                projectile.Kill();
                Main.NewText("MORE THAN ONE NOT ALLOWED");
            }
            ZenithCount = 0;
        }
        public override void AI()
        {
            Player owner = Main.player[projectile.owner];
            ZenithProjID = projectile.whoAmI;
            ZenithActive = true;
            //int DustID3 = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), 1, 1, 15, 0f, 0f, 10, new Color(0, 255, 0), 2f);
            projectile.timeLeft = 2;
            if(ProjCount.ZenithProj.Count < 6)
            {
                SpawnTimer++;
                if(SpawnTimer >= 5)
                {
                    int knifeSelect = Main.rand.Next(0, 19);
                    if (knifeSelect == 0)
                        ProjType = ModContent.ProjectileType<Ammo.CopperProj>();
                    if (knifeSelect == 1)
                        ProjType = ModContent.ProjectileType<LightandDarkProj>();
                    if (knifeSelect == 2)
                        ProjType = ModContent.ProjectileType<SengosForgottenProj>();
                    if (knifeSelect == 3)
                        ProjType = ModContent.ProjectileType<ButchersKnivesProj>();
                    if (knifeSelect == 4)
                        ProjType = ModContent.ProjectileType<StarfuryKnivesProj>();
                    if (knifeSelect == 5)
                        ProjType = ModContent.ProjectileType<EnchantedKnivesProj>();
                    if (knifeSelect == 6)
                        ProjType = ModContent.ProjectileType<BeeKnifeProj>();
                    if (knifeSelect == 7)
                        ProjType = ModContent.ProjectileType<JungleKnivesProj>();
                    if (knifeSelect == 8)
                        ProjType = ModContent.ProjectileType<FieryKnivesProj>();
                    if (knifeSelect == 9)
                        ProjType = ModContent.ProjectileType<ShadowProj>();
                    if (knifeSelect == 10)
                        ProjType = ModContent.ProjectileType<TrueShadowProj>();
                    if (knifeSelect == 11)
                        ProjType = ModContent.ProjectileType<ExcaliburProj>();
                    if (knifeSelect == 12)
                        ProjType = ModContent.ProjectileType<TrueExcaliburProj>();
                    if (knifeSelect == 13)
                        ProjType = ModContent.ProjectileType<HorsemansKnivesProj>();
                    if (knifeSelect == 14)
                        ProjType = ModContent.ProjectileType<BloomingTerrorProj>();
                    if (knifeSelect == 15)
                        ProjType = ModContent.ProjectileType<TerraKnivesProj>();
                    if (knifeSelect == 16)
                        ProjType = ModContent.ProjectileType<RukasusTeslaProj>();
                    if (knifeSelect == 17)
                        ProjType = ModContent.ProjectileType<WrathfulStarProj>();
                    if (knifeSelect == 18)
                        ProjType = ModContent.ProjectileType<NyivesBigProj>();
                    if (knifeSelect == 19)
                        ProjType = ModContent.ProjectileType<VampireKnifeProj>();

                    int i = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, ProjType, (int)(projectile.damage * 0.75), 0, owner.whoAmI);

                    ProjCount.ZenithProj.Add(i);
                    ProjCount.ZenithType.Add(Main.projectile[i].type);
                    SpawnTimer = 0;
                }
            }

            //for (int g = 0; g < ProjCount.ZenithProj.Count; g++)
            //{
            //    if(!Main.projectile[ProjCount.ZenithProj[g]].active)
            //    {
            //        ProjCount.ZenithProj.RemoveAt(g);
            //        ProjCount.ZenithType.RemoveAt(g);
            //        SpawnTimer = 15;
            //        Main.NewText("Length: " + ProjCount.ZenithProj.Count);
            //    }
            //}

            if (Main.player[projectile.owner].channel)
            {
                projectile.rotation += (float)projectile.direction * 0.8f;
                float num146 = 12f;
                Vector2 vector10 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
                projectile.rotation += (float)projectile.direction * 0.8f;
                float num147 = (float)Main.mouseX + Main.screenPosition.X - vector10.X;
                projectile.rotation += (float)projectile.direction * 0.8f;
                float num148 = (float)Main.mouseY + Main.screenPosition.Y - vector10.Y;
                projectile.rotation += (float)projectile.direction * 0.8f;
                if (Main.player[projectile.owner].gravDir == -1f)
                {
                    num148 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - vector10.Y;
                    projectile.rotation += (float)projectile.direction * 0.8f;
                }
                float num149 = (float)Math.Sqrt((double)(num147 * num147 + num148 * num148));
                num149 = (float)Math.Sqrt((double)(num147 * num147 + num148 * num148));
                if (num149 > num146)
                {
                    projectile.rotation += (float)projectile.direction * 0.8f;
                    num149 = num146 / num149;
                    num147 *= num149;
                    num148 *= num149;
                    int num150 = (int)(num147 * 1000f);
                    int num151 = (int)(projectile.velocity.X * 1000f);
                    projectile.rotation += (float)projectile.direction * 0.8f;
                    int num152 = (int)(num148 * 1000f);
                    int num153 = (int)(projectile.velocity.Y * 1000f);
                    projectile.rotation += (float)projectile.direction * 0.8f;
                    if (num150 != num151 || num152 != num153)
                    {
                        projectile.rotation += (float)projectile.direction * 0.8f;
                        projectile.netUpdate = true;
                        projectile.rotation += (float)projectile.direction * 0.8f;
                    }
                    projectile.velocity.X = num147;
                    projectile.rotation += (float)projectile.direction * 0.8f;
                    projectile.velocity.Y = num148;
                    projectile.rotation += (float)projectile.direction * 0.8f;
                }
                else
                {
                    projectile.rotation += (float)projectile.direction * 0.8f;
                    int num154 = (int)(num147 * 1000f);
                    int num155 = (int)(projectile.velocity.X * 1000f);
                    projectile.rotation += (float)projectile.direction * 0.8f;
                    int num156 = (int)(num148 * 1000f);
                    int num157 = (int)(projectile.velocity.Y * 1000f);
                    projectile.rotation += (float)projectile.direction * 0.8f;
                    if (num154 != num155 || num156 != num157)
                    {
                        projectile.rotation += (float)projectile.direction * 0.8f;
                        projectile.netUpdate = true;
                        projectile.rotation += (float)projectile.direction * 0.8f;
                    }
                    projectile.velocity.X = num147;
                    projectile.rotation += (float)projectile.direction * 0.8f;
                    projectile.velocity.Y = num148;
                    projectile.rotation += (float)projectile.direction * 0.8f;
                }
                projectile.rotation += (float)projectile.direction * 0.8f;
                projectile.velocity *= 1.5f;
            }
            else
            {
                projectile.Kill();
            }
        }
        public override bool SafePreKill(int timeLeft)
        {
            ZenithActive = false;
            return base.SafePreKill(timeLeft);
        }
    }
}