using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.Misc
{
    public class ConnorPet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Connor");
            Tooltip.SetDefault("Connor.");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.CompanionCube);
            item.shoot = mod.ProjectileType("ConnorAnim");
            item.buffType = mod.BuffType("ConnorBuff");
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