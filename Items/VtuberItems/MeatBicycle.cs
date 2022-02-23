using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.VtuberItems
{
	public class MeatBicycle : ModMountData
	{
		public override void SetDefaults()
		{
			mountData.spawnDust = 248;
			mountData.buff = ModContent.BuffType<Buffs.VTuberBuffs.MeatBicycleBuff>();
			mountData.heightBoost = 34;
			mountData.fallDamage = 0; 
			mountData.runSpeed = 11f;
			mountData.dashSpeed = 8f;
			mountData.flightTimeMax = 1;
			mountData.fatigueMax = 0;
			mountData.jumpHeight = 30;
			mountData.acceleration = 0.22f;
			mountData.jumpSpeed = 7f;
			mountData.blockExtraJumps = false;
			mountData.totalFrames = 4;
			mountData.constantJump = true;
			int[] array = new int[mountData.totalFrames];
			for (int l = 0; l < array.Length; l++)
			{
				array[l] = 34;
			}
			mountData.playerYOffsets = array;
			mountData.xOffset = 8;
			mountData.bodyFrame = 3;
			mountData.yOffset = 13;
			mountData.playerHeadOffset = 20;
			mountData.standingFrameCount = 0;
			mountData.standingFrameDelay = 1200;
			mountData.standingFrameStart = 0;
			mountData.runningFrameCount = 4;
			mountData.runningFrameDelay = 12;
			mountData.runningFrameStart = 0;
			mountData.flyingFrameCount = 0;
			mountData.flyingFrameDelay = 0;
			mountData.flyingFrameStart = 0;
			mountData.inAirFrameCount = 1;
			mountData.inAirFrameDelay = 12;
			mountData.inAirFrameStart = 0;
			mountData.idleFrameCount = 0;
			mountData.idleFrameDelay = 1200;
			mountData.idleFrameStart = 0;
			mountData.idleFrameLoop = false;
			mountData.swimFrameCount = mountData.inAirFrameCount;
			mountData.swimFrameDelay = mountData.inAirFrameDelay;
			mountData.swimFrameStart = mountData.inAirFrameStart;
			if (Main.netMode == NetmodeID.Server)
			{
				return;
			}

			mountData.textureWidth = mountData.backTexture.Width;
			mountData.textureHeight = mountData.backTexture.Height;
		}
        public override void UpdateEffects(Player player)
        {
			if (player.mount._flyTime > 1 && player.mount._flyTime < 100 && player.velocity.Y < 0)
            {
				for(int x = 0; x < 5; x++)
                {
					Dust.NewDust(player.Center + (player.velocity * 1.6f), 5, 5, 16, player.velocity.X * -1f, player.velocity.Y * -1f, 50, Color.SandyBrown, 1f);
				}
			}
		}
		public override void SetMount(Player player, ref bool skipDust)
		{
			// This code bypasses the normal mount spawning dust and replaces it with our own visual.
			for (int i = 0; i < 16; i++)
			{
				Dust.NewDustPerfect(player.Center + new Vector2(80, 0).RotatedBy(i * Math.PI * 2 / 16f), mountData.spawnDust, null, 0, Color.Pink);
			}
			skipDust = true;
		}
    }
}