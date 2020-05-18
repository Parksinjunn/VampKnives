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
            item.value = Item.sellPrice(0, 20, 0, 0);
            item.rare = 8;
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
                d.knifeSupportDamageMult = 2.2f;
            }
            if (NPC.downedMechBoss2)
            {
                d.knifeSupportDamageMult = 2.4f;
            }
            if (NPC.downedMechBoss3)
            {
                d.knifeSupportDamageMult = 2.6f;
            }
            if (NPC.downedPlantBoss)
            {
                d.knifeSupportDamageMult = 2.8f;
            }
            if (NPC.downedGolemBoss)
            {
                d.knifeSupportDamageMult = 2.9f;
            }
            if (NPC.downedFishron)
            {
                d.knifeSupportDamageMult = 3f;
            }
            if (NPC.downedAncientCultist)
            {
                d.knifeSupportDamageMult = 3.1f;
            }
            if (NPC.downedTowers)
            {
                d.knifeSupportDamageMult = 3.2f;
            }
        }
        //Made with spectre bars
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.VampireKnives, 1);
            recipe.AddIngredient(mod.GetItem("CorruptionCrystal"), 5);
            recipe.AddTile(mod.GetTile("KnifeBench"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

}
