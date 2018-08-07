using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameInput;

namespace VampKnives.Items.Misc
{
    public class TestForRetro : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("This is a modded sword.");  //The (English) text shown below your weapon's name
        }

        public override void SetDefaults()
        {
            item.damage = 50;           //The damage of your weapon
            item.melee = true;          //Is your weapon a melee weapon?
            item.width = 80;            //Weapon's texture's width
            item.height = 80;           //Weapon's texture's height
            item.useTime = 4;          //The time span of using the weapon. Remember in terraria, 60 frames is a second.
            item.useAnimation = 4;         //The time span of the using animation of the weapon, suggest set it the same as useTime.
            item.noUseGraphic = true;
            item.channel = true;
            item.useStyle = 1;          //The use style of weapon, 1 for swinging, 2 for drinking, 3 act like shortsword, 4 for use like life crystal, 5 for use staffs or guns
            item.knockBack = 6;         //The force of knockback of the weapon. Maximum is 20
            item.value = Item.buyPrice(gold: 1);           //The value of the weapon
            item.rare = 12;              //The rarity of the weapon, from -1 to 13
            item.UseSound = SoundID.Item1;      //The sound when the weapon is using
            item.autoReuse = false;          //Whether the weapon can use automatically by pressing mousebutton
            item.shoot = mod.ProjectileType("TestForRetroProj");
            item.shootSpeed = 8f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 MousePosition = Main.MouseWorld;
            Vector2 PlayerCenter = player.Center;
            Vector2 Direction = MousePosition - PlayerCenter;
            Direction.Normalize();

            int numProjectiles2 = 1;
            Random random = new Random();
            int ran = random.Next(10, 35);
            float spread = MathHelper.ToRadians(ran);
            float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
            double startAngle = Math.Atan2(speedX, speedY) - spread / 2;
            double deltaAngle = spread / (float)numProjectiles2;
            Projectile.NewProjectile(player.Center + (Direction * 135), new Vector2(baseSpeed * (float)Math.Sin(startAngle), baseSpeed * (float)Math.Cos(startAngle)), type, damage, knockBack, player.whoAmI);
            return false;
        }
    }
}