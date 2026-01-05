using UnityEngine;

public class scCheckpoint : MonoBehaviour
{
    // Opsional: Suara saat checkpoint aktif
    // public AudioClip suaraCheckpoint; 

    private bool sudahAktif = false; // Agar tidak lapor berkali-kali

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Jika yang menabrak adalah Player DAN checkpoint ini belum aktif
        if (collision.CompareTag("Player") && !sudahAktif)
        {
            // 1. Tandai sudah aktif
            sudahAktif = true;

            // 2. Simpan posisi objek ini (papan tanda) ke dalam GameManager
            scGameManager.posisiRespawn = transform.position;

            // 3. Beri pesan di console
            Debug.Log("Checkpoint Berhasil Disimpan di: " + transform.position);

            // (Opsional: Bisa tambahkan ganti warna sprite atau bunyi di sini)
        }
    }
}