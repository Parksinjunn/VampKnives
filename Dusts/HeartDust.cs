﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace VampKnives.Dusts
{
	public class HeartDust : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.noGravity = true;
			dust.frame = new Rectangle(0, 0, 30, 30);
			//If our texture had 2 different dust on top of each other (a 30x60 pixel image), we might do this:
			//dust.frame = new Rectangle(0, Main.rand.Next(2) * 30, 30, 30);
			dust.scale = 0.5f;
		}
		public override bool Update(Dust dust)
		{
			dust.position += dust.velocity;
			dust.scale -= 0.02f;
			if (dust.scale < 0.1f)
			{
				dust.active = false;
			}
			return false;
		}
		public static void LightColor(Vector3 color, Dust DustID)
        {
			Lighting.AddLight(DustID.position, color);
		}
	}
}