using UnityEngine;

namespace ZangdorGames.Helpers.Components
{
    /// <summary>
    /// Add the DontDestroyOnLoad on the gameobject with this component.
    /// </summary>
    public class DontDestroyOnLoad : MonoBehaviour 
    {
        private void Awake() 
        {
            DontDestroyOnLoad(this);
        }
    }
}