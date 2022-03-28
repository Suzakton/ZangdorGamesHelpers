using System;
using UnityEngine;

namespace ZangdorGames.Helpers.Extensions
{
    /// <summary>
    /// Provides extension methods for <typeparamref name="double"/>.
    /// </summary>
    public static class DoubleExtensions 
    {
        /// <summary>
        /// Returns whether the value is greater than or equal to a minimal value 
        /// and smaller than or equal to a maximum value.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="min">The minimal value.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>Whether the value is in the range.</returns>
        public static bool InRangeInclusive(this double value, double min, double max) => value >= min && value <= max;


        /// <summary>
        /// Returns whether the value is strictly greater to a minimal value 
        /// and strictly smaller to a maximum value.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="min">The minimal value.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>Whether the value is in the range.</returns>
        public static bool InRangeExclusive(this double value, double min, double max) => value > min && value < max;

        /// <summary>
        /// Returns the inversed value. This means a positive value
        /// if the given value is negative and negative value if the 
        /// given one is positive.
        /// </summary>
        /// <param name="value">The value to inverse.</param>
        /// <returns>The inversed value.</returns>
        public static double Inverse(this double value) => value *= -1d;

        /// <summary>
        /// Returns the complement of the value so (1 - 'value').
        /// </summary>
        /// <param name="value">The value to get the complement of.</param>
        /// <returns>The complement.</returns>
        public static double Complement(this double value)
        {
            if (value < 0.0d || value > 1.0d)
                throw new ArgumentOutOfRangeException(nameof(value), "Expects value between in range 0 to 1.");

            return 1.0d - value;
        }

        /// <summary>
        /// Returns the normalized (between 0 and 1) value.
        /// </summary>
        /// <param name="value">The value to normalize.</param>
        /// <param name="min">The minimum value to use.</param>
        /// <param name="max">The maximum value to use.</param>
        /// <returns>The normalized value.</returns>
        public static double Normalize(this double value, double min, double max) => (value - min) / (max - min);

        /// <summary>
        /// Returns the value mapped to a new scale.
        /// </summary>
        /// <param name="value">The value to map.</param>
        /// <param name="min">The minimum range.</param>
        /// <param name="max">The maximum range.</param>
        /// <param name="targetMin">The new minimum range.</param>
        /// <param name="targetMax">The new maximum range.</param>
        /// <returns>The mapped value.</returns>
        public static double Map(this double value, double min, double max, double targetMin, double targetMax)
                        => (value - min) * ((targetMax - targetMin) / (max - min)) + targetMin;
    

        /// <summary>
        /// Clamps and normalize a value between a minimum and a maximum angle value (in degrees).
        /// </summary>
        /// <param name="value">The angle to clamp.</param>
        /// <param name="min">The minimum angle.</param>
        /// <param name="max">The maximum angle.</param>
        /// <returns>The clamped angle.</returns>
        public static double ClampAngle(this double value, double min, double max)
        {
            double toClamp = value.NormalizeAngle();
            double toClampMin = min.NormalizeAngle();
            double toClampMax = max.NormalizeAngle();
            if(min > max)
            {
                toClampMin = max.NormalizeAngle();
                toClampMax = min.NormalizeAngle();
            }
            if(toClamp < toClampMin)
                return toClampMin;
            else if (toClamp > toClampMax)
                return toClampMax;
            else
                return toClamp;
        }

        /// <summary>
        /// Normalizes and angle value (in degrees), making it be between the value ranges of 0 and 360. 
        /// This means that the value 365 will be changed to 5, and the value -5 will be changed to 355.
        /// </summary>
        /// <param name="value">The angle to normalize.</param>
        /// <returns>The normalized angle.</returns>
        public static double NormalizeAngle(this double value) 
        {
            if(value % 360 < 0)
                return value % 360 + 360;
            else
                return value % 360;
        }

        /// <summary>
        /// Converts an angle in degrees to radians.
        /// </summary>
        /// <param name="value">The angle to convert.</param>
        /// <returns>The converted angle.</returns>
        public static double DegreesToRadians(this double value) => value * Mathf.PI / 180;

        /// <summary>
        /// Converts an angle in radians to degrees.
        /// </summary>
        /// <param name="value">The angle to convert.</param>
        /// <returns>The converted angle.</returns>
        public static double RadiansToDegrees(this double value) => value * 180 / Mathf.PI;

        /// <summary>
        /// Returns the value raised to power exponent.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="exponent">The exponent.</param>
        /// <returns>The result of the value power the exponent</returns>
        public static double Pow(this double value, float exponent) => Mathf.Pow((float) value, exponent);

        /// <summary>
        /// Returns the value raised to power exponent.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="exponent">The exponent.</param>
        /// <returns>The result of the value power the exponent</returns>
        public static double Pow(this double value, double exponent) => Mathf.Pow((float) value, (float) exponent);
    }
}