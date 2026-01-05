using UnityEngine;
using UnityEngine.SceneManagement;

public class scMusicBG : MonoBehaviour
{
    public static scMusicBG instance;

    void Awake()
    {
        // --- LOGIKA SINGLETON (Agar Musik Tidak Double) ---
        if (instance != null)
        {
            // Jika sudah ada musik yang sedang main (dari scene sebelumnya),
            // maka objek yang baru ini harus mengalah (hancurkan diri).
            Destroy(gameObject);
        }
        else
        {
            // Jika belum ada musik, maka sayalah pemusiknya.
            instance = this;
            // JANGAN HANCUR saat pindah scene
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        // --- LOGIKA MATI DI GAMEPLAY ---
        // Jika sudah masuk scene "Game1", musik horor ini harus berhenti/hilang
        // Supaya nanti bisa diganti musik gameplay.

        if (SceneManager.GetActiveScene().name == "Game1")
        {
            // Hapus instance static agar nanti kalau balik ke menu bisa spawn lagi
            instance = null;
            Destroy(gameObject);
        }
    }
}