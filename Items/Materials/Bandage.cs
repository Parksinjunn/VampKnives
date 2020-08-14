using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using VampKnives.Buffs;

namespace VampKnives.Items.Materials
{
    public class Bandage : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Sacrifice a bit of your own blood to get a bit of bp instantly");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 34;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 15;
            item.useTime = 15;
            item.noUseGraphic = false;
            item.UseSound = SoundID.Item1;
            item.maxStack = 99;
            item.rare = 1;
            //item.value = Item.buyPrice(gold: 1);
            item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.HasBuff(ModContent.BuffType<BleedingOutDebuff>()))
            {
                return true;
            }
            else
                return false;
        }
        public override bool UseItem(Player player)
        {
            if (!player.HasBuff(ModContent.BuffType<BandageBuff>()))
            {
                player.AddBuff(ModContent.BuffType<BandageBuff>(), 18000);
                item.consumable = true;
            }
            else
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y - 50, player.width, player.height), new Color(255, 0, 0, 255), "You already used a bandage!", true);
            }
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Silk, 5);
            recipe.AddTile(mod.GetTile("KnifeBench"));
            recipe.SetResult(this, 2);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Silk, 3);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this, 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Materials.PlanteraCloth>(), 5);
            recipe.AddTile(mod.GetTile("KnifeBench"));
            recipe.SetResult(this, 2);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Materials.PlanteraCloth>(), 3);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this, 4);
            recipe.AddRecipe();
        }
    }
}
