using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles.DefenseKnivesProj
{
    public class SpectreDefenseKnivesProj : ReflectiveProj
    {
        public override void SetDefaults()
        {
            NumProjHits = 10;
            ReflectChance = 5f;
            IsSpectre = true;
            projectile.width = 60;
            projectile.height = 28;
            projectile.knockBack = 60;
            projectile.friendly = true;
            projectile.penetrate = NumProjHits;
            projectile.hostile = false;
            projectile.magic = true;
            projectile.ignoreWater = true;
            projectile.timeLeft = 800;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 40;
        }
        public override void Kill(int timeLeft)
        {
            float spread = projectile.rotation;
            float baseSpeed = 5;
            double startAngle = Math.Atan2(projectile.velocity.X, projectile.velocity.Y) - spread / 2;
            double deltaAngle = spread;
            Projectile.NewProjectile(projectile.Center, new Vector2(baseSpeed * (float)Math.Sin(startAngle), baseSpeed * (float)Math.Cos(startAngle)), ModContent.ProjectileType<SpectreDefProj>(), SpectreDamage, 2, projectile.owner);
        }
    }
}