using UnityEngine;
using UnityEngine.UI;

public class ButtonImageChanger : MonoBehaviour
{
    // Referanslar
    public Image buttonImage;       // Butonun Image bileşeni
    public Sprite[] sprites;        // PNG dosyalarının listesi

    private int currentIndex = 0;   // Mevcut PNG dosyasının indeksi

    // Butona basıldığında çalışacak fonksiyon
    public void ChangeImage()
    {
        // PNG değişimi
        currentIndex = (currentIndex + 1) % sprites.Length;
        buttonImage.sprite = sprites[currentIndex];
    }
    private void Awake()
    {
        // Bu nesneyi sahne değişikliklerinde yok etme
        //DontDestroyOnLoad(gameObject);
    }
}
