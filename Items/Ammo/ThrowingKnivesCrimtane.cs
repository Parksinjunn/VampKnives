using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.Ammo
{
    public class ThrowingKnivesCrimtane : AmmoCraftItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crimtane Throwing Knives");
        }

        public override void SafeSetDefaults()
        {
            BarType = ItemID.CrimtaneBar;
            item.damage = 4;
            item.width = 48;
            item.height = 48;
            item.maxStack = 999;
            item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
            item.knockBack = 1.5f;
            item.crit = 4;
            item.value = Item.sellPrice(0, 0, 8, 0);
            item.rare = 1;
            item.shoot = mod.ProjectileType("CrimtaneProj");   //The projectile shoot when your weapon using this ammo
            item.shootSpeed = 6f;                  //The speed of the projectile
            item.ammo = ModContent.ItemType<ThrowingKnivesAmmo>();              //The ammo class this ammo belongs to.
        }
    }
}
