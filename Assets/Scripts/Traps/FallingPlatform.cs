using System.Collections;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Animator animator;
    public float fallDelay = 1f;
    public float destroyDelay = 1.5f;
    private Rigidbody2D rb;
    private bool isFalling = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isFalling)
        {
            StartCoroutine(Fall());
        }
    }

    private IEnumerator Fall()
    {
        isFalling = true;
        yield return new WaitForSeconds(fallDelay);

        animator.Play("Off");
        yield return new WaitForSeconds(0.5f);

        rb.isKinematic = false;
        rb.linearVelocity = new Vector2(0, -5f);

        yield return new WaitForSeconds(destroyDelay);
        Destroy(gameObject);
    }
}
