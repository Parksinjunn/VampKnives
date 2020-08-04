using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.Ammo
{
    public class ThrowingKnivesCopper : AmmoCraftItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Copper Throwing Knives");
        }

        public override void SafeSetDefaults()
        {
            BarType = ItemID.CopperBar;
            item.damage = 1;
            item.width = 38;
            item.height = 46;
            item.maxStack = 999;
            item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
            item.knockBack = 1.5f;
            item.crit = 2;
            item.value = Item.sellPrice(0, 0, 0, 20) ;
            item.rare = 2;
            item.shoot = mod.ProjectileType("CopperProj");   //The projectile shoot when your weapon using this ammo
            item.shootSpeed = 6f;                  //The speed of the projectile
            item.ammo = ModContent.ItemType<ThrowingKnivesAmmo>();              //The ammo class this ammo belongs to.
        }
    }
}
