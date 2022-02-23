using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles.SeasonalProj
{
    public class HarvestersSoulProj : KnifeProjectile
    {
        int TrailLength = 17;
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[projectile.type] = TrailLength; // The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[projectile.type] = 0; // The recording mode
        }
        public override void SafeSetDefaults()
        {
            projectile.Name = "HavestersSoulSmolProj";
            projectile.width = 30;
            projectile.height = 30;
            projectile.friendly = true;
            projectile.penetrate = 2;                       //this is the projectile penetration
            projectile.hostile = false;
            projectile.magic = true;                        //this make the projectile do magic damage
            projectile.tileCollide = true;                 //this make that the projectile does not go thru walls
            projectile.ignoreWater = true;
            projectile.timeLeft = 300;
        }

        public override void AI()
        {
            //this is projectile dust
            //int DustID2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width - 3, projectile.height - 3, 158, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 10, Color.LightBlue, 1f);
            //Main.dust[DustID2].noGravity = true;
            projectile.rotation += Main.rand.NextFloat(0.1f, 0.4f);
            projectile.localAI[0] += 1f;
            //projectile.light = .04f;
            //projectile.alpha = (int)projectile.localAI[0] * 2;
            if(CollisionTimerStart && CollisionTimer < CollisionTimerMax)
            {
                CollisionTimer++;
            }
            else if(CollisionTimer >= CollisionTimerMax)
            {
                projectile.tileCollide = true;
            }
        }
        int CollisionTimer;
        int CollisionTimerMax = 20;
        bool CollisionTimerStart;
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if(!CollisionTimerStart)
            {
                CollisionTimerStart = true;
                projectile.tileCollide = false;
                projectile.velocity = oldVelocity;
                return false;
            }
            else
            {
                return base.OnTileCollide(oldVelocity);
            }
        }
        int EffectTimer;
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            EffectTimer++;
            SpriteEffects effects = projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            Texture2D texture = Main.projectileTexture[projectile.type];
            int frameHeight = texture.Height / Main.projFrames[projectile.type];
            int spriteSheetOffset = frameHeight * projectile.frame;
            Player player = Main.player[projectile.owner];
            Vector2 sheetInsertPosition = (projectile.Center + Vector2.UnitY * projectile.gfxOffY - Main.screenPosition).Floor();
            Color drawColor = new Color(255, 255, 255);
            spriteBatch.Draw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), drawColor, projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), projectile.scale, effects, 0f);

            //Redraw the projectile with the color not influenced by light
            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            Vector2 drawPos = projectile.oldPos[(TrailLength - 1)] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
            Color color = projectile.GetAlpha(drawColor) * ((float)(projectile.oldPos.Length - (TrailLength - 1)) / (float)projectile.oldPos.Length);
            Vector2 drawOrigin2 = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            Vector2 drawPos2 = projectile.oldPos[(TrailLength - (1 + (((TrailLength - 1) / 4) * 1)))] - Main.screenPosition + drawOrigin2 + new Vector2(0f, projectile.gfxOffY);
            Color color2 = projectile.GetAlpha(drawColor) * ((float)(projectile.oldPos.Length - (TrailLength - (1 + (((TrailLength - 1) / 4) * 1)))) / (float)projectile.oldPos.Length);
            Vector2 drawOrigin3 = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            Vector2 drawPos3 = projectile.oldPos[(TrailLength - (1 + (((TrailLength - 1) / 4) * 2)))] - Main.screenPosition + drawOrigin3 + new Vector2(0f, projectile.gfxOffY);
            Color color3 = projectile.GetAlpha(drawColor) * ((float)(projectile.oldPos.Length - (TrailLength - (1 + (((TrailLength - 1) / 4) * 2)))) / (float)projectile.oldPos.Length);
            Vector2 drawOrigin4 = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            Vector2 drawPos4 = projectile.oldPos[(TrailLength - (1 + (((TrailLength - 1) / 4) * 3)))] - Main.screenPosition + drawOrigin4 + new Vector2(0f, projectile.gfxOffY);
            Color color4 = projectile.GetAlpha(drawColor) * ((float)(projectile.oldPos.Length - (TrailLength - (1 + (((TrailLength - 1) / 4) * 3)))) / (float)projectile.oldPos.Length);

            if (EffectTimer > (TrailLength - (1 + (((TrailLength - 1) / 4) * 3))))
                spriteBatch.Draw(mod.GetTexture("Projectiles/SeasonalProj/HarvestersSoulProj"), drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
            if (EffectTimer > (TrailLength - (1 + (((TrailLength - 1) / 4) * 2))))
                spriteBatch.Draw(mod.GetTexture("Projectiles/SeasonalProj/HarvestersSoulProj"), drawPos2, null, color2, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
            if (EffectTimer > (TrailLength - (1 + (((TrailLength - 1) / 4) * 1))))
                spriteBatch.Draw(mod.GetTexture("Projectiles/SeasonalProj/HarvestersSoulProj"), drawPos3, null, color3, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
            if (EffectTimer > (TrailLength - 1))
                spriteBatch.Draw(mod.GetTexture("Projectiles/SeasonalProj/HarvestersSoulProj"), drawPos4, null, color4, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
    }
}