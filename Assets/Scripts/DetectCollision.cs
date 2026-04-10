using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject explosionParticle; // ADD THIS LINE

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Laser"))
        {
            // ADD THIS LINE: Spawn explosion at the asteroid's position
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);

            gameManager.AddScore(10);
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Player"))
        {
            // ADD THIS LINE: Spawn explosion at the player's position
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);

            gameManager.GameOver();
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}