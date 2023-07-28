using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class Menu : MonoBehaviour
    {
    
        public void StartButton()
        {
            SceneManager.LoadScene("Scenes/Gameplay");
        }
    }
}
