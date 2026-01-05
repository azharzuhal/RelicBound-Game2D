using UnityEngine;
using UnityEngine.SceneManagement;

public class scCharacter : MonoBehaviour
{
    [Header("Pengaturan Gerak")]
    public float kecepatan = 5f;
    public float kekuatanLompat = 10f;
    public float batasJatuh = -10f;

    [Header("Pengaturan Mentok Kiri")]
    public bool aktifkanBatasKiri = true;
    [Range(0f, 2f)]
    public float jarakBatasKiri = 0.6f;

    [Header("Pengaturan Deteksi Tanah")]
    public LayerMask layerTanah;

    private Rigidbody2D rb;
    private Animator anim;
    private Collider2D coll;

    private Vector3 skalaAwal;
    private bool diTanah;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();

        skalaAwal = transform.localScale;

        if (scGameManager.posisiRespawn.x == -999)
        {
            scGameManager.posisiRespawn = transform.position;
        }
    }

    void Update()
    {
        // 1. LOGIKA MENTOK KIRI (Ikut Kamera)
        if (aktifkanBatasKiri)
        {
            float tepiKiriLayar = Camera.main.ViewportToWorldPoint(Vector3.zero).x;
            float batasAman = tepiKiriLayar + jarakBatasKiri;

            if (transform.position.x < batasAman)
            {
                transform.position = new Vector3(batasAman, transform.position.y, transform.position.z);
            }
        }

        // 2. JATUH
        if (transform.position.y < batasJatuh) KenaDamage();

        // 3. GERAK (BAGIAN INI YANG DIUBAH)
        diTanah = coll.IsTouchingLayers(layerTanah);

        // Menggunakan GetAxisRaw agar gerakan INSTAN (tidak licin/meluncur)
        float inputGerak = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && diTanah)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, kekuatanLompat);
        }
        else
        {
            rb.linearVelocity = new Vector2(inputGerak * kecepatan, rb.linearVelocity.y);
        }

        // 4. ANIMASI
        if (diTanah)
        {
            anim.SetBool("isJumping", false);
            // Cek apakah inputGerak tidak 0 untuk animasi jalan
            anim.SetBool("isWalking", inputGerak != 0);
        }
        else
        {
            anim.SetBool("isJumping", true);
            anim.SetBool("isWalking", false);
        }

        // 5. FLIP
        if (inputGerak > 0)
        {
            Vector3 s = transform.localScale;
            s.x = Mathf.Abs(skalaAwal.x);
            transform.localScale = s;
        }
        else if (inputGerak < 0)
        {
            Vector3 s = transform.localScale;
            s.x = -Mathf.Abs(skalaAwal.x);
            transform.localScale = s;
        }
    }

    void LateUpdate()
    {
        Vector3 uk = transform.localScale;
        if (uk.x > 0) transform.localScale = new Vector3(Mathf.Abs(skalaAwal.x), skalaAwal.y, skalaAwal.z);
        else transform.localScale = new Vector3(-Mathf.Abs(skalaAwal.x), skalaAwal.y, skalaAwal.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            scGameManager.posisiRespawn = other.transform.position;
        }
    }

    public void KenaDamage()
    {
        scGameManager.nyawa--;

        // Update tampilan hati
        if (scUIManager.akses != null) scUIManager.akses.UpdateTampilanHati();

        if (scGameManager.nyawa > 0)
        {
            Respawn();
        }
        else
        {
            // Matikan karakter, biarkan UI Game Over muncul
            gameObject.SetActive(false);
        }
    }

    void Respawn()
    {
        transform.position = scGameManager.posisiRespawn;
        rb.linearVelocity = Vector2.zero;

        scKamera scriptKamera = Camera.main.GetComponent<scKamera>();
        if (scriptKamera != null)
        {
            scriptKamera.ResetPosisiKamera(transform.position.x);
        }
    }
}