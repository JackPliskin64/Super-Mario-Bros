using UnityEngine;
using UnityEngine.Tilemaps;

public class Collisions : MonoBehaviour
{
    public Tilemap tilemap;

    public int scoreAmount = 10;

    public AudioSource audioSource;
    public AudioClip examSound;
    public AudioClip breakSound;

    public GameManager gameManager;

    public CharacterController2D characterController;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        characterController = GetComponent<CharacterController2D>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            ContactPoint2D contact = collision.GetContact(0);
            Vector3 hitPosition = contact.point - new Vector2(0, contact.normal.y * 0.5f);
            Vector3Int cellPosition = tilemap.WorldToCell(hitPosition);

            if (tilemap.HasTile(cellPosition))
            {
                Vector3 blockCenter = tilemap.GetCellCenterWorld(cellPosition);
                if (hitPosition.y > blockCenter.y)
                {
                    tilemap.SetTile(cellPosition, null);
                    audioSource.PlayOneShot(breakSound);
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Exams"))
        {
            Destroy(collision.gameObject);
            Debug.Log("colisionado");
            GameManager scoreManager = FindObjectOfType<GameManager>();
            scoreManager.IncreaseScore(scoreAmount);
            audioSource.PlayOneShot(examSound);
        }

        if (collision.CompareTag("DeathZone"))
        {
            gameManager.gameOver = true;
        }

        if (collision.CompareTag("Finish"))
        {
            gameManager.win = true;
        }
    }
}
