using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;

namespace VampKnives.Items.Accessories
{
    public class VampireNecklaceType : ExamplePlayer
    {
        public int PlayerProgress = 0;
        public void VampNeckBonus()
        {
            if (PlayerProgress == 1)
            {
                player.GetModPlayer<ExamplePlayer>().NeckAdd = 1.02f;
            }
            if (PlayerProgress == 2)
            {
                player.GetModPlayer<ExamplePlayer>().NeckAdd = 1.05f;
            }
            if (PlayerProgress == 3)
            {
                player.GetModPlayer<ExamplePlayer>().NeckAdd = 1.1f;
            }
            if (PlayerProgress == 4)
            {
                player.GetModPlayer<ExamplePlayer>().NeckAdd = 1.13f;
            }
            if (PlayerProgress == 5)
            {
                player.GetModPlayer<ExamplePlayer>().NeckAdd = 1.2f;
            }
            if (PlayerProgress == 6)
            {
                player.GetModPlayer<ExamplePlayer>().NeckAdd = 1.5f;
            }
            if (PlayerProgress == 7)
            {
                player.GetModPlayer<ExamplePlayer>().NeckAdd = 1.55f;
            }
            if (PlayerProgress == 8)
            {
                player.GetModPlayer<ExamplePlayer>().NeckAdd = 1.6f;
            }
            if (PlayerProgress == 9)
            {
                player.GetModPlayer<ExamplePlayer>().NeckAdd = 1.7f;
            }
            if (PlayerProgress == 10)
            {
                player.GetModPlayer<ExamplePlayer>().NeckAdd = 2;
            }
            if (PlayerProgress == 11)
            {
                player.GetModPlayer<ExamplePlayer>().NeckAdd = 2.2f;
            }
            if (PlayerProgress == 12)
            {
                player.GetModPlayer<ExamplePlayer>().NeckAdd = 2.5f;
            }
            if (PlayerProgress == 13)
            {
                player.GetModPlayer<ExamplePlayer>().NeckAdd = 3;
            }
            if (PlayerProgress == 14)
            {
                player.GetModPlayer<ExamplePlayer>().NeckAdd = 4f;
            }
        }
        public bool CheckHolding()
        {
            if (Main.mouseItem.type != 0)
            {
                //Main.NewText("Holding item");
                return true;
            }
            else
            {
                //Main.NewText("Holding air");
                return false;
            }
        }
        public void VampNeckProg()
        {
            if (NPC.downedMoonlord)
            {
                PlayerProgress = 14;
                player.GetModPlayer<ExamplePlayer>().KillText = "None";
            }
            else if (NPC.downedAncientCultist)
            {
                PlayerProgress = 13;
                player.GetModPlayer<ExamplePlayer>().KillText = "Moon Lord";
            }
            else if (NPC.downedFishron)
            {
                PlayerProgress = 12;
                player.GetModPlayer<ExamplePlayer>().KillText = "Lunatic Cultist";
            }
            else if (NPC.downedGolemBoss)
            {
                PlayerProgress = 11;
                player.GetModPlayer<ExamplePlayer>().KillText = "Duke Fishron";
            }
            else if (NPC.downedPlantBoss)
            {
                PlayerProgress = 10;
                player.GetModPlayer<ExamplePlayer>().KillText = "Golem";
            }
            else if (NPC.downedMechBoss3)
            {
                PlayerProgress = 9;
                player.GetModPlayer<ExamplePlayer>().KillText = "Plantera";
            }
            else if (NPC.downedMechBoss1)
            {
                PlayerProgress = 8;
                player.GetModPlayer<ExamplePlayer>().KillText = "Skeletron Prime";
            }
            else if (NPC.downedMechBoss2)
            {
                PlayerProgress = 7;
                player.GetModPlayer<ExamplePlayer>().KillText = "Twins";
            }
            else if (Main.hardMode)
            {
                PlayerProgress = 6;
                player.GetModPlayer<ExamplePlayer>().KillText = "Destroyer";
            }
            else if (NPC.downedBoss3)
            {
                PlayerProgress = 5;
                player.GetModPlayer<ExamplePlayer>().KillText = "WoF";
            }
            else if (NPC.downedBoss2)
            {
                PlayerProgress = 4;
                player.GetModPlayer<ExamplePlayer>().KillText = "Skeletron";
            }
            else if (NPC.downedQueenBee)
            {
                PlayerProgress = 3;
                player.GetModPlayer<ExamplePlayer>().KillText = "BoC or EoW";
            }
            else if (NPC.downedBoss1)
            {
                PlayerProgress = 2;
                player.GetModPlayer<ExamplePlayer>().KillText = "Queen Bee";
            }
            else if (NPC.downedSlimeKing)
            {
                PlayerProgress = 1;
                player.GetModPlayer<ExamplePlayer>().KillText = "Eye of Cthulhu";
            }
        }
    }
}