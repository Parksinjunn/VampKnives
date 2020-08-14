using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using VampKnives.Buffs;

namespace VampKnives.Items.Materials
{
    public class SacrificialDagger : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Sacrifice a bit of your own blood to get a bit of bp instantly\n[c/B48C8C:Disclaimer: This kind of behavior is not endorsed]\n[c/B48C8C:this is a game not real life]\n[c/B48C8C:If you have any thoughts of self-harm or suicide]\n[c/B48C8C:please talk to a loved one you trust or dial this number: 1-800-273-8255 to talk to someone who will listen]\n[c/B48C8C:You may feel alone, but I urge you to keep fighting, there's a reason you're here]\n[c/B48C8C:when you think you have done nothing worthwile, just remember that by downloading this mod you've made my day]\n[c/B48C8C:knowing that think of how many other people's days you've made better just by living]\n[c/B48C8C:we all make mistakes, and yours aren't any greater than mine]\n[c/B48C8C:we're all just hunks of carbon in the end, so make the most of your time alive]\n[c/B48C8C:you're a warrior, by the power of grayskull, you have the power!]");
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
            if(!player.HasBuff(ModContent.BuffType<BleedingOutDebuff>()))
            {
                player.AddBuff(ModContent.BuffType<BleedingOutDebuff>(),18000);
                player.GetModPlayer<ExamplePlayer>().BloodPoints += Main.rand.Next(50, 75);
                item.consumable = false;
            }
            else
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y - 50, player.width, player.height), new Color(255, 0, 0, 255), "You are still recovering!", true);
            }
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Obsidian, 6);
            recipe.AddIngredient(ItemID.HallowedBar, 4);
            recipe.AddIngredient(ItemID.GoldBar, 2);
            recipe.AddTile(mod.GetTile("KnifeBench"));
            recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Obsidian, 4);
            recipe.AddIngredient(ItemID.HallowedBar, 3);
            recipe.AddIngredient(ItemID.GoldBar, 1);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
