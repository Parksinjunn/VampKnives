﻿using VampKnives.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;

namespace VampKnives.Projectiles
{
    public class VampiricPrismHeldProj : KnifeProjectile
    {

        // The vanilla Last Prism is an animated item with 5 frames of animation. We copy that here.
        private const int NumAnimationFrames = 8;

        // This value controls how many frames it takes for the Prism to reach "max charge". 60 frames = 1 second.
        public const float MaxCharge = 1000f;
        float ChargeCounter;
        float ChargeDivisionFactor = 40f;
        static int ShootTimerMax = 50;
        int ShootTimer;
        static int DustTimerMax = 17;
        int DustTimer;
        int HealthTimer;

        // This value controls how many frames it takes for the beams to begin dealing damage. Before then they can't hit anything.
        public const float DamageStart = 1f;

        // This value controls how sluggish the Prism turns while being used. Vanilla Last Prism is 0.08f.
        // Higher values make the Prism turn faster.
        private const float AimResponsiveness = 0.3f;

        // This value controls how frequently the Prism emits sound once it's firing.
        private const int SoundInterval = 20;

        // These values place caps on the mana consumption rate of the Prism.
        // When first used, the Prism consumes mana once every MaxManaConsumptionDelay frames.
        // Every time mana is consumed, the pace becomes one frame faster, meaning mana consumption smoothly increases.
        // When capped out, the Prism consumes mana once every MinManaConsumptionDelay frames.
        private const float MaxManaConsumptionDelay = 15f;
        private const float MinManaConsumptionDelay = 5f;

        // This property encloses the internal AI variable projectile.ai[0]. It makes the code easier to read.
        private float FrameCounter
        {
            get => projectile.ai[0];
            set => projectile.ai[0] = value;
        }

        // This property encloses the internal AI variable projectile.ai[1].
        private float NextManaFrame
        {
            get => projectile.ai[1];
            set => projectile.ai[1] = value;
        }

        // This property encloses the internal AI variable projectile.localAI[0].
        // localAI is not automatically synced over the network, but that does not cause any problems in this case.
        private float ManaConsumptionRate
        {
            get => projectile.localAI[0];
            set => projectile.localAI[0] = value;
        }
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Example Last Prism");
            Main.projFrames[projectile.type] = NumAnimationFrames;

            // Signals to Terraria that this projectile requires a unique identifier beyond its index in the projectile array.
            // This prevents the issue with the vanilla Last Prism where the beams are invisible in multiplayer.
            ProjectileID.Sets.NeedsUUID[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            ShootTimer = 50;
            DustTimer = 17;
            // Use CloneDefaults to clone all basic projectile statistics from the vanilla Last Prism.
            projectile.CloneDefaults(ProjectileID.LastPrism);
        }

