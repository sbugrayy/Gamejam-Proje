using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void SceneChange(string name)
    {
        SceneManager.LoadScene(name);
        //Time.timeScale = 1f;
    }

    public void QuitToMenu(string name)
    {
        // Singleton'� yok et
        if (CharacterSelector.instance != null)
        {
            CharacterSelector.instance.DestroySingleton();  // CharacterSelector'� temizle
        }

        // Menu sahnesine d�n
        SceneManager.LoadScene(name);
    }
}
