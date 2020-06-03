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
    public class WyvernHead : KnifeItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wyvern's Head");
        }
        public override void SafeSetDefaults()
        {
            item.damage = 26;
            item.crit = 6;
            item.width = 44;
            item.height = 50;
            item.useTime = 12;
            item.useAnimation = 12;
            item.useStyle = 1;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.knockBack = 3;
            item.value = Item.sellPrice(0, 7, 62, 22);
            item.rare = 8;
            item.UseSound = SoundID.Item39;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("WyvernProj");
            item.shootSpeed = 17f;
        }
    }

}
