using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.Materials
{
    public class CorruptionCrystal : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Unstable Corruption Crystal");
            Tooltip.SetDefault("Seems to have corrupt energy pouring from its cracks");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(2, 9));
        }
        public override void SetDefaults()
        {
            item.maxStack = 10;
            item.value = Item.sellPrice(0, 0, 50, 0) ;
            item.rare = 11;
        }
        public override bool CloneNewInstances
        {
            get
            {
                return true;
            }
        }
        public bool crafted;
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
        ExamplePlayer p = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
            TooltipLine line = new TooltipLine(mod, "Face", "Can be turned into shards with a Hammer");
            line.overrideColor = new Color(86, 86, 86);
            if (crafted == false)
                tooltips.Add(line);
        }
        public override void OnCraft(Recipe recipe)
        {
            crafted = true;
        }
        public override void UpdateInventory(Player player)
        {
            crafted = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("CrimsonCrystal"), 1);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();

            HammerRecipe recipe2 = new HammerRecipe(mod);
            recipe2.AddIngredient(this);
            recipe2.SetResult(mod.GetItem("CorruptionShard"), 4);
            recipe2.AddRecipe();
        }
    }
}