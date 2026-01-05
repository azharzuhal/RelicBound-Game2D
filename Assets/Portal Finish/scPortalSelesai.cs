using UnityEngine;
using UnityEngine.SceneManagement;

public class scPortalSelesai : MonoBehaviour
{
    [Header("Nama Scene Tujuan")]
    public string namaSceneTujuan = "Play";

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Cek apakah yang masuk adalah Player
        if (other.CompareTag("Player"))
        {
            // Pindah Scene
            SceneManager.LoadScene(namaSceneTujuan);
        }
    } // <--- Kurung penutup fungsi (JANGAN DIHAPUS)

} // <--- Kurung penutup Class (JANGAN DIHAPUS - INI YANG SERING HILANG)