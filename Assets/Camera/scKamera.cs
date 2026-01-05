using UnityEngine;

public class scKamera : MonoBehaviour
{
    [Header("Target Yang Diikuti")]
    public Transform target;

    [Header("Pengaturan")]
    public float kecepatanHalus = 0.125f;

    // Variabel pengunci
    private float posisiXTerjauh;
    private float posisiYTetap;
    private float offsetZ;

    void Start()
    {
        posisiXTerjauh = transform.position.x;
        posisiYTetap = transform.position.y;
        offsetZ = transform.position.z;

        if (target != null && target.position.x > posisiXTerjauh)
        {
            posisiXTerjauh = target.position.x;
        }
    }

    void LateUpdate()
    {
        if (target == null) return;

        // 1. Logika Anti-Mundur (Hanya update kalau maju)
        if (target.position.x > posisiXTerjauh)
        {
            posisiXTerjauh = target.position.x;
        }

        // 2. Gerakkan kamera ke posisiXTerjauh (bukan posisi player langsung)
        Vector3 posisiTujuan = new Vector3(posisiXTerjauh, posisiYTetap, offsetZ);
        transform.position = Vector3.Lerp(transform.position, posisiTujuan, kecepatanHalus);
    }

    // --- FUNGSI BARU (WAJIB ADA UNTUK RESPAWN) ---
    // Fungsi ini dipanggil scCharacter saat mati agar kamera mau mundur
    public void ResetPosisiKamera(float posisiBaruX)
    {
        // Paksa ubah ingatan posisi terjauh jadi mundur
        posisiXTerjauh = posisiBaruX;

        // Langsung teleport kamera (jangan pakai Lerp biar instan)
        transform.position = new Vector3(posisiBaruX, posisiYTetap, offsetZ);
    }
}