using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class VampiricChestplate : KnifeItem
    {
        int StatLifeBonus;
        public int Frame = 0;
        public int FrameCounter = 0;
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Vampiric Chestplate");
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
            ExamplePlayer p = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
            KnifeDamagePlayer d = Main.LocalPlayer.GetModPlayer<KnifeDamagePlayer>();
            TooltipLine line = new TooltipLine(mod, "Face", "+" + (int)(((d.knifeDamageMult*100)*0.00341)*100) + "% Knife Damage");
            line.overrideColor = new Color(160, 0, 0);
            TooltipLine line2 = new TooltipLine(mod, "Face", "+" + StatLifeBonus + " Health");
            line2.overrideColor = new Color(160, 0, 0);
            if (NPC.downedBoss2)
            {
                tooltips.Add(line);
            }
            if(NPC.downedBoss3)
            {
                tooltips.Add(line2);
            }

            if (p.VampiricArmorSet)
            {
                TooltipLine line4 = new TooltipLine(mod, "Face", "Set Bonus:");
                line4.overrideColor = new Color(180, 0, 0);
                tooltips.Add(line4);
                TooltipLine line3 = new TooltipLine(mod, "Face", "Enemies are more likely to target you\nHave a " + ((2f * p.VampiricSetScaler) / 10f) + "% Chance to steal the life of the enemies around you upon being hit");
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
                        line5.text = ("[c/3B0000:Vampiric Chestplate]");
                    }
                    if (Frame == 1)
                    {
                        line5.text = ("[c/730600:Vampiric Chestplate]");
                    }
                    if (Frame == 2)
                    {
                        line5.text = ("[c/AD0900:Vampiric Chestplate]");
                    }
                    if (Frame == 3)
                    {
                        line5.text = ("[c/730600:Vampiric Chestplate]");
                    }
                }
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
            KnifeDamagePlayer d = player.GetModPlayer<KnifeDamagePlayer>();
            player.aggro += 300;
            if (NPC.downedBoss2)
            {
                item.value = Item.sellPrice(0, 2, 0, 0);
                item.defense = 8;
                d.knifeDamageMult += 0.05f;
            }
            if (NPC.downedQueenBee)
            {
                item.value = Item.sellPrice(0, 3, 0, 0);
                item.defense = 9;
                d.knifeDamageMult += 0.06f;
            }
            if (NPC.downedBoss3)
            {
                item.value = Item.sellPrice(0, 4, 0, 0);
                item.defense = 10;
                d.knifeDamageMult += 0.08f;
                StatLifeBonus = 10;
            }
            if (Main.hardMode)
            {
                item.value = Item.sellPrice(0, 5, 0, 0);
                d.knifeDamageMult += 0.10f;
                item.defense = 12;
                StatLifeBonus = 20;
            }
            if (NPC.downedMechBoss1)
            {
                item.value = Item.sellPrice(0, 6, 0, 0);
                d.knifeDamageMult += 0.12f;
                item.defense = 14;
            }
            if (NPC.downedMechBoss2)
            {
                item.value = Item.sellPrice(0, 7, 0, 0);
                d.knifeDamageMult += 0.14f;
                item.defense = 16;
            }
            if (NPC.downedMechBoss3)
            {
                item.value = Item.sellPrice(0, 8, 0, 0);
                d.knifeDamageMult += 0.16f;
                item.defense = 20;
                StatLifeBonus = 30;
            }
            if (NPC.downedPlantBoss)
            {
                item.value = Item.sellPrice(0, 9, 0, 0);
                d.knifeDamageMult += 0.18f;
                item.defense = 22;
            }
            if (NPC.downedGolemBoss)
            {
                item.value = Item.sellPrice(0, 10, 0, 0);
                d.knifeDamageMult += 0.20f;
                item.defense = 23;
                StatLifeBonus = 40;
            }
            if (NPC.downedFishron)
            {
                item.value = Item.sellPrice(0, 12, 0, 0);
                d.knifeDamageMult += 0.22f;
                item.defense = 25;
            }
            if (NPC.downedAncientCultist)
            {
                item.value = Item.sellPrice(0, 14, 0, 0);
                d.knifeDamageMult += 0.25f;
                item.defense = 30;
                StatLifeBonus = 50;
            }
            if (NPC.downedTowers)
            {
                item.value = Item.sellPrice(0, 16, 0, 0);
                d.knifeDamageMult += 0.28f;
                item.defense = 34;
                StatLifeBonus = 60;
            }
            if (NPC.downedMoonlord)
            {
                item.value = Item.sellPrice(0, 20, 0, 0);
                d.knifeDamageMult += 0.34f;
                item.defense = 40;
                StatLifeBonus = 80;
            }
            if(StatLifeBonus > 0)
            {
                player.statLifeMax2 += StatLifeBonus;
            }
        }
    }
}