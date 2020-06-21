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
            line.overrideColor = new Color(255, 60, 28);
            if (NPC.downedBoss2)
            {
                tooltips.Add(line);
            }

            if (p.VampiricArmorSet)
            {
                TooltipLine line4 = new TooltipLine(mod, "Face", "Set Bonus:");
                line4.overrideColor = new Color(255, 70, 38);
                tooltips.Add(line4);
                TooltipLine line3 = new TooltipLine(mod, "Face", "Enemies are more likely to target you\nHave a " + ((2f*p.VampiricSetScaler)/10f) + "% Chance to steal the life of the enemies around you upon being hit");
                line3.overrideColor = new Color(255, 70, 38);
                tooltips.Add(line3);
            }

            foreach (TooltipLine line5 in tooltips)
            {
                if (line5.mod == "Terraria" && line5.Name == "Equipable")
                {
                    line5.overrideColor = new Color(255, 40, 20);
                }
                if (line5.mod == "Terraria" && line5.Name == "Defense")
                {
                    line5.overrideColor = new Color(235, 32, 12);
                }
                if (line5.mod == "Terraria" && line5.Name == "Tooltip0")
                {
                    line5.overrideColor = new Color(215, 20, 2);
                }
                if (line5.mod == "Terraria" && line5.Name == "ItemName")
                {
                    if (Frame == 0)
                    {
                        line5.text = ("[c/FF3333:Psionic Hood]");
                    }
                    if (Frame == 1)
                    {
                        line5.text = ("[c/B48C8C:Ps][c/FF3333:ionic Hood]");
                    }
                    if (Frame == 2)
                    {
                        line5.text = ("[c/75D6D6:Ps][c/B48C8C:io][c/FF3333:nic Hood]");
                    }
                    if (Frame == 3)
                    {
                        line5.text = ("[c/B48C8C:Ps][c/75D6D6:io][c/B48C8C:ni][c/FF3333:c Hood]");
                    }
                    if (Frame == 4)
                    {
                        line5.text = ("[c/FF3333:Ps][c/B48C8C:io][c/75D6D6:ni][c/B48C8C:c][c/FF3333: Hood]");
                    }
                    if (Frame == 5)
                    {
                        line5.text = ("[c/FF3333:Psio][c/B48C8C:ni][c/75D6D6:c][c/B48C8C: Ho][c/FF3333:od]");
                    }
                    if (Frame == 6)
                    {
                        line5.text = ("[c/FF3333:Psioni][c/B48C8C:c][c/75D6D6: Ho][c/B48C8C:od]");
                    }
                    if (Frame == 7)
                    {
                        line5.text = ("[c/FF3333:Psionic][c/B48C8C: Ho][c/75D6D6:od]");
                    }
                    if (Frame == 8)
                    {
                        line5.text = ("[c/FF3333:Psionic Ho][c/B48C8C:od]");
                    }
                    if (Frame == 9)
                    {
                        line5.text = ("[c/FF3333:Psionic Hood]");
                    }
                }
            }
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<PsionicChestplate>() && legs.type == ModContent.ItemType<PsionicLeggings>();
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
            if (FrameCounter >= 4) //once the frameCounter has reached 3 - change the 10 to change how fast the projectile animates
            {
                FrameCounter = 0;
                Frame++; //go to the next frame
                if (Frame > 9) //if past the last frame
                    Frame = 0; //go back to the first frame
            }
        }
        public override void UpdateEquip(Player player)
        {
            FrameCounter++; //increase the frameCounter by one
            if (FrameCounter >= 4) //once the frameCounter has reached 3 - change the 10 to change how fast the projectile animates
            {
                FrameCounter = 0;
                Frame++; //go to the next frame
                if (Frame > 9) //if past the last frame
                    Frame = 0; //go back to the first frame
            }
            ExamplePlayer p = player.GetModPlayer<ExamplePlayer>();
            player.aggro += 300;
            //KnifeDamagePlayer d = player.GetModPlayer<KnifeDamagePlayer>();
            if (NPC.downedBoss2)
            {
                item.value = Item.sellPrice(0, 2, 0, 0);
                p.DefenseReflectChance = 1.2f;
                item.defense = 7;
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
                item.defense = 9;
            }
            if (Main.hardMode)
            {
                item.value = Item.sellPrice(0, 5, 0, 0);
                p.DefenseReflectChance = 1.6f;
                item.defense = 11;
            }
            if (NPC.downedMechBoss1)
            {
                item.value = Item.sellPrice(0, 6, 0, 0);
                p.DefenseReflectChance = 1.7f;
                item.defense = 13;
            }
            if (NPC.downedMechBoss2)
            {
                item.value = Item.sellPrice(0, 7, 0, 0);
                p.DefenseReflectChance = 1.8f;
                item.defense = 14;
            }
            if (NPC.downedMechBoss3)
            {
                item.value = Item.sellPrice(0, 8, 0, 0);
                p.DefenseReflectChance = 1.9f;
                item.defense = 15;
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