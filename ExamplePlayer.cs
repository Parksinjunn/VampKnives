using Terraria;
using Terraria.ModLoader;
using Terraria.GameInput;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.UI;
using System;
using Terraria.ModLoader.IO;

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
        public float HealAccMult = 0.4f;
        public bool ArmorSet;
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

        public bool LegacyPlayer;
        public bool NormalPlayer;
        public bool UnforgivingPlayer;



        public int NumCrafted;

        public override void ResetEffects()
        {
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
            if(VampKnives.Legacy)
            {
                HealAccMult = 0.8f;
            }
            if (VampKnives.Normal)
            {
                HealAccMult = 0.4f;
            }
            if (VampKnives.Unforgiving)
            {
                HealAccMult = 0.2f;
            }
            DelayAdd = 0;
            ArmorSet = false;
            IsTrueSupport = false;
            TrueSupportBuff = 1f;
            TitaniumDefenseBuff = false;
            ShroomiteBuff = false;
            VampKnives.ChangeItemIsHeld = false;
            LegacyPlayer = VampKnives.Legacy;
            NormalPlayer = VampKnives.Normal;
            UnforgivingPlayer = VampKnives.Unforgiving;
        }
        public override void clientClone(ModPlayer clientClone)
        {
            ExamplePlayer clone = clientClone as ExamplePlayer;
            // Here we would make a backup clone of values that are only correct on the local players Player instance.
            // Some examples would be RPG stats from a GUI, Hotkey states, and Extra Item Slots
            clone.HoodIsVisible = this.HoodIsVisible;
        }

        public override void SendClientChanges(ModPlayer clientPlayer)
        {
            ModPacket packet = mod.GetPacket();
            packet.Write(Packet1);
            packet.Write(HoodIsVisible);
            packet.Write(Main.myPlayer);
            //eventually more stuff
            packet.Send(); //both are optional here
            //packet.Send(toWhichClientOnly, whatClientToIgnoreWhileSending)
        }

        public override void UpdateDead()
        {
            PenetratingPoison = false;
            SengosCurse = false;
            TitaniumDefenseBuff = false;
            ShroomiteBuff = false;
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
            if (ArmorSet)
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
            return new TagCompound {
                {"NeckProgress", NeckProgress},
                {"Given", Given},
                {"NeckAdd", NeckAdd},
                {"KillText", KillText},
                {"Legacy", LegacyPlayer},
                {"Normal", NormalPlayer},
                {"Unforgiving", UnforgivingPlayer},
                {"NumCrafted", NumCrafted },
            };
        }
        public override void Load(TagCompound tag)
        {
            NeckProgress = tag.GetInt("NeckProgress");
            Given = tag.GetBool("Given");
            NeckAdd = tag.GetFloat("NeckAdd");
            KillText = tag.GetString("KillText");
            LegacyPlayer = tag.GetBool("Legacy");
            NormalPlayer = tag.GetBool("Normal");
            UnforgivingPlayer = tag.GetBool("Unforgiving");
            NumCrafted = tag.GetInt("NumCrafted");
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
        }
        public override void UpdateVanityAccessories()
        {
            for (int n = 13; n < 18 + player.extraAccessorySlots; n++)
            {
                Item item = player.armor[n];
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

        public override void UpdateEquips(ref bool wallSpeedBuff, ref bool tileSpeedBuff, ref bool tileRangeBuff)
        {
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
            // Make sure this condition is the same as the condition in the Buff to remove itself. We do this here instead of in ModItem.UpdateAccessory in case we want future upgraded items to set blockyAccessory
            if (HoodKeyPressed == true && pyroAccessory)
            {
                player.AddBuff(ModContent.BuffType<Buffs.PyroHoodBuff>(), 60, true);
            }
            if(HoodKeyPressed == true && dPyroAccessory)
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
        public override void ProcessTriggers(TriggersSet triggersSet)
        {
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
        }
    }
}