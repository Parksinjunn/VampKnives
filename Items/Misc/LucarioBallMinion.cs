using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.Misc
{
    public class LucarioBallMinion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("L Ball");
            Tooltip.SetDefault("TODO");
        }

        //public override void SetDefaults()
        //{
        //    item.CloneDefaults(ItemID.Carrot);
        //    item.shoot = mod.ProjectileType("LucarioMinion");
        //    item.buffType = mod.BuffType("LucarioBuffMinion");
        //}

        ////public override void AddRecipes()
        ////{
        ////    ModRecipe recipe = new ModRecipe(mod);
        ////    recipe.AddIngredient(ItemID.GoldCoin, 10);
        ////    recipe.SetResult(this);
        ////    recipe.AddRecipe();
        ////}

        //public override void UseStyle(Player player)
        //{
        //    if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
        //    {
        //        player.AddBuff(item.buffType, 3600, true);
        //    }
        //}
    }
}