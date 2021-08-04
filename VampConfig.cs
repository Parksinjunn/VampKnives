using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace VampKnives
{
	public class VampConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ClientSide;
		[Header("[c/FF0000:Difficulty Presets]")]
		[BackgroundColor(0, 0, 0)]
		public bool Easy;
		[BackgroundColor(0, 0, 0)]
		public bool Normal;
		[BackgroundColor(0, 0, 0)]
		public bool Hard;
		[BackgroundColor(0, 0, 0)]
		public bool Expert;
		[BackgroundColor(0, 0, 0)]
		public bool Legacy;

		[Header("[c/FF0000:Advanced Settings]")]
		[Range(0.5f, 2f)]
		[Increment(0.10f)]
		[DrawTicks]
		[DefaultValue(1f)]
		[Tooltip("This changes the amount of damage knives do, under 1 decreases damage, over 1 increases damage.")]
		[BackgroundColor(0, 0, 0)]
		[Slider]
		[SliderColor(160, 0, 0)]
		[Label("Damage multiplier")]
		public float DamageMultiplier = 1f;

		[Range(0.5f, 2f)]
		[Increment(0.10f)]
		[DrawTicks]
		[DefaultValue(1f)]
		[Tooltip("This changes the amount of healing you get from healing projectiles, under 1 decreases healing, over 1 increases healing")]
		[BackgroundColor(0, 0, 0)]
		[Slider]
		[SliderColor(160, 0, 0)]
		[Label("Heal Amount Multiplier")]
		public float HealAmntMultiplier = 1f;

		[Range(0, 100)]
		[Increment(10)]
		[DrawTicks]
		[DefaultValue(1)]
		[Tooltip("This changes the rate at which knives spawn healing projectiles, 0 is no chance, 1 is 100% chance")]
		[BackgroundColor(0, 0, 0)]
		[Slider]
		[SliderColor(160, 0, 0)]
		[Label("Heal Projectile Spawn Chance")]
		public float HealProjectileSpawnChance = 1f;

		[Range(0, 100)]
		[Increment(10)]
		[DrawTicks]
		[DefaultValue(1)]
		[Tooltip("This changes the amount of defence that is stripped from enemies by ammo-based knives, 0 is no defense, 1 is the base value")]
		[BackgroundColor(0, 0, 0)]
		[Slider]
		[SliderColor(160, 0, 0)]
		[Label("Ammo Knives Defence-Break Multiplier")]
		public float AmmoKnivesDefenceBreakMult = 1f;

		public override void OnChanged()
		{
			if(Easy)
            {
				Normal = false;
				Hard = false;
				Expert = false;
				Legacy = false;
				DamageMultiplier = 1.2f;
				HealAmntMultiplier = 1f;
				HealProjectileSpawnChance = 0.90f;
				AmmoKnivesDefenceBreakMult = 1f;
            }
			else if (Normal)
			{
				Easy = false;
				Hard = false;
				Expert = false;
				Legacy = false;
				DamageMultiplier = 1f;
				HealAmntMultiplier = 1f;
				HealProjectileSpawnChance = 0.90f;
				AmmoKnivesDefenceBreakMult = 1f;
			}
			else if (Hard)
			{
				Easy = false;
				Normal = false;
				Expert = false;
				Legacy = false;
				DamageMultiplier = 0.9f;
				HealAmntMultiplier = 0.8f;
				HealProjectileSpawnChance = 0.70f;
				AmmoKnivesDefenceBreakMult = 0.8f;
			}
			else if (Expert)
			{
				Easy = false;
				Hard = false;
				Normal = false;
				Legacy = false;
				DamageMultiplier = 0.8f;
				HealAmntMultiplier = 0.6f;
				HealProjectileSpawnChance = 0.40f;
				AmmoKnivesDefenceBreakMult = 0.3f;
			}
			else if (Legacy)
			{
				Easy = false;
				Hard = false;
				Expert = false;
				Normal = false;
				DamageMultiplier = 1.3f;
				HealAmntMultiplier = 1.4f;
				HealProjectileSpawnChance = 1f;
				AmmoKnivesDefenceBreakMult = 1f;
			}
			VampKnives.ConfigDamageMult = DamageMultiplier;
			VampKnives.ConfigHealAmntMult = HealAmntMultiplier;
			VampKnives.HealProjectileSpawn = HealProjectileSpawnChance * 100f;
		}
	}
}