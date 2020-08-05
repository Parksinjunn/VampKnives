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
            Tooltip.SetDefault("Fires knives extremely fast at the cost of life");
        }
        public override void SafeSetDefaults()
        {
            item.damage = 95; //PUT DAMAGE, GENERALLY 1/2 OF COMPONENT'S DAMAGE
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
        //MAKE THIS JUST A PROJECTILE RATHER THAN USING SHOOT
        //public override void UseStyle(Player player)
        //{
        //    PrismUsed = true;
        //    player.itemRotation = 90f;
        //}

        //public override void UpdateInventory(Player player)
        //{
        //    if(PrismUsed)
        //    {
        //        if(UseTime < UseTimeMax)
        //        {
        //            UseTime++;
        //        }
        //        TimerTick = 0;
        //    }
        //    if(!PrismUsed)
        //    {
        //        TimerTick++;
        //    }
        //    if(TimerTick >= Timer)
        //    {
        //        TimerTick = 0;
        //        UseTime = 0;
        //        item.useTime = 10;
        //        item.useAnimation = 10;
        //    }
        //    if(UseTime > 1)
        //    {
        //        ItemUseTimeStore = 10;
        //        ItemAnimationTimeStore = 10;
        //        ItemUseTimeStore *= (1f - ((float)UseTime / 1000f));
        //        ItemAnimationTimeStore *= (1f - ((float)UseTime / 1000f));
        //        item.useTime = (int)ItemUseTimeStore;
        //        item.useAnimation = (int)ItemAnimationTimeStore;
        //        Main.NewText("UseTime: " + item.useTime + "    UseAnimation: " + item.useAnimation);
        //    }
        //    PrismUsed = false;
        //}

        //public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        //{
        //    int numProjectiles2 = player.GetModPlayer<ExamplePlayer>().NumProj + player.GetModPlayer<ExamplePlayer>().ExtraProj;
        //    Random random = new Random();
        //    int ran = random.Next(10, 65);
        //    float spread = MathHelper.ToRadians(ran);
        //    float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
        //    double startAngle = Math.Atan2(speedX, speedY) - spread / 2;
        //    double deltaAngle = spread / (float)numProjectiles2;
        //    double offsetAngle;

        //    offsetAngle = startAngle + deltaAngle;
        //    Projectile.NewProjectile(position.X, position.Y, baseSpeed * (float)Math.Sin(offsetAngle), baseSpeed * (float)Math.Cos(offsetAngle), type, damage, knockBack, player.whoAmI);
        //    return false;
        //}

        //public override Vector2? HoldoutOffset()
        //{
        //    return new Vector2(10, 0);
        //}
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
        public override bool CanUseItem(Player player) => player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.VampiricPrismHeldProj>()] <= 0;
    }

}
