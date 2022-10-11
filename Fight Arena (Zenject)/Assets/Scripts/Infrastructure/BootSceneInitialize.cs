using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure
{
    public class BootSceneInitialize: MonoBehaviour
    {
        private void Start()
        {
            // Game init logic
            SceneManager.LoadSceneAsync("Game");
        }
    }
}
