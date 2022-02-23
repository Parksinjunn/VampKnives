using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;
using Terraria;
using Terraria.ModLoader;
using System.Linq;

namespace VampKnives.Items
{
    public abstract class KnifeItem : ModItem
    {
        public float WepDamage;

        public bool IsMagic()
        {
            if (item.type == ModContent.ItemType<SorcerersSarukh>() && item.type == ModContent.ItemType<TrueDemonsScourge>() && item.type == ModContent.ItemType<PrismaticArcanum>())
            {
                return true;
            }
            else
                return false;
        }
        public virtual void SafeSetDefaults()
        {
        }

        public sealed override void SetDefaults()
        {
            SafeSetDefaults();
            item.melee = false;
            item.ranged = false;
            if (IsMagic() == false)
            {
                item.magic = false;
            }
            else
            {
                item.magic = true;
            }
            item.thrown = false;
            item.summon = false;
        }
        public override void ModifyWeaponDamage(Player player, ref float add, ref float mult, ref float flat)
        {
            if (IsMagic() == false)
            {
                add += KnifeDamagePlayer.ModPlayer(player).knifeDamageAdd;
                mult *= KnifeDamagePlayer.ModPlayer(player).knifeDamageMult;
            }
        }

        public override void GetWeaponKnockback(Player player, ref float knockback)
        {
            if (IsMagic() == false)
            {
                knockback = knockback + KnifeDamagePlayer.ModPlayer(player).KnifeKnockback;
            }
        }

        public override void GetWeaponCrit(Player player, ref int crit)
        {
            if (IsMagic() == false)
            {
                crit = crit + KnifeDamagePlayer.ModPlayer(player).KnifeCrit;
            }
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (IsMagic() == false)
            {
                TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.mod == "Terraria");
                if (tt != null)
                {
                    string[] splitText = tt.text.Split(' ');
                    string damageValue = splitText.First();
                    string damageWord = splitText.Last();
                    tt.text = damageValue + " Knife " + damageWord;
                }
            }
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numProjectiles2 = player.GetModPlayer<VampPlayer>().NumProj + player.GetModPlayer<VampPlayer>().ExtraProj;
            Random random = new Random();
            int ran = random.Next(10, 35);
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
    

