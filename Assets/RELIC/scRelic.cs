using UnityEngine;

public class scRelic : MonoBehaviour
{
    public enum TipeRelic { Potion, Skull, Tongkat }

    [Header("Pilih Jenis Relic Ini:")]
    public TipeRelic jenisRelic;

    [Header("Pengaturan Audio")]
    public AudioClip suaraAmbil;
    [Range(0f, 1f)]
    public float volumeSuara = 1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // 1. LOGIKA GAME (Tetap Sama)
            if (jenisRelic == TipeRelic.Potion) scGameManager.jumlahPotion++;
            else if (jenisRelic == TipeRelic.Skull) scGameManager.jumlahSkull++;
            else if (jenisRelic == TipeRelic.Tongkat) scGameManager.jumlahTongkat++;

            Debug.Log("Dapat Item!");

            // 2. LOGIKA AUDIO BARU (Anti Mendem)
            if (suaraAmbil != null)
            {
                // Cari objek bernama "Canvas" secara otomatis
                GameObject canvas = GameObject.Find("Canvas");

                if (canvas != null)
                {
                    // Pinjam AudioSource milik Canvas
                    AudioSource speakerCanvas = canvas.GetComponent<AudioSource>();

                    // Mainkan suara sebagai OneShot (Sekali lewat)
                    // Suara ini 2D, jadi pasti jelas dan kencang
                    if (speakerCanvas != null)
                    {
                        speakerCanvas.PlayOneShot(suaraAmbil, volumeSuara);
                    }
                }
            }

            // 3. HAPUS BENDA
            Destroy(gameObject);
        }
    }
}