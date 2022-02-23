using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.VtuberItems
{
    public class DemonLoli : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 34;
            item.rare = 11;
            item.accessory = true;
            item.value = Item.sellPrice(0, 69, 4, 20);
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<VampPlayer>().MouseTransform = true;
        }
    }
    public class LoliVanityEquipHead : EquipTexture
    {
        public override bool DrawHead()
        {
            return false;
        }
        public override void UpdateVanity(Player player, EquipType type)
        {
            player.GetModPlayer<VampPlayer>().MouseTransform = true;
        }
    }
    public class LoliVanityEquipBody : EquipTexture
    {
        public override bool DrawBody()
        {
            return false;
        }
    }
    public class LoliVanityEquipLegs : EquipTexture
    {
        public override bool DrawLegs()
        {
            return false;
        }
    }
}
