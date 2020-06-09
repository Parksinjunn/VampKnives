using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles.DefenseKnivesProj
{
    public class MeteoriteDefenseKnivesProj : ReflectiveProj
    {
        int FrameNum;
        public override void SafeSetDefaults()
        {
            NumProjHits = 5;
            ReflectChance = 0.3f;
            projectile.width = 60;
            projectile.height = 28;
            projectile.knockBack = 60;
            projectile.friendly = true;
            projectile.penetrate = NumProjHits;
            projectile.hostile = false;
            projectile.magic = true;
            projectile.ignoreWater = true;
            projectile.timeLeft = 600;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 40;
            Main.projFrames[projectile.type] = 3;           //this is projectile frames
            FrameNum = Main.rand.Next(0, 3);
        }
        public override bool PreDraw(SpriteBatch sb, Color lightColor) //this is where the animation happens
        {
            projectile.frame = FrameNum;
            return true;
        }
    }
}