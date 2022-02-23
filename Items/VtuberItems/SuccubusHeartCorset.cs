using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.VtuberItems
{
    public class SuccubusHeartCorset : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("");
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
            player.GetModPlayer<VampPlayer>().VeiTransform = true;
        }
    }
    public class SuccubusVanityEquipHead : EquipTexture
    {
        public override bool DrawHead()
        {
            return false;
        }
        public override void UpdateVanity(Player player, EquipType type)
        {
            player.GetModPlayer<VampPlayer>().VeiTransform = true;
        }
    }
    public class SuccubusVanityEquipBody : EquipTexture
    {
        public override bool DrawBody()
        {
            return false;
        }
    }
    public class SuccubusVanityEquipLegs : EquipTexture
    {
        public override bool DrawLegs()
        {
            return false;
        }
    }
}
