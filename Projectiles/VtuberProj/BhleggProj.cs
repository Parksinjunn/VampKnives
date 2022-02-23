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
    public class BhleggProj : KnifeProjectile
    {
        public override void SafeSetDefaults()
        {
            projectile.width = 32;
            projectile.height = 32;
            projectile.friendly = true;
            Main.projFrames[projectile.type] = 3;           //this is projectile frames
            projectile.penetrate = 1;
            projectile.hostile = false;
            projectile.tileCollide = true;                 //this make that the projectile does not go thru walls
            projectile.ignoreWater = true;
            projectile.timeLeft = 110;
            projectile.frame = Main.rand.Next(0, 3);
            projectile.scale = Main.rand.NextFloat(0.3f, 0.6f);
            projectile.rotation = Main.rand.NextFloat(0f, (float)Math.PI);
        }
        public override void AI()
        {
            Lighting.AddLight(projectile.Center, 1f, 0.75f, 0.80f);
            projectile.alpha = 32;
        }
        public override bool SafePreKill(int timeLeft)
        {
            if(Main.player[projectile.owner].HeldItem.type == ModContent.ItemType<Items.VtuberItems.BhleggGun>())
            {
                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/BubblePop").WithVolume(1f).WithPitchVariance(Main.rand.NextFloat(-0.30f, 0.30f)), projectile.position);
            }
            else
            {
                int RandSound = Main.rand.Next(0, 2);
                if (RandSound == 0)
                {
                    Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Bhlegg1").WithVolume(1f).WithPitchVariance(Main.rand.NextFloat(-0.30f, 0.30f)), projectile.position);
                }
                else
                {
                    Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Bhlegg2").WithVolume(1f).WithPitchVariance(Main.rand.NextFloat(-0.30f, 0.30f)), projectile.position);
                }
            }
            for (int x = 0; x < 4; x++)
            {
                VampPlayer.OvalDust(projectile.Center, projectile.width / 8, projectile.height / 8, Color.Pink, 263, 0.8f, true);
            }
            return base.SafePreKill(timeLeft);
        }
    }
}