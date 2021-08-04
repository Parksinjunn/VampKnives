using Terraria;
using Terraria.ModLoader;
using Terraria.GameInput;
using System.Collections.Generic;
using Terraria.UI;
using System;
using Terraria.ModLoader.IO;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using VampKnives.Projectiles.DefenseKnivesProj;
using VampKnives.Tiles;
using VampKnives.Items;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;

namespace VampKnives
{
    public class ExamplePlayer : ModPlayer
    {
        public bool PenetratingPoison = false;
        public bool SengosCurse = false;
        public bool TitaniumDefenseBuff = false;
        public bool ShroomiteBuff = false;

        private const int saveVersion = 0;
        public int Packet1 = 11;
        public int Packet2 = 22;
 
        public bool Connor = false;
        public bool Cobalt = false;
        public bool Mudkip = false;
        public bool lucario = false;
        public bool lucarioMinion = false;
        public bool MudkipMinion = false;
        public bool Mime = false;
        public bool Eevee = false;
        public bool Link = false;
        public bool hasMyBuff = false;
        public bool Arcanine = false;
        public int ExtraProj = 0;
        public int NumProj = 5;

        public bool pyroAccessoryPrevious;
        public bool pyroAccessory;
        public bool pyroHideVanity;
        public bool pyroForceVanity;
        public bool pyroPower;
        public bool pyro = false;

        public bool dPyroAccessoryPrevious;
        public bool dPyroAccessory;
        public bool dPyroHideVanity;
        public bool dPyroForceVanity;
        public bool dPyroPower;
        public bool dPyro = false;

        public bool TransmuterAccessoryPrevious;
        public bool TransmuterAccessory;
        public bool TransmuterHideVanity;
        public bool TransmuterForceVanity;
        public bool TransmuterPower;
        public bool Transmuter = false;

        public bool InvokerAccessoryPrevious;
        public bool InvokerAccessory;
        public bool InvokerHideVanity;
        public bool InvokerForceVanity;
        public bool InvokerPower;
        public bool Invoker = false;

        public bool MageAccessoryPrevious;
        public bool MageAccessory;
        public bool MageHideVanity;
        public bool MageForceVanity;
        public bool MagePower;
        public bool Mage = false;

        public bool TechnomancerAccessoryPrevious;
        public bool TechnomancerAccessory;
        public bool TechnomancerHideVanity;
        public bool TechnomancerForceVanity;
        public bool TechnomancerPower;
        public bool Technomancer = false;

        public bool PartyAccessoryPrevious;
        public bool PartyAccessory;
        public bool PartyHideVanity;
        public bool PartyForceVanity;
        public bool PartyPower;
        public bool Party = false;

        public bool ShamanAccessoryPrevious;
        public bool ShamanAccessory;
        public bool ShamanHideVanity;
        public bool ShamanForceVanity;
        public bool ShamanPower;
        public bool Shaman = false;

        public bool WitchDoctorAccessoryPrevious;
        public bool WitchDoctorAccessory;
        public bool WitchDoctorHideVanity;
        public bool WitchDoctorForceVanity;
        public bool WitchDoctorPower;
        public bool WitchDoctor = false;
        public bool ShrunkenHead = false;

        public bool nullified = false;
        public bool HoodKeyPressed = false;
        public bool HoodIsVisible = false;

        public bool PlayerHasChisel = false;
        public float VampMax;
        public float VampCurrent;
        public float VampDecreaseRate = 2f;
        public float VampDecSlow = 1f;
        public int DelayTimer;
        public double DelayAdd;
        public float HealAccMult = 1f;
        public bool PsionicArmorSet;
        public bool PsionicPower;
        public int numProj;

        public bool VampNecklace = false;
        public int KillCount;
        public int NeckProgress;
        public float NeckAdd;
        public bool Given = false;
        public string KillText;

        public bool IsTrueSupport;
        public bool IsSupportKeyPressed;
        public float TrueSupportBuff;

        public float DefenseReflectChance = 0f;
        public int DefenseExtraLives = 0;

        bool DoubleTapStart;
        int DoubleTapTimer;
        public bool Transform;
        public bool HasTabletEquipped;
        public bool VampiricArmorSet;
        public float VampiricSetScaler = 1f;

        public int NumCrafted;

        public bool SupportArmor = false;
        public bool SupportArmorSetBuff;
        public bool RunSupportTimer;
        public bool SupportArmorBuff = false;
        public bool SupportLegs = false;
        public int SupportArmorSetBuffCount;
        public int SupportArmorLifeSteal;
        int SupportTimer;
        public int BuffCountStore;
        public bool SupportArmorKeyPressed;

        public int BloodPoints;
        public bool UIOpen=false;
        public bool UIOpenElsewhere;
        public bool SacrificialDebuff;
        public bool Bandaged;
        public bool SendPackage;
        public bool SendKillPackage;
        public int SendKillDelay;
        public static bool HasHeldTier1;
        public static bool HasHeldTier2;
        public static bool HasHeldTier3;

        public bool VeiWingsEquipped;
        public bool VeiTransform;

