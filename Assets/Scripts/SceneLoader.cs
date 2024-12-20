using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    AudioSource audioSource;
    private void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    public void OnButtonPress()
    {
        audioSource.Play();
        Invoke("LoadScene", 1f);
    }
    //Used in invoke
    private void LoadScene()
    {
        SceneManager.LoadScene("Game");
    }
}
