using UnityEngine;

public class Booster : MonoBehaviour
{
    private Animator animator;
    public float jumpForce = 14f;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().linearVelocity = Vector2.up * jumpForce;
            animator.Play("Collect");
            Destroy(gameObject, 0.2f);
        }
    }
}
