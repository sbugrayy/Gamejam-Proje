using UnityEngine;
using UnityEngine.UI;

public class ButtonImageChanger : MonoBehaviour
{
    // Referanslar
    public Image buttonImage;       // Butonun Image bileþeni
    public Sprite[] sprites;        // PNG dosyalarýnýn listesi

    private int currentIndex = 0;   // Mevcut PNG dosyasýnýn indeksi

    // Butona basýldýðýnda çalýþacak fonksiyon
    public void ChangeImage()
    {
        // PNG deðiþimi
        currentIndex = (currentIndex + 1) % sprites.Length;
        buttonImage.sprite = sprites[currentIndex];
    }
    private void Awake()
    {
        // Bu nesneyi sahne deðiþikliklerinde yok etme
        //DontDestroyOnLoad(gameObject);
    }
}
