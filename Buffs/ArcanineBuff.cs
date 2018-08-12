using Terraria;
using Terraria.ModLoader; 
/*These tells the game what you are referencing in this file, so for example Terraria.ModLoader is what is loading variables from the mod, in this case it is calling ExamplePlayer on line 20
  Visual Studios should tell you when these are needed and will auto suggest what to add*/

namespace VampKnives.Buffs /*This is the namespace and it states where the class file is located. Autoload uses this information to load the image for this file,
    it goes down the folder structure and finds an image with the same name as the .cs file.*/
{
    public class ArcanineBuff : ModBuff //This is instantiating a new class ArcanineBuff, which inherits all values from ModBuff.
    {
        public override void SetDefaults() //Here we override SetDefaults, meaning we add onto whatever ModBuff's SetDefaults() is. This is called ONCE.
        {
            DisplayName.SetDefault("Arcanine!"); //This decides what the Buff's name is when you hover over it.
            Description.SetDefault("A dog of pure flame protects you"); //This decides what the Buff's description shows when you hover over it.
            Main.buffNoTimeDisplay[Type] = true; //This makes it so the buff doesn't show how much time is left, this is useful for pet buffs so the player doesn't see how long they are set to.
            Main.vanityPet[Type] = true;  //UNSURE I would assume this just tells the game that the buff is tied to a pet
        }

        public override void Update(Player player, ref int buffIndex) //Here is where we override Update, which is run every tick.
        {
            player.buffTime[buffIndex] = 18000; //Sets the time left to 10000 ticks. This number doesn't matter as it is re-run every tick.
            player.GetModPlayer<ExamplePlayer>(mod).Arcanine = true; //This sets Arcanine in ExamplePlayer to TRUE
            bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("Arcanine")] <= 0; //This sets the bool pPNS to Arcanine (so, TRUE)

            //This if statement checks if the bool pPNS is true or false, AND, cross checks to make sure it is checking for the right player (so multiple people can have the same pet in MP)
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer) 
            {
                /*                              This spawns the pet projectile. Here's a description of what the variables do in order:
                1. X position - (player.position.X + (float)(player.width/3) Spawns the projectile at the player's X coordinate + a third of the player's width.
                2. Y position - (player.position.Y + (float)(player.height/3) Spawns the projectile at the player's Y coordinate + a third of the player's height.
                THINGS TO NOTE ABOUT POSITION:
                The leftmost pixel of the player's hitbox is the X coordinate and the uppermost pixel, of the player's hitbox, is the Y coordinate, as player's are drawn left-to-right, up-to-down.
                Position values will always be floats.
                3 & 4. X & Y velocity - 0f (because the pet's AI code will set it's velocity based on the situation)
                5. The type of projectile spawned (Yes pets are projectiles). To spawn a mod projectile use mod.ProjectileType as shown, to spawn a vanilla projectile use the projectile ID
                (i.e. 1 for wooden arrows, full list located here: https://terraria.gamepedia.com/Projectile_IDs)
                6. Damage - this sets the projectile's damage, for pets this is 0, for anything else this will be where you set it's damage, not in the actual projectile class.
                7. Knockback - Pretty self explanatory, but it's stored as a float so keep that in mind.
                8. Owner - player.whoAmI makes the projectile the local players, otherwise the projectile wouldn't work well in MP. However, for NPC's you'd want to use 'npc.whoAmI' or 'this' I believe. */
                Projectile.NewProjectile(player.position.X + (float)(player.width / 3), player.position.Y + (float)(player.height / 3), 0f, 0f, mod.ProjectileType("Arcanine"), 0, 0f, player.whoAmI);
            }
        }
    }
}