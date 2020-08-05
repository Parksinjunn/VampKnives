using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles
{
    public class HealProj : KnifeProjectile
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
            //Main.NewText("HealInstantiated");
        }
        public override void AI()
        {
            Lighting.AddLight(projectile.Center, 0.5f, 0f, 0f);

            projectile.localAI[0] += 1f;
            if (projectile.localAI[0] > 9f)
            {
                for (int i = 0; i < 4; i++)
                {
                    Vector2 projectilePosition = projectile.position;
                    projectilePosition -= projectile.velocity * ((float)i * 0.25f);
                    projectile.alpha = 255;
                    int dust = Dust.NewDust(projectilePosition, 1, 1, 183, 0f, 0f, 0, default(Color), 1.5f);
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
                    int dust = Dust.NewDust(projectilePosition, 1, 1, 175, 0f, 0f, 0, default(Color), 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].position = projectilePosition;
                    Main.dust[dust].scale = (float)Main.rand.Next(70, 110) * 0.013f;
                    Main.dust[dust].velocity *= 0.2f;
                }
            }
            projectile.localAI[0] += 1f;

            int num498 = (int)projectile.ai[0];
            float num499 = 26f;
            Vector2 vector31 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
            float num500 = Main.player[num498].Center.X - vector31.X;
            float num501 = Main.player[num498].Center.Y - vector31.Y;
            float num502 = (float)Math.Sqrt((double)(num500 * num500 + num501 * num501));
            if (num502 < 50f && projectile.position.X < Main.player[num498].position.X + (float)Main.player[num498].width && projectile.position.X + (float)projectile.width > Main.player[num498].position.X && projectile.position.Y < Main.player[num498].position.Y + (float)Main.player[num498].height && projectile.position.Y + (float)projectile.height > Main.player[num498].position.Y)
            {
                if (projectile.owner == Main.myPlayer && !Main.player[Main.myPlayer].moonLeech)
                {
                    int damage = projectile.damage;
                    ExamplePlayer p = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
                    p.VampCurrent += (int)(damage * 0.40);
                    if (((int)(damage * 0.40)) < 1)
                        p.VampCurrent += 1f;
                    p.DelayTimer = 30;
                    int statLifeCalc = (int)((p.HealAccMult) * ((p.VampCurrent / 230) + (1.21015154 * Math.Log(damage) - 0.04153757)));
                    if (statLifeCalc > 20)
                        statLifeCalc = 20 + Main.rand.Next(-3, 3) + (int)p.VampCurrent / 330;
                    if (VampKnives.Unforgiving && statLifeCalc > 10)
                        statLifeCalc = 10 + Main.rand.Next(-5, 3);
                    if (statLifeCalc < 1)
                        statLifeCalc = 1;
                    statLifeCalc += ParentWeapon.LifeStealBonus;
                    Main.player[projectile.owner].statLife += (statLifeCalc);
                    if (statLifeCalc >= 1)
                        Main.player[projectile.owner].HealEffect(statLifeCalc, false);

                    NetMessage.SendData(66, -1, -1, null, Main.myPlayer, (float)statLifeCalc, 0f, 0f, 0, 0, 0);
                }
                projectile.Kill();
            }
            num502 = num499 / num502;
            num500 *= num502;
            num501 *= num502;
            projectile.velocity.X = (projectile.velocity.X * 15f + num500) / 16f;
            projectile.velocity.Y = (projectile.velocity.Y * 15f + num501) / 16f;
        }
    }
}
