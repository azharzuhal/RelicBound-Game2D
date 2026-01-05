using UnityEngine;

public class scGameManager : MonoBehaviour
{
    public static int nyawa = 3;

    // --- VARIABEL BARU (Hafalkan nama ini) ---
    public static int jumlahPotion = 0;
    public static int jumlahSkull = 0;
    public static int jumlahTongkat = 0;
    // Catatan: 'Tongkat' menggantikan 'Kunci'

    public static Vector3 posisiRespawn = new Vector3(-999, -999, 0);

    public static void ResetGame()
    {
        nyawa = 3;
        jumlahPotion = 0;
        jumlahSkull = 0;
        jumlahTongkat = 0;
        posisiRespawn = new Vector3(-999, -999, 0);
    }
}