        public override void AI()
        {
            if (ChargeCounter < 360)
            {
                ChargeCounter++;
            }
            Player player = Main.player[projectile.owner];
            ExamplePlayer p = player.GetModPlayer<ExamplePlayer>();

            HealthTimer += (int)(1 + (ChargeCounter / 72));
            if(HealthTimer > 10)
            {
                HealthTimer = 0;
                player.statLife-= (int)(1 + (ChargeCounter / 360));
            }

            Vector2 rrp = player.RotatedRelativePoint(player.MountedCenter, true);

            // Update the frame counter.
            FrameCounter += 1f;

            // Update projectile visuals and sound.
            UpdateAnimation();
            PlaySounds();

            // Update the Prism's position in the world and relevant variables of the player holding it.
            UpdatePlayerVisuals(player, rrp);

            // Update the Prism's behavior: project beams on frame 1, consume mana, and despawn if out of mana.
            if (projectile.owner == Main.myPlayer)
            {
                // Slightly re-aim the Prism every frame so that it gradually sweeps to point towards the mouse.
                UpdateAim(rrp, player.HeldItem.shootSpeed);

                // The Prism immediately stops functioning if the player is Cursed (player.noItems) or "Crowd Controlled", e.g. the Frozen debuff.
                // player.channel indicates whether the player is still holding down the mouse button to use the item.
                bool stillInUse = player.channel && !player.noItems && !player.CCed;

                // Spawn in the Prism's lasers on the first frame if the player is capable of using the item.
                if (stillInUse)
                {
                    DustTimer++;
                    if (DustTimer >= DustTimerMax)
                    {
                        
                        //Main.NewText("End1: " + End1);
                        //Main.NewText("End2: " + End2);
                    }
                    float numProjectiles2 = player.GetModPlayer<ExamplePlayer>().NumProj + player.GetModPlayer<ExamplePlayer>().ExtraProj;
                    int ShootTimerAdd = (int)(1f * (ChargeCounter / (MaxCharge / ChargeDivisionFactor + numProjectiles2)));
                    if(ShootTimerAdd < 1)
                    {
                        ShootTimer++;
                    }
                    else
                    {
                        ShootTimer += ShootTimerAdd;
                    }
                    if (ShootTimer > ShootTimerMax)
                    {
                        float speedX = projectile.velocity.X;
                        float speedY = projectile.velocity.Y;
                        int ran = (int)(Main.rand.NextFloat(-70 + (ShootTimerAdd * 6), 70 - (ShootTimerAdd * 6)));
                        float spread = MathHelper.ToRadians(ran);
                        float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
                        double startAngle = Math.Atan2(speedX, speedY) - spread / 2;
                        double deltaAngle = spread / (float)numProjectiles2;
                        double offsetAngle;

                        offsetAngle = startAngle + deltaAngle;
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, baseSpeed * (float)Math.Sin(offsetAngle), baseSpeed * (float)Math.Cos(offsetAngle), ProjectileType<VampiricPrismProj>(), projectile.damage, projectile.knockBack, player.whoAmI);

                        //DUST SPAWN CODE
                        float ProjectileRotationDeg = MathHelper.ToDegrees(projectile.rotation - (90f * (float)Math.PI / 180f));
                        float ProjectileRotationRad = projectile.rotation - (90f * (float)Math.PI / 180f);
                        if (ProjectileRotationDeg < 0)
                        {
                            ProjectileRotationDeg = 180 + (180 + ProjectileRotationDeg);
                            ProjectileRotationRad = (180f * (float)Math.PI / 180f) + ((180f * (float)Math.PI / 180f) + ProjectileRotationRad);
                        }
                        DustTimer = 0;
                        Vector2 DustPosition = projectile.Hitbox.Center.ToVector2();
                        //int DustID3 = Dust.NewDust(DustPosition, 1, 1, 15, 0f, 0f, 10, new Color(0, 255, 0), 2f);
                        //Main.dust[DustID3].noGravity = true;
                        //Main.dust[DustID3].velocity *= 0;
                        //p.OvalDust(DustPosition, 4, 4, player, Color.LightBlue, 15, 1f);
                        float scaleFactor = (float)(Math.Sqrt(Math.Pow(projectile.velocity.X, 2) + Math.Pow(projectile.velocity.Y, 2)));
                        //Main.NewText("Rotation: " + projectile.rotation);
                        //Main.NewText("Velocity X: " + projectile.velocity.X);
                        //Main.NewText("Velocity Y: " + projectile.velocity.Y);
                        //Main.NewText("ScaleFactor" + scaleFactor);
                        //Main.NewText("Angle: " + ProjectileRotationDeg);
                        //float VelocityToRotation = projectile.velocity.ToRotation();
                        if (projectile.rotation > -90f * (float)(Math.PI/180) && projectile.rotation < 49.7f * (float)(Math.PI / 180))
                        {
                            DustPosition.X = (float)((DustPosition.X) + ((Math.Sin(projectile.rotation) * (scaleFactor)) - (4f + projectile.rotation)));
                            DustPosition.Y = (float)((DustPosition.Y) - ((Math.Cos(projectile.rotation) * (scaleFactor)) + 3f));
                        }
                        else if (projectile.rotation > 49.7f * (float)(Math.PI / 180)) 
                        {
                            DustPosition.X = (float)((DustPosition.X) + ((Math.Sin(projectile.rotation) * (scaleFactor)) - (8f - projectile.rotation)));
                            DustPosition.Y = (float)((DustPosition.Y) - ((Math.Cos(projectile.rotation) * (scaleFactor)) + 5f));
                        }
                        Vector2 VelocityXYMult = projectile.rotation.ToRotationVector2();
                        float SizeX;
                        float SizeY;
                        if (ProjectileRotationDeg > 0 && ProjectileRotationDeg < 270)
                        {
                            SizeX = 1.25f + (0.25f * (float)Math.Cos(2 * ProjectileRotationRad));
                            SizeY = 1.25f + (0.25f * (float)Math.Sin(2 * ProjectileRotationRad));
                        }
                        else
                        {
                            SizeX = 1.25f + (0.25f * (float)Math.Cos(2 * ((360 * Math.PI / 180) + ProjectileRotationRad)));
                            SizeY = 1.25f + (0.25f * (float)Math.Sin(2 * ((360 * Math.PI / 180) + ProjectileRotationRad)));
                        }

                        float End1;
                        float End2;
                        End1 = 330 + (60 * ProjectileRotationRad);
                        End2 = End1 + 60;
                        while (End1 > 360)
                        {
                            End1 = End1 - 360;
                        }
                        while (End2 > 360)
                        {
                            End2 = End2 - 360;
                        }
                        //SizeX *= 5f;
                        //SizeY *= 5f;
                        if (player.velocity.X == 0 && player.velocity.Y == 0)
                        {
                            p.OvalDust(DustPosition, SizeY, SizeX, player, Color.Red, 15, 1f, false, true, new Vector2(End1, End2));
                        }
                        else
                        {
                            p.OvalDust(DustPosition, SizeY, SizeX, player, Color.Red, 15, 1f, false);
                        }
                        //END DUST SPAWN CODE
                        ShootTimer = 0;
                    }
                }
                else if (!stillInUse)
                {
                    projectile.Kill();
                }
            }
            projectile.timeLeft = 2;
        }

