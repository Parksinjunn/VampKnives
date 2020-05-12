using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VampKnives.Buffs;

namespace VampKnives.Items.Misc
{
    public class ArcanineBall : KnifeItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("A Ball");
            Tooltip.SetDefault("Summons a mature dog of flame");
        }

        public override void SafeSetDefaults()
        {
            item.CloneDefaults(ItemID.Carrot);
            item.shoot = mod.ProjectileType("Arcanine");
            item.buffType = ModContent.BuffType<ArcanineBuff>();
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