using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles
{

    class TestForRetroProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 6;
        }

        public override void SetDefaults()
        {
            projectile.width = 210;
            projectile.height = 128;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            //projectile.alpha = 255;
            projectile.penetrate = -1;
            projectile.timeLeft = 60;
            //projectile.ownerHitCheck = true;

            //1: projectile.penetrate = 1; // Will hit even if npc is currently immune to player
            //2a: projectile.penetrate = -1; // Will hit and unless 3 is use, set 10 ticks of immunity
            //2b: projectile.penetrate = 3; // Same, but max 3 hits before dying
            //5: projectile.usesLocalNPCImmunity = true;
            //5a: projectile.localNPCHitCooldown = -1; // 1 hit per npc max
            //5b: projectile.localNPCHitCooldown = 20; // o
        }

        //public override Color? GetAlpha(Color lightColor)
        //{
        //    //return Color.White;
        //    return new Color(255, 255, 255, 0) * (1f - (float)projectile.alpha / 255f);
        //}

        public override void AI()
        {
            //projectile.ai[0] += 1f;
            //if (projectile.ai[0] > 50f)
            //{
            //    // Fade out
            //    projectile.alpha += 25;
            //    if (projectile.alpha > 255)
            //    {
            //        projectile.alpha = 255;
            //    }
            //}
            //else
            //{
            //    // Fade in
            //    projectile.alpha -= 25;
            //    if (projectile.alpha < 100)
            //    {
            //        projectile.alpha = 100;
            //    }
            //}
            //// Slow down
            //projectile.velocity *= 0.98f;
            //// Loop through the 4 animation frames, spending 5 ticks on each.
            if (++projectile.frameCounter >= 5)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 6)
                {
                    projectile.frame = 0;
                }
            }
            // Since our sprite has an orientation, we need to adjust rotation to compensate for the draw flipping.
            //projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;

            //int DustID2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width - 3, projectile.height - 3, 127, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 10, Color.Red, 4f);
            //Main.dust[DustID2].noGravity = true;

            //VANILLA AI CODE
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
                if (player.channel && !player.noItems && !player.CCed)
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

            projectile.position = (player.RotatedRelativePoint(player.MountedCenter, true) - projectile.Size / 2f) + (projectile.velocity*6); // Set the position of the Arkhalis projectile, based on the 'Scale' vector.
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

    //class slasher : ModItem
    //{
    //    public override string Texture
    //    {
    //        get { return "Terraria/Item_" + ItemID.NebulaBlaze; }
    //    }

    //    public override void SetDefaults()
    //    {
    //        item.CloneDefaults(ItemID.NebulaBlaze);
    //        item.mana = 3;
    //        item.damage = 30;
    //        item.shoot = mod.ProjectileType<slash>();
    //    }
    //}
}