using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class VampiricHelm : KnifeItem
    {
        public int Frame;
        public int FrameCounter;
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Vampiric Helm");
            Tooltip.SetDefault("");
        }

        public override void SafeSetDefaults()
        {
            item.width = 30;
            item.height = 20;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 2;
            item.defense = 5;
        }

        public override bool CloneNewInstances
        {
            get
            {
                return true;
            }
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            ExamplePlayer p = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
            TooltipLine line = new TooltipLine(mod, "Face", "+" + ((p.DefenseReflectChance-1))*100 + "% reflect chance");
            line.overrideColor = new Color(160, 0, 0);
            if (NPC.downedBoss2)
            {
                tooltips.Add(line);
            }

            if (p.VampiricArmorSet)
            {
                TooltipLine line4 = new TooltipLine(mod, "Face", "Set Bonus:");
                line4.overrideColor = new Color(180, 0, 0);
                tooltips.Add(line4);
                TooltipLine line3 = new TooltipLine(mod, "Face", "Enemies are more likely to target you\nHave a " + ((2f*p.VampiricSetScaler)/10f) + "% Chance to steal the life of the enemies around you upon being hit");
                line3.overrideColor = new Color(180, 0, 0);
                tooltips.Add(line3);
            }

            foreach (TooltipLine line5 in tooltips)
            {
                if (line5.mod == "Terraria" && line5.Name == "Equipable")
                {
                    line5.overrideColor = new Color(160, 0, 0);
                }
                if (line5.mod == "Terraria" && line5.Name == "Defense")
                {
                    line5.overrideColor = new Color(160, 0, 0);
                }
                if (line5.mod == "Terraria" && line5.Name == "Tooltip0")
                {
                    line5.overrideColor = new Color(160, 0, 0);
                }
                if (line5.mod == "Terraria" && line5.Name == "ItemName")
                {
                    if (Frame == 0)
                    {
                        line5.text = ("[c/3B0000:Vampiric Helm]");
                    }
                    if(Frame == 1)
                    {
                        line5.text = ("[c/730600:Vampiric Helm]");
                    }
                    if (Frame == 2)
                    {
                        line5.text = ("[c/AD0900:Vampiric Helm]");
                    }
                    if (Frame == 3)
                    {
                        line5.text = ("[c/730600:Vampiric Helm]");
                    }
                }
            }
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<VampiricChestplate>() && legs.type == ModContent.ItemType<VampiricGreaves>();
        }

        public override void UpdateArmorSet(Player player)
        {
            ExamplePlayer p = player.GetModPlayer<ExamplePlayer>();
            p.VampiricArmorSet = true;
            if (NPC.downedBoss2)
            {
                p.VampiricSetScaler = 1.5f;
            }
            if (NPC.downedBoss3)
            {
                p.VampiricSetScaler = 2f;
            }
            if (Main.hardMode)
            {
                p.VampiricSetScaler = 2.5f;
            }
            if (NPC.downedMechBoss1)
            {
                p.VampiricSetScaler = 3f;
            }
            if (NPC.downedMechBoss2)
            {
                p.VampiricSetScaler = 3.5f;
            }
            if (NPC.downedMechBoss3)
            {
                p.VampiricSetScaler = 4f;
            }
            if (NPC.downedPlantBoss)
            {
                p.VampiricSetScaler = 4.5f;
            }
            if (NPC.downedGolemBoss)
            {
                p.VampiricSetScaler = 5f;
            }
            if (NPC.downedFishron)
            {
                p.VampiricSetScaler = 5.5f;
            }
            if (NPC.downedAncientCultist)
            {
                p.VampiricSetScaler = 6f;
            }
            if (NPC.downedTowers)
            {
                p.VampiricSetScaler = 7f;
            }
            if (NPC.downedMoonlord)
            {
                p.VampiricSetScaler = 10f;
            }
        }
        public override void UpdateInventory(Player player)
        {
            FrameCounter++; //increase the frameCounter by one
            if (FrameCounter >= 8) //once the frameCounter has reached 3 - change the 10 to change how fast the projectile animates
            {
                FrameCounter = 0;
                Frame++; //go to the next frame
                if (Frame > 3) //if past the last frame
                    Frame = 0; //go back to the first frame
            }
        }
        public override void UpdateEquip(Player player)
        {
            FrameCounter++; //increase the frameCounter by one
            if (FrameCounter >= 8) //once the frameCounter has reached 3 - change the 10 to change how fast the projectile animates
            {
                FrameCounter = 0;
                Frame++; //go to the next frame
                if (Frame > 3) //if past the last frame
                    Frame = 0; //go back to the first frame
            }
            ExamplePlayer p = player.GetModPlayer<ExamplePlayer>();
            player.aggro += 300;
            //KnifeDamagePlayer d = player.GetModPlayer<KnifeDamagePlayer>();
            if (NPC.downedBoss2)
            {
                item.value = Item.sellPrice(0, 2, 0, 0);
                p.DefenseReflectChance = 1.2f;
                item.defense = 5;
            }
            if (NPC.downedQueenBee)
            {
                item.value = Item.sellPrice(0, 3, 0, 0);
                p.DefenseReflectChance = 1.3f;
            }
            if (NPC.downedBoss3)
            {
                item.value = Item.sellPrice(0, 4, 0, 0);
                p.DefenseReflectChance = 1.5f;
                item.defense = 7;
            }
            if (Main.hardMode)
            {
                item.value = Item.sellPrice(0, 5, 0, 0);
                p.DefenseReflectChance = 1.6f;
                item.defense = 10;
            }
            if (NPC.downedMechBoss1)
            {
                item.value = Item.sellPrice(0, 6, 0, 0);
                p.DefenseReflectChance = 1.7f;
                item.defense = 12;
            }
            if (NPC.downedMechBoss2)
            {
                item.value = Item.sellPrice(0, 7, 0, 0);
                p.DefenseReflectChance = 1.8f;
                item.defense = 13;
            }
            if (NPC.downedMechBoss3)
            {
                item.value = Item.sellPrice(0, 8, 0, 0);
                p.DefenseReflectChance = 1.9f;
                item.defense = 14;
            }
            if (NPC.downedPlantBoss)
            {
                item.value = Item.sellPrice(0, 9, 0, 0);
                p.DefenseReflectChance = 2.1f;
                item.defense = 16;
            }
            if (NPC.downedGolemBoss)
            {
                item.value = Item.sellPrice(0, 10, 0, 0);
                p.DefenseReflectChance = 2.2f;
                item.defense = 18;
            }
            if (NPC.downedFishron)
            {
                item.value = Item.sellPrice(0, 12, 0, 0);
                p.DefenseReflectChance = 2.5f;
                item.defense = 20;
            }
            if (NPC.downedAncientCultist)
            {
                item.value = Item.sellPrice(0, 14, 0, 0);
                p.DefenseReflectChance = 3f;
                item.defense = 22;
            }
            if (NPC.downedTowers)
            {
                item.value = Item.sellPrice(0, 16, 0, 0);
                p.DefenseReflectChance = 4f;
                item.defense = 24;
            }
            if (NPC.downedMoonlord)
            {
                item.value = Item.sellPrice(0, 20, 0, 0);
                p.DefenseReflectChance = 5f;
                item.defense = 32;
            }
        }
    }
}