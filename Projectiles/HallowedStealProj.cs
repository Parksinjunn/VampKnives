using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles
{
    public class HallowedStealProj : KnifeProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 2;
            projectile.height = 2;
            projectile.friendly = false;
            projectile.penetrate = 1;                       
            projectile.hostile = false;
            projectile.tileCollide = false;                 
            projectile.ignoreWater = true;
            projectile.timeLeft = 3600;
        }
        //public override Color? GetAlpha(Color lightColor)
        //{
        //    //return Color.White;
        //    lightColor = new Color(255, 0, 0);
        //    return lightColor;
        //}
        public override void AI()
        {
            Lighting.AddLight(projectile.Center, Main.DiscoR/255f, Main.DiscoG/255f, Main.DiscoB/255f);

            projectile.localAI[0] += 1f;
            if (projectile.localAI[0] > 9f)
            {
                for (int i = 0; i < 4; i++)
                {
                    Vector2 projectilePosition = projectile.position;
                    projectilePosition -= projectile.velocity * ((float)i * 0.25f);
                    projectile.alpha = 255;
                    // Important, changed 173 to 178!
                    int dust = Dust.NewDust(projectilePosition, 1, 1, 182, 0f, 0f, 0, new Color(Main.DiscoR / 255f, Main.DiscoG / 255f, Main.DiscoB / 255f), 1.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].position = projectilePosition;
                    Main.dust[dust].scale = (float)Main.rand.Next(110, 150) * 0.013f;
                    Main.dust[dust].velocity *= 0.2f;
                    Main.dust[dust].shader = GameShaders.Armor.GetSecondaryShader(77, Main.LocalPlayer);
                }
            }
            projectile.localAI[0] += 1f;

            for (int i = 0; i < 200; i++)
            {
                Player owner = Main.player[projectile.owner];
                float shootToX = owner.position.X + (float)owner.width * 0.5f - projectile.Center.X;
                float shootToY = owner.position.Y + (owner.height / 2) - projectile.Center.Y;
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
                        statLifeCalc = 20 + Main.rand.Next(-3, 3) + (int)p.VampCurrent / 330;
                    if (VampKnives.Unforgiving && statLifeCalc > 10)
                        statLifeCalc = 10 + Main.rand.Next(-5, 3);
                    if (statLifeCalc < 1)
                        statLifeCalc = 1;
                    statLifeCalc += ParentWeapon.LifeStealBonus;
                    bool ManaOrHealth = Main.rand.NextBool();
                    if (ManaOrHealth)
                    {
                        owner.statLife += (statLifeCalc);
                        if (statLifeCalc >= 1)
                            owner.HealEffect(statLifeCalc, false);
                        projectile.Kill();
                    }
                    else if (ManaOrHealth == false)
                    {
                        owner.statMana += statLifeCalc;
                        owner.ManaEffect(statLifeCalc);
                        projectile.Kill();
                    }
                    break;
                }
            }
        }
    }
}
