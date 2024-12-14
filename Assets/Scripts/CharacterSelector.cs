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
            DontDestroyOnLoad(gameObject); // Sahneler arasý taþýnýr
        }
        else
        {
            Debug.LogWarning("EXTRA " + this + " DELETED");
            Destroy(gameObject); // Fazla kopyalarý sil
        }
    }

    // Karakter verisini döndür
    public static CharacterScriptableObject GetData()
    {
        return instance.characterData;
    }

    public void SelectCharacter(CharacterScriptableObject character)
    {
        characterData = character;
    }

    //Singleton'ý sýfýrlar ve objeyi yok eder
    public void DestroySingleton()
    {
        instance = null;
        Destroy(gameObject);
    }
}
