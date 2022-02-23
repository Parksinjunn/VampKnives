using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using System.IO;

namespace VampKnives.Items.Misc
{
    public class BloodCrystalSoul : ModItem
    {
        public int NPCID;
        public string NPCName;
        public override bool CloneNewInstances => true;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blood Crystal");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(8, 7));
        }
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 30;
            item.maxStack = 1;
            item.value = Item.sellPrice(silver: 1);
            NPCID = -69;
            NPCName = "ERROR THROW ON GROUND";
        }
        public override void Update(ref float gravity, ref float maxFallSpeed)
        {
            if(NPCID != -69)
            {
                NPC n = new NPC();
                n.SetDefaults(NPCID);
                NPCName = n.FullName;
            }
            base.Update(ref gravity, ref maxFallSpeed);
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (NPCID != -69)
            {
                TooltipLine line = new TooltipLine(mod, "DamageMod", "NPC: " + NPCName)
                {
                    overrideColor = Color.Red
                };
                tooltips.Add(line);
            }
            else if (NPCID == -69)
            {
                TooltipLine line = new TooltipLine(mod, "DamageMod", "Empty")
                {
                    overrideColor = Color.DarkRed
                };
                tooltips.Add(line);
            }
        }

        public override TagCompound Save()
        {
            return new TagCompound {
                {"NPCID", NPCID},
                {"NPCName", NPCName },
            };
        }
        public override void Load(TagCompound tag)
        {
            NPCID = tag.GetInt("NPCID");
            NPCName = tag.GetString("NPCName");
        }

        public override void NetSend(BinaryWriter writer)
        {
            writer.Write(NPCID);
            writer.Write(NPCName);
        }
        public override void NetRecieve(BinaryReader reader)
        {
            NPCID = reader.ReadInt32();
            NPCName = reader.ReadString();
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(this);
            recipe.AddTile(ModContent.TileType<Tiles.VampTableTile>());
            recipe.SetResult(this);
            recipe.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(ModContent.ItemType<Materials.CrimsonCrystal>());
            recipe2.AddIngredient(ItemID.Ectoplasm, 10);
            recipe2.AddIngredient(ItemID.Ruby, 1);
            recipe2.AddIngredient(ItemID.Blinkroot, 5);
            recipe2.AddIngredient(ItemID.Moonglow, 5);
            recipe2.AddTile(ModContent.TileType<Tiles.VampTableTile>());
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }
    }
}