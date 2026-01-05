using UnityEngine;

public class scParallax : MonoBehaviour
{
    [Header("Setting")]
    public GameObject kamera; // Masukkan Main Camera ke sini
    public float efekParallax; // 0 = Diam, 1 = Nempel Kamera (Gerak bareng)

    private float panjangAwal;
    private float posisiMulai;

    void Start()
    {
        // Simpan posisi awal background
        posisiMulai = transform.position.x;

        // (Opsional) Mengambil lebar gambar agar nanti bisa looping (infinite)
        // Kalau backgroundmu Sprite biasa, ini berguna.
        if (GetComponent<SpriteRenderer>() != null)
        {
            panjangAwal = GetComponent<SpriteRenderer>().bounds.size.x;
        }
    }

    void Update()
    {
        // Hitung jarak geser berdasarkan posisi kamera * efekParallax
        float jarak = (kamera.transform.position.x * efekParallax);

        // Pindahkan posisi background
        transform.position = new Vector3(posisiMulai + jarak, transform.position.y, transform.position.z);
    }
}