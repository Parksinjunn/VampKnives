using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using Terraria.DataStructures;
using Terraria.Localization;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VampKnives.Items;
using VampKnives;
using VampKnives.Buffs;
using VampKnives.Projectiles.DefenseKnivesProj;

namespace VampKnives.Projectiles
{
    public abstract class KnifeProjectile : ModProjectile
    {
        public int ShatterTarget;
        bool PenetrationBuffApplied = false;
        public static bool ZenithActive = false;
        public static int ZenithProjID;
        public static bool ProjectileNotZenith = false;
        float RandomVelocity;
        bool Instanced;
        bool TileCollision;
        float RotationSpeed;
        public static int HealProjChanceScale = 101;
        public static int HealProjChance = HealProjChanceScale;
        public KnifeWeapon ParentWeapon = new KnifeWeapon();

        public virtual void SafeSetDefaults() {
        }
        public virtual void SafeAI() {
        }
        public virtual bool SafePreKill(int timeleft) {
            return true;
        }
        public virtual bool SafeOnTileCollide(Vector2 OldVelocity){
            return true;
        }
        public virtual void SafeOnHitNPC(NPC n, int damage, float knockback, bool crit) {
        }
        public virtual void SafeModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection){
        }
        public override void SetDefaults()
        {
            SafeSetDefaults();
            if(ZenithActive)
            {
                RandomVelocity = Main.rand.NextFloat(0.8f, 1.25f);
                projectile.tileCollide = false;
                projectile.aiStyle = 0;
                projectile.penetrate = 1;
                HealProjChance = 3;
            }
            else
            {
                HealProjChance = HealProjChanceScale;
            }
        }
        public override bool PreAI()
        {
            if (ModContent.GetModItem(Main.LocalPlayer.HeldItem.type) is Items.KnifeDamageItem)
            {
                ParentWeapon = Main.LocalPlayer.HeldItem.GetGlobalItem<KnifeWeapon>();
            }
            return true;
        }
        public override void AI()
        {
            SafeAI();
            if(ZenithActive)
            {
                for (int g = 0; g < ProjCount.ZenithProj.Count; g++)
                {
                    if (Main.projectile[ProjCount.ZenithProj[g]].type == ModContent.ProjectileType<HealProj>())
                    {
                        Main.projectile[ProjCount.ZenithProj[g]].Kill();
                    }
                    projectile.frame = 0;
                    Player p = Main.player[projectile.owner];

                    //Factors for calculations
                    double deg = (double)RotationSpeed + (60*g); //The degrees, you can multiply projectile.ai[1] to make it orbit faster, may be choppy depending on the value
                    double rad = deg * (Math.PI / 180); //Convert degrees to radians

                    float distX = 64; //Distance away from the player
                    float distY = 64;

                    distX = 80f + (40f * (float)Math.Sin(2 * rad));
                    distY = 80f + (40f * (float)Math.Cos(2 * rad));

                    /*Position the player based on where the player is, the Sin/Cos of the angle times the /
                    /distance for the desired distance away from the player minus the projectile's width   /
                    /and height divided by two so the center of the projectile is at the right place.     */
                    Main.projectile[ProjCount.ZenithProj[g]].position.X = Main.projectile[ZenithProjID].Center.X - (int)(Math.Cos(rad) * distX) - Main.projectile[ProjCount.ZenithProj[g]].width / 2;
                    Main.projectile[ProjCount.ZenithProj[g]].position.Y = Main.projectile[ZenithProjID].Center.Y - (int)(Math.Sin(rad) * distY) - Main.projectile[ProjCount.ZenithProj[g]].height / 2;

                    //Increase the counter/angle in degrees by 1 point, you can change the rate here too, but the orbit may look choppy depending on the value
                    RotationSpeed += 1.4f;
                    Main.projectile[ProjCount.ZenithProj[g]].timeLeft = 120;

                    Main.projectile[ProjCount.ZenithProj[g]].rotation = Main.projectile[ProjCount.ZenithProj[g]].rotation + (float)rad; // projectile faces sprite right
                    projectile.netUpdate = true;
                }      
            }
        }
        public override bool PreKill(int timeLeft)
        {
            SafePreKill(timeLeft);
            //if (projectile.owner == Main.projectile[ZenithProjID].owner && projectile.whoAmI != ZenithProjID)
            //{
            //    Main.NewText("Bye");
            //     NumActiveZenithProj--;
            //}
            if (projectile.type == ModContent.ProjectileType<ZenithsTrueBladesProj>())
            {
                ZenithActive = false;
                //Main.NewText("Length: " + ProjCount.ZenithProj.Count);
                for (int g = 0; g < ProjCount.ZenithProj.Count; g++)
                {
                    Main.projectile[ProjCount.ZenithProj[g]].Kill();
                }
            }
            return base.PreKill(timeLeft);
        }
        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            //for (int g = 0; g < ProjCount.ZenithProj.Count; g++)
            //{
            //    if (projectile.whoAmI == ProjCount.ZenithProj[g] && projectile.type == Main.projectile[ProjCount.ZenithProj[g]].type)
            //    {
            //        NumActiveZenithProj--;
            //        ProjCount.ZenithProj.RemoveAt(g);
            //    }
            //}
            SafeModifyHitNPC(target,ref damage,ref knockback,ref crit,ref hitDirection);
            if (projectile.penetrate != -1 && PenetrationBuffApplied == false && mod.ItemType("" + ParentWeapon.GetType()) != ModContent.ItemType<CorruptionNestKnives>() && mod.ItemType("" + ParentWeapon.GetType()) != ModContent.ItemType<CrimsonNestKnives>() && mod.ItemType("" + ParentWeapon.GetType()) != ModContent.ItemType<PrismaticArcanum>())
            {
                projectile.penetrate += ParentWeapon.PenetrationBonus;
                PenetrationBuffApplied = true;
            }
        }
        public void Hoods(NPC n)
        {
            ExamplePlayer p = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
            int effectLength = Main.rand.Next(300,600);
            if (p.pyro == true && p.HoodKeyPressed == false)
            {
                n.AddBuff(BuffID.OnFire, effectLength);
            }
            if (p.pyro == true && p.HoodKeyPressed == true)
            {
                n.AddBuff(ModContent.BuffType<Hellfire>(), effectLength);
            }
            if (p.dPyro == true && p.HoodKeyPressed == false)
            {
                n.AddBuff(BuffID.CursedInferno, effectLength);
            }
            if (p.dPyro == true && p.HoodKeyPressed == true)
            {
                n.AddBuff(ModContent.BuffType<CursedFire>(), effectLength);
            }
            if (p.Transmuter == true && p.HoodKeyPressed == false)
            {
                n.AddBuff(BuffID.Midas, effectLength);
            }
            if (p.Transmuter == true && p.HoodKeyPressed == true)
            {
                n.AddBuff(ModContent.BuffType<GildedCurse>(), 60);
            }
            if (p.Invoker == true && p.HoodKeyPressed == false)
            {
                n.AddBuff(BuffID.Ichor, effectLength);
            }
            if (p.Invoker == true && p.HoodKeyPressed == true)
            {
                n.AddBuff(ModContent.BuffType<IchorUproar>(), effectLength);
            }
            if (p.Mage == true && p.HoodKeyPressed == false)
            {
                int healamnt = (int)(projectile.damage * .75);
                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("ManaHeal"), healamnt, projectile.knockBack, projectile.owner); //Creates a new Projectile
            }
            if (p.Technomancer == true && p.HoodKeyPressed == false)
            {
                n.AddBuff(BuffID.Confused, effectLength);
            }
            if (p.Technomancer == true && p.HoodKeyPressed == true)
            {
                Random random = new Random();
                int ran1 = random.Next(-10, 10);
                int ran2 = random.Next(1, 6);
                Projectile.NewProjectile(n.position.X, n.position.Y, ran1, ran2, mod.ProjectileType("NaniteProjectile"), 15, projectile.knockBack, projectile.owner); //Creates a new Projectile
            }
            if (p.Party == true && p.HoodKeyPressed == false)
            {
                Projectile.NewProjectile(n.position.X, n.position.Y, 0, 0, 289, 0, 8, projectile.owner); //Creates a new Projectile
            }
            if (p.Party == true && p.HoodKeyPressed == true)
            {
                n.AddBuff(ModContent.BuffType<PartyBuff>(), effectLength);
                //Projectile.NewProjectile(n.position.X, n.position.Y, 0, 0, 289, 0, 8, projectile.owner); //Creates a new Projectile
            }
            if (p.Shaman == true && p.HoodKeyPressed == false)
            {
                n.AddBuff(BuffID.Poisoned, effectLength);
            }
            if (p.Shaman == true && p.HoodKeyPressed == true)
            {
                n.AddBuff(ModContent.BuffType<PenetratingPoison>(), effectLength);
            }
            if (p.WitchDoctor == true && p.HoodKeyPressed == false)
            {
                n.AddBuff(BuffID.Venom, effectLength);
            }
        }
        public int NumRicochets;
        public void Ricochet(Vector2 OldVelocity)
        {
            if (projectile.velocity.X != OldVelocity.X)
            {
                projectile.position.X = projectile.position.X + projectile.velocity.X;
                projectile.velocity.X = 0f - OldVelocity.X;
            }
            if (projectile.velocity.Y != OldVelocity.Y)
            {
                projectile.position.Y = projectile.position.Y + projectile.velocity.Y;
                projectile.velocity.Y = 0f - OldVelocity.Y;
            }
            NumRicochets++;
            if(NumRicochets > 5)
            {
                projectile.Kill();
            }
        }

        public override void OnHitNPC(NPC n, int damage, float knockback, bool crit)
        {
                Player owner = Main.player[projectile.owner];
                if (Main.rand.Next(0, HealProjChanceScale) <= HealProjChance)
                {
                    Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("HealProj"), (int)(projectile.damage * 0.75), 0, owner.whoAmI);
                }
                SafeOnHitNPC(n, damage, knockback, crit);
                Hoods(n);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            //for (int g = 0; g < ProjCount.ZenithProj.Count; g++)
            //{
            //    if (ZenithActive && projectile.whoAmI == ProjCount.ZenithProj[g] && projectile.type == ModContent.ProjectileType<NyivesBigProj>())
            //    {
            //        NumActiveZenithProj--;
            //        ProjCount.ZenithProj.RemoveAt(g);
            //    }
            //}
            //Main.NewText("Ricochet: " + ParentWeapon.RicochetChance);
            if (ParentWeapon.RicochetChance > Main.rand.NextFloat(0f, 1.0f))
            {
                Ricochet(oldVelocity);
            }
            SafeOnTileCollide(oldVelocity);
            if(SafeOnTileCollide(oldVelocity) == false)
            {
                TileCollision = false;
                return TileCollision;
            }
            else
            {
                return true;
            }
        }
    }
}