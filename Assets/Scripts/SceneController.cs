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
        // Singleton'ý yok et
        if (CharacterSelector.instance != null)
        {
            CharacterSelector.instance.DestroySingleton();  // CharacterSelector'ý temizle
        }

        // Menu sahnesine dön
        SceneManager.LoadScene(name);
    }
}
