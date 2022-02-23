﻿using Terraria;
using Terraria.ModLoader;
using VampKnives;

namespace VampKnives.Buffs
{
    public class WitchDoctorHoodBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("WitchDoctor");
            Description.SetDefault("Do what?" +
                "\nRemind me of the babe~");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            VampPlayer p = player.GetModPlayer<VampPlayer>();

            // We use blockyAccessoryPrevious here instead of blockyAccessory because UpdateBuffs happens before UpdateEquips but after ResetEffects.
            if (p.HoodIsVisible == true && p.WitchDoctorAccessoryPrevious)
            {
                p.WitchDoctorPower = true;
                player.GetModPlayer<VampPlayer>().ShrunkenHead = true;
                bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("ShrunkenHead")] <= 0;
                if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
                {
                    Projectile.NewProjectile(player.position.X - (float)(player.width / 2), player.position.Y - (float)(player.height / 2), 0.5f, 0.4f, mod.ProjectileType("ShrunkenHead"), 0, 0f, player.whoAmI, 0f, 0f);
                }
            }
            else
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
        }
    }
}