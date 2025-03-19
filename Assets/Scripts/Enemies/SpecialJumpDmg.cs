using UnityEngine;

public class SpecialJumpDmg : MonoBehaviour
{
    public Collider2D collider2d;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    public float jumpForce;
    public int lifes;
    AudioManager audioManager;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioManager = GameObject.FindGameObjectsWithTag("Audio")[0].GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
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
