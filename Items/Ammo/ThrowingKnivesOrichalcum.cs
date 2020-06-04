using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.Ammo
{
    public class ThrowingKnivesOrichalcum : AmmoCraftItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Orichalcum Throwing Knives");
        }

        public override void SafeSetDefaults()
        {
            BarType = ItemID.OrichalcumBar;
            item.damage = 7;
            item.width = 48;
            item.height = 48;
            item.maxStack = 999;
            item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
            item.knockBack = 1.5f;
            item.crit = 4;
            item.value = Item.sellPrice(0, 0, 8, 80);
            item.rare = 3;
            item.shoot = mod.ProjectileType("OrichalcumProj");   //The projectile shoot when your weapon using this ammo
            item.shootSpeed = 6f;                  //The speed of the projectile
            item.ammo = ModContent.ItemType<ThrowingKnivesAmmo>();              //The ammo class this ammo belongs to.
        }
    }
}
