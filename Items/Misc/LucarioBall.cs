using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VampKnives.Buffs;

namespace VampKnives.Items.Misc
{
    public class LucarioBall : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("L Ball");
            Tooltip.SetDefault("Summons a creature with the speed of a wyvern");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.Carrot);
            item.shoot = mod.ProjectileType("Lucario");
            item.buffType = ModContent.BuffType<LucarioBuff>();
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