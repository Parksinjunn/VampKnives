using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace VampKnives.Items
{
    public class VampiricPrism : KnifeDamageItem
    {
        int Timer = 10;
        int TimerTick;
        int UseTimeMax = 900;
        int UseTime;
        float ItemUseTimeStore;
        float ItemAnimationTimeStore;
        bool PrismUsed;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vampiric Prism");
            Tooltip.SetDefault("Fires knives with increasing speed at the cost of life");
        }
        public override void SafeSetDefaults()
        {
            item.damage = 104; //PUT DAMAGE, GENERALLY 1/2 OF COMPONENT'S DAMAGE
            item.width = 26;
            item.height = 30;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = 5;
            item.noUseGraphic = true;
            item.noMelee = true;
            //item.channel = true;
            item.knockBack = 0;
            item.value = Item.sellPrice(0,10,0,0); //10000 = 1 gold, 100 silver, or 10000 copper
            item.rare = 10; // -1 = Grey; 0 = White; 1 = Blue; 2 = Green; 3 = Orange; 4 = Light Red
            //5 = Pink; 6 = Light Purple; 7 = Lime; 8 = Yellow; 9 = Cyan; 10 = Red; 11 = Purple
            //-12 = Rainbow; -2 = Amber
            item.UseSound = SoundID.Item13; //Default 39
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("VampiricPrismHeldProj");
            item.shootSpeed = 30f;
            item.channel = true;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            return true;
        }
        

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SengosForgottenBlades>());
            recipe.AddIngredient(ItemID.VampireKnives, 1);
            recipe.AddIngredient(ItemID.LastPrism, 1);
            recipe.AddIngredient(ItemID.LunarBar, 7);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public bool RegenedHealth;
        public override bool CanUseItem(Player player)
        {
            if(player.statLife > 1)
            {
                RegenedHealth = true;
            }
            if(player.statLife <= 1 && RegenedHealth)
            {
                VampPlayer.OvalDust(player.position, 5f, 5f, Color.Red, 67, 1.2f);
                RegenedHealth = false;
                return false;
            }
            else if(player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.VampiricPrismHeldProj>()] <= 0 && RegenedHealth);
                return true;
        }
    }

}
