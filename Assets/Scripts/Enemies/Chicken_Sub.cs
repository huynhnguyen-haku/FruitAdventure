using UnityEngine;

public class Chicken_Sub : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    public float speed = 5f;
    public float detectionRange = 5f;
    public Transform viewPoint;

    private bool isMoving = false;
    private Transform playerTransform;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        DetectPlayer();
        if (isMoving)
        {
            MoveTowardsPlayer();
        }
        else
        {
            animator.SetBool("Idle", true);
        }
    }

    private void DetectPlayer()
    {
        RaycastHit2D hitLeft = Physics2D.Raycast(viewPoint.position, Vector2.left, detectionRange);
        RaycastHit2D hitRight = Physics2D.Raycast(viewPoint.position, Vector2.right, detectionRange);

        Debug.DrawRay(transform.position, Vector2.left * detectionRange, Color.red);
        Debug.DrawRay(transform.position, Vector2.right * detectionRange, Color.red);

        if (hitLeft.collider != null && hitLeft.collider.CompareTag("Player"))
        {
            playerTransform = hitLeft.transform;
            isMoving = true;
            spriteRenderer.flipX = false; // Face left
            animator.SetBool("Idle", false);
        }
        else if (hitRight.collider != null && hitRight.collider.CompareTag("Player"))
        {
            playerTransform = hitRight.transform;
            isMoving = true;
            spriteRenderer.flipX = true; // Face right
            animator.SetBool("Idle", false);
        }
        else
        {
            isMoving = false;
        }
    }

    private void MoveTowardsPlayer()
    {
        if (playerTransform != null)
        {
            Vector2 targetPosition = new Vector2(playerTransform.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerRespawn>()?.PlayerDamaged();
        }
    }
}
