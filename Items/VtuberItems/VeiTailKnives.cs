using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace VampKnives.Items.VtuberItems
{
    public class VeiTailKnives : KnifeDamageItem
    {
        ////TO CALL A MOD
        //Mod Calamity = ModLoader.GetMod("CalamityMod");
        public override void SetStaticDefaults()
        {
            //Defaults
            DisplayName.SetDefault("Succubus's Tails");
            Tooltip.SetDefault("A succubus's tail is arguably more dangerous than her eyes\nPulls enemies in towards you and stuns them\nEnemies affected by gravity take fall damage after being released");
        }
        public override void SafeSetDefaults()
        {
            item.damage = 69; //PUT DAMAGE, GENERALLY 1/2 OF COMPONENT'S DAMAGE
            item.width = 66;
            item.height = 52;
            item.autoReuse = true;
            item.useStyle = 5;
            item.useTurn = true;
            item.channel = true;
            item.useAnimation = 2;
            item.useTime = 2;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.knockBack = 3;
            item.value = Item.sellPrice(0, 69, 4, 20);
            item.rare = 10; // -1 = Grey; 0 = White; 1 = Blue; 2 = Green; 3 = Orange; 4 = Light Red
            //5 = Pink; 6 = Light Purple; 7 = Lime; 8 = Yellow; 9 = Cyan; 10 = Red; 11 = Purple
            //-12 = Rainbow; -2 = Amber
            item.UseSound = SoundID.Item39; //Default 39
            item.shoot = mod.ProjectileType("VeiTailProj");
            item.shootSpeed = 60f;
        }
    }
}
