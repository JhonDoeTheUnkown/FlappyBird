using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float jumpforce;
    Rigidbody2D rb;
    public Text scoreText, highScoreText; // UI Text untuk menampilkan skor

    public GameObject loseScreenUI; // Panel untuk menampilkan game over
    public int score; // Variabel untuk menyimpan skor pemain
    private int highScore; // Variabel untuk menyimpan skor tertinggi
    string highScoreKey = "HighScore"; // Kunci untuk menyimpan skor tertinggi di PlayerPrefs
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        highScore = PlayerPrefs.GetInt(highScoreKey); // Ambil skor tertinggi dari PlayerPrefs (default 0 jika belum ada)
    }

    // Update is called once per frame
    void Update()
    {
        PlayerJump();
    }

    private void PlayerJump()
    {
        // Jump SOund SFX
        if (Input.GetMouseButtonDown(0))
        {
            AudioManager.singleton.PlayAudio(0); // Memanggil metode PlayAudio pada AudioManager untuk memutar klip audio dengan indeks 0 (misalnya, suara loncatan)
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
        AudioManager.singleton.PlayAudio(2); // Memanggil metode PlayAudio pada AudioManager untuk memutar klip audio dengan indeks 1 (misalnya, suara kalah)
        if(score > highScore)
        {
            highScore = score; 
            PlayerPrefs.SetInt(highScoreKey, highScore); // Simpan skor tertinggi di PlayerPrefs
        }
        highScoreText.text = "High Score: " + highScore.ToString(); // Perbarui teks skor tertinggi di UI    
        loseScreenUI.SetActive(true); // Tampilkan panel game over
        // Kode untuk menangani kekalahan pemain (misalnya, restart game atau tampilkan game over)
        Time.timeScale = 0f; // Hentikan waktu untuk menghentikan permainan
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // Kembalikan waktu ke normal
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Muat ulang scene saat ini
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("ScoreZone"))
        {
            // Kode untuk menangani ketika pemain melewati zona skor (misalnya, tambahkan skor)
            // Anda dapat menambahkan logika untuk meningkatkan skor di sini
            addScore();
        }
    }

    void addScore()
    {
        // play Sound SFX 
        AudioManager.singleton.PlayAudio(1); // Memanggil metode PlayAudio pada AudioManager untuk memutar klip audio dengan indeks 0 (misalnya, suara loncatan)
        // Kode untuk menambahkan skor ketika pemain melewati zona skor
        score++; // Tambahkan 1 ke skor
        scoreText.text = "Score: " + score.ToString(); // Perbarui teks skor di UI
        // Anda dapat mengimplementasikan logika untuk meningkatkan skor di sini
    }
}
// RestartGame() dapat dipanggil dari tombol pada loseScreenUI untuk memulai ulang permainan setelah pemain kalah. lalu ketika 