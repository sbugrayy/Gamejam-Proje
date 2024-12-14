using UnityEngine;
using UnityEngine.UI;

public class ButtonImageChanger : MonoBehaviour
{
    // Referanslar
    public Image buttonImage;       // Butonun Image bile�eni
    public Sprite[] sprites;        // PNG dosyalar�n�n listesi

    private int currentIndex = 0;   // Mevcut PNG dosyas�n�n indeksi

    // Butona bas�ld���nda �al��acak fonksiyon
    public void ChangeImage()
    {
        // PNG de�i�imi
        currentIndex = (currentIndex + 1) % sprites.Length;
        buttonImage.sprite = sprites[currentIndex];
    }
    private void Awake()
    {
        // Bu nesneyi sahne de�i�ikliklerinde yok etme
        //DontDestroyOnLoad(gameObject);
    }
}
