using UnityEngine;

namespace ZangdorGames.Helpers.Extensions
{
    public static class ColorExtensions 
    {
        /// <summary>
        /// Returns a new <see cref="Color"/> with an inverted color value but keep same alpha value.
        /// </summary>
        /// <param name="color">The color to invert.</param>
        /// <returns>The inverted color.</returns>
        public static Color Invert(this Color color) => new Color(1.0f-color.r, 1.0f-color.g, 1.0f-color.b, color.a);
        
        /// <summary>
        /// Returns a new <see cref="Color"/> with a modified alpha value.
        /// </summary>
        /// <param name="color">The color to change the alpha value of.</param>
        /// <param name="alpha">The new alpha value</param>
        /// <returns>The new Color with a modified alpha value.</returns>
        public static Color Alpha(this Color color, float alpha) => new Color(color.r, color.g, color.b, alpha);
        
        /// <summary>
        /// Returns a new <see cref="Color"/> with a modified red value.
        /// </summary>
        /// <param name="color">The color to change the red value of.</param>
        /// <param name="red">The new red value</param>
        /// <returns>The new Color with a modified red value.</returns>
        public static Color Red(this Color color, float red) => new Color(red, color.g, color.b, color.a);
        
        /// <summary>
        /// Returns a new <see cref="Color"/> with a modified green value.
        /// </summary>
        /// <param name="color">The color to change the green value of.</param>
        /// <param name="green">The new green value</param>
        /// <returns>The new Color with a modified green value.</returns>
        public static Color Green(this Color color, float green) => new Color(color.r, green, color.b, color.a);
        
        /// <summary>
        /// Returns a new <see cref="Color"/> with a modified blue value.
        /// </summary>
        /// <param name="color">The color to change the blue value of.</param>
        /// <param name="blue">The new blue value</param>
        /// <returns>The new Color with a modified blue value.</returns>
        public static Color Blue(this Color color, float blue) => new Color(color.r, color.g, blue, color.a);

        /// <summary>
        /// Returns the grayscale version of the <see cref="Color"/> but keep same alpha value..
        /// </summary>
        /// <param name="color">The color to change to grayscale.</param>
        /// <returns>The grayscale version of the Color.</returns>
        public static Color ToGrayScale(this Color color) => new Color(color.grayscale, color.grayscale, color.grayscale, color.a);

        /// <summary>
        /// Tries to create a new <see cref="Color"/> with the prompted hex color value. 
        /// <para>If it fails it will return the value of originalColor.</para>
        /// </summary>
        /// <param name="hex">The hexadecimal string value.</param>
        /// <param name="originalColor">The color to return if it fails.</param>
        /// <returns>The new color from the hexadecimal value.</returns>
        public static Color HtmlToColor(this string hex, Color originalColor = new Color()) 
        {
            Color hexColor = new Color();
            bool convert = ColorUtility.TryParseHtmlString(hex, out hexColor);
            if(convert)
                return hexColor;
            
            return originalColor;
        }
    }
}