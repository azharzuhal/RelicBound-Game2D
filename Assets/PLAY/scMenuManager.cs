using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // Wajib ada untuk fitur Tunggu/Jeda

public class scMenuManager : MonoBehaviour
{
    [Header("Nama Scene")]
    public string sceneMenuUtama = "Play";
    public string sceneCredit = "CreditTeam";
    public string sceneGameplay = "SceneCerita1";
    public string sceneCaraBermain = "CaraBermain";

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip suaraKlik;

    // --- NAVIGASI (DENGAN JEDA) ---

    public void TekanKeCredit()
    {
        StartCoroutine(PindahDenganJeda(sceneCredit));
    }

    public void TekanCaraBermain()
    {
        StartCoroutine(PindahDenganJeda(sceneCaraBermain));
    }

    public void TekanKembaliKeMenu()
    {
        StartCoroutine(PindahDenganJeda(sceneMenuUtama));
    }

    public void TekanMulai()
    {
        StartCoroutine(PindahDenganJeda(sceneGameplay));
    }

    public void TekanKeluar()
    {
        StartCoroutine(ProsesKeluar());
    }

    // --- LOGIKA JEDA (RAHASIA AGAR SUARA TIDAK MATI) ---

    IEnumerator PindahDenganJeda(string tujuan)
    {
        // 1. Bunyikan suara
        Bunyi();

        // 2. Tunggu sebentar (sesuai durasi suara atau 0.3 detik)
        // Pakai Realtime supaya kalau game dipause tetap jalan
        yield return new WaitForSecondsRealtime(0.4f);

        // 3. Baru pindah scene
        SceneManager.LoadScene(tujuan);
    }

    IEnumerator ProsesKeluar()
    {
        Bunyi();
        yield return new WaitForSecondsRealtime(0.3f);
        Debug.Log("Keluar Game");
        Application.Quit();
    }

    void Bunyi()
    {
        if (audioSource != null && suaraKlik != null)
        {
            audioSource.PlayOneShot(suaraKlik);
        }
    }
}