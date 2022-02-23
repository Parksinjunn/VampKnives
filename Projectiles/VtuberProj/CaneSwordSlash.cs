using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles.VtuberProj
{

    class CaneSwordSlash : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 24;
        }
        int Cooldown;
        public override void SetDefaults()
        {
            projectile.width = 120;
            projectile.height = 152;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.penetrate = 1;
            projectile.timeLeft = 60;
            //projectile.ownerHitCheck = true;

            //1: projectile.penetrate = 1; // Will hit even if npc is currently immune to player
            //2a: projectile.penetrate = -1; // Will hit and unless 3 is use, set 10 ticks of immunity
            //2b: projectile.penetrate = 3; // Same, but max 3 hits before dying
            //5: projectile.usesLocalNPCImmunity = true;
            //5a: projectile.localNPCHitCooldown = -1; // 1 hit per npc max
            //5b: projectile.localNPCHitCooldown = 20; // o
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            projectile.penetrate++;
            Cooldown = 2;
        }
        public override bool CanDamage()
        {
            if(Cooldown == 0)
            {
                return true;
            }
            else
            {
                Cooldown--;
                return false;
            }
        }
        public override void AI()
        {
            if (++projectile.frame >= 24)
            {
                projectile.frame = 0;
            }
            if (projectile.frame == 0 || projectile.frame == 15)
            {
                int Rando = Main.rand.Next(0, 100);
                if (Rando <= 49)
                {
                    Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/SwordCaneStab").WithVolume(1f).WithPitchVariance(Main.rand.NextFloat(-0.10f, 0.10f)), projectile.position);
                }
                else if (Rando == 50)
                {
                    Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/SwordCaneDIE").WithVolume(1f).WithPitchVariance(Main.rand.NextFloat(-0.10f, 0.10f)), projectile.position);
                }
                else
                {
                    Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/SwordCaneStab2").WithVolume(1f).WithPitchVariance(Main.rand.NextFloat(-0.10f, 0.10f)), projectile.position);
                }
            }

            Player player = Main.LocalPlayer;
            float num = 1.57079637f;
            Vector2 vector = player.RotatedRelativePoint(player.MountedCenter, true);
            num = 0f;
            if (projectile.direction == -1)
            {
                num = 3.14159274f;
            }
            if (Main.myPlayer == projectile.owner)
            {
                if (player.altFunctionUse == 2 && !player.noItems && !player.CCed)
                {
                    float scaleFactor6 = 1f;
                    if (player.inventory[player.selectedItem].shoot == projectile.type)
                    {
                        scaleFactor6 = player.inventory[player.selectedItem].shootSpeed * projectile.scale;
                    }
                    Vector2 vector16 = Main.MouseWorld - vector;
                    vector16.Normalize();
                    if (vector16.HasNaNs())
                    {
                        vector16 = Vector2.UnitX * (float)player.direction;
                    }
                    vector16 *= scaleFactor6;
                    if (vector16.X != projectile.velocity.X || vector16.Y != projectile.velocity.Y)
                    {
                        projectile.netUpdate = true;
                    }
                    projectile.velocity = vector16;
                }
                else
                    projectile.Kill();
                if (Main.mouseRightRelease == true && projectile.active)
                {
                    projectile.Kill();
                }
            }
            Vector2 vector17 = projectile.Center + projectile.velocity * 3f;
            Lighting.AddLight(vector17, 0.8f, 0.8f, 0.8f);
            if (Main.rand.Next(3) == 0)
            {
                int num30 = Dust.NewDust(vector17 - projectile.Size / 2f, projectile.width, projectile.height, 63, projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 2f);
                Main.dust[num30].noGravity = true;
                Main.dust[num30].position -= projectile.velocity;
            }

            projectile.position = (player.RotatedRelativePoint(player.MountedCenter, true) - projectile.Size / 2f) + (projectile.velocity * 2); // Set the position of the Arkhalis projectile, based on the 'Scale' vector.
            projectile.rotation = projectile.velocity.ToRotation() + num; // As you can see, we apply the rotation of this projectile based on the velocity AND the 'num' variable.
                                                                          // Now, I'm sure that the 'num' variable is needed here, but since it's hardcoded, I'm not exactly sure WHAT is does.
                                                                          // You'll just have to fiddle around a bit with setting the 'num' variable untill you achieve the correct rotation.
            projectile.spriteDirection = projectile.direction; // Make sure that the visual direction of the projectile is set correctly.
            projectile.timeLeft = 2; // Makes sure that if this update does not get called a second time, this projectile is destroyed since it's only able to live for 2 more ticks.
            player.ChangeDir(projectile.direction); // Makes sure that the owner of this projectile isfacing the same way that the projectile is (so that you don't get a situation in which
                                                    // the projectile is on the left side of the player while the player is still facing the right.
            player.heldProj = projectile.whoAmI; // Again, not exactly sure what this is good for (you can test by commenting this line out of course, although my lucky guess is
                                                 // that it'll break something for sure.
            player.itemTime = 2; // Hmm yeah, not really know what I should explain about this...
            player.itemAnimation = 2; // This is actually where we make sure that the player sticks to one animation. If you were to change the animation of your new Arkhalis,
                                      // this is probably where you'd want to do this.
                                      // For this last line you might want to read up what Atan2 actually does, but you might be able to guess what this does based on the 'itemRotation' name.
                                      // This doesn't really do anything for the actual AI of the projectile, but makes sure that the 'item' is facing the correct way (although the player is not actually
                                      // holding anything :p).
            player.itemRotation = (float)Math.Atan2((double)(projectile.velocity.Y * (float)projectile.direction), (double)(projectile.velocity.X * (float)projectile.direction));
        }
    }
}