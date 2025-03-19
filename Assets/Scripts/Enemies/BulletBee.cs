using UnityEngine;

public class BulletBee : MonoBehaviour
{
    public float speed = 2;

    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
