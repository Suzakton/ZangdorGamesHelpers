using UnityEngine;

namespace ZangdorGames.Helpers.Components
{
    public class DontDestroyOnLoad : MonoBehaviour 
    {
        private void Awake() 
        {
            DontDestroyOnLoad(this);
        }
    }
}