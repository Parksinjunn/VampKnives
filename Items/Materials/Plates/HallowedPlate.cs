using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.Materials.Plates
{
    public class HallowedPlate : PlateItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hallowed Plate");
            BarType = ItemID.HallowedBar;
            Rarity = 4;
        }
    }
}