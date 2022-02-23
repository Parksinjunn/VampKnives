using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.Materials
{
    public class StoneAmmoSculptComplete : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sculpted knife ammo");
            Tooltip.SetDefault("A rough sculpt of throwing knives");
        }
        public override void SetDefaults()
        {
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 0, 2, 0) ;
            item.rare = -1;
        }
        public override bool CloneNewInstances
        {
            get
            {
                return true;
            }
        }
        public bool crafted;
        public override void OnCraft(Recipe recipe)
        {
            crafted = true;
        }
        public override void UpdateInventory(Player player)
        {
            crafted = true;
        }
    }
}