using UnityEngine;

public class JumpDamage : MonoBehaviour
{
    private Collider2D collider2d;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    public float jumpForce;
    public int lifes;
    AudioManager audioManager;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2d = GetComponent<Collider2D>();
        audioManager = GameObject.FindGameObjectsWithTag("Audio")[0].GetComponent<AudioManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().linearVelocity = Vector2.up * jumpForce;
            LoseLifeAndHit();
            CheckLife();
        }
    }

    private void LoseLifeAndHit()
    {
        audioManager.PlaySFX(audioManager.monsterHit);
        lifes--;
        animator.Play("Hit");
    }

    private void CheckLife()
    {
        if (lifes == 0)
        {
            Invoke("EnemyDie", 0.3f);
        }
    }

    private void EnemyDie()
    {
        spriteRenderer.enabled = false;
        Destroy(gameObject);
    }
}
