using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace VampKnives.Items.VtuberItems
{
    public class DemonicEnsurance : KnifeDamageItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Demonic Ensurance");
            Tooltip.SetDefault("A bubble gun infused with the power of an eldrich horror");
            Item.staff[item.type] = true;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            position.Y -= 20;
            return true;
        }

        public override void SafeSetDefaults()
        {
            item.damage = 47;
            item.width = 66;
            item.height = 56;
            item.useTime = 40;
            item.useAnimation = 20;
            item.channel = true;
            item.scale = 0.75f;
            item.useStyle = 5;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.knockBack = 3;
            item.value = Item.sellPrice(0, 12, 48, 16);
            item.rare = 8;
            //item.UseSound = SoundID.Item39;
            item.autoReuse = true;
            item.shootSpeed = 9f;
            item.shoot = mod.ProjectileType("DemonicEnsuranceProj");
        }
    }
}