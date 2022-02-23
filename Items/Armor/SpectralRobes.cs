using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class SpectralRobes : KnifeItem
    {
        int StatManaBonus;
        public int Frame = 0;
        public int FrameCounter = 0;
        public int Switch = 1;
        public float MagicDamage;
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Spectral Robes");
            Tooltip.SetDefault("");
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
            VampPlayer p = Main.LocalPlayer.GetModPlayer<VampPlayer>();
            KnifeDamagePlayer d = Main.LocalPlayer.GetModPlayer<KnifeDamagePlayer>();
            TooltipLine line = new TooltipLine(mod, "Face", "+" + (int)(((d.knifeDamageMult*100)*0.00341)*100) + "% Knife and Magic Damage");
            line.overrideColor = new Color(50, 158, 194);
            TooltipLine line2 = new TooltipLine(mod, "Face", "+" + StatManaBonus + " Mana");
            line2.overrideColor = new Color(50, 158, 194);
            if (NPC.downedBoss2)
            {
                tooltips.Add(line);
            }
            if(NPC.downedBoss3)
            {
                tooltips.Add(line2);
            }

            if (p.SupportArmor)
            {
                TooltipLine line4 = new TooltipLine(mod, "Face", "Set Bonus:");
                line4.overrideColor = new Color(50, 182, 194);
                tooltips.Add(line4);
                TooltipLine line3 = new TooltipLine(mod, "Face", "By pressing the support buff key you use \nStored charges (indicated by visor intensity)\nto buff the players around you");
                line3.overrideColor = new Color(50, 182, 194);
                tooltips.Add(line3);
            }

            foreach (TooltipLine line5 in tooltips)
            {
                if (line5.mod == "Terraria" && line5.Name == "Equipable")
                {
                    line5.overrideColor = new Color(50, 158, 194);
                }
                if (line5.mod == "Terraria" && line5.Name == "Defense")
                {
                    line5.overrideColor = new Color(50, 158, 194);
                }
                if (line5.mod == "Terraria" && line5.Name == "Tooltip0")
                {
                    line5.overrideColor = new Color(50, 158, 194);
                }
                if (line5.mod == "Terraria" && line5.Name == "ItemName")
                {
                    if (Frame == 0)
                    {
                        line5.text = ("[c/287399:Spectral Robes]");
                    }
                    if (Frame == 1)
                    {
                        line5.text = ("[c/2E91B3:Spectral Robes]");
                    }
                    if (Frame == 2)
                    {
                        line5.text = ("[c/39B3DB:Spectral Robes]");
                    }
                    if (Frame == 3)
                    {
                        line5.text = ("[c/BCE3E3:Spectral Robes]");
                    }
                }
            }
        }
        public override void UpdateInventory(Player player)
        {
            FrameCounter++; //increase the frameCounter by one
            if (FrameCounter >= 9) //once the frameCounter has reached 3 - change the 10 to change how fast the projectile animates
            {
                FrameCounter = 0;
                Frame += Switch; //go to the next frame
                if (Frame > 2) //if past the last frame
                {
                    Switch *= -1;
                }
                else if (Frame < 1)
                {
                    Switch *= -1;
                }
            }
        }
        public override void UpdateEquip(Player player)
        {
            FrameCounter++; //increase the frameCounter by one
            if (FrameCounter >= 9) //once the frameCounter has reached 3 - change the 10 to change how fast the projectile animates
            {
                FrameCounter = 0;
                Frame += Switch; //go to the next frame
                if (Frame > 2) //if past the last frame
                {
                    Switch *= -1;
                }
                else if (Frame < 1)
                {
                    Switch *= -1;
                }
            }
            VampPlayer p = player.GetModPlayer<VampPlayer>();
            KnifeDamagePlayer d = player.GetModPlayer<KnifeDamagePlayer>();
            player.aggro += 300;
            if (NPC.downedBoss2)
            {
                item.value = Item.sellPrice(0, 2, 0, 0);
                item.defense = 2;
                d.knifeDamageMult += 0.02f;
            }
            if (NPC.downedQueenBee)
            {
                item.value = Item.sellPrice(0, 3, 0, 0);
                item.defense = 3;
                d.knifeDamageMult += 0.04f;
            }
            if (NPC.downedBoss3)
            {
                item.value = Item.sellPrice(0, 4, 0, 0);
                item.defense = 4;
                d.knifeDamageMult += 0.05f;
                StatManaBonus = 10;
            }
            if (Main.hardMode)
            {
                item.value = Item.sellPrice(0, 5, 0, 0);
                d.knifeDamageMult += 0.06f;
                item.defense = 6;
                StatManaBonus = 20;
            }
            if (NPC.downedMechBoss1)
            {
                item.value = Item.sellPrice(0, 6, 0, 0);
                d.knifeDamageMult += 0.08f;
                item.defense = 7;
            }
            if (NPC.downedMechBoss2)
            {
                item.value = Item.sellPrice(0, 7, 0, 0);
                d.knifeDamageMult += 0.09f;
                MagicDamage = 0.11f;
                item.defense = 8;
            }
            if (NPC.downedMechBoss3)
            {
                item.value = Item.sellPrice(0, 8, 0, 0);
                d.knifeDamageMult += 0.10f;
                item.defense = 9;
                StatManaBonus = 35;
            }
            if (NPC.downedPlantBoss)
            {
                item.value = Item.sellPrice(0, 9, 0, 0);
                d.knifeDamageMult += 0.11f;
                item.defense = 10;
            }
            if (NPC.downedGolemBoss)
            {
                item.value = Item.sellPrice(0, 10, 0, 0);
                d.knifeDamageMult += 0.12f;
                item.defense = 12;
                StatManaBonus = 50;
            }
            if (NPC.downedFishron)
            {
                item.value = Item.sellPrice(0, 12, 0, 0);
                d.knifeDamageMult += 0.14f;
                item.defense = 14;
            }
            if (NPC.downedAncientCultist)
            {
                item.value = Item.sellPrice(0, 14, 0, 0);
                d.knifeDamageMult += 0.15f;
                item.defense = 16;
            }
            if (NPC.downedTowers)
            {
                item.value = Item.sellPrice(0, 16, 0, 0);
                d.knifeDamageMult += 0.18f;
                item.defense = 20;
                StatManaBonus = 60;
            }
            if (NPC.downedMoonlord)
            {
                item.value = Item.sellPrice(0, 20, 0, 0);
                d.knifeDamageMult += 0.24f;
                item.defense = 30;
                StatManaBonus = 80;
            }
            if(StatManaBonus > 0)
            {
                player.statManaMax2 += StatManaBonus;
            }
            if (NPC.downedBoss2)
            {
                float Multiplier = 0.78f;
                player.magicDamageMult += ((d.knifeDamageMult - 1.2f) * Multiplier);
            }
        }
    }
}