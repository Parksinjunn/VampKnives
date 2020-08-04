using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items
{
	public abstract class PouchWeapon : KnifeItem
	{
        public virtual void PouchDefaults() {
        }
        public override void SafeSetDefaults()
        {
            PouchDefaults();
            item.useAnimation = 18;
            item.useTime = 4;
            item.reuseDelay = 20;
        }
        int Delay = 60;
        int DelayTick;
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numProjectiles2 = player.GetModPlayer<ExamplePlayer>().NumProj + player.GetModPlayer<ExamplePlayer>().ExtraProj;
            Random random = new Random();
            int ran = random.Next(10, 35);
            float spread = MathHelper.ToRadians(ran);
            float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
            double startAngle = Math.Atan2(speedX, speedY) - spread / 2;
            double deltaAngle = spread / (float)numProjectiles2;
            double offsetAngle;

            offsetAngle = startAngle + deltaAngle * (player.itemAnimation/2);
            Projectile.NewProjectile(position.X, position.Y, baseSpeed * (float)Math.Sin(offsetAngle), baseSpeed * (float)Math.Cos(offsetAngle), type, damage, knockBack, player.whoAmI);

            return false;
        }
    }

}
