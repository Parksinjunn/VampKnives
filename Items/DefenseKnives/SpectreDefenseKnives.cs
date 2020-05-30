using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace VampKnives.Items.DefenseKnives
{
    public class SpectreDefenseKnives : KnifeDefenseItem
    {
        public override void SetStaticDefaults()
        {
                DisplayName.SetDefault("Spectre Defense Knives");
                Tooltip.SetDefault("These knives form a protective Spectre wall when thrown");
            PlateType = ModContent.GetInstance<Items.Materials.Plates.SpectrePlate>();
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine line3 = new TooltipLine(mod, "Face", "Each barrier can stop 10 projectiles before it breaks");
            line3.overrideColor = new Color(120, 200, 240);
            tooltips.Add(line3);
            TooltipLine line4 = new TooltipLine(mod, "Face", "Has a high rate of reflection and summons a homing specral spirit upon being hit");
            line4.overrideColor = new Color(120, 200, 240);
            tooltips.Add(line4);
        }
        public override void SafeSetDefaults()
        {
            item.damage = 1;
            item.width = 50;
            item.height = 50;
            item.useTime = 20;
            item.useAnimation = 20;
            item.noUseGraphic = true;
            item.useStyle = 1;
            item.noMelee = true;
            item.value = Item.sellPrice(0, 1, 15, 0);
            item.rare = 3;
            item.UseSound = SoundID.Item39;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("SpectreDefenseKnivesProj");
            item.shootSpeed = 8f;
        }
    }

}
