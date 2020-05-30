using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.Materials.Plates
{
    public class MythrilPlate : PlateItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mythril Plate");
            BarType = ItemID.MythrilBar;
            Rarity = 4;
        }
    }
}