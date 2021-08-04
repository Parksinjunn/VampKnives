using Terraria.DataStructures;
using Terraria;
using Terraria.ModLoader;

namespace VampKnives.Items.VtuberItems
{
    public class SuccubusHeartCorset : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("What mystic energy resides in this tablet?\nDouble-tap transform key (check key config) to transform into a bat");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(8, 8));
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.rare = 11;
            item.accessory = true;
            item.value = Item.sellPrice(0, 69, 4, 20);
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<ExamplePlayer>().VeiTransform = true;
        }
    }
}
