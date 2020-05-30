using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.Materials.Plates
{
    public class GoldPlate : PlateItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gold Plate");
            BarType = ItemID.GoldBar;
            Rarity = 0;
        }
    }
}