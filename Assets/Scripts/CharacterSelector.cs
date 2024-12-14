using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public static CharacterSelector instance;
    public CharacterScriptableObject characterData; // Tek karakter verisi

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Sahneler aras� ta��n�r
        }
        else
        {
            Debug.LogWarning("EXTRA " + this + " DELETED");
            Destroy(gameObject); // Fazla kopyalar� sil
        }
    }

    // Karakter verisini d�nd�r
    public static CharacterScriptableObject GetData()
    {
        return instance.characterData;
    }

    public void SelectCharacter(CharacterScriptableObject character)
    {
        characterData = character;
    }

    //Singleton'� s�f�rlar ve objeyi yok eder
    public void DestroySingleton()
    {
        instance = null;
        Destroy(gameObject);
    }
}
