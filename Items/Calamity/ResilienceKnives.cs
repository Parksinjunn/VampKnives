using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace VampKnives.Items.Calamity
{
    public class ResilienceKnives : KnifeItem
    {
        Mod Calamity = ModLoader.GetMod("CalamityMod");
        public override void SetStaticDefaults()
        {
            if (Calamity != null)
            {
                DisplayName.SetDefault("Knives of Resistance");
                Tooltip.SetDefault("These knives seem to form some sort of protective wall when thrown");
            }
            else
            {
                DisplayName.SetDefault("Knives of Resistance");
                Tooltip.SetDefault("Please enable Calamity");
            }
        }
        public override void SafeSetDefaults()
        {
            item.damage = 1;
            item.width = 50;
            item.height = 50;
            item.useTime = 20;
            item.useAnimation = 20;
            item.noUseGraphic = true;
            item.useStyle = 1;
            item.noMelee = true;
            //item.knockBack = 15;
            item.value = Item.sellPrice(0, 1, 15, 0);
            item.rare = -2;
            item.UseSound = SoundID.Item39;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("ResilienceKnivesProj");
            item.shootSpeed = 10f;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numProjectiles2 = player.GetModPlayer<ExamplePlayer>().NumProj + player.GetModPlayer<ExamplePlayer>().ExtraProj;
            Random random = new Random();
            int ran = 50;
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
            if (Calamity != null)
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ModLoader.GetMod("CalamityMod"), "RelicOfResilience");
                recipe.AddIngredient(ItemID.VampireKnives);
                recipe.AddTile(mod.GetTile("VampTableTile"));
                recipe.SetResult(this);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ModLoader.GetMod("CalamityMod"), "DivineGeode", 10);
                recipe.AddIngredient(ModLoader.GetMod("CalamityMod"), "UnholyEssence", 13);
                recipe.AddTile(mod.GetTile("VampTableTile"));
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
    }

}
