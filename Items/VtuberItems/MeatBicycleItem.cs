using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.VtuberItems
{
	public class MeatBicycleItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("When you combine muscle. And power. And skill, with a greatsword.\nBIg tHiNGs HapPeN!\nIf you've got some meat and a greatsword you can make my cool bike at home.");
		}

		public override void SetDefaults()
		{
			item.width = 72;
			item.height = 58;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = 30000;
			item.rare = ItemRarityID.Pink;
			item.UseSound = SoundID.NPCDeath11;
			item.noMelee = true;
			item.mountType = ModContent.MountType<MeatBicycle>();
		}
	}
}