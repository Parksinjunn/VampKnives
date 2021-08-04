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
        public static int HealProjBossChanceScale = 101;
        public static int HealProjBossChance = 25;
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
                RandomVelocity = 0f;
                projectile.tileCollide = false;
                projectile.aiStyle = 0;
                projectile.penetrate = 1;
                projectile.timeLeft = 20;
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
                    if (Main.projectile[ProjCount.ZenithProj[g]].type == ModContent.ProjectileType<HealProj>() || Main.projectile[ProjCount.ZenithProj[g]].type == ModContent.ProjectileType<ManaHeal>() || Main.projectile[ProjCount.ZenithProj[g]].type == ProjectileID.Bee)
                    {
                        Main.projectile[ProjCount.ZenithProj[g]].Kill();
                    }
                    //Main.NewText("ProjXBefore: " + Main.projectile[ProjCount.ZenithProj[g]].position.X);
                    Player p = Main.player[projectile.owner];

                    double deg = (double)RotationSpeed + (60*g); 
                    double rad = deg * (Math.PI / 180);

                    float distX = 120f; 
                    float distY = 120f;

                    //float a = (Main.projectile[ZenithProjID].position.X - p.position.X);
                    //float b = (Main.projectile[ZenithProjID].position.Y - p.position.Y);
                    float a = 1f;
                    float b = 1f;

                    Main.projectile[ProjCount.ZenithProj[g]].position.X = Main.projectile[ZenithProjID].Center.X - (float)(a * (Math.Cos(rad) * distX)) - Main.projectile[ProjCount.ZenithProj[g]].width / 2f;
                    Main.projectile[ProjCount.ZenithProj[g]].position.Y = Main.projectile[ZenithProjID].Center.Y - (float)(b * (Math.Sin(rad) * distY)) - Main.projectile[ProjCount.ZenithProj[g]].height / 2f;

                    RotationSpeed += 1f;
                    //Main.projectile[ProjCount.ZenithProj[g]].alpha+=1; //WHAT THE FUCK DID I DO
                    //int DustID2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width - 3, projectile.height - 3, 184, projectile.velocity.X * 0f, projectile.velocity.Y * 0f, 10, Color.LightGreen, 1.5f);
                    //Main.dust[DustID2].noGravity = false;
                    //Main.projectile[ProjCount.ZenithProj[g]].rotation = (float)rad + MathHelper.PiOver2 + 0.5f;
                    projectile.netUpdate = true;
                    //Main.NewText("ProjXAfter: " + Main.projectile[ProjCount.ZenithProj[g]].position.X);
                }
                //Main.NewText("NumProj: " + countOfProj);
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
            if(!n.boss)
            {
                if (Main.rand.Next(0, HealProjChanceScale) <= VampKnives.HealProjectileSpawn)
                {
                    Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("HealProj"), (int)(projectile.damage * 0.75), 0, owner.whoAmI);
                }
            }
            else if(n.boss)
            {
                if (Main.rand.Next(0, HealProjBossChanceScale) <= HealProjBossChance)
                {
                    Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("HealProj"), (int)(projectile.damage * 0.75), 0, owner.whoAmI);
                }
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