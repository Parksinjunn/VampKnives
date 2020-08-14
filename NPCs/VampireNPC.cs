using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;
using VampKnives.Items.Armor;
using VampKnives.Items.Materials;
using static Terraria.ModLoader.ModContent;


namespace VampKnives.NPCs
{
    [AutoloadHead]
    public class VampireNPC : ModNPC
    {
        public bool SkinShopClicked;
        public override string Texture
        {
            get
            {
                return "VampKnives/NPCs/VampireNPC";
            }
        }

        public override bool Autoload(ref string name)
        {
            name = "Vampire NPC";
            return mod.Properties.Autoload;
        }
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[npc.type] = 25;
            NPCID.Sets.ExtraFramesCount[npc.type] = 9;
            NPCID.Sets.AttackFrameCount[npc.type] = 4;
            NPCID.Sets.DangerDetectRange[npc.type] = 700;
            NPCID.Sets.AttackType[npc.type] = 0;
            NPCID.Sets.AttackTime[npc.type] = 90;
            NPCID.Sets.AttackAverageChance[npc.type] = 30;
            NPCID.Sets.HatOffsetY[npc.type] = 4;
        }

        public override void SetDefaults()
        {
            npc.townNPC = true;
            npc.friendly = true;
            npc.width = 24;
            npc.height = 46;
            npc.aiStyle = 7;
            npc.damage = 10;
            npc.defense = 15;
            npc.lifeMax = 9001;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            animationType = NPCID.Guide;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            int num = npc.life > 0 ? 1 : 5;
            for (int k = 0; k < num; k++)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, 5);
            }
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            if (NPC.downedBoss2)
            {
                return true;
            }
            return false;
        }

        public override string TownNPCName()
        {
            switch (WorldGen.genRand.Next(4))
            {
                case 0:
                    return "Darick";
                case 1:
                    return "Francius";
                case 2:
                    return "Vlad";
                default:
                    return "Viktor";
            }
        }

        public override string GetChat()
        {
            ExamplePlayer p = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
            if (p.Given == false)
                return "Young one, interested in an old vampire relic?";
            if (p.Given == true && SkinShopClicked == false)
            {
                return "Sometimes I get the urge to drink from everyone here";
            }
            if (SkinShopClicked == true)
                return ("Sometimes I get the urge to drink from everyone here");
            else
                return "who pie is?";
        }
        public int timer;
        public override void SetChatButtons(ref string button, ref string button2)
        {
            timer++;
            if(timer == 300)
            {
                SkinShopClicked = false;
            }
            ExamplePlayer p = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
            if (p.Given == false)
            {
                button = "Sure?";
                button2 = "N-n-no thanks";
            }
            if (p.Given == true)
            {
                button = Language.GetTextValue("LegacyInterface.28");
                button2 = ("Open Skin Shop");
            }
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            ExamplePlayer p = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
            if (p.Given == false)
            {
                if (firstButton)
                {
                    Main.LocalPlayer.QuickSpawnItem(ModContent.ItemType<Items.Accessories.VampNecklace>());
                    p.Given = true;
                }
                else
                {
                    p.Given = false;
                    Main.npcChatText = "";
                }
            }
            if(p.Given == true)
            {
                if (firstButton)
                {
                    shop = true;
                }
                else
                {
                    SkinShopClicked = true;
                }
            }
            if (SkinShopClicked == true)
            {
                Main.playerInventory = true;
                // remove the chat window...
                Main.npcChatText = "";
                // and start an instance of our UIState.
                GetInstance<VampKnives>().VampireUserInterface.SetState(new UI.SkinInventory());
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {//THINK OF GOOD WAY TO MAKE RESOURCES INFINITE
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.RecipePages.AmmoCastRecipe>());
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.RecipePages.IronCastRecipe>());
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.RecipePages.SharpeningRodRecipe>());
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.RecipePages.PlateRecipe>());
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.RecipePages.AmmoSculptRecipe>());
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.RecipePages.KnifeSculptRecipe>());
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.RecipePages.SharpeningSculptRecipe>());
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<PsionicHood>());
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<PsionicChestplate>());
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<PsionicLeggings>());
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<VampiricHelm>());
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<VampiricChestplate>());
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<VampiricGreaves>());
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<SpectralHood>());
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<SpectralRobes>());
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<SpectralBoots>());
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Accessories.VampNecklaces.VampNecklaceBee>());
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Materials.SacrificialDagger>());
            nextSlot++;
            if (NPC.downedSlimeKing)
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Superglue>());
                nextSlot++;
            }
            if(NPC.downedBoss2)
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<CorruptionCrystal>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<CorruptionShard>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<CrimsonCrystal>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<CrimsonShard>());
                nextSlot++;
            }
            if(NPC.downedPlantBoss)
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<PlantFiber>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<TransmutersHood>());
                nextSlot++;
                if (Main.eclipse)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<LivingTissue>());
                    nextSlot++;
                }
            }
            if(NPC.downedGolemBoss && Main.eclipse)
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.BrokenHeroKnives>());
                nextSlot++;
            }
            if(NPC.downedBoss3)
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.SengosForgottenBlades>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Accessories.ExtraFinger>());
                nextSlot++;
            }
        }

        public override void NPCLoot()
        {
            base.NPCLoot();
        }
        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 20;
            knockback = 4f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 30;
            randExtraCooldown = 30;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = mod.ProjectileType("VampireKnifeProj");
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 12f;
            randomOffset = 2f;
        }
    }
}