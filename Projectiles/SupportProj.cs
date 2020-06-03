using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles
{
    public class SupportProj : KnifeProjectile
    {
        Player Decide;
        int Decision;
        int LowestLife = 500;
        public override void SetDefaults()
        {
            Player owner = Main.player[projectile.owner];

            projectile.Name = "Vampire Healing";
            projectile.width = 2;
            projectile.height = 2;
            projectile.friendly = false;
            projectile.penetrate = 1;
            projectile.hostile = false;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            //projectile.light = 0.5f;
            projectile.timeLeft = 3600;
        }
        public override void AI()
        {

            Lighting.AddLight(projectile.Center, 0.2f, 0.5f, 0.8f);

            projectile.localAI[0] += 1f;
            if (projectile.localAI[0] > 9f)
            {
                for (int i = 0; i < 4; i++)
                {
                    Vector2 projectilePosition = projectile.position;
                    projectilePosition -= projectile.velocity * ((float)i * 0.25f);
                    projectile.alpha = 255;
                    // Important, changed 173 to 178!
                    int dust = Dust.NewDust(projectilePosition, 1, 1, 185, 0f, 0f, 0, default(Color), 1.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].position = projectilePosition;
                    Main.dust[dust].scale = (float)Main.rand.Next(110, 150) * 0.013f;
                    Main.dust[dust].velocity *= 0.2f;
                }
            }
            if (projectile.localAI[0] > 9f)
            {
                for (int i = 0; i < 4; i++)
                {
                    Vector2 projectilePosition = projectile.position;
                    projectilePosition -= projectile.velocity * ((float)i * 0.25f);
                    projectile.alpha = 255;
                    // Important, changed 173 to 178!
                    int dust = Dust.NewDust(projectilePosition, 1, 1, 175, 0f, 0f, 0, Color.White, 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].position = projectilePosition;
                    Main.dust[dust].scale = (float)Main.rand.Next(70, 110) * 0.013f;
                    Main.dust[dust].velocity *= 0.2f;
                }
            }
            //projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            projectile.localAI[0] += 1f;
            //projectile.light = .04f;
            //projectile.alpha = (int)projectile.localAI[0] * 2;
            for (int i = 0; i < 200; i++)
            {
                Player owner = Main.player[projectile.owner];
                for (int g = 0; g < Main.ActivePlayersCount; g++)
                {
                    Decide = Main.player[g];
                    int TempStatLife = Decide.statLife;
                    //Main.NewText("LowestLife: " + LowestLife + "   TempStatLife: " + TempStatLife);
                    if (TempStatLife < LowestLife && Decide != owner)
                    {
                        LowestLife = TempStatLife;
                        Decision = g;
                        //Main.NewText("Decision: " + Decide + "Decision's Life: " + Decide.statLife);
                    }
                }
                if (owner.HasBuff(mod.BuffType("TrueSupportDebuff")) == true)
                {
                    Player Target = Main.player[Decision];
                    float shootToX = Target.position.X + (float)Target.width * 0.5f - projectile.Center.X;
                    float shootToY = Target.position.Y + (Target.height / 2) - projectile.Center.Y;
                    float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

                    if (distance < 2000f && Target.active && Target != owner)
                    {
                        distance = 4f / distance;

                        shootToX *= distance * 5;
                        shootToY *= distance * 5;

                        projectile.velocity.X = shootToX;
                        projectile.velocity.Y = shootToY;
                    }
                    float distanceX = Target.position.X - projectile.position.X;
                    float distanceY = Target.position.Y - projectile.position.Y;
                    if (distance < 70f && projectile.position.X < Target.position.X + Target.width && projectile.position.X + projectile.width > Target.position.X && projectile.position.Y < Target.position.Y + Target.height && projectile.position.Y + projectile.height > Target.position.Y && Target != owner)
                    {
                        ExamplePlayer p = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
                        float damage = projectile.damage * p.TrueSupportBuff;
                        p.VampCurrent += (int)(damage * 0.40);
                        if (((int)(damage * 0.40)) < 1)
                            p.VampCurrent += 1f;
                        p.DelayTimer = 30;
                        int statLifeCalc = (int)((p.HealAccMult) * ((p.VampCurrent / 230) + (0.6 * ((0.000000180527267 * Math.Pow(damage, 4)) - (0.0000551402375 * Math.Pow(damage, 3)) + (0.00382482 * Math.Pow(damage, 2)) + (0.09874884 * damage) + 1.34702863)) + Main.rand.NextFloat(-2, 2)));
                        if (statLifeCalc > 30)
                            statLifeCalc = 30 + Main.rand.Next(-3, 3);
                        if (statLifeCalc < 1)
                            statLifeCalc = 1;
                        Target.statLife += (statLifeCalc);
                        if (statLifeCalc >= 1)
                            Target.HealEffect(statLifeCalc, false);
                        projectile.Kill();
                        break;
                    }
                }
                else if (owner.HasBuff(mod.BuffType("TrueSupportDebuff")) != true)
                {
                    for (int g = 0; g < Main.ActivePlayersCount; g++)
                    {
                        Decide = Main.player[g];
                        int TempStatLife = Decide.statLife;
                        //Main.NewText("LowestLife: " + LowestLife + "   TempStatLife: " + TempStatLife);
                        if (TempStatLife < LowestLife)
                        {
                            LowestLife = TempStatLife;
                            Decision = g;
                            //Main.NewText("Decision: " + Decide + "Decision's Life: " + Decide.statLife);
                        }
                    }
                    Player Target = Main.player[Decision];
                    float shootToX = Target.position.X + (float)Target.width * 0.5f - projectile.Center.X;
                    float shootToY = Target.position.Y + (Target.height / 2) - projectile.Center.Y;
                    float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

                    if (distance < 2000f && owner.active)
                    {
                        distance = 4f / distance;

                        shootToX *= distance * 5;
                        shootToY *= distance * 5;

                        projectile.velocity.X = shootToX;
                        projectile.velocity.Y = shootToY;
                    }
                    float distanceX = owner.position.X - projectile.position.X;
                    float distanceY = owner.position.Y - projectile.position.Y;
                    if (distance < 70f && projectile.position.X < owner.position.X + owner.width && projectile.position.X + projectile.width > owner.position.X && projectile.position.Y < owner.position.Y + owner.height && projectile.position.Y + projectile.height > owner.position.Y)
                    {
                        int damage = projectile.damage;
                        ExamplePlayer p = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
                        p.VampCurrent += (int)(damage * 0.40);
                        if (((int)(damage * 0.40)) < 1)
                            p.VampCurrent += 1f;
                        p.DelayTimer = 30;
                        int statLifeCalc = (int)((p.HealAccMult) * ((p.VampCurrent / 230) + (0.6 * ((0.000000180527267 * Math.Pow(damage, 4)) - (0.0000551402375 * Math.Pow(damage, 3)) + (0.00382482 * Math.Pow(damage, 2)) + (0.09874884 * damage) + 1.34702863)) + Main.rand.NextFloat(-2, 2)));
                        if (statLifeCalc > 20)
                            statLifeCalc = 20 + Main.rand.Next(-3, 3);
                        if (statLifeCalc < 1)
                            statLifeCalc = 1;
                        owner.statLife += (statLifeCalc);
                        if (statLifeCalc >= 1)
                            owner.HealEffect(statLifeCalc, false);
                        projectile.Kill();
                        break;
                    }
                }
            }
        }
    }
}
