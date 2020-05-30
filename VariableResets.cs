using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using VampKnives.Items.RecipePages;
using static Terraria.ModLoader.ModContent;

namespace VampKnives
{
    public class VariableResets : ModWorld
    {
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