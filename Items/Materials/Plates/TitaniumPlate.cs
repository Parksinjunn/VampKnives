using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.Materials.Plates
{
    public class TitaniumPlate : PlateItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Titanium Plate");
            BarType = ItemID.TitaniumBar;
            Rarity = 4;
        }
    }
}