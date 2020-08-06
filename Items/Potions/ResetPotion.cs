using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using VampKnives.Buffs;

namespace VampKnives.Items.Potions
{
    public class ResetPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Resets BP");
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
            player.GetModPlayer<ExamplePlayer>().BloodPoints = 0;
            item.consumable = true;
            return true;
        }
    }
}
//x8 crit damage, x0.06125 crit chance for knives