        private void UpdateAnimation()
        {
            projectile.frameCounter++;

            int framesPerAnimationUpdate = FrameCounter >= MaxCharge ? 1 : FrameCounter >= (MaxCharge * 0.80f) ? 2 : FrameCounter >= (MaxCharge * 0.60f) ? 3 : FrameCounter >= (MaxCharge * 0.40f) ? 4 : FrameCounter >= (MaxCharge * 0.20f) ? 5 : 6;

            if (projectile.frameCounter >= framesPerAnimationUpdate)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= NumAnimationFrames)
                {
                    projectile.frame = 0;
                }
            }
        }

        private void PlaySounds()
        {
            // The Prism makes sound intermittently while in use, using the vanilla projectile variable soundDelay.
            if (projectile.soundDelay <= 0)
            {
                projectile.soundDelay = SoundInterval;

                // On the very first frame, the sound playing is skipped. This way it doesn't overlap the starting hiss sound.
                if (FrameCounter > 1f)
                {
                    Main.PlaySound(SoundID.Item15, projectile.position);
                }
            }
        }

        private void UpdatePlayerVisuals(Player player, Vector2 playerHandPos)
        {
            // Place the Prism directly into the player's hand at all times.
            projectile.Center = playerHandPos;
            // The beams emit from the tip of the Prism, not the side. As such, rotate the sprite by pi/2 (90 degrees).
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
            projectile.spriteDirection = projectile.direction;

            // The Prism is a holdout projectile, so change the player's variables to reflect that.
            // Constantly resetting player.itemTime and player.itemAnimation prevents the player from switching items or doing anything else.
            player.ChangeDir(projectile.direction);
            player.heldProj = projectile.whoAmI;
            player.itemTime = 2;
            player.itemAnimation = 2;

            // If you do not multiply by projectile.direction, the player's hand will point the wrong direction while facing left.
            player.itemRotation = (projectile.velocity * projectile.direction).ToRotation();
        }

        private void UpdateAim(Vector2 source, float speed)
        {
            // Get the player's current aiming direction as a normalized vector.
            Vector2 aim = Vector2.Normalize(Main.MouseWorld - source);
            if (aim.HasNaNs())
            {
                aim = -Vector2.UnitY;
            }

            // Change a portion of the Prism's current velocity so that it points to the mouse. This gives smooth movement over time.
            aim = Vector2.Normalize(Vector2.Lerp(Vector2.Normalize(projectile.velocity), aim, AimResponsiveness));
            aim *= speed;

            if (aim != projectile.velocity)
            {
                projectile.netUpdate = true;
            }
            projectile.velocity = aim;
        }

        // Because the Prism is a holdout projectile and stays glued to its user, it needs custom drawcode.
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            SpriteEffects effects = projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            Texture2D texture = Main.projectileTexture[projectile.type];
            int frameHeight = texture.Height / Main.projFrames[projectile.type];
            int spriteSheetOffset = frameHeight * projectile.frame;
            Vector2 sheetInsertPosition = (projectile.Center + Vector2.UnitY * projectile.gfxOffY - Main.screenPosition).Floor();

            // The Prism is always at full brightness, regardless of the surrounding light. This is equivalent to it being its own glowmask.
            // It is drawn in a non-white color to distinguish it from the vanilla Last Prism.
            Color drawColor = new Color(255,0,0);
            spriteBatch.Draw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), drawColor, projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), projectile.scale, effects, 0f);
            return false;
        }
    }
}