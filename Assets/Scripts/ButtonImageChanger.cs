using UnityEngine;
using UnityEngine.UI;

public class ButtonImageChanger : MonoBehaviour
{
    // Referanslar
    public Image buttonImage;       // Butonun Image bileşeni
    public Sprite[] sprites;        // PNG dosyalarının listesi
    public AudioSource audioSource; // Ses kaynağı
    public AudioClip clickSound;    // Ses dosyası

    private int currentIndex = 0;   // Mevcut PNG dosyasının indeksi

    // Butona basıldığında çalışacak fonksiyon
    public void ChangeImage()
    {
        // PNG değişimi
        currentIndex = (currentIndex + 1) % sprites.Length;
        buttonImage.sprite = sprites[currentIndex];

        // Ses çalma
        if (audioSource != null && clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }
    private void Awake()
    {
        // Bu nesneyi sahne değişikliklerinde yok etme
        DontDestroyOnLoad(gameObject);
    }
}
