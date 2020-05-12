using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VampKnives.Buffs;

namespace VampKnives.Items.Misc
{
    public class EeveeBall : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("E Ball");
            Tooltip.SetDefault("Summons a creature of many forms");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.Carrot);
            item.shoot = mod.ProjectileType("EBunny");
            item.buffType = ModContent.BuffType<EeveeBuff>();
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