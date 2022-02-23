using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.Ammo
{
    public class ThrowingTeeth : KnifeItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Teeth");
        }
        public bool HasChisel = false;
        public override void SafeSetDefaults()
        {
            item.damage = 12;
            item.width = 48;
            item.height = 48;
            item.maxStack = 999;
            item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
            item.knockBack = 1.5f;
            item.crit = 50;
            item.value = Item.sellPrice(0, 0, 0, 2);
            item.rare = 3;
            item.shoot = mod.ProjectileType("ToothProj");   //The projectile shoot when your weapon using this ammo
            item.shootSpeed = 6f;                  //The speed of the projectile
            item.ammo = item.type;              //The ammo class this ammo belongs to.
        }
        public override bool CloneNewInstances
        {
            get
            {
                return true;
            }
        }
        public bool crafted;
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
        VampPlayer p = Main.LocalPlayer.GetModPlayer<VampPlayer>();
            TooltipLine line = new TooltipLine(mod, "Face", "Can be crafted cheaper with a chisel");
            line.overrideColor = new Color(86, 86, 86);
            if (crafted == false)
                tooltips.Add(line);
        }
        public override void OnCraft(Recipe recipe)
        {
            crafted = true;
        }
        public override void UpdateInventory(Player player)
        {
            crafted = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bone, 1);
            recipe.AddTile(null, "KnifeBench");
            recipe.SetResult(this, 5);
            recipe.AddRecipe();

            ChiselRecipe recipe2 = new ChiselRecipe(mod);
            recipe2.AddIngredient(ItemID.Bone, 3);
            recipe2.AddTile(null, "KnifeBench");
            recipe2.SetResult(this, 25);
            recipe2.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bone, 3);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this, 20);
            recipe.AddRecipe();

            recipe2 = new ChiselRecipe(mod);
            recipe2.AddIngredient(ItemID.Bone, 3);
            recipe2.AddTile(mod.GetTile("VampTableTile"));
            recipe2.SetResult(this, 35);
            recipe2.AddRecipe();
        }
    }
}
