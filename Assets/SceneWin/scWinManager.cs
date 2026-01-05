using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class scWinManager : MonoBehaviour
{
    [Header("Navigasi")]
    public string namaSceneMenu = "Play"; // <-- Pastikan nama scene menu kamu "Play"

    [Header("UI Text")]
    public Text textPotion;
    public Text textSkull;
    public Text textTongkat;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip suaraTombol;

    void Start()
    {
        Time.timeScale = 1f; // WAJIB RESET WAKTU

        if (textPotion != null) textPotion.text = " " + scGameManager.jumlahPotion;
        if (textSkull != null) textSkull.text = " " + scGameManager.jumlahSkull;
        if (textTongkat != null) textTongkat.text = " " + scGameManager.jumlahTongkat;
    }

    public void TekanMainLagi()
    {
        StartCoroutine(ProsesMainLagi());
    }

    IEnumerator ProsesMainLagi()
    {
        if (audioSource != null) audioSource.PlayOneShot(suaraTombol);
        yield return new WaitForSecondsRealtime(0.3f);
        scGameManager.ResetGame();
        SceneManager.LoadScene("Game1");
    }

    public void TekanKeluar()
    {
        StartCoroutine(ProsesKeluar());
    }

    // --- PERUBAHAN DI SINI (KE MENU) ---
    IEnumerator ProsesKeluar()
    {
        if (audioSource != null) audioSource.PlayOneShot(suaraTombol);

        yield return new WaitForSecondsRealtime(0.3f); // Tunggu suara selesai

        Debug.Log("Kembali ke Menu Utama...");

        // Reset data game jika perlu (opsional)
        scGameManager.ResetGame();

        // Pindah Scene
        SceneManager.LoadScene(namaSceneMenu);
    }
}