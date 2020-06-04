using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;
using Terraria;
using Terraria.ModLoader;
using System.Linq;
using Terraria.ID;

namespace VampKnives.Items.MaterialKnives
{
    public abstract class KnifeMaterialItem : KnifeItem
    {

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numProjectiles2 = player.GetModPlayer<ExamplePlayer>().NumProj + player.GetModPlayer<ExamplePlayer>().ExtraProj;
            Random random = new Random();
            int ran = random.Next(6, 20); ;
            float spread = MathHelper.ToRadians(ran);
            float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
            double startAngle = Math.Atan2(speedX, speedY) - spread / 2;
            double deltaAngle = spread / (float)numProjectiles2;
            double offsetAngle;

            for (int j = 0; j < numProjectiles2; j++)
            {
                offsetAngle = startAngle + deltaAngle * j;
                Projectile.NewProjectile(position.X, position.Y, baseSpeed * (float)Math.Sin(offsetAngle), baseSpeed * (float)Math.Cos(offsetAngle), type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
    }
}
    

