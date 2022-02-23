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
    public class BalitiusSpear : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Balitiu's Spear");
            Tooltip.SetDefault("A spear used by Balitiu to trap the souls of his enemies in Blood Crystals");  //The (English) text shown below your weapon's name
        }

        public override void SetDefaults()
        {
            item.damage = 1;
            item.melee = true;
            item.width = 54;
            item.height = 54;
            item.useAnimation = 18;
            item.useTime = 24;
            item.shootSpeed = 3.7f;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 6;
            item.value = Item.buyPrice(gold: 1);
            item.rare = 12;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType("BalitiusDaggerProj");
        }
        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[item.shoot] < 1;
        }
    }
}