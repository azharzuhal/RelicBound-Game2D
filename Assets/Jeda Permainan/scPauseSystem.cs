using UnityEngine;
using UnityEngine.SceneManagement;

public class scPauseSystem : MonoBehaviour
{
    [Header("Hubungkan Panel")]
    public GameObject panelPause;
    public GameObject panelCredit;

    [Header("Pengaturan Scene")]
    // Kita isi default-nya langsung "Play" biar aman
    public string namaSceneMenu = "Play";

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip suaraKlik;

    public static bool isPaused = false;

    void Start()
    {
        if (panelPause != null) panelPause.SetActive(false);
        if (panelCredit != null) panelCredit.SetActive(false);

        Time.timeScale = 1f;
        isPaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (panelCredit != null && panelCredit.activeSelf)
                TutupCredit();
            else
            {
                if (isPaused) TekanLanjutkan();
                else PauseGame();
            }
        }
    }

    // --- FUNGSI UTAMA ---
    public void PauseGame()
    {
        if (audioSource) audioSource.PlayOneShot(suaraKlik);
        panelPause.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void TekanLanjutkan()
    {
        if (audioSource) audioSource.PlayOneShot(suaraKlik);
        panelPause.SetActive(false);
        if (panelCredit != null) panelCredit.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void TekanMulaiUlang()
    {
        Time.timeScale = 1f;
        BunyiAntiMati();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // --- BAGIAN INI YANG DIPERBAIKI ---
    public void TekanKeluar()
    {
        // 1. Wajib nyalakan waktu lagi (Kalau TimeScale 0, loading scene bisa macet)
        Time.timeScale = 1f;

        // 2. Bunyi (Pakai trik speaker hantu biar tidak kepotong)
        BunyiAntiMati();

        // 3. Logika Pindah Scene
        Debug.Log("Mencoba kembali ke menu: " + namaSceneMenu);
        SceneManager.LoadScene(namaSceneMenu);
    }

    // --- LOGIKA CREDIT ---
    public void BukaCredit()
    {
        if (audioSource) audioSource.PlayOneShot(suaraKlik);
        panelPause.SetActive(false);
        panelCredit.SetActive(true);
    }

    public void TutupCredit()
    {
        if (audioSource) audioSource.PlayOneShot(suaraKlik);
        panelCredit.SetActive(false);
        panelPause.SetActive(true);
    }

    // --- AUDIO HELPER ---
    void BunyiAntiMati()
    {
        if (suaraKlik != null)
            AudioSource.PlayClipAtPoint(suaraKlik, Camera.main.transform.position);
    }
}