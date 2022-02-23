using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace VampKnives.Items
{
    public class StarfuryKnives : KnifeDamageItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Knifefury");
            Tooltip.SetDefault("It's a bird! It's a plane? It's a... kni- *thwump*\nSummons knives from up above like it's swung brother");
        }
        public override void SafeSetDefaults()
        {
            item.damage = 22; //PUT DAMAGE, GENERALLY 1/2 OF COMPONENT'S DAMAGE       
            item.width = 34;
            item.height = 34;
            item.useTime = 25;
            item.useAnimation = 25;
            item.noUseGraphic = true;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 3;
            item.value = 100000; //10000 = 1 gold, 100 silver, or 10000 copper
            item.rare = 2; // -1 = Grey; 0 = White; 1 = Blue; 2 = Green; 3 = Orange; 4 = Light Red
            //5 = Pink; 6 = Light Purple; 7 = Lime; 8 = Yellow; 9 = Cyan; 10 = Red; 11 = Purple
            //-12 = Rainbow; -2 = Amber
            item.UseSound = SoundID.Item60.WithVolume(0.15f); //Default 39
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("StarfuryKnivesProj");
            item.shootSpeed = 15f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numProjectiles2 = player.GetModPlayer<VampPlayer>().NumProj + player.GetModPlayer<VampPlayer>().ExtraProj;
            for (int x = 0; x < numProjectiles2; x+= 2)
            {
                Vector2 StartPosition = Main.MouseWorld;
                StartPosition.X += Main.rand.Next(-200, 200);
                StartPosition.Y = player.position.Y - Main.screenHeight/1.5f;
                Vector2 ProjectileVelocity;

                float shootToX = Main.MouseWorld.X - StartPosition.X + Main.rand.Next(-75,75);
                float shootToY = Main.MouseWorld.Y - StartPosition.Y;
                float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

                distance = 3f / distance;

                //Multiply the distance by a multiplier if you wish the projectile to have go faster
                shootToX *= distance * 5;
                shootToY *= distance * 5;

                //Set the velocities to the shoot values
                ProjectileVelocity.X = shootToX;
                ProjectileVelocity.Y = shootToY;

                Projectile.NewProjectile(StartPosition.X, StartPosition.Y, ProjectileVelocity.X, ProjectileVelocity.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Starfury);
            recipe.AddIngredient(ModContent.ItemType<WeakVampireKnives>());
            recipe.AddIngredient(ItemID.SunplateBlock, 15);
            recipe.AddTile(mod.GetTile("KnifeBench"));
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Starfury);
            recipe.AddIngredient(ModContent.ItemType<WeakVampireKnives>());
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

}
