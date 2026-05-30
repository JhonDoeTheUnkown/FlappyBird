using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpforce;
    Rigidbody2D rb;
    private 

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerJump();
    }

    private void PlayerJump()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.linearVelocity = Vector2.up * jumpforce;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            // Kode untuk menangani tabrakan dengan pipa (misalnya, restart game atau tampilkan game over)
            PlayerLose();
        }
    }

    void PlayerLose()
    {
        // Kode untuk menangani kekalahan pemain (misalnya, restart game atau tampilkan game over)
        Time.timeScale = 0f; // Hentikan waktu untuk menghentikan permainan
    }

}
// 