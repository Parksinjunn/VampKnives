using Terraria;
using Terraria.ID;

namespace VampKnives.Items
{
    public class HarpyKnives : KnifeDamageItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Harpy Knives");
        }
        public override void SafeSetDefaults()
        {
            item.damage = 16;
            item.crit = 3;
            item.width = 44;
            item.height = 50;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = 1;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.knockBack = 2;
            item.value = Item.sellPrice(0, 0, 56, 32);
            item.rare = 8;
            item.UseSound = SoundID.Item39;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("HarpyProj");
            item.shootSpeed = 15f;
        }
    }
}
