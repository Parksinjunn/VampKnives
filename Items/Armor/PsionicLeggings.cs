﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class PsionicLeggings : KnifeItem
    {
        public int percentage;
        public int numProj;
        public int Frame;
        public int FrameCounter;
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Psionic Leggings");
            Tooltip.SetDefault("Threaded with pulsing energy.");
        }

        public override void SafeSetDefaults()
        {
            item.width = 30;
            item.height = 20;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 2;
            item.defense = 1;
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
            if (NPC.downedBoss2)
            {
                percentage = 1;
                numProj = 1;
            }
            if (NPC.downedQueenBee)
            {
                percentage = 2;
                numProj = 2;
            }
            if (NPC.downedBoss3)
            {
                percentage = 4;
                numProj = 3;
            }
            if (Main.hardMode)
            {
                percentage = 8;
                numProj = 4;
            }
            if (NPC.downedMechBoss1)
            {
                percentage = 10;
                numProj = 5;
            }
            if (NPC.downedMechBoss2)
            {
                percentage = 12;
                numProj = 6;
            }
            if (NPC.downedMechBoss3)
            {
                percentage = 14;
                numProj = 7;
            }
            if (NPC.downedPlantBoss)
            {
                percentage = 15;
                numProj = 8;
            }
            if (NPC.downedGolemBoss)
            {
                percentage = 16;
                numProj = 9;
            }
            if (NPC.downedFishron)
            {
                percentage = 18;
                numProj = 10;
            }
            if (NPC.downedAncientCultist)
            {
                percentage = 19;
                numProj = 11;
            }
            if (NPC.downedTowers)
            {
                percentage = 20;
                numProj = 12;
            }
            KnifeDamagePlayer d = Main.LocalPlayer.GetModPlayer<KnifeDamagePlayer>();
            VampPlayer p = Main.LocalPlayer.GetModPlayer<VampPlayer>();
            TooltipLine line2 = new TooltipLine(mod, "Face", "+ " + d.KnifeCrit + "% crit chance.");
            line2.overrideColor = new Color(255, 60, 28);
            if (NPC.downedBoss2)
            {
                tooltips.Add(line2);
            }
            TooltipLine line = new TooltipLine(mod, "Face", "+ " + percentage + "% Movement Speed.");
            line.overrideColor = new Color(255, 60, 28);
            if (NPC.downedBoss2)
            {
                tooltips.Add(line);
            }
            if (p.PsionicArmorSet)
            {
                TooltipLine line4 = new TooltipLine(mod, "Face", "Set Bonus:");
                line4.overrideColor = new Color(255, 70, 38);
                tooltips.Add(line4);
                TooltipLine line3 = new TooltipLine(mod, "Face", "+ 4% chance to spawn " + numProj + " 'homing projectiles'");
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
                        line5.text = ("[c/FF3333:Psionic Leggings]");
                    }
                    if (Frame == 1)
                    {
                        line5.text = ("[c/B48C8C:Ps][c/FF3333:ionic Leggings]");
                    }
                    if (Frame == 2)
                    {
                        line5.text = ("[c/75D6D6:Ps][c/B48C8C:io][c/FF3333:nic Leggings]");
                    }
                    if (Frame == 3)
                    {
                        line5.text = ("[c/B48C8C:Ps][c/75D6D6:io][c/B48C8C:ni][c/FF3333:c Leggings]");
                    }
                    if (Frame == 4)
                    {
                        line5.text = ("[c/FF3333:Ps][c/B48C8C:io][c/75D6D6:ni][c/B48C8C:c][c/FF3333: Leggings]");
                    }
                    if (Frame == 5)
                    {
                        line5.text = ("[c/FF3333:Psio][c/B48C8C:ni][c/75D6D6:c][c/B48C8C: Le][c/FF3333:ggings]");
                    }
                    if (Frame == 6)
                    {
                        line5.text = ("[c/FF3333:Psioni][c/B48C8C:c][c/75D6D6: Le][c/B48C8C:gg][c/FF3333:ings]");
                    }
                    if (Frame == 7)
                    {
                        line5.text = ("[c/FF3333:Psionic][c/B48C8C: Le][c/75D6D6:gg][c/B48C8C:in][c/FF3333:gs]");
                    }
                    if (Frame == 8)
                    {
                        line5.text = ("[c/FF3333:Psionic Le][c/B48C8C:gg][c/75D6D6:in][c/B48C8C:gs]");
                    }
                    if (Frame == 9)
                    {
                        line5.text = ("[c/FF3333:Psionic Legg][c/B48C8C:in][c/75D6D6:gs]");
                    }
                    if (Frame == 10)
                    {
                        line5.text = ("[c/FF3333:Psionic Leggin][c/B48C8C:gs]");
                    }
                    if (Frame == 11)
                    {
                        line5.text = ("[c/FF3333:Psionic Leggings]");
                    }
                }
            }
        }

        public override void UpdateInventory(Player player)
        {
            FrameCounter++; //increase the frameCounter by one
            if (FrameCounter >= 4) //once the frameCounter has reached 3 - change the 10 to change how fast the projectile animates
            {
                FrameCounter = 0;
                Frame++; //go to the next frame
                if (Frame > 11) //if past the last frame
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
                if (Frame > 11) //if past the last frame
                    Frame = 0; //go back to the first frame
            }
            KnifeDamagePlayer d = player.GetModPlayer<KnifeDamagePlayer>();
            if (NPC.downedBoss2)
            {
                player.moveSpeed += 0.01f;
                d.KnifeCrit += 1;
                item.value = Item.sellPrice(0, 2, 0, 0);
                item.defense = 2;
            }
            if (NPC.downedQueenBee)
            {
                player.moveSpeed += 0.02f;
                d.KnifeCrit += 1;
                item.value = Item.sellPrice(0, 3, 0, 0);
            }
            if (NPC.downedBoss3)
            {
                player.moveSpeed += 0.04f;
                d.KnifeCrit += 2;
                item.value = Item.sellPrice(0, 4, 0, 0);
                item.defense = 3;
            }
            if (Main.hardMode)
            {
                player.moveSpeed += 0.08f;
                d.KnifeCrit += 2;
                item.value = Item.sellPrice(0, 5, 0, 0);
                item.defense = 5;
            }
            if (NPC.downedMechBoss1)
            {
                player.moveSpeed += 0.1f;
                d.KnifeCrit += 3;
                item.value = Item.sellPrice(0, 6, 0, 0);
                item.defense = 6;
            }
            if (NPC.downedMechBoss2)
            {
                player.moveSpeed += 0.12f;
                d.KnifeCrit += 4;
                item.value = Item.sellPrice(0, 7, 0, 0);
                item.defense = 7;
            }
            if (NPC.downedMechBoss3)
            {
                player.moveSpeed += 0.14f;
                d.KnifeCrit += 5;
                item.value = Item.sellPrice(0, 8, 0, 0);
                item.defense = 8;
            }
            if (NPC.downedPlantBoss)
            {
                player.moveSpeed += 0.15f;
                d.KnifeCrit += 6;
                item.value = Item.sellPrice(0, 9, 0, 0);
                item.defense = 9;
            }
            if (NPC.downedGolemBoss)
            {
                player.moveSpeed += 0.16f;
                d.KnifeCrit += 7;
                item.value = Item.sellPrice(0, 10, 0, 0);
                item.defense = 10;
            }
            if (NPC.downedFishron)
            {
                player.moveSpeed += 0.18f;
                d.KnifeCrit += 8;
                item.value = Item.sellPrice(0, 12, 0, 0);
                item.defense = 11;
            }
            if (NPC.downedAncientCultist)
            {
                player.moveSpeed += 0.19f;
                d.KnifeCrit += 9;
                item.value = Item.sellPrice(0, 14, 0, 0);
                item.defense = 12;
            }
            if (NPC.downedTowers)
            {
                player.moveSpeed += 0.20f;
                d.KnifeCrit += 10;
                item.value = Item.sellPrice(0, 16, 0, 0);
                item.defense = 14;
            }
        }
    }
}