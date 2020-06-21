using Terraria.DataStructures;
using Terraria;
using Terraria.ModLoader;

namespace VampKnives.Items.Accessories
{
    [AutoloadEquip(EquipType.Wings)]
    public class AncientVampiricTablet : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("What mystic energy resides in this tablet?\nDouble-tap transform key (check key config) to transform into a bat");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(1, 11));
        }

        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 34;
            item.rare = 10;
            item.accessory = true;
            item.value = Item.sellPrice(1, 0, 0, 0);
        }
        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising, ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            ascentWhenFalling = 0.85f;
            ascentWhenRising = 0.15f;
            maxCanAscendMultiplier = 1f;
            maxAscentMultiplier = 3f;
            constantAscend = 0.15f;
        }
        public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
        {
            speed = 10f;
            acceleration *= 2.5f;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if(player.GetModPlayer<ExamplePlayer>().Transform == true)
            {
                player.wingTimeMax = 300;
            }
            else
            {
                player.wingTimeMax = 0;
            }
            player.GetModPlayer<ExamplePlayer>().HasTabletEquipped = true;
        }
    }
}
