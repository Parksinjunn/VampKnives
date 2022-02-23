using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace VampKnives
{
    public static class VampMethods
    {
        public static VampPlayer GetVampPlayer(this Player player) => player.GetModPlayer<VampPlayer>();
        public static T GetTileEntity<T>(this Mod mod, Point16 position) where T : ModTileEntity
        {
            return !TileEntity.ByPosition.TryGetValue(position, out TileEntity TE) ? null : TE as T;
        }
        public static T GetTileEntity<T>(this Mod mod, int ID) where T : ModTileEntity
        {
            return !TileEntity.ByID.TryGetValue(ID, out TileEntity TE) ? null : TE as T;
        }
    }
}