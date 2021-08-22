using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items
{
    public class SorcerersSarukh : KnifeDamageItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sorcerers Sarukh");
            Tooltip.SetDefault("A wand possessing the power of the sorcerers of old\nChanneled knives that follow the player's cursor");
        }
        public override void SafeSetDefaults()
        {
            item.damage = 23;
            item.magic = true;
            item.channel = true;
            item.mana = 14;
            item.width = 40;
            item.height = 40;
            item.useTime = 22;
            item.useAnimation = 22;
            item.useStyle = 1;
            item.noMelee = true;
            item.knockBack = 8;
            item.value = Item.sellPrice(0,8,0,0);
            item.rare = 2; // -1 = Grey; 0 = White; 1 = Blue; 2 = Green; 3 = Orange; 4 = Light Red
            //5 = Pink; 6 = Light Purple; 7 = Lime; 8 = Yellow; 9 = Cyan; 10 = Red; 11 = Purple
            //-12 = Rainbow; -2 = Amber
            item.UseSound = SoundID.Item39; //Default 39
            item.shoot = mod.ProjectileType("SorcerersSarukhProj");
            item.shootSpeed = 15f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numProjectiles2 = 3 + player.GetModPlayer<ExamplePlayer>().ExtraProj;
            Random random = new Random();
            int ran = random.Next(45, 80);
            float spread = MathHelper.ToRadians(ran);
            float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
            double startAngle = Math.Atan2(speedX, speedY) - spread / 2;
            double deltaAngle = spread / (float)numProjectiles2;
            double offsetAngle;

            for (int j = 0; j < numProjectiles2; j++)
            {
                offsetAngle = startAngle + deltaAngle * j;
                Projectile.NewProjectile(position.X, position.Y, baseSpeed * (float)Math.Sin(offsetAngle), baseSpeed * (float)Math.Cos(offsetAngle), type, damage, knockBack, player.whoAmI);
            }
            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MagicMissile, 3);
            recipe.AddIngredient(mod.GetItem("ManaKnivesAnimated"), 1);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MagicMissile, 2);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MagicMissile, 1);
            recipe.AddIngredient(ItemID.Sapphire, 4);
            recipe.AddIngredient(mod.GetItem("ManaKnivesAnimated"), 1);
            recipe.AddIngredient(mod.GetItem("CorruptionCrystal"), 2);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MagicMissile, 1);
            recipe.AddIngredient(ItemID.Sapphire, 2);
            recipe.AddIngredient(mod.GetItem("CorruptionCrystal"), 1);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
