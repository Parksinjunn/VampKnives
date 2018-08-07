using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.Ammo
{
    public class ThrowingKnivesSilver : KnifeItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Silver Throwing Knives");
        }

        public override void SafeSetDefaults()
        {
            item.damage = 2;
            item.width = 48;
            item.height = 48;
            item.maxStack = 999;
            item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
            item.knockBack = 1.5f;
            item.crit = 4;
            item.value = Item.sellPrice(0, 0, 1, 20);
            item.rare = 0;
            item.shoot = mod.ProjectileType("SilverProj");   //The projectile shoot when your weapon using this ammo
            item.shootSpeed = 6f;                  //The speed of the projectile
            item.ammo = mod.ItemType("ThrowingKnivesAmmo");              //The ammo class this ammo belongs to.
        }

        public override void AddRecipes()
        {
            DartCastRecipe recipe = new DartCastRecipe(mod);
            recipe.AddIngredient(ItemID.SilverBar, 1);
            recipe.AddTile(TileID.Furnaces);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 5);
            recipe.AddRecipe();

            recipe = new DartCastRecipe(mod);
            recipe.AddIngredient(ItemID.SilverBar, 1);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this, 10);
            recipe.AddRecipe();
        }
    }
}
