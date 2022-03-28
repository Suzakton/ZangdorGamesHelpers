using UnityEngine;

namespace ZangdorGames.Helpers.Extensions
{
    public static class ColorExtensions 
    {
        /// <summary>
        /// Returns a new <see cref="Color"/> with an inverted color value.
        /// TODO 
        /// </summary>
        /// <param name="color">The color to invert.</param>
        /// <returns>The inverted color.</returns>
        public static Color Invert(this Color color) => new Color();
        
        /// <summary>
        /// Returns a new <see cref="Color"/> with a modified alpha value.
        /// TODO 
        /// </summary>
        /// <param name="color">The color to change the alpha value of.</param>
        /// <param name="alpha">The new alpha value</param>
        /// <returns>The new Color with a modified alpha value.</returns>
        public static Color Alpha(this Color color, float alpha) => new Color();
        
        /// <summary>
        /// Returns a new <see cref="Color"/> with a modified red value.
        /// TODO 
        /// </summary>
        /// <param name="color">The color to change the red value of.</param>
        /// <param name="red">The new red value</param>
        /// <returns>The new Color with a modified red value.</returns>
        public static Color Red(this Color color, float red) => new Color();
        
        /// <summary>
        /// Returns a new <see cref="Color"/> with a modified green value.
        /// TODO 
        /// </summary>
        /// <param name="color">The color to change the green value of.</param>
        /// <param name="green">The new green value</param>
        /// <returns>The new Color with a modified green value.</returns>
        public static Color Green(this Color color, float green) => new Color();
        
        /// <summary>
        /// Returns a new <see cref="Color"/> with a modified blue value.
        /// TODO 
        /// </summary>
        /// <param name="color">The color to change the blue value of.</param>
        /// <param name="blue">The new blue value</param>
        /// <returns>The new Color with a modified blue value.</returns>
        public static Color Blue(this Color color, float blue) => new Color();

        /// <summary>
        /// Returns the grayscale version of the <see cref="Color"/>.
        /// TODO
        /// </summary>
        /// <param name="color">The color to change to grayscale.</param>
        /// <returns>The grayscale version of the Color.</returns>
        public static Color ToGrayScale(this Color color) => new Color();

        /// <summary>
        /// Tries to create a new <see cref="Color"/> with the prompted hex color value. 
        /// <para>If it fails it will return the value of originalColor.</para>
        /// TODO
        /// </summary>
        /// <param name="hex">The hexadecimal string value.</param>
        /// <param name="originalColor">The color to return if it fails.</param>
        /// <returns>The new color from the hexadecimal value.</returns>
        public static Color HtmlToColor(this string hex, Color originalColor = new Color()) => new Color();
    }
}