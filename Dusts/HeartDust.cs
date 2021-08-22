using Microsoft.Xna.Framework;
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
		int discreteUnits = 10;
		Color fadeTo = Color.Red;
		Color baseClr = Color.HotPink;
		float correctionFactor = 0.0f;
		float corFactorStep;
		Color curClr;
		Vector3 ColorVector;
		public override bool Update(Dust dust)
		{
			if (curClr == Color.Red)
			{
				correctionFactor = 0f;
			}
			corFactorStep = 1.0f / discreteUnits;
			correctionFactor += corFactorStep;
			float red = (fadeTo.R - baseClr.R) * correctionFactor + baseClr.R;
			float green = (fadeTo.G - baseClr.G) * correctionFactor + baseClr.G;
			float blue = (fadeTo.B - baseClr.B) * correctionFactor + baseClr.B;
			curClr = new Color(red, green, blue);
			ColorVector = new Vector3(curClr.R, curClr.G, curClr.B);
			Main.NewText("COLOR: " + curClr);
			Main.NewText("COLORNUM: " + ColorVector);
			dust.position += dust.velocity;
			dust.scale -= 0.02f;
			Lighting.AddLight(dust.position, ColorVector);
			//Lighting.brightness = 0.5f;
			if (dust.scale < 0.1f)
			{
				dust.active = false;
			}
			return false;
		}
	}
}