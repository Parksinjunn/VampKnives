﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using Terraria.DataStructures;
using Terraria.Localization;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.Accessories
{
    public class VampNecklace : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vampire Necklace");
            //Tooltip.SetDefault("[c/FF0000:Tier 1]");
            //    + string.Format("\n[c/FF0000:Colors ][c/00FF00:are ][c/0000FF:fun ]and so are items: [i:{0}][i:{1}][i/s123:{2}]", item.type, ModContent.ItemType<ExtraFinger>(), ItemID.Ectoplasm));
        }

        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 42;
            item.rare = 10;
            item.accessory = true;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            tooltips.RemoveAll(x => x.Name == "Tooltip0" && x.mod == "Terraria");
            VampPlayer p = Main.LocalPlayer.GetModPlayer<VampPlayer>();
            TooltipLine line3;
            TooltipLine line = new TooltipLine(mod, "Face", "Skin: Original");
            line.overrideColor = new Color(210, 0, 0);
            tooltips.Add(line);
            TooltipLine line4 = new TooltipLine(mod, "Face", "To upgrade, kill: " + p.KillText);
            line4.overrideColor = new Color(255, 0, 0);
            tooltips.Add(line4);
            if (p.NeckAdd - 1 <= 0)
            {
                line3 = new TooltipLine(mod, "Face", "PLEASE KILL FIRST BOSS TO FIX BLOOD METER");
                line3.overrideColor = new Color(255, 255, 255);
            }
            else
            {
                 line3 = new TooltipLine(mod, "Face", "Lifesteal Bonus: " + ((p.NeckAdd - 1) * 100) + "%");
                line3.overrideColor = new Color(255, 0, 0);
            }
            tooltips.Add(line3);
            foreach (TooltipLine line2 in tooltips)
            {
                if (line2.mod == "Terraria" && line2.Name == "Equipable")
                {
                    line2.overrideColor = new Color(160,0,0);
                }
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.text = "[c/FF0000:Va][c/EE0200:mp][c/DD0400:ir][c/CC0600:e] [c/BB0800:Ne][c/AB0A00:ck][c/9A0C00:la][c/890E00:ce]";
                }
                if (line2.mod == "Terraria" && line2.Name == "PrefixAccMoveSpeed")
                {
                    line2.text = "";
                }
                if (line2.mod == "Terraria" && line2.Name == "PrefixAccDefense")
                {
                    line2.text = "";
                }
                if (line2.mod == "Terraria" && line2.Name == "PrefixAccCritChance")
                {
                    line2.text = "";
                }
                if (line2.mod == "Terraria" && line2.Name == "PrefixAccDamage")
                {
                    line2.text = "";
                }
                if (line2.mod == "Terraria" && line2.Name == "PrefixAccMeleeSpeed")
                {
                    line2.text = "";
                }
                if (line2.mod == "Terraria" && line2.Name == "PrefixAccMaxMana")
                {
                    line2.text = "";
                }
            }
        }
        public override bool CanEquipAccessory(Player player, int slot)
        {
            if (slot < 10) 
            {
                int maxAccessoryIndex = 5 + player.extraAccessorySlots;
                for (int i = 3; i < 3 + maxAccessoryIndex; i++)
                {
                    if (player.GetModPlayer<VampPlayer>().VampNecklace == true)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<VampireNecklaceType>().VampNeckProg();
            player.GetModPlayer<VampireNecklaceType>().VampNeckBonus();
            player.GetModPlayer<VampPlayer>().VampNecklace = true;
        }
    }
}
