using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float speed = 10.0f;
    private float topBound = -10.0f;

    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        // Memory cleanup: Destroy if it goes off-screen
        if (transform.position.z < topBound)
        {
            Destroy(gameObject);
        }
    }
}