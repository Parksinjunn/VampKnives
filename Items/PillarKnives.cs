using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using Terraria.DataStructures;
using Terraria.Localization;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items
{
    public class PillarKnives : KnifeDamageItem
    {
        Mod Calamity = ModLoader.GetMod("CalamityMod");

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Astronomical Singularity");
            Tooltip.SetDefault("Shoots a random assortment of all astral knives");
        }
        public override void SafeSetDefaults()
        {
            item.damage = 86;
            item.width = 32;
            item.height = 32;
            item.useTime = 15;
            item.useAnimation = 15;
            item.noUseGraphic = true;
            item.useStyle = 1;
            item.noMelee = true;
            item.knockBack = 3;
            item.value = Item.sellPrice(1, 80, 15, 0);
            item.rare = -13;
            item.UseSound = SoundID.Item39;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("NebulaProj");
            item.shootSpeed = 15f;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach (TooltipLine line2 in tooltips)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.text = "[c/FF3300:A][c/DE6E41:s][c/BCA881:t][c/9BE3C2:r][c/B29BD0:o][c/C953DD:n][c/E00BEB:o][c/A047EE:m][c/6083F2:i][c/20BFF5:c][c/6083F2:a][c/A047EE:l] [c/E00BEB:S][c/C953DD:i][c/B29BD0:n][c/9BE3C2:g][c/BCA881:u][c/DE6E41:l][c/FF3300:a][c/DE6E41:r][c/BCA881:i][c/9BE3C2:t][c/B29BD0:y]";
                }
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("NebulaKnives"));
            recipe.AddIngredient(mod.GetItem("VortexKnives"));
            recipe.AddIngredient(mod.GetItem("SolarKnives"));
            recipe.AddIngredient(mod.GetItem("StardustKnives"));
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();

            if (Calamity != null)
            {
                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ModLoader.GetMod("CalamityMod"), "GalacticaSingularity", 18);
                recipe.AddTile(mod.GetTile("VampTableTile"));
                recipe.SetResult(this);
                recipe.AddRecipe();
            }

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FragmentSolar, 18);
            recipe.AddIngredient(ItemID.FragmentStardust, 18);
            recipe.AddIngredient(ItemID.FragmentVortex, 18);
            recipe.AddIngredient(ItemID.FragmentNebula, 18);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numProjectiles2 = player.GetModPlayer<VampPlayer>().NumProj + player.GetModPlayer<VampPlayer>().ExtraProj;
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
                int knifeSelect = Main.rand.Next(0, 4);
                if (knifeSelect == 0)
                    Projectile.NewProjectile(position.X, position.Y, baseSpeed * (float)Math.Sin(offsetAngle), baseSpeed * (float)Math.Cos(offsetAngle), mod.ProjectileType("NebulaProj"), damage, knockBack, player.whoAmI);
                if (knifeSelect == 1)
                    Projectile.NewProjectile(position.X, position.Y, baseSpeed * (float)Math.Sin(offsetAngle), baseSpeed * (float)Math.Cos(offsetAngle), mod.ProjectileType("SolarProj"), damage, knockBack, player.whoAmI);
                if (knifeSelect == 2)
                    Projectile.NewProjectile(position.X, position.Y, baseSpeed * (float)Math.Sin(offsetAngle), baseSpeed * (float)Math.Cos(offsetAngle), mod.ProjectileType("StardustProj"), damage, knockBack, player.whoAmI);
                if (knifeSelect == 3)
                    Projectile.NewProjectile(position.X, position.Y, baseSpeed * (float)Math.Sin(offsetAngle), baseSpeed * (float)Math.Cos(offsetAngle), mod.ProjectileType("VortexProj"), damage, knockBack, player.whoAmI);
            }
            return false;
        }
    }

}
