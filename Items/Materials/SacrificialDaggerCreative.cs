using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using VampKnives.Buffs;

namespace VampKnives.Items.Materials
{
    public class SacrificialDaggerCreative : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Unlimited Power");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.useStyle = ItemUseStyleID.Stabbing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.noUseGraphic = false;
            item.UseSound = SoundID.Item1;
            item.maxStack = 1;
            item.rare = 1;
            item.value = Item.buyPrice(gold: 1);
            item.consumable = false;
        }
        public override bool UseItem(Player player)
        {
            player.GetModPlayer<VampPlayer>().BloodPoints += Main.rand.Next(150, 225);
            item.consumable = false;
            return true;
        }
        //public override void AddRecipes()
        //{
        //    ModRecipe recipe = new ModRecipe(mod);
        //    recipe.AddIngredient(ItemID.BottledWater,2);
        //    recipe.AddIngredient(ItemID.TissueSample, 4);
        //    recipe.AddIngredient(ItemID.Hemopiranha);
        //    recipe.AddTile(mod.GetTile("KnifeBench"));
        //    recipe.SetResult(this, 2);
        //    recipe.AddRecipe();
        //    recipe = new ModRecipe(mod);
        //    recipe.AddIngredient(ItemID.BottledWater, 3);
        //    recipe.AddIngredient(ItemID.ShadowScale, 6);
        //    recipe.AddIngredient(ItemID.Ebonkoi);
        //    recipe.AddTile(mod.GetTile("KnifeBench"));
        //    recipe.SetResult(this, 3);
        //    recipe.AddRecipe();

        //    recipe = new ModRecipe(mod);
        //    recipe.AddIngredient(ItemID.BottledWater, 2);
        //    recipe.AddIngredient(ItemID.TissueSample, 4);
        //    recipe.AddIngredient(ItemID.Hemopiranha);
        //    recipe.AddTile(mod.GetTile("VampTableTile"));
        //    recipe.SetResult(this, 3);
        //    recipe.AddRecipe();
        //    recipe = new ModRecipe(mod);
        //    recipe.AddIngredient(ItemID.BottledWater, 3);
        //    recipe.AddIngredient(ItemID.ShadowScale, 6);
        //    recipe.AddIngredient(ItemID.Ebonkoi);
        //    recipe.AddTile(mod.GetTile("VampTableTile"));
        //    recipe.SetResult(this, 4);
        //    recipe.AddRecipe();
        //}
    }
}
