using System.Collections.Generic;
using UnityEngine;

namespace ZangdorGames.Helpers.Extensions
{
    public static class TransformExtension 
    {
        /// <summary>
        /// Returns the direct childs of the <see cref="Transform"/> instance, excluding grandchildren, great-grand children and so on.
        /// </summary>
        /// <param name="transform">The <see cref="Transform"/> to get the children of.</param>
        /// <returns>An array of the children transform.</returns>
        public static Transform[] GetDirectChildren(this Transform transform)
        {
            Transform[] children = new Transform[transform.childCount];
            for (int i = 0; i < transform.childCount; i++)
            {
                children[i] = transform.GetChild(i);
            }
            return children;
        }

        /// <summary>
        /// Returns the direct children's components of the <see cref="Transform"/> instance, excluding grandchildren, great-grand children and so on.
        /// </summary>
        /// <typeparam name="T">The type of component to look for.</typeparam>
        /// <param name="transform">The <see cref="Transform"/> to look at the direct children of.</param>
        /// <returns>An array of component.</returns>
        public static T[] GetComponentsInDirectChildren<T>(this Transform transform) where T : MonoBehaviour
        {
            List<T> components = new List<T>();
            foreach (Transform item in transform.GetDirectChildren())
            {
                T comp = item.GetComponent<T>();
                if(comp != null)
                    components.Add(comp);

            }
            return components.ToArray();
        }

        /// <summary>
        /// Returns the direct children's components of the <see cref="GameObject"/> instance, excluding grandchildren, great-grand children and so on.
        /// </summary>
        /// <typeparam name="T">The type of component to look for.</typeparam>
        /// <param name="transform">The <see cref="GameObject"/> to look at the direct children of.</param>
        /// <returns>An array of component.</returns>
        public static T[] GetComponentsInDirectChildren<T>(this GameObject gameobject) where T : MonoBehaviour => gameobject.transform.GetComponentsInDirectChildren<T>();
    }
}