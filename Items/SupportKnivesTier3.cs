using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace VampKnives.Items
{
    public class SupportKnivesTier3 : KnifeItemSupportScaler
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tier 3 Support Knives");
            Tooltip.SetDefault("Its daggers produce orbs that heal other players");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 12));
        }
        public override void SafeSetDefaults()
        {
            item.damage = 29;
            item.width = 40;
            item.height = 40;
            item.useTime = 15;
            item.noUseGraphic = true;
            item.useAnimation = 15;
            item.useStyle = 1;
            item.noMelee = true;
            item.knockBack = 2.75f;
            item.rare = 9;
            item.UseSound = SoundID.Item39;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("SupportKnivesProj3");
            item.shootSpeed = 15f;
        }
        public override void UpdateInventory(Player player)
        {
            KnifeSupportDamagePlayer d = player.GetModPlayer<KnifeSupportDamagePlayer>();
            if (NPC.downedBoss1)
            {
                d.knifeSupportDamageMult = 1.1f;
            }
            if (NPC.downedBoss2)
            {
                d.knifeSupportDamageMult = 1.3f;
            }
            if (NPC.downedQueenBee)
            {
                d.knifeSupportDamageMult = 1.4f;
            }
            if (NPC.downedBoss3)
            {
                d.knifeSupportDamageMult = 1.5f;
            }
            if (Main.hardMode)
            {
                d.knifeSupportDamageMult = 2f;
            }
            if (NPC.downedMechBoss1)
            {
                d.knifeSupportDamageMult = 2.3f;
            }
            if (NPC.downedMechBoss2)
            {
                d.knifeSupportDamageMult = 2.6f;
            }
            if (NPC.downedMechBoss3)
            {
                d.knifeSupportDamageMult = 2.9f;
            }
            if (NPC.downedPlantBoss)
            {
                d.knifeSupportDamageMult = 3.2f;
            }
            if (NPC.downedGolemBoss)
            {
                d.knifeSupportDamageMult = 3.3f;
            }
            if (NPC.downedFishron)
            {
                d.knifeSupportDamageMult = 3.5f;
            }
            if (NPC.downedAncientCultist)
            {
                d.knifeSupportDamageMult = 3.6f;
            }
            if (NPC.downedTowers)
            {
                d.knifeSupportDamageMult = 3.7f;
            }
            if(NPC.downedMoonlord)
            {
                d.knifeSupportDamageMult = 4.0f;
            }
        }
        //Made with spectre bars
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("SupportKnivesTier2"), 1);
            recipe.AddIngredient(mod.GetItem("PlantFiber"), 17);
            recipe.AddIngredient(ItemID.SpectreBar, 20);
            recipe.AddTile(mod.GetTile("KnifeBench"));
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe.AddIngredient(mod.GetItem("SupportKnivesTier2"), 1);
            recipe.AddIngredient(mod.GetItem("PlantFiber"), 13);
            recipe.AddIngredient(ItemID.SpectreBar, 16);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

}