        public override void ResetEffects()
        {
            if (MagePower && HoodKeyPressed)
            {
                player.velocity *= 0f;
                player.gravity *= 0f;
            }
            Connor = false;
            Cobalt = false;
            Mudkip = false;
            lucario = false;
            lucarioMinion = false;
            MudkipMinion = false;
            Mime = false;
            Eevee = false;
            Link = false;
            hasMyBuff = false;
            Arcanine = false;
            PenetratingPoison = false;
            SengosCurse = false;
            nullified = false;
            ExtraProj = 0;
            NumProj = 5;
            pyroAccessoryPrevious = pyroAccessory;
            pyroAccessory = pyroHideVanity = pyroForceVanity = pyroPower = false;
            pyro = false;
            dPyroAccessoryPrevious = dPyroAccessory;
            dPyroAccessory = dPyroHideVanity = dPyroForceVanity = dPyroPower = false;
            dPyro = false;
            TransmuterAccessoryPrevious = TransmuterAccessory;
            TransmuterAccessory = TransmuterHideVanity = TransmuterForceVanity = TransmuterPower = false;
            Transmuter = false;
            InvokerAccessoryPrevious = InvokerAccessory;
            InvokerAccessory = InvokerHideVanity = InvokerForceVanity = InvokerPower = false;
            Invoker = false;
            TechnomancerAccessoryPrevious = TechnomancerAccessory;
            TechnomancerAccessory = TechnomancerHideVanity = TechnomancerForceVanity = TechnomancerPower = false;
            Technomancer = false;
            PartyAccessoryPrevious = PartyAccessory;
            PartyAccessory = PartyHideVanity = PartyForceVanity = PartyPower = false;
            Party = false;
            ShamanAccessoryPrevious = ShamanAccessory;
            ShamanAccessory = ShamanHideVanity = ShamanForceVanity = ShamanPower = false;
            Shaman = false;
            WitchDoctorAccessoryPrevious = WitchDoctorAccessory;
            WitchDoctorAccessory = WitchDoctorHideVanity = WitchDoctorForceVanity = WitchDoctorPower = false;
            WitchDoctor = ShrunkenHead = false;
            MageAccessoryPrevious = MageAccessory;
            MageAccessory = MageHideVanity = MageForceVanity = MagePower = false;
            Mage = false;
            if (VampNecklace == true)
            {
                VampMax = 1000 * NeckAdd;
            }
            else
            {
                VampMax = 1000;
            }
            VampDecreaseRate = 2f;
            VampDecSlow = 1f;
            VampNecklace = false;
            HealAccMult = 1f * VampKnives.ConfigHealAmntMult;
            DelayAdd = 0;
            PsionicArmorSet = false;
            IsTrueSupport = false;
            TrueSupportBuff = 1f;
            TitaniumDefenseBuff = false;
            ShroomiteBuff = false;
            HasTabletEquipped = false;
            DefenseReflectChance = 0;
            DefenseExtraLives = 0;
            TitaniumDefenseBuff = false;
            VampiricArmorSet = false;
            SupportArmor = false;
            RunSupportTimer = SupportArmorSetBuff = SupportArmorBuff = false;
            SacrificialDebuff = false;
            Bandaged = false;
            VeiWingsEquipped = false;
            VeiTransform = false;
            //SupportArmorKeyPressed = false;
            //Transform = false;
            for (int g = 0; g < ProjCount.ZenithProj.Count; g++)
            {
                if (!Main.projectile[ProjCount.ZenithProj[g]].active)
                {
                    ProjCount.ZenithProj.RemoveAt(g);
                    ProjCount.ZenithType.RemoveAt(g);
                    Projectiles.ZenithsTrueBladesProj.SpawnTimer = 15;
                    //Main.NewText("Length: " + ProjCount.ZenithProj.Count);
                }
            }
            //Main.NewText("UIOpen: " + UIOpen + "    UIOpenElseWHere: " + UIOpenElsewhere);
        }
        public override void clientClone(ModPlayer clientClone)
        {
            ExamplePlayer clone = clientClone as ExamplePlayer;
            // Here we would make a backup clone of values that are only correct on the local players Player instance.
            // Some examples would be RPG stats from a GUI, Hotkey states, and Extra Item Slots
            clone.HoodIsVisible = this.HoodIsVisible;
            clone.Transform = this.Transform;
            clone.SendPackage = this.SendPackage;
            clone.VeiTransform = this.VeiTransform;
        }

