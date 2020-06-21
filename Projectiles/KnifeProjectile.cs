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

namespace VampKnives.Projectiles
{
    public abstract class KnifeProjectile : ModProjectile
    {
        public int ShatterTarget;
        bool PenetrationBuffApplied = false;
        bool TileCollision;
        public KnifeWeapon ParentWeapon = new KnifeWeapon();

        public virtual void SafeSetDefaults() {
        }
        public virtual bool SafeOnTileCollide(Vector2 OldVelocity){
            return true;
        }
        public virtual void SafeModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection){
        }
        public override void SetDefaults()
        {
            SafeSetDefaults();
        }
        public override bool PreAI()
        {
            if (ModContent.GetModItem(Main.LocalPlayer.HeldItem.type) is Items.KnifeDamageItem)
            {
                ParentWeapon = Main.LocalPlayer.HeldItem.GetGlobalItem<KnifeWeapon>();
                //Main.NewText("Weapon: " + ParentWeapon);
            }
            return true;
        }
        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            SafeModifyHitNPC(target,ref damage,ref knockback,ref crit,ref hitDirection);
            if (projectile.penetrate != -1 && PenetrationBuffApplied == false && mod.ItemType("" + ParentWeapon.GetType()) != ModContent.ItemType<CorruptionNestKnives>())
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
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
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