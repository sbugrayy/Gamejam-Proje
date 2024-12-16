using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMainMenuLoader : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 1f;
    }
    private void Start()
    {
        Invoke("LoadScene", 14.5f);
    }
    //Used in invoke
    private void LoadScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
