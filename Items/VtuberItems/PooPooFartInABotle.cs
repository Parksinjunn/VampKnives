using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.VtuberItems
{
    public class PooPooFartInABottle : ModItem
    {
        public override void SetStaticDefaults()
        {           
            DisplayName.SetDefault("[c/964B00:Poo Poo Fart in a Bottle]");
            Tooltip.SetDefault("Allows flight while mounted on your meat bike");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(8, 5));
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.rare = 0;
            item.accessory = true;
            item.value = Item.sellPrice(0, 69, 4, 20);
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.mount._flyTime = 80;
        }
    }
}
