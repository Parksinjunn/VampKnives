using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.Misc
{
    public class MasterSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Master Sword");
            Tooltip.SetDefault("Summons a warrior from Hyrule");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(8, 6));
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.Carrot);
            item.shoot = mod.ProjectileType("LinkBunny");
            item.buffType = mod.BuffType("LinkBuff");
            item.noUseGraphic = true;
        }

        public override void UseStyle(Player player)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(item.buffType, 3600, true);
            }
        }
    }
}