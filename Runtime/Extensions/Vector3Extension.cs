using UnityEngine;

namespace ZangdorGames.Helpers.Extensions
{
    public static  class Vector3Extension 
    {
        /// <summary>
        /// Returns a new <see cref="Vector3"/> with a modified x value.
        /// </summary>
        /// <param name="vector">The vector to modify.</param>
        /// <param name="x">The value to add.</param>
        /// <returns>The modified vector.</returns>
        public static Vector3 SetX(this Vector3 vector, float x) => new Vector3(x, vector.y, vector.z);

        /// <summary>
        /// Returns a new Vect<see cref="Vector3"/>or3 with a modified y value.
        /// </summary>
        /// <param name="vector">The vector to modify.</param>
        /// <param name="y">The value to add.</param>
        /// <returns>The modified vector.</returns>
        public static Vector3 SetY(this Vector3 vector, float y) => new Vector3(vector.x, y, vector.z);

        /// <summary>
        /// Returns a new <see cref="Vector3"/> with a modified z value.
        /// </summary>
        /// <param name="vector">The vector to modify.</param>
        /// <param name="z">The value to add.</param>
        /// <returns>The modified vector.</returns>
        public static Vector3 SetZ(this Vector3 vector, float z) => new Vector3(vector.x, vector.y, z);

        /// <summary>
        /// Returns the squared distance between two <see cref="Vector3"/> (selected vector and another).
        /// </summary>
        /// <param name="vector">The selected vector.</param>
        /// <param name="other">The other vector.</param>
        /// <returns>The square distance between the two vectors.</returns>
        public static float SqrDistance(this Vector3 vector, Vector3 other) => Vector3.SqrMagnitude(vector - other);

        /// <summary>
        /// Returns a new <see cref="Vector2"/> using the given vector's x as x and the y as y.
        /// </summary>
        /// <param name="vector">The vector to convert.</param>
        /// <returns>The new <see cref="Vector2"/>.</returns>
        public static Vector2 ToVector2XY(this Vector3 vector) => new Vector2(vector.x, vector.y);

        /// <summary>
        /// Returns a new <see cref="Vector2"/> using the given vector's x as x and the z as y.
        /// </summary>
        /// <param name="vector">The vector to convert.</param>
        /// <returns>The new <see cref="Vector2"/>.</returns>
        public static Vector2 ToVector2XZ(this Vector3 vector) => new Vector2(vector.x, vector.z);
    }
}