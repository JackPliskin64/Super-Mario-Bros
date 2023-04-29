using UnityEngine;
using UnityEngine.Tilemaps;

public class Bricks : MonoBehaviour
{
    public Tilemap tilemap;
    public AudioClip breakSound;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
}
