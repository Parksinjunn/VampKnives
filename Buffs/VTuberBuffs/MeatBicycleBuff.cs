using Terraria;
using Terraria.ModLoader;

namespace VampKnives.Buffs.VTuberBuffs
{
	public class MeatBicycleBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Meat Bicycle");
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.mount.SetMount(ModContent.MountType<Items.VtuberItems.MeatBicycle>(), player);
			player.buffTime[buffIndex] = 10;
		}
	}
}