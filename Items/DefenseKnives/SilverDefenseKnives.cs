using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace VampKnives.Items.DefenseKnives
{
    public class SilverDefenseKnives : KnifeDefenseItem
    {
        public override void SetStaticDefaults()
        {
                DisplayName.SetDefault("Silver Defense Knives");
                Tooltip.SetDefault("These knives form a protective Silver wall when thrown");
            PlateType = ModContent.GetInstance<Items.Materials.Plates.SilverPlate>();
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine line3 = new TooltipLine(mod, "Face", "Each barrier can stop 3 projectiles before it breaks");
            line3.overrideColor = new Color(240, 240, 240);
            tooltips.Add(line3);
        }
        public override void SafeSetDefaults()
        {
            item.damage = 1;
            item.width = 50;
            item.height = 50;
            item.useTime = 30;
            item.useAnimation = 30;
            item.noUseGraphic = true;
            item.useStyle = 1;
            item.noMelee = true;
            item.value = Item.sellPrice(0, 1, 15, 0);
            item.rare = 3;
            item.UseSound = SoundID.Item39;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("SilverDefenseKnivesProj");
            item.shootSpeed = 6f;
        }
    }

}
