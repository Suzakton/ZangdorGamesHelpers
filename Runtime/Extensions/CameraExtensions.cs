using UnityEngine;

namespace ZangdorGames.Helpers.Extensions
{
    public static class CameraExtensions 
    {
        /// <summary>
        /// Returns whether or not the gameObject is visible to the camera.
        /// </summary>
        /// <param name="camera">The camera to check if the object is visible.</param>
        /// <param name="gameObject">The gameObject to check wether is visible or not.</param>
        /// <returns>True is the gameObject is visible to the camera, false otherwise.</returns>
        public static bool IsInFov(this Camera camera, GameObject gameObject)
        {
            if(gameObject.GetComponent<Renderer>() == null)
                throw new System.Exception("No component Renderer was found on gameObject "+ gameObject.name);

            Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
            if (GeometryUtility.TestPlanesAABB(planes , gameObject.GetComponent<Renderer>().bounds))
                return true;
            else
                return false;
        }
    }
}