        public override void SendClientChanges(ModPlayer clientPlayer)
        {
            ExamplePlayer clone = clientPlayer as ExamplePlayer;
            if (HoodIsVisible != clone.HoodIsVisible)
            {
                ModPacket packet = mod.GetPacket();
                packet.Write(Packet1);
                packet.Write(HoodIsVisible);
                packet.Write(Main.myPlayer);
                packet.Send();
            }
            else if(Transform != clone.Transform)
            {
                ModPacket packet2 = mod.GetPacket();
                packet2.Write(88);
                packet2.Write(Transform);
                packet2.Write(HasTabletEquipped);
                packet2.Write(Main.myPlayer);
                packet2.Send();
            }
            else if(VeiTransform != clone.VeiTransform)
            {
                ModPacket packet3 = mod.GetPacket();
                packet3.Write(420);
                packet3.Write(VeiTransform);
                packet3.Write(Main.myPlayer);
                packet3.Send();
            }
            else if(SupportArmorKeyPressed != clone.SupportArmorKeyPressed)
            {
                for (int x = 0; x < Main.ActivePlayersCount; x++)
                {
                    float shootToX = player.position.X + (float)player.width * 0.5f - Main.player[x].Center.X;
                    float shootToY = player.position.Y + (player.height / 2) - Main.player[x].Center.Y;
                    float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));
                    if (distance < 2000)
                    {
                        ModPacket packet2 = mod.GetPacket();
                        packet2.Write(99);
                        packet2.Write(Main.player[x].whoAmI);
                        Main.NewText("Count: " + BuffCountStore);
                        packet2.Write(BuffCountStore);
                        packet2.Write(Main.myPlayer);
                        packet2.Send();
                    }
                }
                SupportArmorKeyPressed = clone.SupportArmorKeyPressed;
            }
            else if (UIOpen != clone.UIOpen)
            {
                //Main.NewText("Sent");
                ModPacket packet2 = mod.GetPacket();
                packet2.Write(28);
                packet2.Write(UIOpen);
                packet2.Write(Main.myPlayer);
                packet2.Send();
            }
        }

        public override void UpdateDead()
        {
            PenetratingPoison = false;
            SengosCurse = false;
            TitaniumDefenseBuff = false;
            ShroomiteBuff = false;
            SupportArmorBuff = false;
        }
        public override void OnHitByNPC(NPC npc, int damage, bool crit)
        {
            if (VampiricArmorSet && Main.rand.Next(0, 1001) <= 2 * VampiricSetScaler)
            {
                for (int NPCID = 0; NPCID < Main.maxNPCs; NPCID++)
                {
                float shootToX = Main.npc[NPCID].position.X + (float)Main.npc[NPCID].width * 0.5f - player.Center.X;
                float shootToY = Main.npc[NPCID].position.Y - player.Center.Y;
                float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));
                if (Main.npc[NPCID].CanBeChasedBy() && distance < 1000f)
                    {
                        int LifeStealRandom = Main.rand.Next(40, 90);
                        player.ApplyDamageToNPC(Main.npc[NPCID], LifeStealRandom, 0f, 0, false);
                        Projectile.NewProjectile(Main.npc[NPCID].position, new Vector2(0f, 0f), ModContent.ProjectileType<Projectiles.HealProj>(), LifeStealRandom, 0f, player.whoAmI);
                    }
                }
            }
        }
        public override void OnHitByProjectile(Projectile proj, int damage, bool crit)
        {
            if (VampiricArmorSet && Main.rand.Next(0, 1001) <= (int)(2f * VampiricSetScaler))
            {
                for (int NPCID = 0; NPCID < Main.maxNPCs; NPCID++)
                {
                    float shootToX = Main.npc[NPCID].position.X + (float)Main.npc[NPCID].width * 0.5f - player.Center.X;
                    float shootToY = Main.npc[NPCID].position.Y - player.Center.Y;
                    float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));
                    if (Main.npc[NPCID].CanBeChasedBy() && distance < 1000f)
                    {
                        int LifeStealRandom = Main.rand.Next(40, 90);
                        player.ApplyDamageToNPC(Main.npc[NPCID], LifeStealRandom, 0f, 0, false);
                        Projectile.NewProjectile(Main.npc[NPCID].position, new Vector2(0f, 0f), ModContent.ProjectileType<Projectiles.HealProj>(), LifeStealRandom, 0f, player.whoAmI);
                    }
                }
            }
        }
        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            if (hasMyBuff == true)
                ApplyMyBuff(target);
        }
        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if (hasMyBuff == true)
                ApplyMyBuff(target);
            if (PsionicArmorSet)
            {
                if (Main.rand.Next(25) == 3)
                {
                    if (NPC.downedBoss2)
                    {
                        numProj = 1;
                    }
                    if (NPC.downedQueenBee)
                    {
                        numProj = 2;
                    }
                    if (NPC.downedBoss3)
                    {
                        numProj = 3;
                    }
                    if (Main.hardMode)
                    {
                        numProj = 4;
                    }
                    if (NPC.downedMechBoss1)
                    {
                        numProj = 5;
                    }
                    if (NPC.downedMechBoss2)
                    {
                        numProj = 6;
                    }
                    if (NPC.downedMechBoss3)
                    {
                        numProj = 7;
                    }
                    if (NPC.downedPlantBoss)
                    {
                        numProj = 8;
                    }
                    if (NPC.downedGolemBoss)
                    {
                        numProj = 9;
                    }
                    if (NPC.downedFishron)
                    {
                        numProj = 10;
                    }
                    if (NPC.downedAncientCultist)
                    {
                        numProj = 11;
                    }
                    if (NPC.downedTowers)
                    {
                        numProj = 12;
                    }
                    for (int x =0; x<numProj ; x++)
                    {
                        Player owner = Main.player[proj.owner];
                        Projectile.NewProjectile(proj.position.X+Main.rand.Next(-3,3), proj.position.Y+ Main.rand.Next(-3, 3), Main.rand.Next(-10,10), Main.rand.Next(-10, 10), mod.ProjectileType("PsionicProj"), (int)(proj.damage * 0.25), 0, owner.whoAmI);
                    }
                }
            }
        }
        void ApplyMyBuff(NPC npc)
        {
            npc.AddBuff(72, 60 * 4); //7 seconds, 60 frames per second, just an example number
        }
        public override TagCompound Save()
        {
            var staticVars = new List<string>();
            if (HasHeldTier3)
            {
                staticVars.Add("Tier3");
            }
            if (HasHeldTier2)
            {
                staticVars.Add("Tier2");
            }
            if (HasHeldTier1)
            {
                staticVars.Add("Tier1");
            }

            return new TagCompound {
                {"NeckProgress", NeckProgress},
                {"Given", Given},
                {"NeckAdd", NeckAdd},
                {"KillText", KillText},
                {"NumCrafted", NumCrafted },
                {"BloodPoints", BloodPoints },
                {"staticVars", staticVars }
            };
        }
        public override void Load(TagCompound tag)
        {
            var staticVars = tag.GetList<string>("staticVars");

            NeckProgress = tag.GetInt("NeckProgress");
            Given = tag.GetBool("Given");
            NeckAdd = tag.GetFloat("NeckAdd");
            KillText = tag.GetString("KillText");
            NumCrafted = tag.GetInt("NumCrafted");
            BloodPoints = tag.GetInt("BloodPoints");
            HasHeldTier1 = staticVars.Contains("Tier1");
            HasHeldTier2 = staticVars.Contains("Tier2");
            HasHeldTier3 = staticVars.Contains("Tier3");
            //if (staticVars.Contains("Tier3"))
            //{
            //    HasHeldTier3 = staticVars.Contains("Tier3");
            //    HasHeldTier2 = staticVars.Contains("Tier3");
            //    HasHeldTier1 = staticVars.Contains("Tier3");
            //}
            //else if (staticVars.Contains("Tier3"))
            //{
            //    HasHeldTier3 = staticVars.Contains("Tier2");
            //    HasHeldTier2 = staticVars.Contains("Tier2");
            //    HasHeldTier1 = staticVars.Contains("Tier2");
            //}
            //else if (staticVars.Contains("Tier1"))
            //{
            //    HasHeldTier3 = staticVars.Contains("Tier1");
            //    HasHeldTier2 = staticVars.Contains("Tier2");
            //    HasHeldTier1 = staticVars.Contains("Tier2");
            //}
        }
        public override void UpdateBadLifeRegen()
        {
            if (PenetratingPoison)
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                player.lifeRegen -= 3;
            }
            if(SengosCurse)
            {
                if(player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                player.lifeRegen -= 10;
            }
            if (DelayTimer == (0-DelayAdd))
            {
                VampDecreaseRate = (float)Math.Pow(VampDecreaseRate * VampDecSlow, 1.5);
                VampCurrent -= VampDecreaseRate;
            }
            if (DelayTimer > (0-DelayAdd))
                DelayTimer--;
            if (VampCurrent <= 0)
                VampCurrent = 0;
            if (VampCurrent > VampMax)
                VampCurrent = VampMax;
            if(SacrificialDebuff)
            {
                KnifeDamagePlayer p = KnifeDamagePlayer.ModPlayer(player);

                if (!Bandaged)
                {
                    player.lifeRegen -= 16;
                }
                p.KnifeDamage *= 0.6f;
                player.pickSpeed *= 2f;
                player.maxRunSpeed *= 0.7f;
                player.allDamage *= 0.6f;
                
            }
        }
        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            if(player.HasBuff(ModContent.BuffType<Buffs.BleedingOutDebuff>()))
            {
                damageSource = PlayerDeathReason.ByCustomReason(" lost too much blood");
            }
            base.Kill(damage, hitDirection, pvp, damageSource);
        }
        public override void UpdateVanityAccessories()
        {
            for (int n = 13; n < 18 + player.extraAccessorySlots; n++)
            {
                    Item item = player.armor[n];
                if (item.type == ModContent.ItemType<Items.Accessories.AncientVampiricTablet>())
                {
                    HasTabletEquipped = true;
                }
                if (item.type == ModContent.ItemType<Items.Armor.PyromancersHood>())
                {
                    pyroHideVanity = false;
                    pyroForceVanity = true;
                }
                if(item.type == ModContent.ItemType<Items.Armor.DarkPyromancersHood>())
                {
                    dPyroHideVanity = false;
                    dPyroForceVanity = true;
                }
                if (item.type == ModContent.ItemType<Items.Armor.TransmutersHood>())
                {
                    TransmuterHideVanity = false;
                    TransmuterForceVanity = true;
                }
                if (item.type == ModContent.ItemType<Items.Armor.InvokersHood>())
                {
                    InvokerHideVanity = false;
                    InvokerForceVanity = true;
                }
                if (item.type == ModContent.ItemType<Items.Armor.TechnomancersHood>())
                {
                    TechnomancerHideVanity = false;
                    TechnomancerForceVanity = true;
                }
                if (item.type == ModContent.ItemType<Items.Armor.PartyHood>())
                {
                    PartyHideVanity = false;
                    PartyForceVanity = true;
                }
                if (item.type == ModContent.ItemType<Items.Armor.ShamansHood>())
                {
                    ShamanHideVanity = false;
                    ShamanForceVanity = true;
                }
                if (item.type == ModContent.ItemType<Items.Armor.WitchDoctorHood>())
                {
                    WitchDoctorHideVanity = false;
                    WitchDoctorForceVanity = true;
                }
                if (item.type == ModContent.ItemType<Items.Armor.MagesHood>())
                {
                    MageHideVanity = false;
                    MageForceVanity = true;
                }
            }
        }
        bool FirstEnhancedText;
        bool SecondEnhancedText;
        bool ThirdEnhancedText;
        bool FourthEnhancedText;
        bool FifthEnhancedText;
        bool SixthEnhancedText;
        bool SeventhEnhancedText;
        bool EigthEnhancedText;
        bool NinthEnhancedText;
        float DirectionSwitch;
        int SupportTime = 300;
        bool VisualRun = true;
        int VisorAlpha = 220;
        int MovementSoundTimer;
        int identifier;
        public override void PostUpdate()
        {
            VampKnives v = new VampKnives();
            if (SendKillPackage)
            {
                SendKillDelay++;
                if(SendKillDelay > 2)
                {
                    //Main.NewText("SendingKillPackage");
                    for (int iterations = 0; iterations < VampireWorld.AltarBeingUsed.Count; iterations += 2)
                    {
                        if (VampireWorld.AltarBeingUsed[iterations] == VampireWorld.MostRecentClick.X && VampireWorld.AltarBeingUsed[iterations + 1] == VampireWorld.MostRecentClick.Y)
                        {
                            //Main.NewText("FoundAltar");
                            identifier = iterations;
                        }
                        //Main.NewText("Identifier" + identifier);
                    }
                    SendKillPackage = false;
                    ModPacket KillBlocksSend = mod.GetPacket();
                    KillBlocksSend.Write(VampKnives.KillBlocksRecieve);
                    KillBlocksSend.Write(identifier);
                    KillBlocksSend.Write(VampireWorld.AltarBeingUsed[identifier] + 1);
                    KillBlocksSend.Write(VampireWorld.AltarBeingUsed[identifier + 1] - 2);
                    KillBlocksSend.Write(VampireWorld.AltarBeingUsed.Count);
                    for (int g = 0; g < VampireWorld.AltarBeingUsed.Count; g++)
                    {
                        KillBlocksSend.Write(VampireWorld.RitualOfTheStone[g]);
                        KillBlocksSend.Write(VampireWorld.RitualOfTheMiner[g]);
                        KillBlocksSend.Write(VampireWorld.RitualOfMidas[g]);
                    }
                    KillBlocksSend.Send();
                }        
            }
        }

        public override void UpdateEquips(ref bool wallSpeedBuff, ref bool tileSpeedBuff, ref bool tileRangeBuff)
        {
            VampKnives v = new VampKnives();
            if (SendPackage)
            {
                SendPackage = false;
                ModPacket RitualClientSend = mod.GetPacket();
                RitualClientSend.Write(VampKnives.RitualsRecieve);
                RitualClientSend.Write(VampireWorld.AltarBeingUsed.Count);
                RitualClientSend.Write(player.whoAmI);
                for (int g = 0; g < VampireWorld.AltarBeingUsed.Count; g++)
                {
                    //RitualClientSend.Write(VampireWorld.AltarBeingUsed[g]);
                    RitualClientSend.Write(VampireWorld.RitualOfTheStone[g]);
                    RitualClientSend.Write(VampireWorld.RoEType[g]);
                    RitualClientSend.Write(VampireWorld.RitualOfTheMiner[g]);
                    RitualClientSend.Write(VampireWorld.RoMType[g]);
                    RitualClientSend.Write(VampireWorld.RitualOfMidas[g]);
                    RitualClientSend.Write(VampireWorld.RoMiType[g]);
                    RitualClientSend.Write(VampireWorld.AltarOwner[g]);
                }
                RitualClientSend.Send();
            }
            if (SupportArmorSetBuff == true)
            {
                RunSupportTimer = true;
            }
            if (RunSupportTimer)
            {
                if(SupportTimer < SupportTime && SupportArmorSetBuffCount < 6)
                {
                    SupportTimer++;
                }
                else if (SupportTimer >= SupportTime && SupportArmorSetBuffCount < 6)
                {
                    SupportArmorSetBuffCount++;
                    SupportTime += 50 * SupportArmorSetBuffCount;
                    SupportTimer = 0;
                }
            }
            else
            {
                RunSupportTimer = false;
                SupportTimer = 0;
                SupportArmorSetBuffCount = 0;
            }
            if (StartStoreResetTimer && HasSupportBuff == false)
            {
                StoreResetTimer++;
                if(StoreResetTimer >= 600)
                {
                    BuffCountStore = 0;
                    StoreResetTimer = 0;
                    StartStoreResetTimer = false;
                }
            }
            if (SupportArmorBuff && BuffCountStore > 0)
            {
                player.maxRunSpeed *= (1.5f + (float)Math.Log(BuffCountStore));
                player.accRunSpeed *= (1.5f + (float)Math.Log(BuffCountStore));
                player.lifeRegenTime += (int)(15 * BuffCountStore);
                player.allDamage *= (1f + (float)Math.Log(BuffCountStore));
                player.statDefense += (2 + (int)BuffCountStore);
            }
            if (SupportArmorSetBuffCount >= 1 && Transform == false)
            {
                int DustType = 67;
                float VisorScale = 0.5f;
                Color VisorColor = new Color(0, 251, 255);
                if(SupportArmorSetBuffCount == 1)
                {
                    VisorAlpha = 220;
                }
                if (SupportArmorSetBuffCount == 2 && VisualRun == true)
                {
                    VisorAlpha = 180;
                    OvalDust(new Vector2(player.Center.X, player.Center.Y - 13), 1.5f, 0.5f, VisorColor, DustType, 1.2f, true);
                    VisualRun = false;
                }
                else if(SupportArmorSetBuffCount == 3 && VisualRun == false)
                {
                    VisorAlpha = 140;
                    OvalDust(new Vector2(player.Center.X, player.Center.Y - 13), 1.5f, 0.5f, VisorColor, DustType, 1.2f, true);
                    VisualRun = true;
                }
                else if (SupportArmorSetBuffCount == 4 && VisualRun == true)
                {
                    VisorAlpha = 100;
                    OvalDust(new Vector2(player.Center.X, player.Center.Y - 13), 1.5f, 0.5f, VisorColor, DustType, 1.2f, true);
                    VisualRun = false;
                }
                else if (SupportArmorSetBuffCount == 5 && VisualRun == false)
                {
                    VisorAlpha = 60;
                    OvalDust(new Vector2(player.Center.X, player.Center.Y - 13), 1.5f, 0.5f, VisorColor, DustType, 1.2f, true);
                    VisualRun = true;
                }
                else if (SupportArmorSetBuffCount == 6 && VisualRun == true)
                {
                    VisorAlpha = 0;
                    OvalDust(new Vector2(player.Center.X, player.Center.Y - 13), 1.5f, 0.5f, VisorColor, DustType, 1.2f, true);
                    VisualRun = false;
                }
                if (player.direction == 1)
                {
                    for (int x = 0; x < 5; x++)
                    {
                        if (x >= 1 && x < 3)
                        {
                            int VisorDust = Dust.NewDust(new Vector2((player.Center.X + (4 - (2 * x))), player.Center.Y - 12), 0, 0, DustType, 0f, 0f, VisorAlpha, VisorColor, VisorScale);
                            Main.dust[VisorDust].noGravity = true;
                            Main.dust[VisorDust].velocity *= 0;
                            Main.dust[VisorDust].shader = GameShaders.Armor.GetSecondaryShader(88, Main.LocalPlayer);
                        }
                        else
                        {
                            int VisorDust = Dust.NewDust(new Vector2((player.Center.X + (4 - (2 * x))), player.Center.Y - 14), 0, 0, DustType, 0f, 0f, VisorAlpha, VisorColor, VisorScale);
                            Main.dust[VisorDust].noGravity = true;
                            Main.dust[VisorDust].velocity *= 0;
                            Main.dust[VisorDust].shader = GameShaders.Armor.GetSecondaryShader(88, Main.LocalPlayer);
                        }
                    }
                }
                else
                {
                    for (int x = 0; x < 5; x++)
                    {
                        if (x >= 1 && x < 3)
                        {
                            int VisorDust = Dust.NewDust(new Vector2((player.Center.X - (12 - (2 * x))), player.Center.Y - 12), 0, 0, DustType, 0f, 0f, VisorAlpha, VisorColor, VisorScale);
                            Main.dust[VisorDust].noGravity = true;
                            Main.dust[VisorDust].velocity *= 0;
                            Main.dust[VisorDust].shader = GameShaders.Armor.GetSecondaryShader(88, Main.LocalPlayer);
                        }
                        else
                        {
                            int VisorDust = Dust.NewDust(new Vector2((player.Center.X - (12 - (2 * x))), player.Center.Y - 14), 0, 0, DustType, 0f, 0f, VisorAlpha, VisorColor, VisorScale);
                            Main.dust[VisorDust].noGravity = true;
                            Main.dust[VisorDust].velocity *= 0;
                            Main.dust[VisorDust].shader = GameShaders.Armor.GetSecondaryShader(88, Main.LocalPlayer);
                        }
                    }
                }

            }
            if (NumCrafted == 20 && !FirstEnhancedText)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y - 50, player.width, player.height), new Color(255, 255, 255, 255), "Ammo Crafting Enhanced!", true);
                FirstEnhancedText = true;
            }
            if (NumCrafted == 50 && !SecondEnhancedText)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y - 50, player.width, player.height), new Color(255, 255, 255, 255), "Ammo Crafting Enhanced!", true);
                SecondEnhancedText = true;
            }
            if (NumCrafted == 100 && !ThirdEnhancedText)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y - 50, player.width, player.height), new Color(255, 255, 255, 255), "Ammo Crafting Enhanced!", true);
                ThirdEnhancedText = true;
            }
            if (NumCrafted == 150 && !FourthEnhancedText)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y - 50, player.width, player.height), new Color(255, 255, 255, 255), "Ammo Crafting Enhanced!", true);
                FourthEnhancedText = true;
            }
            if (NumCrafted == 225 && !FifthEnhancedText)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y - 50, player.width, player.height), new Color(255, 255, 255, 255), "Ammo Crafting Enhanced!", true);
                FifthEnhancedText = true;
            }
            if (NumCrafted == 300 && !SixthEnhancedText)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y - 50, player.width, player.height), new Color(255, 255, 255, 255), "Ammo Crafting Enhanced!", true);
                SixthEnhancedText = true;
            }
            if (NumCrafted == 400 && !SeventhEnhancedText)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y - 50, player.width, player.height), new Color(255, 255, 255, 255), "Ammo Crafting Enhanced!", true);
                SeventhEnhancedText = true;
            }
            if (NumCrafted == 500 && !EigthEnhancedText)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y - 50, player.width, player.height), new Color(255, 255, 255, 255), "Ammo Crafting Enhanced!", true);
                EigthEnhancedText = true;
            }
            if (NumCrafted == 1000 && !NinthEnhancedText)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y - 50, player.width, player.height), new Color(255, 255, 255, 255), "Ammo Crafting Enhanced!", true);
                Main.NewText("You've crafted ammo a thousand times, you've mastered the art of crafting knife ammo", 180, 0, 0);
                NinthEnhancedText = true;
            }
            if (IsSupportKeyPressed)
            {
                player.AddBuff(ModContent.BuffType<Buffs.TrueSupportDebuff>(), 60, true);
            }
            //if(Transform == true)
            //{
            //    player.AddBuff(ModContent.BuffType<Buffs.BatBuff>(), 60, true);
            //}
            // Make sure this condition is the same as the condition in the Buff to remove itself. We do this here instead of in ModItem.UpdateAccessory in case we want future upgraded items to set blockyAccessory
            if (HoodKeyPressed == true && pyroAccessory)
            {
                player.AddBuff(ModContent.BuffType<Buffs.PyroHoodBuff>(), 60, true);
            }
            if (HoodKeyPressed == true && dPyroAccessory)
            {
                player.AddBuff(ModContent.BuffType<Buffs.DPyroHoodBuff>(), 60, true);
            }
            if (HoodKeyPressed == true && TransmuterAccessory)
            {
                player.AddBuff(ModContent.BuffType<Buffs.TransmuterHoodBuff>(), 60, true);
            }
            if (HoodKeyPressed == true && InvokerAccessory)
            {
                player.AddBuff(ModContent.BuffType<Buffs.InvokerHoodBuff>(), 60, true);
            }
            if (HoodKeyPressed == true && TechnomancerAccessory)
            {
                player.AddBuff(ModContent.BuffType<Buffs.TechnomancerHoodBuff>(), 60, true);
            }
            if (HoodKeyPressed == true && PartyAccessory)
            {
                player.AddBuff(ModContent.BuffType<Buffs.PartyHoodBuff>(), 60, true);
            }
            if (HoodKeyPressed == true && ShamanAccessory)
            {
                player.AddBuff(ModContent.BuffType<Buffs.ShamanHoodBuff>(), 60, true);
            }
            if (HoodKeyPressed == true && WitchDoctorAccessory)
            {
                player.AddBuff(ModContent.BuffType<Buffs.WitchDoctorHoodBuff>(), 60, true);
            }
            if (HoodKeyPressed == true && MageAccessory)
            {
                player.AddBuff(ModContent.BuffType<Buffs.MageHoodBuff>(), 60, true);
                if (Main.rand.NextFloat() < 1f)
                {
                    Dust dust;
                    // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                    dust = Main.dust[Terraria.Dust.NewDust(new Vector2(player.position.X - (player.width / 2), player.position.Y - (player.height)), 47, 0, 226, 0f, 7f, 3, new Color(255, 255, 255), 0.6f)];
                    dust.noGravity = true;
                    dust.shader = GameShaders.Armor.GetSecondaryShader(22, Main.LocalPlayer);
                }
            }
            if(HasTabletEquipped == true && Transform == true && (player.bodyFrame.Y == 560 || player.bodyFrame.Y == 168))
            {
                Main.PlaySound(SoundID.Item32.WithVolume(0.5f), player.position);
            }
            //mod.Logger.Info("FRAME: " + player.bodyFrame.Y);
            if (HasTabletEquipped == false)
            {
                Transform = false;
                DoubleTapTimer = 0;
                DoubleTapStart = false;
            }
        }
        public override void FrameEffects()
        {
            if ((pyroPower || pyroForceVanity) && !pyroHideVanity)
            {
                player.head = mod.GetEquipSlot("PyroHead", EquipType.Head);
            }
            if ((dPyroPower || dPyroForceVanity) && !dPyroHideVanity)
            {
                player.head = mod.GetEquipSlot("DPyroHead", EquipType.Head);
            }
            if ((TransmuterPower || TransmuterForceVanity) && !TransmuterHideVanity)
            {
                player.head = mod.GetEquipSlot("TransmuterHead", EquipType.Head);
            }
            if ((InvokerPower || InvokerForceVanity) && !InvokerHideVanity)
            {
                player.head = mod.GetEquipSlot("InvokerHead", EquipType.Head);
            }
            if ((TechnomancerPower || TechnomancerForceVanity) && !TechnomancerHideVanity)
            {
                player.head = mod.GetEquipSlot("TechnomancerHead", EquipType.Head);
            }
            if ((PartyPower || PartyForceVanity) && !PartyHideVanity)
            {
                player.head = mod.GetEquipSlot("PartyHead", EquipType.Head);
            }
            if ((ShamanPower || ShamanForceVanity) && !ShamanHideVanity)
            {
                player.head = mod.GetEquipSlot("ShamanHead", EquipType.Head);
            }
            if ((WitchDoctorPower || WitchDoctorForceVanity) && !WitchDoctorHideVanity)
            {
                player.head = mod.GetEquipSlot("WitchDoctorHead", EquipType.Head);
            }
            if ((MagePower || MageForceVanity) && !MageHideVanity)
            {
                player.head = mod.GetEquipSlot("MageHead", EquipType.Head);
            }
            if(HasTabletEquipped && Transform)
            {
                if (player.bodyFrameCounter == 0 && (player.velocity.X < 0 || player.velocity.X > 0 || player.velocity.Y < 0 || player.velocity.Y > 0))
                {
                    player.head = mod.GetEquipSlot("BatTransformHidden", EquipType.Head);
                    player.wings = mod.GetEquipSlot("BatFlyMovement", EquipType.Wings);
                    int num74 = 4;
                    if (player.direction == 1)
                    {
                        num74 = -40;
                    }
                    int num75 = Dust.NewDust(new Vector2(player.position.X + (float)(player.width / 2) + (float)num74, player.position.Y + (float)(player.height / 2) - 15f), 30, 30, 182, 0f, 0f, 100, Color.Red, 0.5f);
                    Main.dust[num75].noGravity = true;
                    Dust dust3 = Main.dust[num75];
                    dust3.velocity *= 0.3f;
                    Lighting.AddLight(new Vector2(player.position.X + (float)(player.width / 2) + (float)num74, player.position.Y + (float)(player.height / 2) - 15f), new Vector3(0.45f, 0.02f, 0.02f));
                }
                else
                {
                    player.head = mod.GetEquipSlot("BatTransform", EquipType.Head);
                    player.wings = mod.GetEquipSlot("BatWingsHidden", EquipType.Wings);
                }
            }
            if(VeiTransform && !HasTabletEquipped)
            {
                player.head = mod.GetEquipSlot("VeiTransform", EquipType.Head);
            }
            //if(VeiWingsEquipped)
            //{
            //    if (player.bodyFrameCounter == 0 && (player.velocity.X < 0 || player.velocity.X > 0 || player.velocity.Y < 0 || player.velocity.Y > 0))
            //    {
            //        player.wings = mod.GetEquipSlot("BatFlyMovement", EquipType.Wings);
            //        int num74 = 4;
            //        if (player.direction == 1)
            //        {
            //            num74 = -40;
            //        }
            //        int num75 = Dust.NewDust(new Vector2(player.position.X + (float)(player.width / 2) + (float)num74, player.position.Y + (float)(player.height / 2) - 15f), 30, 30, 182, 0f, 0f, 100, Color.Red, 0.5f);
            //        Main.dust[num75].noGravity = true;
            //        Dust dust3 = Main.dust[num75];
            //        dust3.velocity *= 0.3f;
            //        Lighting.AddLight(new Vector2(player.position.X + (float)(player.width / 2) + (float)num74, player.position.Y + (float)(player.height / 2) - 15f), new Vector3(0.45f, 0.02f, 0.02f));
            //    }
            //    else
            //    {
            //        player.wings = mod.GetEquipSlot("BatWingsHidden", EquipType.Wings);
            //    }
            //}
            if (nullified)
            {
                Nullify();
            }
        }
        public override void SetControls()
        {
            if (Mage == true && HoodKeyPressed == true)
            {
                player.controlRight = false;
                player.controlLeft = false;
                player.controlJump = false;
            }
            base.SetControls();
        }
        int VeiWingFrame = 0;
        int WingTimer = 0;
        public static readonly PlayerLayer VeiWings = new PlayerLayer("VampKnives", "VeiWings", PlayerLayer.MiscEffectsBack, delegate (PlayerDrawInfo drawInfo)
        {
            if (drawInfo.shadow != 0f)
            {
                return;
            }
            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("VampKnives");
            ExamplePlayer modPlayer = drawPlayer.GetModPlayer<ExamplePlayer>();
            if(drawPlayer.bodyFrameCounter == 0 && (drawPlayer.velocity.X < 0 || drawPlayer.velocity.X > 0 || drawPlayer.velocity.Y < 0 || drawPlayer.velocity.Y > 0))
            {
                modPlayer.WingTimer++;
                if (drawPlayer.wingTime == 0)
                    modPlayer.VeiWingFrame = 0;
                else if (modPlayer.WingTimer % 2 == 0)
                {
                    if (modPlayer.VeiWingFrame < 9 && drawPlayer.controlJump)
                    {
                        modPlayer.VeiWingFrame++;
                    }
                    else
                        modPlayer.VeiWingFrame = 0;
                }
                if (modPlayer.WingTimer >= 60)
                {
                    modPlayer.WingTimer = 0;
                }
            }
            else
            {
                modPlayer.VeiWingFrame = 6;
            }
            if (modPlayer.VeiWingsEquipped)
            {
                Texture2D texture = mod.GetTexture("Items/VtuberItems/VeiWingsAnim");
                int frameSize = texture.Height / 10;
                int drawX;
                if(drawPlayer.direction == 1)
                {
                    drawX = (int)(drawInfo.position.X + drawPlayer.width / 2f - (Main.screenPosition.X+4));
                }
                else
                {
                    drawX = (int)(drawInfo.position.X + drawPlayer.width / 2f - (Main.screenPosition.X-4));
                }
                int drawY = (int)(drawInfo.position.Y + drawPlayer.height / 2f - (Main.screenPosition.Y-236));
                DrawData data = new DrawData(texture, new Vector2(drawX, drawY), new Rectangle(0, frameSize * modPlayer.VeiWingFrame, texture.Width, frameSize), Color.White, 0f, new Vector2(texture.Width / 2f, texture.Height / 2f), 1f, SpriteEffects.None, 0);
                Main.playerDrawData.Add(data);
            }
        });
        public override void ModifyDrawLayers(List<PlayerLayer> layers)
        {
            if(VeiWingsEquipped)
            {
                layers.Remove(PlayerLayer.Wings);
                VeiWings.visible = true;
                layers.Insert(0, VeiWings);
            }
            if (Transform && HasTabletEquipped)
            {
                //layers.Remove(PlayerLayer.Head);
                layers.Remove(PlayerLayer.Body);
                layers.Remove(PlayerLayer.Legs);
                layers.Remove(PlayerLayer.Skin);
                layers.Remove(PlayerLayer.BackAcc);
                layers.Remove(PlayerLayer.WaistAcc);
                layers.Remove(PlayerLayer.BalloonAcc);
                layers.Remove(PlayerLayer.FaceAcc);
                //layers.Remove(PlayerLayer.Wings);
                layers.Remove(PlayerLayer.Face);
                layers.Remove(PlayerLayer.FrontAcc);
                layers.Remove(PlayerLayer.HandOffAcc);
                layers.Remove(PlayerLayer.HandOnAcc);
                layers.Remove(PlayerLayer.NeckAcc);
                layers.Remove(PlayerLayer.ShieldAcc);
                layers.Remove(PlayerLayer.ShoeAcc);
                layers.Remove(PlayerLayer.WaistAcc);
                layers.Remove(PlayerLayer.Arms);
            }
            if(VeiTransform && !HasTabletEquipped)
            {
                layers.Remove(PlayerLayer.Body);
                layers.Remove(PlayerLayer.Legs);
                layers.Remove(PlayerLayer.Skin);
                layers.Remove(PlayerLayer.Face);
                layers.Remove(PlayerLayer.Arms);
            }
            base.ModifyDrawLayers(layers);
        }
        private void Nullify()
        {
            player.ResetEffects();
            player.head = -1;
            player.body = -1;
            player.legs = -1;
            player.handon = -1;
            player.handoff = -1;
            player.back = -1;
            player.front = -1;
            player.shoe = -1;
            player.waist = -1;
            player.shield = -1;
            player.neck = -1;
            player.face = -1;
            player.balloon = -1;
            nullified = true;
        }
        bool HasSupportBuff;
        bool StartStoreResetTimer;
        int StoreResetTimer;
        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (DoubleTapStart && HasTabletEquipped)
            {
                DoubleTapTimer++;
                if (DoubleTapTimer > 15)
                {
                    DoubleTapStart = false;
                    DoubleTapTimer = 0;
                }
            }
            if (VampKnives.HoodUpDownHotkey.JustPressed)
            {
                if (HoodKeyPressed == false)
                {
                    HoodKeyPressed = true;
                    HoodIsVisible = true;
                }
                else
                {
                    HoodKeyPressed = false;
                    HoodIsVisible = false;
                }
            }
            if(VampKnives.SupportHotKey.JustPressed)
            {
                if(IsSupportKeyPressed == false)
                {
                    IsSupportKeyPressed = true;
                    IsTrueSupport = true;
                }
                else
                {
                    IsSupportKeyPressed = false;
                    IsTrueSupport = false;
                }
            }
            if(VampKnives.VampDashHotKey.JustPressed && HasTabletEquipped)
            {
                DoubleTapStart = true;
            }
            if (DoubleTapTimer > 1 && VampKnives.VampDashHotKey.JustPressed)
            {
                if(Transform == false)
                {
                    //Main.NewText("Transformed");
                    Transform = true;
                    DoubleTapStart = false;
                    DoubleTapTimer = 0;
                }
                else if(Transform == true)
                {
                    Transform = false;
                    DoubleTapStart = false;
                    DoubleTapTimer = 0;
                }
            }
            if (VampKnives.SupportArmorHotKey.JustPressed)
            {
                for (int x = 0; x < Main.ActivePlayersCount; x++)
                {
                    if (Main.player[x].HasBuff(ModContent.BuffType<Buffs.SupportBuff>()))
                    {
                        HasSupportBuff = true;
                    }
                    else
                    {
                        HasSupportBuff = false;
                    }
                }
                if (HasSupportBuff == false)
                {
                    BuffCountStore = SupportArmorSetBuffCount;
                    SupportArmorSetBuffCount = 0;
                    StartStoreResetTimer = true;
                    StoreResetTimer = 0;
                    //Main.NewText("BuffCountStore: " + BuffCountStore);
                    SupportArmorKeyPressed = true;
                    OvalDust(new Vector2(player.Center.X - 5, player.Center.Y),3, 5, new Color(50, 182, 194), 15, 2f);
                    player.AddBuff(ModContent.BuffType<Buffs.SupportBuff>(), 600);
                    SupportTime = 300;
                    VisualRun = true;
                }
            }
        }

        public void TurnOffRituals(Player p)
        {
            for (int iterations = 0; iterations < VampireWorld.AltarBeingUsed.Count; iterations += 2)
            {
                identifier = iterations;
                if (VampireWorld.AltarOwner[identifier] == p.whoAmI)
                {
                    if (VampireWorld.RitualOfTheStone[identifier])
                    {
                        VampireWorld.RitualOfTheStone[identifier] = false;
                    }
                    if (VampireWorld.RitualOfMidas[identifier])
                    {
                        VampireWorld.RitualOfMidas[identifier] = false;
                    }
                    if (VampireWorld.RitualOfTheMiner[identifier])
                    {
                        VampireWorld.RitualOfTheMiner[identifier] = false;
                    }
                    if (Main.netMode == NetmodeID.MultiplayerClient)
                    {
                        SendPackage = true;
                    }
                }
            }
        }

        public static void OvalDust(Vector2 position, float width, float height, Color color, int DustType, float size, bool scattered = false, bool IsCut = false, Vector2? CutPositionsAndVelocityMult = null)
        {
            float VelocityX = 0;
            float VelocityY = 0;
            float End1;
            float End2;
            float End1Final = 0;
            float End2Final = 0;
            float a = width;
            float b = height;
            float Circle = 360f;
            float DivisorFactor = 360f;
            float Divisor = Circle / DivisorFactor;
            float FirstLower = 0;
            float FirstUpper = 90f/Divisor;
            float SecondLower = 270f/Divisor;
            float SecondUpper = 360f/Divisor;
            float ThirdLower = 90f/Divisor;
            float ThirdUpper = 270f/Divisor;
            float HalfOfFirstUpper = FirstUpper / 2;
            float DoubleOfFirstUpper = FirstUpper * 2;
            int ScatteredWeight = 0;
            //bool IsCut = false;
            //if(CutPositions != null)
            //{
            //    IsCut = true;
            //}
            if(scattered)
            {
                ScatteredWeight = 96;
            }

            for (int iteration = 0; iteration < SecondUpper; iteration += 12)
            {
                if (Main.rand.Next(1, 100) > ScatteredWeight)
                {
                    if (IsCut)
                    {
                        End1 = CutPositionsAndVelocityMult.Value.X;
                        End2 = CutPositionsAndVelocityMult.Value.Y;
                        if (End1 > End2)
                        {
                            End1Final = End2;
                            End2Final = End1;
                            if (iteration > End1Final && iteration <= End2Final)
                            {
                                float radian = MathHelper.ToRadians(iteration);
                                Vector2 vector = radian.ToRotationVector2() * new Vector2(a, b);
                                int DustID3 = Dust.NewDust(position, 1, 1, DustType, 0f, 0f, 10, color, size);
                                Main.dust[DustID3].noGravity = true;
                                Main.dust[DustID3].velocity = vector;
                            }
                        }
                        else
                        {
                            End1Final = End1;
                            End2Final = End2;
                            if (iteration < End1Final || iteration >= End2Final)
                            {
                                float radian = MathHelper.ToRadians(iteration);
                                Vector2 vector = radian.ToRotationVector2() * new Vector2(a, b);
                                int DustID3 = Dust.NewDust(position, 1, 1, DustType, 0f, 0f, 10, color, size);
                                Main.dust[DustID3].noGravity = true;
                                Main.dust[DustID3].velocity = vector;
                            }
                        }
                    }

                    else if (!IsCut)
                    {
                        if ((iteration >= FirstLower && iteration < FirstUpper) || iteration > SecondLower && iteration <= SecondUpper)
                        {
                            VelocityX = (float)((a * b) / Math.Sqrt(Math.Pow(b, 2) + Math.Pow(a, 2) * Math.Pow(Math.Tan(MathHelper.ToRadians(iteration)), 2)));
                            VelocityY = (float)((a * b * Math.Tan(MathHelper.ToRadians(iteration))) / Math.Sqrt(Math.Pow(b, 2) + Math.Pow(a, 2) * Math.Pow(Math.Tan(MathHelper.ToRadians(iteration)), 2)));
                        }
                        else if (iteration >= ThirdLower && iteration < ThirdUpper)
                        {
                            VelocityX = -(float)((a * b) / Math.Sqrt(Math.Pow(b, 2) + Math.Pow(a, 2) * Math.Pow(Math.Tan(MathHelper.ToRadians(iteration)), 2)));
                            VelocityY = -(float)((a * b * Math.Tan(MathHelper.ToRadians(iteration))) / Math.Sqrt(Math.Pow(b, 2) + Math.Pow(a, 2) * Math.Pow(Math.Tan(MathHelper.ToRadians(iteration)), 2)));
                        }
                        int DustID3 = Dust.NewDust(position, 1, 1, DustType, 0f, 0f, 10, color, size);
                        Main.dust[DustID3].noGravity = true;
                        Main.dust[DustID3].velocity = new Vector2(VelocityX, VelocityY);
                    }
                }
            }
        }
    }
}