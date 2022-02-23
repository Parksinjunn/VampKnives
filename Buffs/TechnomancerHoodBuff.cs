using Terraria;
using Terraria.ModLoader;
using VampKnives;

namespace VampKnives.Buffs
{
    public class TechnomancerHoodBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Technomancy");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            VampPlayer p = player.GetModPlayer<VampPlayer>();

            // We use blockyAccessoryPrevious here instead of blockyAccessory because UpdateBuffs happens before UpdateEquips but after ResetEffects.
            if (p.HoodIsVisible == true && p.TechnomancerAccessoryPrevious)
            {
                p.TechnomancerPower = true;

            }
            else
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
        }
    }
}