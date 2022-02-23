using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using VampKnives.NPCs;

namespace VampKnives.Projectiles.VtuberProj
{
    public class DemonicEnsuranceProj : KnifeProjectile
    {
        public override void SafeSetDefaults()
        {
            projectile.width = 32;
            projectile.height = 68;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.hostile = false;
            projectile.tileCollide = true;                 //this make that the projectile does not go thru walls
            projectile.ignoreWater = true;
            projectile.timeLeft = 240;
            projectile.scale = 0.65f;
            //projectile.scale = Main.rand.NextFloat(0.3f, 0.6f);
        }
        public override void AI()
        {
            projectile.rotation += 0.1f;
            if(projectile.timeLeft < 220)
                projectile.velocity.Y += 0.3f;
            //projectile.alpha = 32;
        }
        public override bool SafePreKill(int timeLeft)
        {
            int RandSound = 0;
            if (RandSound == 0)
            {
                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Milk1").WithVolume(1f).WithPitchVariance(Main.rand.NextFloat(-0.30f, 0.30f)), projectile.position);
            }
            for (int x = 0; x < Main.ActivePlayersCount; x++)
            {
                Player target = Main.player[x];
                Vector2 vector31 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
                float num500 = target.Center.X - vector31.X;
                float num501 = target.Center.Y - vector31.Y;
                float num502 = (float)Math.Sqrt((double)(num500 * num500 + num501 * num501));
                if (num502 < 100f)
                {
                    target.AddBuff(ModContent.BuffType<Buffs.VTuberBuffs.ImEnsured>(), 900);
                    target.statLife += 12;
                    target.HealEffect(12, true);
                }
            }
            for(int x = 0; x < Main.maxNPCs; x++)
            {
                NPC target = Main.npc[x];
                Vector2 vector31 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
                float num500 = target.Center.X - vector31.X;
                float num501 = target.Center.Y - vector31.Y;
                float num502 = (float)Math.Sqrt((double)(num500 * num500 + num501 * num501));
                if (num502 < 100f)
                {
                    target.AddBuff(ModContent.BuffType<Buffs.VTuberBuffs.ImEnsured>(), 900);
                }
            }
            for (int i = 0; i < 50; i++)
            {
                int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), (int)(projectile.width * 1.4), (int)(projectile.height * 1.4), 268, 0f, 0f, 100, Color.Brown, 2f);
                Main.dust[dustIndex].velocity *= 1.4f;
            }
            for (int i = 0; i < 80; i++)
            {
                int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), (int)(projectile.width * 1.4), (int)(projectile.height * 1.4), 268, 0f, 0f, 100, Color.Brown, 2f);
                Main.dust[dustIndex].velocity *= 3f;
            }
            return base.SafePreKill(timeLeft);
        }
    }
}