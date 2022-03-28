using UnityEngine;

namespace ZangdorGames.Helpers.Extensions
{
    public static class RectExtensions 
    {
        /// <summary>
        /// Returns the position of the <see cref="Rect"/>'s center.
        /// TODO
        /// </summary>
        /// <param name="rect">The rect to get the center from.</param>
        /// <returns>The center of the rect.</returns>
        public static Vector2 GetCenter(this Rect rect) => Vector2.zero;

        /// <summary>
        /// Adds a x value to the current <see cref="Rect"/>.
        /// TODO
        /// </summary>
        /// <param name="rect">The Rect to modify.</param>
        /// <param name="x">The value to add to the Rect.</param>
        /// <returns>The new Rect modified.</returns>
        public static Rect AddX(this Rect rect, float x) => new Rect();

        /// <summary>
        /// Adds a y value to the current <see cref="Rect"/>.
        /// </summary>
        /// <param name="rect">The Rect to modify.</param>
        /// <param name="y">The value to add to the Rect.</param>
        /// <returns>The new Rect modified.</returns>
        public static Rect AddY(this Rect rect, float y) => new Rect();

        /// <summary>
        /// Adds a width value to the current <see cref="Rect"/>.
        /// TODO
        /// </summary>
        /// <param name="rect">The Rect to modify.</param>
        /// <param name="width">The value to add to the width of the Rect.</param>
        /// <returns>The new Rect modified.</returns>
        public static Rect AddWidth(this Rect rect, float width) => new Rect();

        /// <summary>
        /// Adds a height value to the current <see cref="Rect"/>.
        /// TODO
        /// </summary>
        /// <param name="rect">The Rect to modify.</param>
        /// <param name="height">The value to add to the height of the Rect.</param>
        /// <returns>The new Rect modified.</returns>
        public static Rect AddHeight(this Rect rect, float height) => new Rect();

        /// <summary>
        /// Sets a x value to the current <see cref="Rect"/>.
        /// TODO
        /// </summary>
        /// <param name="rect">The Rect to modify.</param>
        /// <param name="x">The value to set to the Rect.</param>
        /// <returns>The new Rect modified.</returns>
        public static Rect SetX(this Rect rect, float x) => new Rect();

        /// <summary>
        /// Sets a y value to the current <see cref="Rect"/>.
        /// </summary>
        /// <param name="rect">The Rect to modify.</param>
        /// <param name="y">The value to set to the Rect.</param>
        /// <returns>The new Rect modified.</returns>
        public static Rect SetY(this Rect rect, float y) => new Rect();

        /// <summary>
        /// Sets a width value to the current <see cref="Rect"/>.
        /// TODO
        /// </summary>
        /// <param name="rect">The Rect to modify.</param>
        /// <param name="width">The value to set to the width of the Rect.</param>
        /// <returns>The new Rect modified.</returns>
        public static Rect SetWidth(this Rect rect, float width) => new Rect();

        /// <summary>
        /// Sets a height value to the current <see cref="Rect"/>.
        /// TODO
        /// </summary>
        /// <param name="rect">The Rect to modify.</param>
        /// <param name="height">The value to set to the height of the Rect.</param>
        /// <returns>The new Rect modified.</returns>
        public static Rect SetHeight(this Rect rect, float height) => new Rect();
    }
}