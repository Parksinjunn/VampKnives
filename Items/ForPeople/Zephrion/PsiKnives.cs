using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.ForPeople.Zephrion
{
	public class PsiKnives : KnifeDamageItem
	{
        public override bool CloneNewInstances => true;
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Psi");
			//Tooltip.SetDefault("Knives with an internal compartment \nfilled with bees that explode out on impact");
        }
		public override void SafeSetDefaults()
		{
			item.damage = 12;            
			item.width = 46;
			item.height = 46;
			item.useTime = 15;
			item.useAnimation = 15;
            item.noUseGraphic = true;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
			item.knockBack = 3;
			item.value = Item.sellPrice(0,0,54,20);
			item.rare = 8;
			//item.UseSound = SoundID.Item97;
			item.autoReuse = true;
            item.shoot = mod.ProjectileType("PsiKnivesProj");
            item.shootSpeed = 9f;
        }
        public override void HoldItem(Player player)
        {
			player.GetModPlayer<VampPlayer>().ExtraProj -= 2;
            base.HoldItem(player);
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        int Mode = 0;
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (Mode == 0)
            {
                TooltipLine line = new TooltipLine(mod, "DamageMod", "Mode: Sticky")
                {
                    overrideColor = Color.Green
                };
                tooltips.Add(line);
                TooltipLine line2 = new TooltipLine(mod, "DamageMod", "Shoots sticky psi bombs that attach to tiles or npcs")
                {
                    overrideColor = Color.LightGreen
                };
                tooltips.Add(line2);
            }
            else if(Mode == 1)
            {
                TooltipLine line = new TooltipLine(mod, "DamageMod", "Mode: Bombing")
                {
                    overrideColor = Color.Red
                };
                tooltips.Add(line);
                TooltipLine line2 = new TooltipLine(mod, "DamageMod", "Shoots psi bombs that fall quickly and prime themselves upon collision with a tile")
                {
                    overrideColor = Color.PaleVioletRed
                };
                tooltips.Add(line2);
            }
            else if (Mode == 2)
            {
                TooltipLine line = new TooltipLine(mod, "DamageMod", "Mode: Defense")
                {
                    overrideColor = Color.Cyan
                };
                tooltips.Add(line);
                TooltipLine line2 = new TooltipLine(mod, "DamageMod", "Shoots psi bombs in a defensive pattern that will only explode once they reach their primed distance")
                {
                    overrideColor = Color.LightCyan
                };
                tooltips.Add(line2);
            }
        }
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                item.autoReuse = false;
                Mode++;
                if (Mode > 2)
                {
                    Mode = 0;
                }
                if (Mode == 0)
                {
                    Main.NewText("Normal");
                    item.autoReuse = true;
                }
                else if (Mode == 1)
                {
                    Main.NewText("Bombing");
                    item.autoReuse = true;
                }
                else if (Mode == 2)
                {
                    Main.NewText("Defense");
                    item.autoReuse = true;
                }
            }
            return true;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if(player.altFunctionUse == 2)
            {
                return false;
            }
            if(Mode == 0)
            {
                damage = 12;
            }
            else if (Mode == 1)
            {
                damage = 15;
            }
            else if (Mode == 2)
            {
                damage = 1;
            }
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
        }
	}

}
