using UnityEngine;

namespace ZangdorGames.Helpers.Extensions
{
    public static class RectExtensions 
    {
        /// <summary>
        /// Adds a x value to the current <see cref="Rect"/>.
        /// </summary>
        /// <param name="rect">The Rect to modify.</param>
        /// <param name="x">The value to add to the Rect.</param>
        /// <returns>The new Rect modified.</returns>
        public static Rect AddX(this Rect rect, float x) => new Rect(rect.x + x, rect.y, rect.width, rect.height);

        /// <summary>
        /// Adds a y value to the current <see cref="Rect"/>.
        /// </summary>
        /// <param name="rect">The Rect to modify.</param>
        /// <param name="y">The value to add to the Rect.</param>
        /// <returns>The new Rect modified.</returns>
        public static Rect AddY(this Rect rect, float y) => new Rect(rect.x, rect.y + y, rect.width, rect.height);

        /// <summary>
        /// Adds a width value to the current <see cref="Rect"/>.
        /// </summary>
        /// <param name="rect">The Rect to modify.</param>
        /// <param name="width">The value to add to the width of the Rect.</param>
        /// <returns>The new Rect modified.</returns>
        public static Rect AddWidth(this Rect rect, float width) => new Rect(rect.x, rect.y, rect.width + width, rect.height);

        /// <summary>
        /// Adds a height value to the current <see cref="Rect"/>.
        /// </summary>
        /// <param name="rect">The Rect to modify.</param>
        /// <param name="height">The value to add to the height of the Rect.</param>
        /// <returns>The new Rect modified.</returns>
        public static Rect AddHeight(this Rect rect, float height) => new Rect(rect.x, rect.y, rect.width, rect.height + height);

        /// <summary>
        /// Sets a x value to the current <see cref="Rect"/>.
        /// </summary>
        /// <param name="rect">The Rect to modify.</param>
        /// <param name="x">The value to set to the Rect.</param>
        /// <returns>The new Rect modified.</returns>
        public static Rect SetX(this Rect rect, float x) => new Rect(x, rect.y, rect.width, rect.height);

        /// <summary>
        /// Sets a y value to the current <see cref="Rect"/>.
        /// </summary>
        /// <param name="rect">The Rect to modify.</param>
        /// <param name="y">The value to set to the Rect.</param>
        /// <returns>The new Rect modified.</returns>
        public static Rect SetY(this Rect rect, float y) => new Rect(rect.x, y, rect.width, rect.height);

        /// <summary>
        /// Sets a width value to the current <see cref="Rect"/>.
        /// </summary>
        /// <param name="rect">The Rect to modify.</param>
        /// <param name="width">The value to set to the width of the Rect.</param>
        /// <returns>The new Rect modified.</returns>
        public static Rect SetWidth(this Rect rect, float width) => new Rect(rect.x, rect.y, width, rect.height);

        /// <summary>
        /// Sets a height value to the current <see cref="Rect"/>.
        /// </summary>
        /// <param name="rect">The Rect to modify.</param>
        /// <param name="height">The value to set to the height of the Rect.</param>
        /// <returns>The new Rect modified.</returns>
        public static Rect SetHeight(this Rect rect, float height) => new Rect(rect.x, rect.y, rect.width, height);
    }
}