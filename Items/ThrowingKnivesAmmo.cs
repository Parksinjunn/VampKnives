using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items
{
    public class ThrowingKnivesAmmo : KnifeItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Throwing Knives");
        }

        public override void SafeSetDefaults()
        {
            item.damage = 1;
            item.width = 24;
            item.height = 24;
            item.maxStack = 999;
            item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
            item.knockBack = 1.5f;
            item.crit = 4;
            item.value = Item.sellPrice(0, 0, 0, 50) ;
            item.rare = 2;
            item.shoot = mod.ProjectileType("DartAnim");   //The projectile shoot when your weapon using this ammo
            item.shootSpeed = 6f;                  //The speed of the projectile
            item.ammo = item.type;              //The ammo class this ammo belongs to.
        }

        public override void AddRecipes()
        {
            DartCastRecipe recipe = new DartCastRecipe(mod);
            recipe.AddIngredient(ItemID.IronBar, 1);
            recipe.anyIronBar = true;
            recipe.AddTile(null, "KnifeBench");
            recipe.SetResult(this, 5);
            recipe.AddRecipe();

            recipe = new DartCastRecipe(mod);
            recipe.AddIngredient(ItemID.IronBar, 1);
            recipe.anyIronBar = true;
            recipe.AddTile(null, "VampTableTile");
            recipe.SetResult(this, 10);
            recipe.AddRecipe();
        }
    }
}
