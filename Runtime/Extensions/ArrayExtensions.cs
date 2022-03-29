using System.Linq;
using UnityEngine;

namespace ZangdorGames.Helpers.Extensions
{
    /// <summary>
    /// Provides extension methods for arrays.
    /// </summary>
    public static class ArrayExtensions
    {
        /// <summary>
        /// Returns whether an index is inside the bounds of the array.
        /// </summary>
        /// <typeparam name="T">The type of array to check the bounds of.</typeparam>
        /// <param name="array">The array to check the bounds of.</param>
        /// <param name="index">The index to check.</param>
        /// <returns>Whether the index is inside the bounds.</returns>
        public static bool HasIndex<T>(this T[] array, int index) => index.InRangeInclusive(0, array.Length - 1);

        /// <summary>
        /// Return a random value from the array.
        /// </summary>
        /// <typeparam name="T">The type of array to return a random value of.</typeparam>
        /// <param name="array">The array to get the value of.</param>
        /// <returns>A random value within the array.</returns>
        public static T GetRandomItem<T>(this T[] array) => array[Random.Range(0, array.Length)];

        /// <summary>
        /// Return new randomized array.
        /// </summary>
        /// <typeparam name="T">The type of array to return a randomized version of.</typeparam>
        /// <param name="array">The array to randomize.</param>
        /// <returns>A new randomized array.</returns>
        public static T[] Randomize<T>(this T[] array) => array.OrderBy(x => Random.value).ToArray();
        

        /// <summary>
        /// Returns whether an index is inside the bounds of the array.
        /// </summary>
        /// <typeparam name="T">The type of array to check the bounds of.</typeparam>
        /// <param name="array">The array to check the bounds of.</param>
        /// <param name="index">The index to check.</param>
        /// <returns>Whether the index is inside the bounds.</returns>
        public static bool HasIndex<T>(this T[,] array, int indexX, int indexY) => indexX.InRangeInclusive(0, array.GetLength(0) - 1) && indexY.InRangeInclusive(0, array.GetLength(1) - 1);

        /// <summary>
        /// Return a random value from the array.
        /// </summary>
        /// <typeparam name="T">The type of array to return a random value of.</typeparam>
        /// <param name="array">The array to get the value of.</param>
        /// <returns>A random value within the array.</returns>
        public static T GetRandomItem<T>(this T[,] array) => array[Random.Range(0, array.GetLength(0)), Random.Range(0, array.GetLength(1))];
    }
}
