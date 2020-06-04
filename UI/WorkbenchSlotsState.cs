using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using static Terraria.ModLoader.ModContent;

namespace VampKnives.UI
{
    internal class WorkbenchSlotState : UIState
    {
        public static bool visible = false;
        public HammerSlot HammerSlot;
        public ChiselSlot ChiselSlot;

        public override void OnInitialize()
        {

            HammerSlot = new HammerSlot();
            base.Append(HammerSlot);

            ChiselSlot = new ChiselSlot();
            base.Append(ChiselSlot);
        }
    }
}