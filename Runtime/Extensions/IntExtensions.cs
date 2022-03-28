namespace ZangdorGames.Helpers.Extensions
{   
    /// <summary>
    /// Provaide extension methods for <typeparamref name="int"/>.
    /// </summary>
    public static class IntExtensions 
    {
        /// <summary>
        /// Returns the inversed value. This means a positive value
        /// if the given value is negative and negative value if the 
        /// given one is positive.
        /// </summary>
        /// <param name="value">The value to inverse.</param>
        /// <returns>The inversed value.</returns>
        public static int Inverse(this int value) => value * -1;

        /// <summary>
        /// Returns whether the value is greater than or equal to a minimal value 
        /// and smaller than or equal to a maximum value.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="min">The minimal value.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>Whether the value is in the range.</returns>
        public static bool InRangeInclusive(this int value, int min, int max) => value >= min && value <= max;


        /// <summary>
        /// Returns whether the value is strictly greater to a minimal value 
        /// and strictly smaller to a maximum value.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="min">The minimal value.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>Whether the value is in the range.</returns>
        public static bool InRangeExclusive(this int value, int min, int max) => value > min && value < max;

    }
}