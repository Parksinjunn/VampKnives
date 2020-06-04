using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.Ammo
{
    public class ThrowingKnivesTungsten : AmmoCraftItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tungsten Throwing Knives");
        }

        public override void SafeSetDefaults()
        {
            BarType = ItemID.SilverBar;
            item.damage = 2;
            item.width = 48;
            item.height = 48;
            item.maxStack = 999;
            item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
            item.knockBack = 1.5f;
            item.crit = 4;
            item.value = Item.sellPrice(0, 0, 1, 80);
            item.rare = 0;
            item.shoot = mod.ProjectileType("TungstenProj");   //The projectile shoot when your weapon using this ammo
            item.shootSpeed = 6f;                  //The speed of the projectile
            item.ammo = ModContent.ItemType<ThrowingKnivesAmmo>();              //The ammo class this ammo belongs to.
        }
    }
}
