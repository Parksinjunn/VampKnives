using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class SpectralHood : KnifeItem
    {
        public int Frame;
        public int FrameCounter;
        public int Switch = 1;
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Spectral Hood");
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
            VampPlayer p = Main.LocalPlayer.GetModPlayer<VampPlayer>();
            TooltipLine line = new TooltipLine(mod, "Face", "+" + (p.SupportArmorLifeSteal) + " Support Knives Life Steal");
            line.overrideColor = new Color(50, 158, 194);
            if (NPC.downedBoss2)
            {
                tooltips.Add(line);
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
                        line5.text = ("[c/287399:Spectral Hood]");
                    }
                    if(Frame == 1)
                    {
                        line5.text = ("[c/2E91B3:Spectral Hood]");
                    }
                    if (Frame == 2)
                    {
                        line5.text = ("[c/39B3DB:Spectral Hood]");
                    }
                    if (Frame == 3)
                    {
                        line5.text = ("[c/BCE3E3:Spectral Hood]");
                    }
                }
            }
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<SpectralRobes>() && legs.type == ModContent.ItemType<SpectralBoots>();
        }

        public override void UpdateArmorSet(Player player)
        {
            VampPlayer p = player.GetModPlayer<VampPlayer>();
            p.SupportArmor = true;
            player.AddBuff(ModContent.BuffType<Buffs.SupportBlastBuff>(), 10);
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
                else if(Frame < 1)
                {
                    Switch *= -1;
                }
            }
            VampPlayer p = player.GetModPlayer<VampPlayer>();
            player.aggro += 300;
            //KnifeDamagePlayer d = player.GetModPlayer<KnifeDamagePlayer>();
            if (NPC.downedBoss2)
            {
                item.value = Item.sellPrice(0, 2, 0, 0);
                p.SupportArmorLifeSteal = 1;
                item.defense = 1;
            }
            if (NPC.downedBoss3)
            {
                item.value = Item.sellPrice(0, 4, 0, 0);
                p.SupportArmorLifeSteal = 2;
                item.defense = 2;
            }
            if (Main.hardMode)
            {
                item.value = Item.sellPrice(0, 5, 0, 0);
                p.SupportArmorLifeSteal = 3;
                item.defense = 4;
            }
            if (NPC.downedMechBoss1)
            {
                item.value = Item.sellPrice(0, 6, 0, 0);
                p.SupportArmorLifeSteal = 4;
                item.defense = 5;
            }
            if (NPC.downedMechBoss2)
            {
                item.value = Item.sellPrice(0, 7, 0, 0);
                p.SupportArmorLifeSteal = 5;
                item.defense = 6;
            }
            if (NPC.downedMechBoss3)
            {
                item.value = Item.sellPrice(0, 8, 0, 0);
                p.SupportArmorLifeSteal = 6;
                item.defense = 8;
            }
            if (NPC.downedPlantBoss)
            {
                item.value = Item.sellPrice(0, 9, 0, 0);
                p.SupportArmorLifeSteal = 7;
                item.defense = 9;
            }
            if (NPC.downedGolemBoss)
            {
                item.value = Item.sellPrice(0, 10, 0, 0);
                item.defense = 10;
            }
            if (NPC.downedFishron)
            {
                item.value = Item.sellPrice(0, 12, 0, 0);
                p.SupportArmorLifeSteal = 8;
                item.defense = 12;
            }
            if (NPC.downedAncientCultist)
            {
                item.value = Item.sellPrice(0, 14, 0, 0);
                item.defense = 14;
            }
            if (NPC.downedTowers)
            {
                item.value = Item.sellPrice(0, 16, 0, 0);
                p.SupportArmorLifeSteal = 9;
                item.defense = 18;
            }
            if (NPC.downedMoonlord)
            {
                item.value = Item.sellPrice(0, 20, 0, 0);
                p.SupportArmorLifeSteal = 10;
                item.defense = 22;
            }
        }
    }
}