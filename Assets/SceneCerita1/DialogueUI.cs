using UnityEngine;
using UnityEngine.UI; // PENTING: Pakai UI biasa
using System.Collections;
using UnityEngine.SceneManagement; // Wajib untuk pindah scene

public class DialogueUI : MonoBehaviour
{
    [Header("Masukkan Text Legacy di Sini")]
    [SerializeField] private Text textLabel; // Tipe data Text Legacy

    [Header("Nama Scene Game")]
    public string namaSceneGame = "Game1"; // Pastikan nama scene benar

    private TypewriterEffect typewriter;

    private void Start()
    {
        // Mencari script TypewriterEffect di benda yang sama
        typewriter = GetComponent<TypewriterEffect>();

        // Mulai bercerita
        StartCoroutine(RunDialogue());
    }

    private IEnumerator RunDialogue()
    {
        // --- BAGIAN 1 ---
        // Ganti kata-katanya sesuka hati di sini
        yield return typewriter.Run("Akhirnya… seseorang berani datang lagi.", textLabel);
        yield return new WaitForSeconds(2f); // Tunggu 2 detik setelah selesai ngetik

        // --- BAGIAN 2 ---
        yield return typewriter.Run("Goa ini hanya muncul setiap seratus tahun.", textLabel);
        yield return new WaitForSeconds(2f);

        // --- BAGIAN 3 ---
        yield return typewriter.Run("Di dalamnya tersembunyi Relik Misterius yang mengikat kutukan kuno.", textLabel);
        yield return new WaitForSeconds(2f);

        // --- BAGIAN 4 ---
        yield return typewriter.Run("Namun waspadalah…", textLabel);
        yield return new WaitForSeconds(2f);

        // --- BAGIAN 5 ---
        yield return typewriter.Run("The Warden telah terbangun.", textLabel);
        yield return new WaitForSeconds(1f);

        // --- BAGIAN 6 ---
        yield return typewriter.Run("Masuklah jika kau berani.", textLabel);
        yield return new WaitForSeconds(1f);

        // --- BAGIAN 7 ---
        yield return typewriter.Run("Cari Reliknya…", textLabel);
        yield return new WaitForSeconds(1f);

        // --- BAGIAN 8 ---
        yield return typewriter.Run("Dan keluar hidup-hidup.", textLabel);
        yield return new WaitForSeconds(1f);

        // --- SELESAI & PINDAH SCENE ---
        Debug.Log("Cerita Selesai, Masuk Game...");
        SceneManager.LoadScene(namaSceneGame);
    }
}