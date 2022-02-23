using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace VampKnives.Projectiles.Misc
{
	public class BloodCrystalProj : ModProjectile
	{
        public override void SetDefaults()
		{
            projectile.aiStyle = -1;
			projectile.width = 18;
			projectile.height = 30;
            projectile.friendly = true;
            projectile.penetrate = -1;                       //this is the projectile penetration
            Main.projFrames[projectile.type] = 7;           //this is projectile frames
            projectile.hostile = false;
			projectile.magic = true;                        //this make the projectile do magic damage
            projectile.tileCollide = false;                 //this make that the projectile does not go thru walls
			projectile.ignoreWater = true;
            projectile.timeLeft = 180;
            //Main.NewText("Spawned");
        }
        ref float NPCID => ref projectile.ai[0];
        public override void AI()
        {                                                  //this is projectile dust
            int DustID2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width - 3, projectile.height - 3, 244, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 10, Color.DarkRed, 1.8f);
            Main.dust[DustID2].noGravity = true;
            projectile.light = .04f;
        }        public override void Kill(int timeLeft)
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                int i = Item.NewItem(projectile.position, ModContent.ItemType<Items.Misc.BloodCrystalSoul>());
                var moditem = Main.item[i].modItem as Items.Misc.BloodCrystalSoul;
                moditem.NPCID = (int)NPCID;
                NetMessage.SendData(MessageID.InstancedItem, -1, NetmodeID.Server, null, i);
            }
        }
        float rotationalOffset;
        public override bool PreDrawExtras(SpriteBatch spriteBatch)
        {
            SpriteEffects effects = projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            Texture2D texture = ModContent.GetTexture("VampKnives/Projectiles/Misc/BloodCrystalProjBack");
            int frameHeight = texture.Height / Main.projFrames[projectile.type];
            int spriteSheetOffset = frameHeight * projectile.frame;
            Player player = Main.player[projectile.owner];
            Vector2 sheetInsertPosition = (projectile.Center + Vector2.UnitY * projectile.gfxOffY - Main.screenPosition).Floor();
            Color drawColor = new Color(255, 255, 255);
            spriteBatch.Draw(texture, sheetInsertPosition - new Vector2(1.5f, -2f), new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), drawColor, projectile.rotation + rotationalOffset, new Vector2(texture.Width / 2f, frameHeight / 2f), projectile.scale/1.2f, effects, 0f);
            return base.PreDrawExtras(spriteBatch);
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            if(projectile.frameCounter >= 6)
            {
                Vector2 DustPosition = Main.rand.NextVector2Circular(0.5f, 1f);
                int d = Dust.NewDust(projectile.position + DustPosition, projectile.width, projectile.height, 35, 0f, 0f);
            }
            projectile.frameCounter++; 
            if (projectile.frameCounter >= (int)(6f * ((float)projectile.timeLeft / 180f))) 
            {
                projectile.frame++; 
                projectile.frameCounter = 0; 
                if (projectile.frame > 6)
                {
                    projectile.frame = 0;
                    rotationalOffset += 0.12f;
                }
            }
            SpriteEffects effects = projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            Texture2D texture = Main.projectileTexture[projectile.type];
            int frameHeight = texture.Height / Main.projFrames[projectile.type];
            int spriteSheetOffset = frameHeight * projectile.frame;
            Player player = Main.player[projectile.owner];
            Vector2 sheetInsertPosition = (projectile.Center + Vector2.UnitY * projectile.gfxOffY - Main.screenPosition).Floor();
            Color drawColor = new Color(255, 255, 255);
            spriteBatch.Draw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), drawColor, projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), projectile.scale, effects, 0f);
            base.PostDraw(spriteBatch, lightColor);
        }
    }
}