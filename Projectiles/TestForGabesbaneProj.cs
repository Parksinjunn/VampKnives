using Terraria.ModLoader;
using Terraria;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Shaders;

namespace VampKnives.Projectiles //CHANGE THIS TO MATCH YOUR OWN WORK
{ 
    public class TestForGabesbaneProj : ModProjectile //CHANGE THIS TO MATCH YOUR OWN WORK
    {
        public override void SetDefaults()
        {
            projectile.width = 64; // sets width
            projectile.height = 64; // sets height
            projectile.timeLeft = 200; // sets how long the projectile has left before it dies
            projectile.penetrate = 2; // how many targets it can pass through
            projectile.tileCollide = true; // whether it colides with tiles or not
            projectile.ignoreWater = false; // whether it is slowed by water or not
            projectile.friendly = true; // whether it damages the player or not
            Main.projFrames[projectile.type] = 5; //this is the # of projectile frames
            projectile.melee = true; // sets the type of damage afflicted
            projectile.light = 0.75f; // sets the amount of light the projectile puts off (I suggest adding a dust instead to give colored lighting and particle effects, your choice though)
        }

        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f; // Some maths done to rotate the projectile correctly based on velocity
            ////////Dust Code if you wish to use it////
            ////if (Main.rand.NextFloat() < 1f)
            ////{
            ////    Dust dust;
            ////    // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            ////    Vector2 position = Main.LocalPlayer.Center;
            ////    dust = Main.dust[Terraria.Dust.NewDust(position, 30, 30, 219, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
            ////    //219 is the Dust type, you can find a list of dusts here: https://forums.terraria.org/index.php?threads/dust-and-sound-catalogue-2.42370/
            ////    //You'll most likely have to mess around with the two float values after that, they are velocity, X and Y respectively and may not work as intended. I set them to 0 for now, but if you want to do the math to
            ////    //figure out the direction the projectile is facing be my guest
            ////    dust.shader = GameShaders.Armor.GetSecondaryShader(61, Main.LocalPlayer); //Gives a shader to the dust
            ////}
        }

        public override bool PreDraw(SpriteBatch sb, Color lightColor) //this is where the animation happens
        {
            projectile.frameCounter++; //increase the frameCounter by one
            if (projectile.frameCounter >= 2) //once the frameCounter has reached 2 - change the 2 to change how fast the projectile animates
            {
                projectile.frame++; //go to the next frame
                projectile.frameCounter = 0; //reset the counter
                if (projectile.frame > 4) //if past the last frame
                    projectile.frame = 0; //go back to the first frame
            }
            return true;
        }
    }
}