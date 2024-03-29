﻿using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VampKnives.Items.Misc;

namespace VampKnives.Projectiles.Misc
{

    class BalitiusDaggerProj : ModProjectile
    {
        int Cooldown;
        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 18;
            projectile.aiStyle = 19;
            projectile.penetrate = -1;
            projectile.scale = 1.2f;
            projectile.alpha = 0;

            projectile.hide = true;
            projectile.ownerHitCheck = true;
            projectile.melee = true;
            projectile.tileCollide = false;
            projectile.friendly = true;
        }
		public float movementFactor
		{
			get => projectile.ai[0];
			set => projectile.ai[0] = value;
		}
        public override bool Autoload(ref string name)
        {
            return base.Autoload(ref name);
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			if (!target.boss)
			{
				for (int i = 0; i < 58; i++)
				{
					Item crystal = Main.player[projectile.owner].inventory[i];
					if (crystal.modItem is BloodCrystalSoul soul && soul.NPCID == -69)
					{
						soul.NPCID = target.type;
						soul.NPCName = target.FullName;
						break;
					}
				}
			}
		}
		public override void AI()
		{
			Player projOwner = Main.player[projectile.owner];
			Vector2 ownerMountedCenter = projOwner.RotatedRelativePoint(projOwner.MountedCenter, true);
			projectile.direction = projOwner.direction;
			projOwner.heldProj = projectile.whoAmI;
			projOwner.itemTime = projOwner.itemAnimation;
			projectile.position.X = projOwner.Center.X - (float)(projectile.width / 2);
			projectile.position.Y = projOwner.Center.Y - (float)(projectile.height / 2);
			if (!projOwner.frozen)
			{
				if (movementFactor == 0f)
				{
					movementFactor = 3f;
					projectile.netUpdate = true;
				}
				if (projOwner.itemAnimation < projOwner.itemAnimationMax / 3)
				{
					movementFactor -= 2.4f;
				}
				else
				{
					movementFactor += 2.1f;
				}
			}
			projectile.position += projectile.velocity * movementFactor;
			if (projOwner.itemAnimation == 0)
			{
				projectile.Kill();
			}
			projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(135f);
			if (projectile.spriteDirection == -1)
			{
				projectile.rotation -= MathHelper.ToRadians(90f);
			}
		}
	}
}