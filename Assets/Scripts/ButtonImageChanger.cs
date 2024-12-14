using UnityEngine;
using UnityEngine.UI;

public class ButtonImageChanger : MonoBehaviour
{
    // Referanslar
    public Image buttonImage;       // Butonun Image bileþeni
    public Sprite[] sprites;        // PNG dosyalarýnýn listesi
    public AudioSource audioSource; // Ses kaynaðý
    public AudioClip clickSound;    // Ses dosyasý

    private int currentIndex = 0;   // Mevcut PNG dosyasýnýn indeksi

    // Butona basýldýðýnda çalýþacak fonksiyon
    public void ChangeImage()
    {
        // PNG deðiþimi
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
        // Bu nesneyi sahne deðiþikliklerinde yok etme
        DontDestroyOnLoad(gameObject);
    }
}
