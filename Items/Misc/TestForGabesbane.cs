using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.Misc //CHANGE THIS TO MATCH YOUR OWN WORK
{
    public class TestForGabesbane : ModItem //CHANGE THIS TO MATCH YOUR OWN WORK
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zangetsu"); //Sets Display Name
            Tooltip.SetDefault("GetsugaTenshou!"); // Sets tooltip
        }
        public override void SetDefaults()
        {
            item.damage = 82; //Sets Damage of item that is swung
            item.melee = true; // Sets damage type
            item.width = 40; //Item Width
            item.height = 65; //Item Height
            item.useTime = 20; //Time it takes to use the item
            item.useAnimation = 20; //Time it takes to play the use animation (Generally have this synced with item.useTime)
            item.useStyle = 1; //The use style of weapon, 1 for swinging, 2 for drinking, 3 act like shortsword, 4 for use like life crystal, 5 for use staffs or guns
            item.knockBack = 5; //Sets Knockback ; Max is 20
            item.value = 10000; // Sets the value for an easier interface you can use Item.buyPrice(0, 0, 10, 55) this puts it in perspective of (Platinum, Gold, Silver, Copper)
            item.rare = 5; // Sets the color text the Display name uses
            item.UseSound = SoundID.Item1; //Sets the sound the item makes when used
            item.autoReuse = false; //determines whether this is autoswung or not
            item.shoot = mod.ProjectileType("TestForGabesbaneProj"); //CHANGE THIS TO MATCH YOUR OWN WORK //makes it so that the item shoots a projectile
            item.shootSpeed = 1f; // Determines speed of projectile
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float spread = MathHelper.ToRadians(Main.rand.Next(10,35)); //Relic, but technically gives some slight variability in angle proj is shot
            float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY); //Calculates a base speed that should be applied based on item.shootSpeed
            double startAngle = Math.Atan2(speedX, speedY) - spread / 2; //Some Math used to further determine the X and Y velocities
            Projectile.NewProjectile(player.Center, new Vector2(baseSpeed * (float)Math.Sin(startAngle), baseSpeed * (float)Math.Cos(startAngle)), type, damage, knockBack, player.whoAmI);
            //Makes a new projectile at the player's center with calculated X and Y velocities
            return false;
        }
        //public override void AddRecipes()
        //{
        //    ModRecipe recipe = new ModRecipe(mod);
        //    recipe.AddIngredient(null, "Zanpakuto", 1);
        //    recipe.AddTile(TileID.Anvils);
        //    recipe.SetResult(this);
        //    recipe.AddRecipe();
        //}
    }
}