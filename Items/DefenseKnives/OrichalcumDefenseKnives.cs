using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace VampKnives.Items.DefenseKnives
{
    public class OrichalcumDefenseKnives : KnifeDefenseItem
    {
        public override void SetStaticDefaults()
        {
                DisplayName.SetDefault("Orichalcum Defense Knives");
                Tooltip.SetDefault("These knives form a protective Orichalcum wall when thrown");
            PlateType = ModContent.GetInstance<Items.Materials.Plates.OrichalcumPlate>();
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine line3 = new TooltipLine(mod, "Face", "Each barrier can stop 5 projectiles before it breaks");
            line3.overrideColor = new Color(240, 240, 240);
            tooltips.Add(line3);
            TooltipLine line4 = new TooltipLine(mod, "Face", "Summons petals from the aether to attack your enemies");
            line4.overrideColor = new Color(240, 240, 240);
            tooltips.Add(line4);
        }
        public override void SafeSetDefaults()
        {
            item.damage = 5;
            item.width = 42;
            item.height = 42;
            item.useTime = 24;
            item.useAnimation = 24;
            item.noUseGraphic = true;
            item.useStyle = 1;
            item.noMelee = true;
            item.value = Item.sellPrice(0, 1, 15, 0);
            item.rare = 3;
            item.UseSound = SoundID.Item39;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("OrichalcumDefenseKnivesProj");
            item.shootSpeed = 7f;
        }
    }

}
