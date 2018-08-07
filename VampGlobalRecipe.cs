using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives
{
    public class ChiselRecipe : ModRecipe
    {
        public ChiselRecipe(Mod mod) : base(mod)
        {
        }

        public override bool RecipeAvailable()
        {
            if (Main.LocalPlayer.HasItem(mod.ItemType("Chisel")))
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
            if (Main.LocalPlayer.HasItem(mod.ItemType("Hammer")))
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
            if (Main.LocalPlayer.HasItem(mod.ItemType("Hammer")) && Main.LocalPlayer.HasItem(mod.ItemType("Chisel")))
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
            if (Main.LocalPlayer.HasItem(mod.ItemType("DartCast")))
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
            if (Main.LocalPlayer.HasItem(mod.ItemType("IronKnivesMold")))
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
            if (Main.LocalPlayer.HasItem(mod.ItemType("SharpeningRodCast")))
                return true;
            else
                return false;
        }
    }
}