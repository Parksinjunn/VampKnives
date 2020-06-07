using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace VampKnives.Items
{
    public class ButchersKnives : KnifeDamageItem
    {
        ////TO CALL A MOD
        //Mod Calamity = ModLoader.GetMod("CalamityMod");
        public override void SetStaticDefaults()
        {
            ////IF MOD EXCLUSIVE
            //if (Calamity != null)
            //{
            //    DisplayName.SetDefault("KNIFENAME");
            //    Tooltip.SetDefault("KNIFEDESCRIPTION");
            //}
            //else
            //{
            //    DisplayName.SetDefault("KNIFENAME");
            //    Tooltip.SetDefault("Please enable Calamity");
            //}

            ////FOR ANIMATIONS
            //Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 13));

            //Defaults
            DisplayName.SetDefault("Butcher's Knives");
            Tooltip.SetDefault("A Random Assortment of Knives");
        }
        public override void SafeSetDefaults()
        {
            item.damage = 13; //PUT DAMAGE, GENERALLY 1/2 OF COMPONENT'S DAMAGE
            item.width = 50;
            item.height = 50;
            item.useTime = 30;
            item.useAnimation = 30;
            item.noUseGraphic = true;
            item.useStyle = 1;
            item.noMelee = true;
            item.knockBack = 3;
            item.value = Item.sellPrice(0,0, 50,0); //10000 = 1 gold, 100 silver, or 10000 copper
            item.rare = 10; // -1 = Grey; 0 = White; 1 = Blue; 2 = Green; 3 = Orange; 4 = Light Red
            //5 = Pink; 6 = Light Purple; 7 = Lime; 8 = Yellow; 9 = Cyan; 10 = Red; 11 = Purple
            //-12 = Rainbow; -2 = Amber
            item.UseSound = SoundID.NPCHit4; //Default 39
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("ButchersKnivesProj");
            item.shootSpeed = 15f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BloodButcherer, 1);
            recipe.AddIngredient(ItemID.CrimtaneBar, 10);
            recipe.AddIngredient(ItemID.Vertebrae, 5);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BloodButcherer, 1);
            recipe.AddIngredient(ItemID.CrimtaneBar, 8);
            recipe.AddIngredient(ItemID.Vertebrae, 3);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

}
