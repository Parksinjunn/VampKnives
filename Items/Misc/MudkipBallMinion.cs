using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.Misc
{
    public class MudkipBallMinion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("M Ball");
            Tooltip.SetDefault("TODO");
        }

        //public override void SetDefaults()
        //{
        //    item.CloneDefaults(ItemID.Carrot);
        //    item.shoot = mod.ProjectileType("MudkipBunnyMinion");
        //    item.buffType = mod.BuffType("MudkipBuffMinion");
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