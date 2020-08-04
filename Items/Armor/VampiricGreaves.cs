using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class VampiricGreaves : KnifeItem
    {
        float SpeedIncrease;
        public int Frame;
        public int FrameCounter;
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Vampiric Greaves");
            Tooltip.SetDefault("");
        }

        public override void SafeSetDefaults()
        {
            item.width = 30;
            item.height = 20;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 2;
            item.defense = 6;
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
            KnifeDamagePlayer d = Main.LocalPlayer.GetModPlayer<KnifeDamagePlayer>();
            ExamplePlayer p = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
            TooltipLine line2 = new TooltipLine(mod, "Face", "Defense knives have " + p.DefenseExtraLives + " extra life");
            if(NPC.downedBoss2)
            {
                line2.text = "Defense knives have " + p.DefenseExtraLives + " extra lives";
            }
            line2.overrideColor = new Color(160, 0, 0);
            if (NPC.downedBoss2)
            {
                tooltips.Add(line2);
            }
            TooltipLine line = new TooltipLine(mod, "Face", "+" + (int)(SpeedIncrease*100) + "% Movement Speed.");
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
                        line5.text = ("[c/3B0000:Vampiric Greaves]");
                    }
                    if (Frame == 1)
                    {
                        line5.text = ("[c/730600:Vampiric Greaves]");
                    }
                    if (Frame == 2)
                    {
                        line5.text = ("[c/AD0900:Vampiric Greaves]");
                    }
                    if (Frame == 3)
                    {
                        line5.text = ("[c/730600:Vampiric Greaves]");
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
            if (NPC.downedBoss2)
            {
                SpeedIncrease = 0.01f;
                item.value = Item.sellPrice(0, 2, 0, 0);
                item.defense = 6;
                p.DefenseExtraLives += 1;
            }
            if (NPC.downedQueenBee)
            {
                SpeedIncrease = 0.02f;
                item.value = Item.sellPrice(0, 3, 0, 0);
            }
            if (NPC.downedBoss3)
            {
                SpeedIncrease = 0.03f;
                item.value = Item.sellPrice(0, 4, 0, 0);
                item.defense = 7;
                p.DefenseExtraLives += 2;
            }
            if (Main.hardMode)
            {
                SpeedIncrease = 0.04f;
                item.value = Item.sellPrice(0, 5, 0, 0);
                item.defense = 8;
            }
            if (NPC.downedMechBoss1)
            {
                SpeedIncrease = 0.05f;
                item.value = Item.sellPrice(0, 6, 0, 0);
                item.defense = 10;
            }
            if (NPC.downedMechBoss2)
            {
                SpeedIncrease = 0.06f;
                item.value = Item.sellPrice(0, 7, 0, 0);
                item.defense = 11;
            }
            if (NPC.downedMechBoss3)
            {
                SpeedIncrease = 0.07f;
                item.value = Item.sellPrice(0, 8, 0, 0);
                item.defense = 12;
                p.DefenseExtraLives += 3;
            }
            if (NPC.downedPlantBoss)
            {
                SpeedIncrease = 0.08f;
                item.value = Item.sellPrice(0, 9, 0, 0);
                item.defense = 14;
                p.DefenseExtraLives += 4;
            }
            if (NPC.downedGolemBoss)
            {
                SpeedIncrease = 0.09f;
                item.value = Item.sellPrice(0, 10, 0, 0);
                item.defense = 15;
            }
            if (NPC.downedFishron)
            {
                SpeedIncrease = 0.10f;
                item.value = Item.sellPrice(0, 12, 0, 0);
                item.defense = 16;
                p.DefenseExtraLives += 5;
            }
            if (NPC.downedAncientCultist)
            {
                SpeedIncrease = 0.11f;
                item.value = Item.sellPrice(0, 14, 0, 0);
                item.defense = 18;
                p.DefenseExtraLives += 6;
            }
            if (NPC.downedTowers)
            {
                SpeedIncrease = 0.12f;
                item.value = Item.sellPrice(0, 16, 0, 0);
                item.defense = 20;
                p.DefenseExtraLives += 7;
            }
            if (NPC.downedMoonlord)
            {
                SpeedIncrease = 0.15f;
                item.value = Item.sellPrice(0, 20, 0, 0);
                item.defense = 24;
                p.DefenseExtraLives += 10;
            }
            player.moveSpeed += SpeedIncrease;
        }
    }
}