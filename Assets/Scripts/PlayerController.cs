using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 15.0f;
    public float xBoundary = 10.0f;
    public GameObject laserPrefab;

    // 1. ADD THESE TWO AUDIO VARIABLES
    public AudioClip shootSound;
    private AudioSource playerAudio;

    void Start()
    {
        // 2. TELL THE SCRIPT TO GRAB THE SPEAKER ON YOUR PLAYER
        playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);

        // Keep Player in bounds
        if (transform.position.x < -xBoundary)
        {
            transform.position = new Vector3(-xBoundary, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > xBoundary)
        {
            transform.position = new Vector3(xBoundary, transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 spawnPos = transform.position + new Vector3(0, 0, 1.5f);
            Instantiate(laserPrefab, spawnPos, laserPrefab.transform.rotation);

            // 3. PLAY THE SOUND WHEN YOU SHOOT
            playerAudio.PlayOneShot(shootSound, 1.0f);
        }
    }
}