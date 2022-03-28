using UnityEngine;

namespace ZangdorGames.Helpers.Extensions
{
    public static class TransformExtension 
    {
        /*
        GetDirectChildren() - Returns the direct childs of the Transform instance, excluding grandchildren, great-grand children and so on.
        GetComponentsInDirectChildren<T>() - Returns the direct children's components of the Transform instance, excluding grandchildren, great-grand children and so on.
        GetComponentsInDirectChildren<T>() - Returns the direct children's components of the GameObject instance, excluding grandchildren, great-grand children and so on.
        */

        /// <summary>
        /// Returns the direct childs of the <see cref="Transform"/> instance, excluding grandchildren, great-grand children and so on.
        /// TODO
        /// </summary>
        /// <param name="transform">The <see cref="Transform"/> to get the child of.</param>
        /// <returns>An array of the child transform.</returns>
        public static Transform[] GetDirectChildren(this Transform transform) => null;

        /// <summary>
        /// Returns the direct children's components of the <see cref="Transform"/> instance, excluding grandchildren, great-grand children and so on.
        /// TODO
        /// </summary>
        /// <typeparam name="T">The type of component to look for.</typeparam>
        /// <param name="transform">The <see cref="Transform"/> to look at the direct child of.</param>
        /// <returns>An array of component.</returns>
        public static T[] GetComponentsInDirectChildren<T>(this Transform transform) => null;

        /// <summary>
        /// Returns the direct children's components of the <see cref="GameObject"/> instance, excluding grandchildren, great-grand children and so on.
        /// TODO
        /// </summary>
        /// <typeparam name="T">The type of component to look for.</typeparam>
        /// <param name="transform">The <see cref="GameObject"/> to look at the direct child of.</param>
        /// <returns>An array of component.</returns>
        public static T[] GetComponentsInDirectChildren<T>(this GameObject gameobject) => null;
    }
}