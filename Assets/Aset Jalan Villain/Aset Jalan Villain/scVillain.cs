using UnityEngine;

public class scVillain : MonoBehaviour
{
    [Header("Gerak Musuh")]
    public float kecepatan = 2f;
    public Transform deteksiTanah;
    public Transform deteksiDinding;
    public LayerMask lapisanPadat;

    private Rigidbody2D rb;
    private bool hadapKanan = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float laju = hadapKanan ? kecepatan : -kecepatan;
        rb.linearVelocity = new Vector2(laju, rb.linearVelocity.y);

        if (deteksiTanah != null && deteksiDinding != null)
        {
            RaycastHit2D tanahHabis = Physics2D.Raycast(deteksiTanah.position, Vector2.down, 1f, lapisanPadat);
            RaycastHit2D tabrakDinding = Physics2D.Raycast(deteksiDinding.position, hadapKanan ? Vector2.right : Vector2.left, 0.5f, lapisanPadat);

            if (tanahHabis.collider == false || tabrakDinding.collider == true)
            {
                BalikArah();
            }
        }
    }

    void BalikArah()
    {
        hadapKanan = !hadapKanan;
        Vector3 s = transform.localScale;
        s.x *= -1;
        transform.localScale = s;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Panggil fungsi KenaDamage di player
            collision.gameObject.GetComponent<scCharacter>().KenaDamage();
        }
    }
}