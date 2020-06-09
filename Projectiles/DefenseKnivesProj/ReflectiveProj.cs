using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VampKnives.Projectiles.DefenseKnivesProj;

namespace VampKnives.Projectiles.DefenseKnivesProj
{
    public class ReflectiveProj : ModProjectile
    {
        public float shootToX;
        public float shootToY;
        public float OwnerPositionX;
        public float OwnerPositionY;
        public float distance;
        public bool Hit;
        public int NumProjHits;
        public int SpectreDamage = 7;
        public float ReflectChance;
        public int Reflect;
        public bool IsPalladium;
        public bool IsOrichalcum;
        public bool IsMythril;
        public bool IsTitanium;
        public bool IsAdamantite;
        public bool IsChlorophyte;
        public bool IsSpectre;
        public bool IsShroomite;
        public bool IsElemental;
        public bool GottenChlorophyteVelocity = false;
        public Vector2 CholorphyteVelocity;

        public int TimerAdamantite;
        public int TimerChlorophyte;
        public float TimerShroomite;
        public int TimerOrichalcum = 200;
        public int TimerElemental;
        public int ShroomiteIterator;
        public bool FirstAdamantiteInitializeDone = false;
        public int NumIntersects;

        public bool HasCountedActive;

        List<Projectile> killlist = new List<Projectile>();
        public virtual void SafeSetDefaults(){
        }
        public override void SetDefaults()
        {
            projectile.knockBack = 60;
            projectile.friendly = true;
            projectile.penetrate = NumProjHits;                     
            projectile.hostile = false;
            projectile.magic = true;                 
            projectile.ignoreWater = true;
            projectile.timeLeft = 600;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 40;
            SafeSetDefaults();
        }
        public bool StopRotation = false;
        public bool GotPlayerPosition = false;
        public Vector2 ProjectileFrontRight;
        public Vector2 ProjectileFrontLeft;
        int ProjHits = 0;
        bool Stopped = false;
        int LifeAdd;
        int petalRandom;
        public override void AI()
        {
            if(projectile.timeLeft == 600)
            {
                ProjCount.NumberActive++;
            }
            if (GottenChlorophyteVelocity == false)
            {
                CholorphyteVelocity = projectile.velocity;
                GottenChlorophyteVelocity = true;
            }
            Reflect = (int)(Main.rand.Next(1, 101) * ReflectChance);
            Player owner = Main.player[projectile.owner];
            if(projectile.numUpdates == -1)
            {
                if (ProjCount.GetActiveConut() > ProjCount.MaxActive && projectile.timeLeft < 550)
                {
                    projectile.Kill();
                }
            }
            
            Random rand = new Random();
            if (GotPlayerPosition == false)
            {
                OwnerPositionX = owner.position.X + (float)owner.width * 0.5f;
                OwnerPositionY = owner.position.Y + (owner.height / 2);
                GotPlayerPosition = true;
            }
            if(IsPalladium || IsMythril || IsAdamantite || IsTitanium || IsChlorophyte || IsShroomite || IsElemental)
            {
                ExamplePlayer p = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
                for (int j = 0; j < Main.ActivePlayersCount; j++)
                {
                    Player DistanceTarget = Main.player[j];
                    float shootToX = DistanceTarget.position.X + (float)DistanceTarget.width * 0.5f - projectile.Center.X;
                    float shootToY = DistanceTarget.position.Y + (DistanceTarget.height / 2) - projectile.Center.Y;
                    float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));
                    if(IsPalladium)
                    {
                        if (Main.rand.Next(0, 101) > 30)
                        {
                            int numdust = Dust.NewDust(projectile.Center - new Vector2(250, 250), 400, 400, 183, 0f, 0f, 100, Color.Red, (float)(Main.rand.NextDouble()));
                            Dust projdust = Main.dust[numdust];
                            projdust.noGravity = true;
                        }
                        if (distance < 400 && Main.rand.Next(1, 500) == 7)
                        {
                            if (p.VampCurrent > 0)
                            {
                                LifeAdd = (int)(Main.rand.Next(4, 9) * Math.Log(p.VampCurrent));
                            }
                            else if (p.VampCurrent <= 0)
                            {
                                LifeAdd = Main.rand.Next(4, 9);
                            }
                            DistanceTarget.statLife += LifeAdd;
                            DistanceTarget.HealEffect(LifeAdd, false);
                        }
                    }
                    if (distance < 400 && IsMythril)
                    {
                        DistanceTarget.AddBuff(BuffID.AmmoBox,10);
                    }
                    if(distance < 400 && IsTitanium && !DistanceTarget.HasBuff(ModContent.BuffType<Buffs.TitaniumDefenseBuff>()))
                    {
                        DistanceTarget.AddBuff(ModContent.BuffType<Buffs.TitaniumDefenseBuff>(), 1000);
                    }
                    if (distance < 400 && IsAdamantite)
                    {
                        for (int Num223 = 0; Num223 < ProjCount.GetActiveAdamantite(); Num223++)
                        {
                            if(FirstAdamantiteInitializeDone == false)
                            {
                                if (Main.rand.Next(1, 101) > 95 + (1.5609f * Math.Pow(1.013, ProjCount.GetActiveAdamantite())))
                                {
                                    DistanceTarget.AddBuff(BuffID.ShadowDodge, 120);
                                    FirstAdamantiteInitializeDone = true;
                                }
                            }
                            TimerAdamantite++;
                            if (TimerAdamantite >= 8000)
                            {
                                if(Main.rand.Next(1, 101) > 90 + (1.5609f * Math.Pow(1.013, ProjCount.GetActiveAdamantite())))
                                {
                                    DistanceTarget.AddBuff(BuffID.ShadowDodge, 120);
                                }
                                TimerAdamantite = 0;
                            }
                        }
                        DistanceTarget.armorEffectDrawOutlines = true;
                        FirstAdamantiteInitializeDone = true;
                    }
                }
                if(IsChlorophyte)
                {
                    TimerChlorophyte++;
                    if(TimerChlorophyte > 20)
                    {
                        ProjectileFrontRight = new Vector2((projectile.Center.X + ((float)Math.Sin(projectile.rotation) * projectile.width / 2)), projectile.Center.Y - ((float)Math.Cos(projectile.rotation) * projectile.height / 2));
                        Projectile.NewProjectile(ProjectileFrontRight, CholorphyteVelocity, ModContent.ProjectileType<ChlorophytePetals>(), 12, 2, owner.whoAmI);
                        TimerChlorophyte = 0;
                    }
                }
                if(IsShroomite && ProjCount.GetActiveShroomiteGasCount() < 5 + (1.46794669 * Math.Pow(1.00839317, ProjCount.GetActiveShroomite())))
                {
                    ProjectileFrontRight = new Vector2((projectile.Center.X + ((float)Math.Sin(projectile.rotation) * projectile.width / 2)), projectile.Center.Y - ((float)Math.Cos(projectile.rotation) * projectile.height / 2));

                    double deg = Main.rand.Next(1,360); //The degrees, you can multiply projectile.ai[1] to make it orbit faster, may be choppy depending on the value
                    double OldDeg = deg;
                    if (OldDeg > deg - 5 && OldDeg < deg + 5)
                    {
                        deg = OldDeg + Main.rand.Next(4, 45);
                    }
                    double rad = deg * (Math.PI / 180); //Convert degrees to radians
                    double dist = 100; //Distance away from the player
                    

                    /*Position the projectile based on where the player is, the Sin/Cos of the angle times the /
                    /distance for the desired distance away from the player minus the projectile's width   /
                    /and height divided by two so the center of the projectile is at the right place.     */
                    float ProjectileXSpawn = OwnerPositionX - (int)(Math.Cos(rad) * dist) - ShroomiteGas.Width / 2;
                    float ProjectileYSpawn = OwnerPositionY - (int)(Math.Sin(rad) * dist) - ShroomiteGas.Height / 2;
                    Vector2 ShroomiteProjectileSpawnPos = new Vector2(ProjectileXSpawn,ProjectileYSpawn+100);

                    TimerShroomite += 2f * (float)MathHelper.ToRadians(Main.rand.Next(1,360));
                    if(TimerShroomite > 20)
                    {
                        ProjCount.ShroomiteIterator++;
                        if (ProjCount.GetShroomiteIterator() > 5)
                        {
                            Projectile.NewProjectile(ShroomiteProjectileSpawnPos, new Vector2(0f, 0f), ModContent.ProjectileType<ShroomiteGas>(), 2, 0, owner.whoAmI);
                            ProjCount.ShroomiteIterator = 0;
                        }
                        TimerShroomite = 0;
                    }
                }
                if(IsElemental)
                {
                    float ProjectileRotationFactorRight = 45;
                    float ProjectileRotationFactorLeft = -45;
                    double StartAngleRight = Math.Atan2(CholorphyteVelocity.X, CholorphyteVelocity.Y) - ProjectileRotationFactorRight / 2;
                    double StartAngleLeft = Math.Atan2(CholorphyteVelocity.X, CholorphyteVelocity.Y) - ProjectileRotationFactorLeft / 2;
                    float ElementalSpeedX = CholorphyteVelocity.X;
                    float ElementalSpeedY = CholorphyteVelocity.Y;
                    float ElementalSpeed = (float)Math.Sqrt(ElementalSpeedX * ElementalSpeedX + ElementalSpeedY * ElementalSpeedY);
                    TimerElemental++;
                    if (TimerElemental > 40)
                    {
                        ProjectileFrontRight = new Vector2((projectile.Center.X + ((float)Math.Sin(MathHelper.ToRadians(ProjectileRotationFactorRight)) * projectile.width / 2)), projectile.Center.Y - ((float)Math.Cos(MathHelper.ToRadians(ProjectileRotationFactorRight)) * projectile.height / 2));
                        Projectile.NewProjectile(ProjectileFrontRight, new Vector2(ElementalSpeed * -(float)Math.Sin(StartAngleRight), ElementalSpeed * -(float)Math.Cos(StartAngleRight)), ModContent.ProjectileType<ElementalDefProj>(), 12, 2, owner.whoAmI);

                        ProjectileFrontLeft = new Vector2((projectile.Center.X - ((float)Math.Sin(MathHelper.ToRadians(ProjectileRotationFactorLeft)) * projectile.width / 2)), projectile.Center.Y + ((float)Math.Cos(MathHelper.ToRadians(ProjectileRotationFactorLeft)) * projectile.height / 2));
                        Projectile.NewProjectile(ProjectileFrontLeft, new Vector2(ElementalSpeed * -(float)Math.Sin(StartAngleLeft), ElementalSpeed * -(float)Math.Cos(StartAngleLeft)), ModContent.ProjectileType<ElementalDefProj>(), 12, 2, owner.whoAmI);
                        TimerElemental = 0;
                    }
                }
            }
            //CODE ADAPTED FROM werickson24's ShieldMod. This projectile behavior is heavily based on his work!
            for (int s = 0; s < 1000; s++)
            {
                if (Main.projectile[s].active && Main.projectile[s].hostile)/* && !Array.Exists(blacklist, element => element == Main.projectile[s].type))*/
                {
                        Projectile ProJ = Main.projectile[s];
                    if (Colliding(projectile.Hitbox, ProJ.Hitbox) == true && Reflect <= 60)
                    {
                        for (int b = 0; b < 10; b++)
                        {
                            double YRand = rand.Next(1, 5) * rand.NextDouble();
                            double XRand = rand.Next(1, 3) * rand.NextDouble();
                            int numdust2 = Dust.NewDust(ProJ.position, 6, 6, 25, 0f, 0f, 100, Color.Brown, 1f);
                            Dust ProjHitDust = Main.dust[numdust2];
                            ProjHitDust.velocity = new Vector2((0.01f) * -ProJ.velocity.X * (float)(b / XRand), (0.1f) * -ProJ.velocity.Y * (float)(b / YRand));
                            ProjHitDust.noGravity = false;
                        }
                        ProjHits += 1;
                        ProJ.Kill();
                        if (ProjHits > NumProjHits)
                        {
                            projectile.Kill();
                            for (int num641 = 0; num641 < 50; num641++)
                            {
                                int numdust = Dust.NewDust(projectile.Center, 6, 6, 268, 0f, 0f, 100, Color.Brown, 1f);
                                Dust projdust = Main.dust[numdust];
                                float num646 = projdust.velocity.X;
                                float y3 = projdust.velocity.Y;
                                if (num646 == 0f && y3 == 0f)
                                {
                                    num646 = 1f;
                                }
                                float num647 = (float)Math.Sqrt(num646 * num646 + y3 * y3);
                                num647 = 4f / num647;
                                num646 *= num647;
                                y3 *= num647;
                                projdust.velocity *= 0.5f;
                                projdust.velocity.X += num646;
                                projdust.scale = 1.3f;
                            }
                        }
                        //if (killlist.Contains(ProJ))
                        //{
                        //    killlist.Remove(ProJ);
                        //    ProJ.Kill();
                        //}
                        if (IsSpectre && Main.rand.Next(1, 15) == 7)
                        {
                            Projectile.NewProjectile(projectile.Center, new Vector2(0f, 0f), ModContent.ProjectileType<SpectreDefProj>(), SpectreDamage, 2, owner.whoAmI);
                        }
                    }
                    else if (Colliding(projectile.Hitbox, ProJ.Hitbox) == true && Reflect > 60)
                    {
                        ProJ.velocity = new Vector2(-ProJ.velocity.X, -ProJ.velocity.Y);
                        Vector2 rotVector = (projectile.rotation - MathHelper.ToRadians(90f)).ToRotationVector2(); 
                        killlist.Add(ProJ);
                        for (int num61 = 0; num61 < 6; num61++)
                        {
                            int RandomJump = Main.rand.Next(0, 11);
                            int numdust2 = Dust.NewDust(ProJ.position, 6, 6, 26, 0f, 0f, 100, Color.Gray, 1f);
                            Dust ProjHitDust = Main.dust[numdust2];
                            ProjHitDust.velocity += rotVector * 2f;
                            ProjHitDust.velocity *= 0.75f;
                            ProjHitDust.noGravity = true;
                        }
                        if (IsSpectre && Main.rand.Next(1, 15) == 7)
                        {
                            Projectile.NewProjectile(projectile.Center, new Vector2(0f, 0f), ModContent.ProjectileType<SpectreDefProj>(), SpectreDamage, 2, owner.whoAmI);
                        }
                    }
                }
            }
            for (int i = 0; i < 200; i++)
            {
                shootToX = OwnerPositionX - projectile.Center.X;
                shootToY = OwnerPositionY - projectile.Center.Y;
                distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));
                if (StopRotation == false)
                {
                    projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
                }
                if (distance > 200f && owner.active)
                {
                    projectile.velocity = new Vector2(0,0);
                    StopRotation = true;
                }
            }

            Rectangle rectangle4 = new Rectangle((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height);
            for (int NPCDist = 0; NPCDist < 200; NPCDist++)
            {
                if (IsOrichalcum && Main.npc[NPCDist].active && !Main.npc[NPCDist].friendly)
                {
                    TimerOrichalcum += Main.rand.Next(1,4);
                    if (TimerOrichalcum == 460)
                    {
                        float PosX = projectile.position.X + Main.rand.Next(-500,500);
                        float PosY = projectile.position.Y - Main.screenHeight;
                        if (Main.rand.Next(1,11) < 5)
                        {
                            PosY = projectile.position.Y + Main.screenHeight;
                        }
                        Projectile.NewProjectile(PosX, PosY, 0f, -15f, ModContent.ProjectileType<OrichalcumPetals>(), Main.rand.Next(9,16), 0f, owner.whoAmI, 0f, 0f);
                        TimerOrichalcum = 0;
                   }
                }
                if (Main.npc[NPCDist].active && !Main.npc[NPCDist].dontTakeDamage && Main.npc[NPCDist].lifeMax > 1 && Main.npc[NPCDist].knockBackResist >= 0 && !Main.npc[NPCDist].friendly)
                {
                    Rectangle value11 = new Rectangle((int)Main.npc[NPCDist].position.X, (int)Main.npc[NPCDist].position.Y, Main.npc[NPCDist].width, Main.npc[NPCDist].height);
                    if (rectangle4.Intersects(value11))
                    {
                        Main.npc[NPCDist].velocity = -Main.npc[NPCDist].velocity;
                        NumIntersects++;
                        if (NumIntersects > 5 && rectangle4.Intersects(value11))
                        {
                            shootToX = projectile.position.X - Main.npc[NPCDist].Center.X;
                            shootToY = projectile.position.Y - Main.npc[NPCDist].Center.Y;
                            distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));
                            if (projectile.rotation > MathHelper.ToRadians(90) && projectile.rotation < MathHelper.ToRadians(270))
                            {
                                Main.npc[NPCDist].position.X += shootToX + Main.npc[NPCDist].Size.X;
                                Main.npc[NPCDist].position.Y += shootToY + Main.npc[NPCDist].Size.Y;
                            }
                            else
                            {
                                Main.npc[NPCDist].position.X -= shootToX + Main.npc[NPCDist].Size.X;
                                Main.npc[NPCDist].position.Y -= shootToY + Main.npc[NPCDist].Size.Y;
                            }
                            NumIntersects = 0;
                        }

                        if (IsSpectre && Main.rand.Next(1,15) == 7)
                        {
                            Projectile.NewProjectile(projectile.Center, new Vector2(0f, 0f), ModContent.ProjectileType<SpectreDefProj>(), SpectreDamage, 2, owner.whoAmI);
                        }
                    }
                    //else
                    //{
                    //    NumIntersects = 0;
                    //}
                }
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.velocity *= 0.5f;
            return false;
        }
        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            bool flag;
            Vector2 clamped = Vector2.Clamp(projectile.Center, targetHitbox.Left(), targetHitbox.Right());
            if (PosHit(clamped))
            {
                flag = Math.Pow(20, 2) > Vector2.DistanceSquared(projectile.Center, clamped);
            }
            else
            {
                flag = false;
            }
            return flag;
        }

        public bool PosHit(Vector2 targetPosition)
        {
            if (WorldGen.SolidTile((int)targetPosition.X / 16, (int)targetPosition.Y / 16))
            {
                return false;
            }
            Vector2 vector = Vector2.Clamp(targetPosition, new Vector2(projectile.Center.X - 16, projectile.Center.Y - 16), new Vector2(projectile.Center.X + 16, projectile.Center.Y + 16));
            bool flag = Collision.CanHitLine(vector, 0, 0, targetPosition, 0, 0);
            if (!flag)
            {
                Vector2 v = targetPosition - vector;
                Vector2 spinningpoint = v.SafeNormalize(Vector2.UnitY);
                Vector2 value = Vector2.Lerp(vector, targetPosition, 0.5f);
                Vector2 vector2 = value + spinningpoint.RotatedBy(1.5707963705062866, default(Vector2)) * v.Length() * 0.15f;
                if (Collision.CanHitLine(vector, 0, 0, vector2, 0, 0) && Collision.CanHitLine(vector2, 0, 0, targetPosition, 0, 0))
                {
                    flag = true;
                }
                if (!flag)
                {
                    Vector2 vector3 = value + spinningpoint.RotatedBy(-1.5707963705062866, default(Vector2)) * v.Length() * 0.15f;
                    if (Collision.CanHitLine(vector, 0, 0, vector3, 0, 0) && Collision.CanHitLine(vector3, 0, 0, targetPosition, 0, 0))
                    {
                        flag = true;
                    }
                }
            }
            return flag;
        }

        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            knockback = 60;
            double DirChk = target.Center.X - projectile.Center.X;
            if (DirChk > 0)
            {
                hitDirection = 1;
            }
            else
            {
                hitDirection = -1;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (IsSpectre && Main.rand.Next(1, 15) == 7)
            {
                Player owner = Main.player[projectile.owner];
                Projectile.NewProjectile(projectile.Center, new Vector2(0f, 0f), ModContent.ProjectileType<SpectreDefProj>(), SpectreDamage, 2, owner.whoAmI);
            }
        }
        public override bool PreKill(int timeLeft)
        {
            ProjCount.NumberActive--;
            return true;
        }

        //public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        //{
        //    if (target.knockBackResist == 0)
        //    {
        //        float NPCVelocityX = target.velocity.X;
        //        float NPCVelocityY = target.velocity.Y;
        //        VampKnives test = new VampKnives();
        //        target.velocity = -target.velocity;
        //        VampKnives.MyPacket = test.GetPacket();
        //        VampKnives.MyPacket.Write(VampKnives.MyPacketIdentifier);
        //        VampKnives.MyPacket.Write(NPCVelocityX);
        //        VampKnives.MyPacket.Write(NPCVelocityY);
        //        VampKnives.MyPacket.Write(target.whoAmI);
        //        VampKnives.MyPacket.Send();
        //    }
        //}
    }
}