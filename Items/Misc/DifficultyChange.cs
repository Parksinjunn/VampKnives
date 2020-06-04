using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VampKnives.Buffs;
using VampKnives.UI;

namespace VampKnives.Items.Misc
{
    public class DifficultyChange : KnifeItem
    {
        public bool FirstUse;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Difficulty Changer");
            Tooltip.SetDefault("Allows you to change the difficulty if needed");
        }

        public override void SafeSetDefaults()
        {
            item.height = 40;
            item.width = 32;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useStyle = 5;
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                item.useStyle = 5;
                if (FirstUse)
                {
                    EntranceDamageSettingsPanel.visible = true;
                    FirstUse = false;
                }
                else if (FirstUse == false)
                {
                    EntranceDamageSettingsPanel.visible = false;
                    FirstUse = true;
                }
            }
            else
            {
            }
            return true;
        }
        public override void HoldItem(Player player)
        {
            VampKnives.ChangeItemIsHeld = true;
            //Main.NewText("Legacy: " + VampKnives.Legacy);
            //Main.NewText("Normal: " + VampKnives.Normal);
            //Main.NewText("Unforgiving: " + VampKnives.Unforgiving);
            //Main.NewText("Chosen: " + VampKnives.ChosenDifficulty);
            //Main.NewText("Chisel Present: " + VampKnives.ChiselInSlot);
            //Main.NewText("Hammer Present : " + VampKnives.HammerInSlot);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 1);
            recipe.AddTile(mod.GetTile("KnifeBench"));
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 1);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}