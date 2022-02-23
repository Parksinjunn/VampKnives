using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles.SeasonalProj
{
    public class EverscreamsBranchProj : KnifeProjectile
    {
        int ProjFrame;
        bool HitTile;
        bool HasDoneEffect;
        float RMax = 1f;
        float Rmin = 0.4f;
        float BMax = 1f;
        float Bmin = 0.4f;
        float GMax = 0.8f;
        float Gmin = 0.2f;
        float FadePos;
        bool Dec;
        bool Red;
        bool Blue;
        float LightR = 0f;
        float LightG = 0f;
        float LightB = 0f;
        public override void SafeSetDefaults()
        {
            projectile.Name = "AbyssalKnives";
            projectile.width = 10;
            projectile.height = 19;
            projectile.friendly = true;
            projectile.penetrate = 1;                       //this is the projectile penetration
            projectile.hostile = false;
            projectile.magic = true;                        //this make the projectile do magic damage
            projectile.tileCollide = true;                 //this make that the projectile does not go thru walls
            projectile.ignoreWater = true;
            projectile.timeLeft = 300;
            Main.projFrames[projectile.type] = 16;
            projectile.scale = 0.95f;
            ProjFrame = Main.rand.Next(0, 16);
            if(ProjFrame >= 8)
            {
                Red = Main.rand.NextBool();
                if (!Red)
                    Blue = true;
            }
        }

        public override void DrawBehind(int index, List<int> drawCacheProjsBehindNPCsAndTiles, List<int> drawCacheProjsBehindNPCs, List<int> drawCacheProjsBehindProjectiles, List<int> drawCacheProjsOverWiresUI)
        {
            if (HitTile)
            {
                drawCacheProjsBehindNPCsAndTiles.Add(index);
                return;
            }
        }
        public override void AI()
        {
            //this is projectile dust
            //int DustID2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width - 3, projectile.height - 3, 158, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 10, Color.LightBlue, 1f);
            //Main.dust[DustID2].noGravity = true;
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            projectile.localAI[0] += 1f;
            if(!HitTile)
                projectile.velocity.Y += 0.4f;
            //projectile.velocity *= 0f;
            if(ProjFrame >= 0 && ProjFrame < 4)
            {
                if (LightR < RMax && !Dec)
                    FadePos += 0.05f;
                else if (LightR > Rmin && Dec)
                    FadePos -= 0.05f;
                if (LightR >= 1f && !Dec)
                    Dec = true;
                else if (LightR <= Rmin && Dec)
                    Dec = false;
                LightR = Rmin + (RMax - Rmin) * FadePos;
            }
            else if(ProjFrame >= 4 && ProjFrame <= 7)
            {
                if (LightB < BMax && !Dec)
                    FadePos += 0.05f;
                else if (LightB > Bmin && Dec)
                    FadePos -= 0.05f;
                if (LightB >= 1f && !Dec)
                    Dec = true;
                else if (LightB <= Bmin && Dec)
                    Dec = false;
                LightB = Bmin + (BMax - Bmin) * FadePos;
                LightG = Gmin + (GMax - Gmin) * FadePos;
            }
            else
            {
                if(Red)
                {
                    if (LightR < RMax && !Dec)
                        FadePos += 0.05f;
                    else if (LightR > Rmin && Dec)
                        FadePos -= 0.05f;
                    if (LightR >= 1f && !Dec)
                        Dec = true;
                    else if (LightR <= Rmin && Dec)
                    {
                        Blue = true;
                        Red = false;
                        Dec = false;
                    }
                    LightR = Rmin + (RMax - Rmin) * FadePos;
                }
                else if(Blue)
                {
                    if (LightB < BMax && !Dec)
                        FadePos += 0.05f;
                    else if (LightB > Bmin && Dec)
                        FadePos -= 0.05f;
                    if (LightB >= 1f && !Dec)
                        Dec = true;
                    else if (LightB <= Bmin && Dec)
                    {
                        Blue = false;
                        Red = true;
                        Dec = false;
                    }
                    LightB = Bmin + (BMax - Bmin) * FadePos;
                    LightG = Gmin + (GMax - Gmin) * FadePos;
                }
            }
            Lighting.AddLight(projectile.position, LightR, LightG, LightB);

            if (HitTile)
            {
                projectile.velocity = projectile.velocity * 0.2f;
                if (HasDoneEffect == false)
                {
                    HasDoneEffect = true;
                    for (int i = 0; i < 10; i++)
                    {
                        int DustID2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width - 3, projectile.height - 3, 1, projectile.velocity.X * 0.2f, projectile.velocity.Y * -0.2f, 10, Color.Gray, 1f);
                    }
                }
            }
        }
        public override bool SafeOnTileCollide(Vector2 oldVelocity)
        {
            HitTile = true;
            projectile.hide = true;
            projectile.penetrate = 1;
            projectile.tileCollide = false;
            projectile.velocity = oldVelocity;
            projectile.timeLeft = 45;
            return false;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            SpriteEffects effects = projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            Texture2D texture = Main.projectileTexture[projectile.type];
            int frameHeight = texture.Height / Main.projFrames[projectile.type];
            int spriteSheetOffset = frameHeight * projectile.frame;
            Player player = Main.player[projectile.owner];
            Vector2 sheetInsertPosition = (projectile.Center + Vector2.UnitY * projectile.gfxOffY - Main.screenPosition).Floor();
            Color drawColor = new Color(255, 255, 255);
            projectile.frame = ProjFrame;
            spriteBatch.Draw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), lightColor, projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), projectile.scale, effects, 0f);
            spriteBatch.Draw(mod.GetTexture("Projectiles/SeasonalProj/EverscreamsBranchProj_LightMap"), sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), drawColor, projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), projectile.scale, effects, 0f);
            return false;
        }
    }
}