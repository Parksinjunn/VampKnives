using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.BossDrops
{
    public class BloomingTerror : KnifeDamageItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blooming Terror");
            Tooltip.SetDefault("It's growing out of control");
        }
        public override void SafeSetDefaults()
        {
            item.damage = 32; //PUT DAMAGE, GENERALLY 1/2 OF COMPONENT'S DAMAGE
            item.width = 68;
            item.height = 68;
            item.useTime = 15;
            item.useAnimation = 15;
            item.noUseGraphic = true;
            item.useStyle = 1;
            item.crit = 15;
            item.noMelee = true;
            item.knockBack = 3;
            item.value = Item.sellPrice(0, 12, 50, 0); //10000 = 1 gold, 100 silver, or 10000 copper
            item.rare = 2; // -1 = Grey; 0 = White; 1 = Blue; 2 = Green; 3 = Orange; 4 = Light Red
            //5 = Pink; 6 = Light Purple; 7 = Lime; 8 = Yellow; 9 = Cyan; 10 = Red; 11 = Purple
            //-12 = Rainbow; -2 = Amber
            item.UseSound = SoundID.Item39; //Default 39
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("BloomingTerrorProj");
            item.shootSpeed = 15f;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach (TooltipLine line2 in tooltips)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.text = "[c/33FF00:Bl][c/77AA44:oo][c/BB5588:mi][c/FF00CC:ng] [c/BB5588:Te][c/77AA44:rr][c/33FF00:or]";
                }
                if (line2.mod == "Terraria" && line2.Name == "Damage")
                {
                    line2.overrideColor = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB);
                }
                if (line2.mod == "Terraria" && line2.Name == "CritChance")
                {
                    line2.overrideColor = new Color(Main.DiscoG, Main.DiscoR, Main.DiscoB);
                }
                if (line2.mod == "Terraria" && line2.Name == "Speed")
                {
                    line2.overrideColor = new Color(Main.DiscoB, Main.DiscoR, Main.DiscoG);
                }
                if (line2.mod == "Terraria" && line2.Name == "Knockback")
                {
                    line2.overrideColor = new Color(Main.DiscoG, Main.DiscoB, Main.DiscoR);
                }
                if (line2.mod == "Terraria" && line2.Name == "Tooltip0")
                {
                    line2.overrideColor = new Color(Main.DiscoR, Main.DiscoB, Main.DiscoG);
                }
            }
        }
    }
}
