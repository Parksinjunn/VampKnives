using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace VampKnives.Items.DefenseKnives
{
    public class AdamantiteDefenseKnives : KnifeDefenseItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Adamantite Defense Knives");
            Tooltip.SetDefault("These knives form a protective Adamantite wall when thrown");
            PlateType = ModContent.GetInstance<Items.Materials.Plates.AdamantitePlate>();
        }
        public override void SafeSetDefaults()
        {
            item.damage = 6;
            item.width = 50;
            item.height = 50;
            item.useTime = 26;
            item.useAnimation = 26;
            item.noUseGraphic = true;
            item.useStyle = 1;
            item.noMelee = true;
            item.value = Item.sellPrice(0, 1, 15, 0);
            item.rare = 3;
            item.UseSound = SoundID.Item39;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("AdamantiteDefenseKnivesProj");
            item.shootSpeed = 7f;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine line3 = new TooltipLine(mod, "Face", "Each barrier can stop 6 projectiles before it breaks");
            line3.overrideColor = new Color(240, 240, 240);
            tooltips.Add(line3);
            TooltipLine line4 = new TooltipLine(mod, "Face", "Anyone in proximity has a 15% chance to recieve the shadow dodge buff");
            line4.overrideColor = new Color(240, 240, 240);
            tooltips.Add(line4);
        }
    }

}
