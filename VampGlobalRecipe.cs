using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using VampKnives.Items.Materials;

namespace VampKnives
{
    public class ChiselRecipe : ModRecipe
    {
        public ChiselRecipe(Mod mod) : base(mod)
        {
        }

        public override bool RecipeAvailable()
        {
            if (Main.LocalPlayer.HasItem(ModContent.ItemType<Chisel>()) || VampKnives.ChiselInSlot)
                return true;
            else
                return false;
        }
    }
    public class HammerRecipe : ModRecipe
    {
        public HammerRecipe(Mod mod) : base(mod)
        {
        }

        public override bool RecipeAvailable()
        {
            if (Main.LocalPlayer.HasItem(ModContent.ItemType<Hammer>()) || VampKnives.HammerInSlot)
                return true;
            else
                return false;
        }
    }
    public class HammerAndChiselRecipe : ModRecipe
    {
        public HammerAndChiselRecipe(Mod mod) : base(mod)
        {
        }

        public override bool RecipeAvailable()
        {
            if ((Main.LocalPlayer.HasItem(ModContent.ItemType<Hammer>()) && Main.LocalPlayer.HasItem(ModContent.ItemType<Chisel>())) || (VampKnives.ChiselInSlot && VampKnives.HammerInSlot))
                return true;
            else
                return false;
        }
    }
    public class DartCastRecipe : ModRecipe
    {
        public DartCastRecipe(Mod mod) : base(mod)
        {
        }

        public override bool RecipeAvailable()
        {
            if (Main.LocalPlayer.HasItem(ModContent.ItemType<DartCast>()))
                return true;
            else
                return false;
        }
    }
    public class KnifeCastRecipe : ModRecipe
    {
        public KnifeCastRecipe(Mod mod) : base(mod)
        {
        }

        public override bool RecipeAvailable()
        {
            if (Main.LocalPlayer.HasItem(ModContent.ItemType<IronKnivesMold>()))
                return true;
            else
                return false;
        }
    }
    public class SharpCastRecipe : ModRecipe
    {
        public SharpCastRecipe(Mod mod) : base(mod)
        {
        }

        public override bool RecipeAvailable()
        {
            if (Main.LocalPlayer.HasItem(ModContent.ItemType<SharpeningRodCast>()))
                return true;
            else
                return false;
        }
    }
    public class AmmoRecipe1 : ModRecipe
    {
        public AmmoRecipe1(Mod mod) : base(mod)
        {
        }

        public override bool RecipeAvailable()
        {
            if (Main.LocalPlayer.GetModPlayer<VampPlayer>().NumCrafted >= 0 && Main.LocalPlayer.GetModPlayer<VampPlayer>().NumCrafted < 20)
                return true;
            else
                return false;
        }
    }
    public class AmmoRecipe2 : ModRecipe
    {
        public AmmoRecipe2(Mod mod) : base(mod)
        {
        }

        public override bool RecipeAvailable()
        {
            if (Main.LocalPlayer.GetModPlayer<VampPlayer>().NumCrafted >= 19 && Main.LocalPlayer.GetModPlayer<VampPlayer>().NumCrafted < 50)
            {
                return true;
            }
            else
                return false;
        }
    }
    public class AmmoRecipe3 : ModRecipe
    {
        public AmmoRecipe3(Mod mod) : base(mod)
        {
        }

        public override bool RecipeAvailable()
        {
            if (Main.LocalPlayer.GetModPlayer<VampPlayer>().NumCrafted >= 49 && Main.LocalPlayer.GetModPlayer<VampPlayer>().NumCrafted < 100)
            {
                return true;
            }
            else
                return false;
        }
    }
    public class AmmoRecipe4 : ModRecipe
    {
        public AmmoRecipe4(Mod mod) : base(mod)
        {
        }

        public override bool RecipeAvailable()
        {
            if (Main.LocalPlayer.GetModPlayer<VampPlayer>().NumCrafted >= 99 && Main.LocalPlayer.GetModPlayer<VampPlayer>().NumCrafted < 150)
            {
                return true;
            }
            else
                return false;
        }
    }
    public class AmmoRecipe5 : ModRecipe
    {
        public AmmoRecipe5(Mod mod) : base(mod)
        {
        }

        public override bool RecipeAvailable()
        {
            if (Main.LocalPlayer.GetModPlayer<VampPlayer>().NumCrafted >= 149 && Main.LocalPlayer.GetModPlayer<VampPlayer>().NumCrafted < 225)
            {
                return true;
            }
            else
                return false;
        }
    }
    public class AmmoRecipe6 : ModRecipe
    {
        public AmmoRecipe6(Mod mod) : base(mod)
        {
        }

        public override bool RecipeAvailable()
        {
            if (Main.LocalPlayer.GetModPlayer<VampPlayer>().NumCrafted >= 224 && Main.LocalPlayer.GetModPlayer<VampPlayer>().NumCrafted < 300)
            {
                return true;
            }
            else
                return false;
        }
    }
    public class AmmoRecipe7 : ModRecipe
    {
        public AmmoRecipe7(Mod mod) : base(mod)
        {
        }

        public override bool RecipeAvailable()
        {
            if (Main.LocalPlayer.GetModPlayer<VampPlayer>().NumCrafted >= 299 && Main.LocalPlayer.GetModPlayer<VampPlayer>().NumCrafted < 400)
            {
                return true;
            }
            else
                return false;
        }
    }
    public class AmmoRecipe8 : ModRecipe
    {
        public AmmoRecipe8(Mod mod) : base(mod)
        {
        }

        public override bool RecipeAvailable()
        {
            if (Main.LocalPlayer.GetModPlayer<VampPlayer>().NumCrafted >= 399 && Main.LocalPlayer.GetModPlayer<VampPlayer>().NumCrafted < 500)
            {
                return true;
            }
            else
                return false;
        }
    }
    public class AmmoRecipe9 : ModRecipe
    {
        public AmmoRecipe9(Mod mod) : base(mod)
        {
        }

        public override bool RecipeAvailable()
        {
            if (Main.LocalPlayer.GetModPlayer<VampPlayer>().NumCrafted >= 499 && Main.LocalPlayer.GetModPlayer<VampPlayer>().NumCrafted < 1000)
            {
                return true;
            }
            else
                return false;
        }
    }
    public class AmmoRecipe10 : ModRecipe
    {
        public AmmoRecipe10(Mod mod) : base(mod)
        {
        }

        public override bool RecipeAvailable()
        {
            if (Main.LocalPlayer.GetModPlayer<VampPlayer>().NumCrafted >= 999)
            {
                return true;
            }
            else
                return false;
        }
    }
}