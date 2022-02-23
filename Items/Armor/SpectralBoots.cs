using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class SpectralBoots : KnifeItem
    {
        float SpeedIncrease;
        public int Frame;
        public int FrameCounter;
        public int Switch = 1;
        int ManaRegen;
        int Counter;
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Spectral Boots");
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
            VampPlayer p = Main.LocalPlayer.GetModPlayer<VampPlayer>();
            TooltipLine line2 = new TooltipLine(mod, "Face", "Movement adds +" + ManaRegen + " active mana regen");
            line2.overrideColor = new Color(50, 158, 194);
            if (NPC.downedBoss2)
            {
                tooltips.Add(line2);
            }
            TooltipLine line = new TooltipLine(mod, "Face", "+" + (int)(SpeedIncrease*100) + "% Movement Speed.");
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
                        line5.text = ("[c/287399:Spectral Boots]");
                    }
                    if (Frame == 1)
                    {
                        line5.text = ("[c/2E91B3:Spectral Boots]");
                    }
                    if (Frame == 2)
                    {
                        line5.text = ("[c/39B3DB:Spectral Boots]");
                    }
                    if (Frame == 3)
                    {
                        line5.text = ("[c/BCE3E3:Spectral Boots]");
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
            if (NPC.downedBoss2)
            {
                SpeedIncrease = 0.01f;
                item.value = Item.sellPrice(0, 2, 0, 0);
                item.defense = 1;
                p.DefenseExtraLives += 1;
                ManaRegen = 1;
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
                item.defense = 2;
                p.DefenseExtraLives += 2;
            }
            if (Main.hardMode)
            {
                SpeedIncrease = 0.04f;
                item.value = Item.sellPrice(0, 5, 0, 0);
                item.defense = 4;
                ManaRegen = 2;
            }
            if (NPC.downedMechBoss1)
            {
                SpeedIncrease = 0.05f;
                item.value = Item.sellPrice(0, 6, 0, 0);
                item.defense = 5;
            }
            if (NPC.downedMechBoss2)
            {
                SpeedIncrease = 0.06f;
                item.value = Item.sellPrice(0, 7, 0, 0);
                item.defense = 6;
            }
            if (NPC.downedMechBoss3)
            {
                SpeedIncrease = 0.07f;
                item.value = Item.sellPrice(0, 8, 0, 0);
                item.defense = 7;
                p.DefenseExtraLives += 3;
                ManaRegen = 3;
            }
            if (NPC.downedPlantBoss)
            {
                SpeedIncrease = 0.08f;
                item.value = Item.sellPrice(0, 9, 0, 0);
                item.defense = 9;
                p.DefenseExtraLives += 4;
                ManaRegen = 4;
            }
            if (NPC.downedGolemBoss)
            {
                SpeedIncrease = 0.09f;
                item.value = Item.sellPrice(0, 10, 0, 0);
                item.defense = 10;
            }
            if (NPC.downedFishron)
            {
                SpeedIncrease = 0.10f;
                item.value = Item.sellPrice(0, 12, 0, 0);
                item.defense = 12;
                p.DefenseExtraLives += 5;
            }
            if (NPC.downedAncientCultist)
            {
                SpeedIncrease = 0.11f;
                item.value = Item.sellPrice(0, 14, 0, 0);
                item.defense = 14;
                p.DefenseExtraLives += 6;
            }
            if (NPC.downedTowers)
            {
                SpeedIncrease = 0.12f;
                item.value = Item.sellPrice(0, 16, 0, 0);
                item.defense = 18;
                p.DefenseExtraLives += 7;
            }
            if (NPC.downedMoonlord)
            {
                SpeedIncrease = 0.15f;
                item.value = Item.sellPrice(0, 20, 0, 0);
                item.defense = 22;
                p.DefenseExtraLives += 10;
                ManaRegen = 5;
            }
            player.moveSpeed += SpeedIncrease;
            if (player.velocity.X > 3 || player.velocity.X < -3 || player.velocity.Y > 3 || player.velocity.Y < -3)
            {
                Counter++;
                if(Counter > 12 && player.statMana < player.statManaMax2)
                {
                    player.statMana += ManaRegen;
                    Counter = 0;
                }
            }
        }
    }
}