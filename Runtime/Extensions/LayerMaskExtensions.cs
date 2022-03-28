using UnityEngine;

namespace ZangdorGames.Helpers.Extensions
{
    public static class LayerMaskExtensions 
    {
        //IncludesLayer(int layer) - Returns if the LayerMask includes the layer value.

        /// <summary>
        /// Returns if the LayerMask includes the layer value.
        /// </summary>
        /// <param name="layerMask">The layermask to search in.</param>
        /// <param name="layer">The layer to search for.</param>
        /// <returns>True if the layermask include the layer, false otherwise.</returns>
        public static bool IncludesLayer(this LayerMask layerMask, int layer) => ((layerMask.value & (1 << layer)) > 0);
    }
}