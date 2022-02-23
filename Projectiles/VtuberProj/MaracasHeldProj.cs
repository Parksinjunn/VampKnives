using VampKnives.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;
using System.Collections.Generic;

namespace VampKnives.Projectiles.VtuberProj
{
    public class MaracasHeldProj : KnifeProjectile
    {

        // The vanilla Last Prism is an animated item with 5 frames of animation. We copy that here.
        private const int NumAnimationFrames = 4;

        // This value controls how many frames it takes for the Prism to reach "max charge". 60 frames = 1 second.
        public const float MaxCharge = 350f;
        float ChargeCounter;
        float ChargeDivisionFactor = 20f;
        static int ShootTimerMax = 60;
        int ShootTimer;
        //static int DustTimerMax = 17;
        //int DustTimer;

        // This value controls how many frames it takes for the beams to begin dealing damage. Before then they can't hit anything.
        public const float DamageStart = 1f;

        // This value controls how sluggish the Prism turns while being used. Vanilla Last Prism is 0.08f.
        // Higher values make the Prism turn faster.
        private const float AimResponsiveness = 1f;

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
            // Use CloneDefaults to clone all basic projectile statistics from the vanilla Last Prism.
            projectile.CloneDefaults(ProjectileID.LastPrism);
            projectile.scale = 0.6f;
        }
        public override bool PreKill(int timeLeft)
        {
            Player player = Main.player[projectile.owner];
            if (player.HeldItem.type == ModContent.ItemType<Items.VtuberItems.Maracas>())
                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Maracas").WithVolume(1f), projectile.position);
            return base.PreKill(timeLeft);
        }
        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            VampPlayer p = Main.player[projectile.owner].GetModPlayer<VampPlayer>();
            if (ChargeCounter < 360)
            {
                ChargeCounter++;
            }

            Vector2 rrp = player.RotatedRelativePoint(player.MountedCenter, true);

            // Update the frame counter.
            FrameCounter += 1f;

            // Update projectile visuals and sound.
            UpdateAnimation();

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
                    float numProjectiles2 = player.GetModPlayer<VampPlayer>().NumProj + player.GetModPlayer<VampPlayer>().ExtraProj;
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
                        int ran = (int)(Main.rand.NextFloat(-40 + (ShootTimerAdd * 6), 40 - (ShootTimerAdd * 6)));
                        float spread = MathHelper.ToRadians(ran)/2;
                        float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
                        double startAngle = Math.Atan2(speedX, speedY) - spread / 2;
                        double deltaAngle = spread / (float)numProjectiles2;
                        double offsetAngle;
                        offsetAngle = startAngle + deltaAngle;
                        Vector2 InitialPos = (player.RotatedRelativePoint(player.MountedCenter, true) - projectile.Size / 2f) + (projectile.velocity * 3);
                        Projectile.NewProjectile(InitialPos.X, InitialPos.Y, baseSpeed * (float)Math.Sin(offsetAngle), baseSpeed * (float)Math.Cos(offsetAngle), ProjectileType<Projectiles.VtuberProj.MaracasProj>(), (int)((float)projectile.damage * 1.5f), projectile.knockBack, player.whoAmI);
                        ShootTimer = 0;
                        if(player.HeldItem.type == ModContent.ItemType<Items.VtuberItems.Maracas>())
                            Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Maracas").WithVolume(0.75f).WithPitchVariance(Main.rand.NextFloat(-0.40f, 0.30f)), projectile.position);

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
        private void UpdatePlayerVisuals(Player player, Vector2 playerHandPos)
        {
            // Place the Prism directly into the player's hand at all times.
            projectile.Center = playerHandPos;
            // The beams emit from the tip of the Prism, not the side. As such, rotate the sprite by pi/2 (90 degrees).
            projectile.spriteDirection = projectile.direction;
            if (projectile.spriteDirection == 1)
            {
                projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2 - 1.57f;
            }
            else
            {
                projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2 + 1.57f;
            }

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
            Color drawColor = new Color(255, 255, 255);
            Player player = Main.player[projectile.owner];
            Vector2 Offset;
            if (player.direction == -1)
            {
                Offset = new Vector2(player.direction * 16, 0);
            }
            else
            {
                Offset = new Vector2(player.direction * 10, 0);
            }
            Vector2 sheetInsertPosition = ((player.RotatedRelativePoint(player.MountedCenter, true) - projectile.Size / 2f) - Offset) + (projectile.velocity * 3) - Main.screenPosition;
            spriteBatch.Draw(texture, new Vector2(sheetInsertPosition.X, sheetInsertPosition.Y), new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), drawColor, projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), projectile.scale, effects, 0f);
            //PlayerLayer.Arms.Draw()
            return false;
        }
    }
}