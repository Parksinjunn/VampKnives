using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.VtuberItems
{
    public class GamerHeadphones : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("");
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
            player.GetModPlayer<VampPlayer>().NyanTransform = true;
        }
    }
    public class GamerVanityEquipHead : EquipTexture
    {
        public override bool DrawHead()
        {
            return false;
        }
        public override void UpdateVanity(Player player, EquipType type)
        {
            player.GetModPlayer<VampPlayer>().NyanTransform = true;
        }
    }
    public class GamerVanityEquipBody : EquipTexture
    {
        public override bool DrawBody()
        {
            return false;
        }
    }
    public class GamerVanityEquipLegs : EquipTexture
    {
        public override bool DrawLegs()
        {
            return false;
        }
    }
}
