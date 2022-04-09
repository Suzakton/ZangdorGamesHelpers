using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ZangdorGames.Helpers.Extensions
{
    public static  class Vector2Extension 
    {
        /// <summary>
        /// Returns a new <see cref="Vector2"/> with a modified x value.
        /// </summary>
        /// <param name="vector">The vector to modify.</param>
        /// <param name="x">The value to add.</param>
        /// <returns>The modified vector.</returns>
        public static Vector2 SetX(this Vector2 vector, float x) => new Vector2(x, vector.y);

        /// <summary>
        /// Returns a new Vect<see cref="Vector2"/>or3 with a modified y value.
        /// </summary>
        /// <param name="vector">The vector to modify.</param>
        /// <param name="y">The value to add.</param>
        /// <returns>The modified vector.</returns>
        public static Vector2 SetY(this Vector2 vector, float y) => new Vector2(vector.x, y);

        /// <summary>
        /// Returns the squared distance between two <see cref="Vector2"/> (selected vector and another).
        /// </summary>
        /// <param name="vector">The selected vector.</param>
        /// <param name="other">The other vector.</param>
        /// <returns>The square distance between the two vectors.</returns>
        public static float SqrDistance(this Vector2 vector, Vector2 other) => Vector2.SqrMagnitude(vector - other);

        /// <summary>
        /// Check at the position (vector.x, vector.y) on the screen if there is an UI.
        /// </summary>
        /// <param name="vector">The position to check.</param>
        /// <returns>True is there is an UI at this position, false otherwise.</returns>
        public static bool IsOverUI(this Vector2 vector) 
        {
            PointerEventData _eventDataCurrentPosition = new PointerEventData(EventSystem.current) { position = vector };
            List<RaycastResult> _results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(_eventDataCurrentPosition, _results);
            return _results.Count > 0;
        }
    }
}