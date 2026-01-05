using UnityEngine;
using UnityEngine.UI;

public class scUIManager : MonoBehaviour
{
    public static scUIManager akses;

    [Header("Hubungkan Panel Game Over")]
    public GameObject panelGameOver; // <-- KOTAK BARU UNTUK PANEL

    [Header("UI Teks Angka")]
    public Text textPotion;
    public Text textSkull;
    public Text textTongkat;

    [Header("UI Gambar Relic")]
    public Image imgPotion;
    public Image imgSkull;
    public Image imgTongkat;

    [Header("UI Nyawa")]
    public GameObject[] gambarHati;

    // Supaya game over cuma terpanggil sekali
    private bool isGameOver = false;

    void Awake()
    {
        akses = this;
    }

    void Start()
    {
        // 1. RESET SEMUA SAAT MULAI
        scGameManager.nyawa = 3;
        scGameManager.jumlahPotion = 0;
        scGameManager.jumlahSkull = 0;
        scGameManager.jumlahTongkat = 0;

        // Sembunyikan panel game over kalau lupa dimatikan di editor
        if (panelGameOver != null) panelGameOver.SetActive(false);
        isGameOver = false;
        Time.timeScale = 1f; // Pastikan waktu jalan

        UpdateTampilanHati();
    }

    void Update()
    {
        // 1. CEK KEMATIAN (LOGIKA BARU)
        if (scGameManager.nyawa <= 0 && !isGameOver)
        {
            MunculkanGameOver();
        }

        // 2. UPDATE UI LAINNYA
        if (textPotion != null) textPotion.text = scGameManager.jumlahPotion.ToString();
        if (textSkull != null) textSkull.text = scGameManager.jumlahSkull.ToString();
        if (textTongkat != null) textTongkat.text = scGameManager.jumlahTongkat.ToString();

        if (imgPotion != null)
            imgPotion.color = scGameManager.jumlahPotion > 0 ? Color.white : Color.gray;
        if (imgSkull != null)
            imgSkull.color = scGameManager.jumlahSkull > 0 ? Color.white : Color.gray;
        if (imgTongkat != null)
            imgTongkat.color = scGameManager.jumlahTongkat > 0 ? Color.white : Color.gray;

        // Update hati terus menerus (supaya pas kena damage langsung hilang)
        UpdateTampilanHati();
    }

    public void UpdateTampilanHati()
    {
        for (int i = 0; i < gambarHati.Length; i++)
        {
            if (i < scGameManager.nyawa) gambarHati[i].SetActive(true);
            else gambarHati[i].SetActive(false);
        }
    }

    void MunculkanGameOver()
    {
        isGameOver = true;
        Debug.Log("Game Over!");

        // Munculkan Panel
        if (panelGameOver != null)
        {
            panelGameOver.SetActive(true);
        }

        // Hentikan Waktu
        Time.timeScale = 0f;
    }
}