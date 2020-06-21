using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class PsionicChestplate : KnifeItem
    {
        public int percentage;
        public int numProj;
        public int Frame = 0;
        public int FrameCounter = 0;
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Psionic Chestplate");
            Tooltip.SetDefault("Threaded with pulsing energy.");
        }

        public override void SafeSetDefaults()
        {
            item.width = 30;
            item.height = 20;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 2;
            item.defense = 2;
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
                percentage = 5;
                numProj = 1;
            }
            if (NPC.downedQueenBee)
            {
                percentage = 6;
                numProj = 2;
            }
            if (NPC.downedBoss3)
            {
                percentage = 8;
                numProj = 3;
            }
            if (Main.hardMode)
            {
                percentage = 10;
                numProj = 4;
            }
            if (NPC.downedMechBoss1)
            {
                percentage = 12;
                numProj = 5;
            }
            if (NPC.downedMechBoss2)
            {
                percentage = 14;
                numProj = 6;
            }
            if (NPC.downedMechBoss3)
            {
                percentage = 16;
                numProj = 7;
            }
            if (NPC.downedPlantBoss)
            {
                percentage = 18;
                numProj = 8;
            }
            if (NPC.downedGolemBoss)
            {
                percentage = 20;
                numProj = 9;
            }
            if (NPC.downedFishron)
            {
                percentage = 22;
                numProj = 10;
            }
            if (NPC.downedAncientCultist)
            {
                percentage = 25;
                numProj = 11;
            }
            if (NPC.downedTowers)
            {
                percentage = 30;
                numProj = 12;
            }
            ExamplePlayer p = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
            TooltipLine line2 = new TooltipLine(mod, "Face", "Adds: " + Math.Round((p.DelayAdd / 60), 3) + " seconds to 'Blood Essence' decay delay");
            line2.overrideColor = new Color(255, 60, 28);
            tooltips.Add(line2);
            TooltipLine line = new TooltipLine(mod, "Face", "+ " + percentage + "% Knife Damage");
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
                        line5.text = ("[c/FF3333:Psionic Chestplate]");
                    }
                    if (Frame == 1)
                    {
                        line5.text = ("[c/B48C8C:Ps][c/FF3333:ionic Chestplate]");
                    }
                    if (Frame == 2)
                    {
                        line5.text = ("[c/75D6D6:Ps][c/B48C8C:io][c/FF3333:nic Chestplate]");
                    }
                    if (Frame == 3)
                    {
                        line5.text = ("[c/B48C8C:Ps][c/75D6D6:io][c/B48C8C:ni][c/FF3333:c Chestplate]");
                    }
                    if (Frame == 4)
                    {
                        line5.text = ("[c/FF3333:Ps][c/B48C8C:io][c/75D6D6:ni][c/B48C8C:c][c/FF3333: Chestplate]");
                    }
                    if (Frame == 5)
                    {
                        line5.text = ("[c/FF3333:Psio][c/B48C8C:ni][c/75D6D6:c][c/B48C8C: Ch][c/FF3333:estplate]");
                    }
                    if (Frame == 6)
                    {
                        line5.text = ("[c/FF3333:Psioni][c/B48C8C:c][c/75D6D6: Ch][c/B48C8C:es][c/FF3333:tplate]");
                    }
                    if (Frame == 7)
                    {
                        line5.text = ("[c/FF3333:Psionic][c/B48C8C: Ch][c/75D6D6:es][c/B48C8C:tp][c/FF3333:late]");
                    }
                    if (Frame == 8)
                    {
                        line5.text = ("[c/FF3333:Psionic Ch][c/B48C8C:es][c/75D6D6:tp][c/B48C8C:la][c/FF3333:te]");
                    }
                    if (Frame == 9)
                    {
                        line5.text = ("[c/FF3333:Psionic Ches][c/B48C8C:tp][c/75D6D6:la][c/B48C8C:te]");
                    }
                    if (Frame == 10)
                    {
                        line5.text = ("[c/FF3333:Psionic Chestp][c/B48C8C:la][c/75D6D6:te]");
                    }
                    if (Frame == 11)
                    {
                        line5.text = ("[c/FF3333:Psionic Chestpla][c/B48C8C:te]");
                    }
                    if (Frame == 12)
                    {
                        line5.text = ("[c/FF3333:Psionic Chestplate]");
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
                if (Frame > 12) //if past the last frame
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
                if (Frame > 12) //if past the last frame
                    Frame = 0; //go back to the first frame
            }
            ExamplePlayer p = player.GetModPlayer<ExamplePlayer>();
            KnifeDamagePlayer d = player.GetModPlayer<KnifeDamagePlayer>();
            p.DelayAdd = 10;
            if (NPC.downedBoss2)
            {
                p.DelayAdd = 20;
                d.knifeDamageMult += 0.05f;
                item.value = Item.sellPrice(0, 2, 0, 0);
                item.defense = 3;
            }
            if (NPC.downedQueenBee)
            {
                p.DelayAdd = 30;
                d.knifeDamageMult += 0.06f;
                item.value = Item.sellPrice(0, 3, 0, 0);
            }
            if (NPC.downedBoss3)
            {
                p.DelayAdd = 30;
                d.knifeDamageMult += 0.08f;
                item.value = Item.sellPrice(0, 4, 0, 0);
                item.defense = 4;
            }
            if (Main.hardMode)
            {
                p.DelayAdd = 40;
                d.knifeDamageMult += 0.10f;
                item.value = Item.sellPrice(0, 5, 0, 0);
                item.defense = 6;
            }
            if (NPC.downedMechBoss1)
            {
                p.DelayAdd = 50;
                d.knifeDamageMult += 0.12f;
                item.value = Item.sellPrice(0, 6, 0, 0);
                item.defense = 7;
            }
            if (NPC.downedMechBoss2)
            {
                p.DelayAdd = 55;
                d.knifeDamageMult += 0.14f;
                item.value = Item.sellPrice(0, 7, 0, 0);
                item.defense = 8;
            }
            if (NPC.downedMechBoss3)
            {
                p.DelayAdd = 60;
                d.knifeDamageMult += 0.16f;
                item.value = Item.sellPrice(0, 8, 0, 0);
                item.defense = 9;
            }
            if (NPC.downedPlantBoss)
            {
                p.DelayAdd = 70;
                d.knifeDamageMult += 0.18f;
                item.value = Item.sellPrice(0, 9, 0, 0);
                item.defense = 10;
            }
            if (NPC.downedGolemBoss)
            {
                p.DelayAdd = 80;
                d.knifeDamageMult += 0.20f;
                item.value = Item.sellPrice(0, 10, 0, 0);
                item.defense = 12;
            }
            if (NPC.downedFishron)
            {
                p.DelayAdd = 90;
                d.knifeDamageMult += 0.22f;
                item.value = Item.sellPrice(0, 12, 0, 0);
                item.defense = 14;
            }
            if (NPC.downedAncientCultist)
            {
                p.DelayAdd = 100;
                d.knifeDamageMult += 0.25f;
                item.value = Item.sellPrice(0, 14, 0, 0);
                item.defense = 16;
            }
            if (NPC.downedTowers)
            {
                p.DelayAdd = 120;
                d.knifeDamageMult += 0.30f;
                item.value = Item.sellPrice(0, 16, 0, 0);
                item.defense = 18;
            }
        }
    }
}