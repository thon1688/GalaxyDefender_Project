using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 20.0f;
    private float topBound = 15.0f;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Memory cleanup: Destroy if it goes off-screen
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
    }
}