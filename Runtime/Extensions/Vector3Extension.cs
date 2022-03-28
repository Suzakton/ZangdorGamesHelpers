using UnityEngine;

namespace ZangdorGames.Helpers.Extensions
{
    public static  class Vector3Extension 
    {
        /// <summary>
        /// Returns a new <see cref="Vector3"/> with a modified x value.
        /// TODO
        /// </summary>
        /// <param name="vector">The vector to modify.</param>
        /// <param name="x">The value to add.</param>
        /// <returns>The modified vector.</returns>
        public static Vector3 SetX(this Vector3 vector, float x) => Vector3.zero;

        /// <summary>
        /// Returns a new Vect<see cref="Vector3"/>or3 with a modified y value.
        /// TODO
        /// </summary>
        /// <param name="vector">The vector to modify.</param>
        /// <param name="y">The value to add.</param>
        /// <returns>The modified vector.</returns>
        public static Vector3 SetY(this Vector3 vector, float y) => Vector3.zero;

        /// <summary>
        /// Returns a new <see cref="Vector3"/> with a modified z value.
        /// TODO
        /// </summary>
        /// <param name="vector">The vector to modify.</param>
        /// <param name="z">The value to add.</param>
        /// <returns>The modified vector.</returns>
        public static Vector3 SetZ(this Vector3 vector, float z) => Vector3.zero;

        /// <summary>
        /// Returns the squared distance between two <see cref="Vector3"/> (selected vector and another).
        /// TODO
        /// </summary>
        /// <param name="vector">The selected vector.</param>
        /// <param name="other">The other vector.</param>
        /// <returns>The square distance between the two vectors.</returns>
        public static float SqrDistance(this Vector3 vector, Vector3 other) => 0;

        /// <summary>
        /// Returns a new <see cref="Vector2"/> using the given vector's x as x and the y as y.
        /// TODO
        /// </summary>
        /// <param name="vector">The vector to convert.</param>
        /// <returns>The new <see cref="Vector2"/>.</returns>
        public static Vector2 ToVector2XY(this Vector3 vector) => Vector2.zero;

        /// <summary>
        /// Returns a new <see cref="Vector2"/> using the given vector's x as x and the z as y.
        /// TODO
        /// </summary>
        /// <param name="vector">The vector to convert.</param>
        /// <returns>The new <see cref="Vector2"/>.</returns>
        public static Vector2 ToVector2XZ(this Vector3 vector) => Vector2.zero;


        /*
        TODO
        GetPerpendicularDirector() - Returns the perpendicular director of the current Vector3.
        IsRight(Vector3 right) - Returns if current vector's direction is relatively Right, right being the relative Right direction used for comparison.
        IsLeft(Vector3 right) - Returns if current vector's direction is relatively Left, right being the relative Right direction used for comparison.
        IsLateral(Vector3 right) - Returns if current vector's direction is either right or left relative to a custom right direction.
        IsForward(Vector3 forward) - Returns if current vector's direction is relatively Forward, forward being the relative forward used for comparison.
        IsBackward(Vector3 forward) - Returns if current vector's direction is relatively Backward, forward being the relative Forward direction used for comparison.
        IsFrontal(Vector3 forward) - Returns if current vector's direction is either forward or backward relative to a custom Forward direction.
        */
        
    }
}