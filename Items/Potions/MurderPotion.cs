using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VampKnives.Buffs;

namespace VampKnives.Items.Potions
{
    public class MurderPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Randomly deal massive damage." +
                                "\nCrit chance is lowered." +
                                "\nEffects last 30 seconds.");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 40;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.UseSound = SoundID.Item3;
            item.maxStack = 30;
            item.rare = 10;
            item.value = Item.buyPrice(gold: 1);
            item.consumable = true;
        }
        public override bool UseItem(Player player)
        {
            player.AddBuff(ModContent.BuffType<MurderPotionBuff>(), 1800);
            item.consumable = true;
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater, 2);
            recipe.AddIngredient(ItemID.TissueSample, 4);
            recipe.AddIngredient(ItemID.Vertebrae, 5);
            recipe.AddTile(mod.GetTile("KnifeBench"));
            recipe.SetResult(this, 2);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater, 3);
            recipe.AddIngredient(ItemID.ShadowScale, 6);
            recipe.AddIngredient(ItemID.RottenChunk, 5);
            recipe.AddTile(mod.GetTile("KnifeBench"));
            recipe.SetResult(this, 3);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater, 2);
            recipe.AddIngredient(ItemID.TissueSample, 4);
            recipe.AddIngredient(ItemID.Vertebrae, 5);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this, 3);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater, 3);
            recipe.AddIngredient(ItemID.ShadowScale, 6);
            recipe.AddIngredient(ItemID.RottenChunk, 5);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this, 4);
            recipe.AddRecipe();
        }
    }
}