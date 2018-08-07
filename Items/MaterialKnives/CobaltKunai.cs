using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.MaterialKnives
{
    public class CobaltKunai : KnifeItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cobalt Kunai");
            Tooltip.SetDefault("Fires 10 Knives at once");
        }
        public override void SafeSetDefaults()
        {
            item.damage = 8;
            item.width = 32;
            item.height = 32;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = 1;
            item.noMelee = true;
            item.knockBack = 3;
            item.value = Item.sellPrice(0, 2, 5, 20);
            item.rare = 8;
            item.UseSound = SoundID.Item39;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("DartAnim");
            item.shootSpeed = 15f;
            item.useAmmo = mod.ItemType("ThrowingKnivesAmmo");
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numProjectiles2 = player.GetModPlayer<ExamplePlayer>().NumProj + player.GetModPlayer<ExamplePlayer>().ExtraProj + 5;
            Random random = new Random();
            int ran = random.Next(10, 35);
            float spread = MathHelper.ToRadians(ran);
            float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
            double startAngle = Math.Atan2(speedX, speedY) - spread / 2;
            double deltaAngle = spread / (float)numProjectiles2;
            double offsetAngle;

            for (int j = 0; j < numProjectiles2; j++)
            {
                offsetAngle = startAngle + deltaAngle * j;
                Projectile.NewProjectile(position.X, position.Y, baseSpeed * (float)Math.Sin(offsetAngle), baseSpeed * (float)Math.Cos(offsetAngle), type, damage/2, knockBack, player.whoAmI);
            }
            return false;
        }

        public override void AddRecipes()
        {
            KnifeCastRecipe recipe = new KnifeCastRecipe(mod);
            recipe.AddIngredient(ItemID.CobaltBar, 8);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new KnifeCastRecipe(mod);
            recipe.AddIngredient(ItemID.CobaltBar, 6);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

}
