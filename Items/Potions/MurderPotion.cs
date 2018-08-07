using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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
            item.rare = 3;
            item.value = Item.buyPrice(gold: 1);
            item.consumable = true;
        }
        public override bool UseItem(Player player)
        {
            player.AddBuff(mod.BuffType("MurderPotionBuff"), 1800);
            item.consumable = true;
            return true;
        }
    }
}