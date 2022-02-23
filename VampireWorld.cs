using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using VampKnives.Items.RecipePages;
using VampKnives.Tiles;
using static Terraria.ModLoader.ModContent;

namespace VampKnives
{
    public class VampireWorld : ModWorld
    {
        //public static List<int> AltarBeingUsed = new List<int>();
        //public static List<bool> RitualOfTheStone = new List<bool>();
        //public static List<ushort> RoEType = new List<ushort>();
        //public static List<bool> RitualOfTheMiner = new List<bool>();
        //public static List<ushort> RoMType = new List<ushort>();
        //public static List<bool> RitualOfMidas = new List<bool>();
        //public static List<short> RoMiType = new List<short>();
        //public static List<int> AltarOwner = new List<int>(); //MAKE INTO A LIST TO SET OWNER FOR EACH ALTAR
        //public static List<bool> RitualOfSouls = new List<bool>();
        //public static List<int> RoSoTypeAndDelay = new List<int>();
        //public static Vector2 MostRecentClick;

        static int DustTimer;
        int DustType;

        public override TagCompound Save()
        {
            Projectiles.DefenseKnivesProj.ProjCount.ShroomiteActiveGasCount = 0;
            Projectiles.DefenseKnivesProj.ProjCount.NumActiveAdamantite = 0;
            Projectiles.DefenseKnivesProj.ProjCount.NumActiveTitanium = 0;
            Projectiles.DefenseKnivesProj.ProjCount.NumActiveShroomite = 0;
            return null;
        }

        public override void PostWorldGen()
        {
            // Places some items in Chests
            int[] itemsToPlaceInChests = { ItemType<AmmoCastRecipe>(), ItemType<AmmoSculptRecipe>(), ItemType<PlateRecipe>(), ItemType<IronCastRecipe>(), ItemType<KnifeSculptRecipe>(), ItemType<SharpeningRodRecipe>(), ItemType<SharpeningSculptRecipe>() };
            for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
            {
                int NumberOfItems = Main.rand.Next(1,4);
                Chest chest = Main.chest[chestIndex];
                // If you look at the sprite for Chests by extracting Tiles_21.xnb, you'll see that the 12th chest is the Ice Chest. Since we are counting from 0, this is where 11 comes from. 36 comes from the width of each tile including padding. 
                if (chest != null && Main.tile[chest.x, chest.y].type == TileID.Containers && Main.tile[chest.x, chest.y].frameX == 0 * 36)
                {
                    for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                    {
                        if (chest.item[inventoryIndex].type == ItemID.None)
                        {
                            for (int NumIterations = 0; NumIterations < NumberOfItems; NumIterations++)
                            {
                                chest.item[inventoryIndex + NumIterations].SetDefaults(Main.rand.Next(itemsToPlaceInChests));
                            }
                            break;
                        }
                    }
                }
            }
        }
    }
}