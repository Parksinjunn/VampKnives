using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.Potions
{
    public class LifeStealPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Adds 10% more lifesteal" +
                               "\nEffects last 3 minutes.");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(7, 6));
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 40;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 30;
            item.rare = 10;
            item.value = Item.buyPrice(gold: 1);
            item.consumable = true;
        }
        public override bool UseItem(Player player)
        {
            player.AddBuff(mod.BuffType("LifeStealPotionBuff"), 10800);
            item.consumable = true;
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater,2);
            recipe.AddIngredient(ItemID.TissueSample, 4);
            recipe.AddIngredient(ItemID.Hemopiranha);
            recipe.AddTile(mod.GetTile("KnifeBench"));
            recipe.SetResult(this, 2);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater, 3);
            recipe.AddIngredient(ItemID.ShadowScale, 6);
            recipe.AddIngredient(ItemID.Ebonkoi);
            recipe.AddTile(mod.GetTile("KnifeBench"));
            recipe.SetResult(this, 3);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater, 2);
            recipe.AddIngredient(ItemID.TissueSample, 4);
            recipe.AddIngredient(ItemID.Hemopiranha);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this, 3);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater, 3);
            recipe.AddIngredient(ItemID.ShadowScale, 6);
            recipe.AddIngredient(ItemID.Ebonkoi);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this, 4);
            recipe.AddRecipe();
        }
    }
}
//x8 crit damage, x0.06125 crit chance for knives