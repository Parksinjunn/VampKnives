using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.MaterialKnives
{
    public class ReaverHead : KnifeItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Reaver Head");
            Tooltip.SetDefault("Launches Teeth");
        }
        public override void SafeSetDefaults()
        {
            item.damage = 8;
            item.width = 32;
            item.height = 32;
            item.useTime = 15;
            item.useAnimation = 15;
            item.noUseGraphic = true;
            item.useStyle = 1;
            item.noMelee = true;
            item.knockBack = 3;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = 8;
            item.UseSound = SoundID.Item39;
            item.shoot = mod.ProjectileType("ToothProj");
            item.autoReuse = true;
            item.shootSpeed = 15f;
            item.useAmmo = mod.ItemType("ThrowingTeeth");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ReaverShark, 1);
            recipe.AddTile(mod.GetTile("KnifeBench"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

}
